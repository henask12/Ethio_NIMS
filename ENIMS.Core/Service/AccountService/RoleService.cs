using ENIMS.Common;
using ENIMS.DataObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ENIMS.Core.Interface.Helper;

namespace ENIMS.Core
{
    public class RoleService : IBaseService<RoleRequest, RoleResponse, RolesResponse>
    {
        private readonly IAppUnitOfWork _appUow;
        private readonly IAppDbTransactionContext _appTransaction;
        private readonly IRepositoryBase<Role> _roleRepository;
        private readonly IPrivilegeService _privilege;

        private readonly IRepositoryBase<RolePrivilege> _rolePrivilageRepository;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RoleService(IAppUnitOfWork appUow,
            IAppDbTransactionContext appTransaction,
            IRepositoryBase<Role> roleRepository, IPrivilegeService privilege,
            IRepositoryBase<RolePrivilege> rolePrivilageRepository, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _appUow = appUow;
            _privilege = privilege;
            _configuration = configuration;
            _appTransaction = appTransaction;
            _roleRepository = roleRepository;
            _rolePrivilageRepository = rolePrivilageRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<OperationStatusResponse> Delete(BulkAction bulkAction)
        {
            if (bulkAction?.Ids == null || bulkAction.Ids.Count < 1)
            {
                return new OperationStatusResponse
                {
                    Message = Resources.PleaseSelectOneRecordToDelete,
                    Status = OperationStatus.ERROR,
                };
            }

            ApplicationDbContext dbContext = new ApplicationDbContext(_configuration);
            using (var appUow = new AppUnitOfWork(dbContext))
            {
                using (var appTransaction = appUow.BeginTrainsaction())
                {
                    try
                    {
                        RepositoryBase<Role> roleRepository = new RepositoryBase<Role>(_configuration);

                        int numberOfRecordsAffected = 0;

                        foreach (var id in bulkAction.Ids)
                        {
                            var role = await roleRepository.FindAsync(id);
                            if (role != null)
                            {
                                numberOfRecordsAffected++;
                                role.RecordStatus = RecordStatus.Deleted;
                                //role.UpdatedBy = _httpContextAccessor.HttpContext.Session.GetString("UserName");
                                role.UpdatedBy = _httpContextAccessor.HttpContext.Session.GetString("UserName");

                                role.TimeZoneInfo = TimeZoneInfo.Local.StandardName;
                                role.LastUpdateDate = DateTime.UtcNow;
                                roleRepository.Update(role);
                                await appUow.SaveChangesAsync();
                            }
                        }

                        if (numberOfRecordsAffected > 0)
                            appTransaction.Commit();

                        return new OperationStatusResponse
                        {

                            Message = string.Format(Resources.OperationSucessfullyCompletedNumberOfRecordAffected, numberOfRecordsAffected),
                            Status = OperationStatus.SUCCESS,
                        };
                    }
                    catch (Exception)
                    {
                        appTransaction.Rollback();
                        return new OperationStatusResponse
                        {
                            Message = Resources.DatabaseOperationFailed,
                            Status = OperationStatus.ERROR,
                        };
                    }
                }
            }
        }

        public async Task<OperationStatusResponse> Delete(long Id)
        {
            if (Id < 1)
            {
                return new OperationStatusResponse
                {
                    Message = Resources.PleaseSelectOneRecordToDelete,
                    Status = OperationStatus.ERROR,
                };
            }

            using (var appUow = new AppUnitOfWork(_appTransaction.GetDbContext()))
            {
                using (var appTransaction = appUow.BeginTrainsaction())
                {
                    try
                    {
                        var roleRepository = new RepositoryBaseWork<Role>(appUow);
                        var rolePrivilageRepository = new RepositoryBaseWork<RolePrivilege>(appUow);

                        var role = await roleRepository.FindAsync(Id);

                        if (role != null)
                        {
                            role.RecordStatus = RecordStatus.Deleted;
                            role.UpdatedBy = _httpContextAccessor.HttpContext.Session.GetString("UserName");

                            role.TimeZoneInfo = TimeZoneInfo.Local.StandardName;
                            role.LastUpdateDate = DateTime.UtcNow;
                            roleRepository.Update(role);
                            await appUow.SaveChangesAsync();


                            var prevRolePrevilageList = rolePrivilageRepository.Where(rp => rp.RoleId == role.Id).ToList();

                            foreach (var previlage in prevRolePrevilageList)
                            {
                                previlage.RecordStatus = RecordStatus.Deleted;
                                previlage.UpdatedBy = _httpContextAccessor.HttpContext.Session.GetString("UserName");

                                previlage.TimeZoneInfo = TimeZoneInfo.Local.StandardName;
                                previlage.LastUpdateDate = DateTime.UtcNow;

                                roleRepository.Update(role);

                                await appUow.SaveChangesAsync();
                            }

                            appTransaction.Commit();

                            return new OperationStatusResponse
                            {

                                Message = Resources.OperationSucessfullyCompletedNumberOfRecordAffected,
                                Status = OperationStatus.SUCCESS,
                            };
                        }
                        else
                            return new RoleResponse { Message = Resources.RecordDoesNotExist, Status = OperationStatus.ERROR };
                    }
                    catch (Exception ex)
                    {
                        appTransaction.Rollback();
                        return new RoleResponse { Message = Resources.OperationEndWithError, Status = OperationStatus.ERROR };
                    }
                }
            }
        }

        public RolesResponse GetAll()
        {
            var roleResponseList = new RolesResponse();
            var roleList = _roleRepository.Where(u => u.RecordStatus == RecordStatus.Active ||
                            u.RecordStatus == RecordStatus.Inactive);

            if (roleList != null)
            {
                foreach (var role in roleList)
                {
                    var rolePrivilageList = _rolePrivilageRepository.Where(rp => rp.RoleId == role.Id, new string[] { nameof(Privilege) });

                    var roleResponse = new RoleRes
                    {
                        Id = role.Id,
                        Description = role.Description,
                        Name = role.Name,
                        RecordStatus = role.RecordStatus
                    };

                    if (rolePrivilageList != null)
                        foreach (var rolePrivilage in rolePrivilageList)
                            roleResponse.Privileges.Add(new PrivilegeRes { Id = rolePrivilage.PrivilegeId, Action = rolePrivilage.Privilege.Action });
                    roleResponseList.Roles.Add(roleResponse);

                }
            }
            roleResponseList.Status = OperationStatus.SUCCESS;
            roleResponseList.Message = Resources.OperationSucessfullyCompleted;
            return roleResponseList;
        }

        public RoleResponse GetById(long id)
        {
            var role = _roleRepository.FirstOrDefault(r => r.Id == id);

            if (role != null)
            {
                var roleResponse = new RoleResponse();

                roleResponse.Status = OperationStatus.SUCCESS;
                roleResponse.Message = Resources.OperationSucessfullyCompleted;


                roleResponse.Role = new RoleRes
                {
                    Id = role.Id,
                    Name = role.Name,
                    Description = role.Description,
                    RecordStatus = role.RecordStatus,
                };

                var rolePrivilageList = _rolePrivilageRepository.Where(rp => rp.RoleId == role.Id, new string[] { nameof(Privilege) });
                if (rolePrivilageList != null)
                    foreach (var rolePrivilage in rolePrivilageList)
                        roleResponse.Role.Privileges.Add(new PrivilegeRes { Id = rolePrivilage.PrivilegeId, Action = rolePrivilage.Privilege.Action });

                return roleResponse;
            }
            return new RoleResponse { Status = OperationStatus.ERROR, Message = Resources.RecordDoesNotExist };

        }

        public async Task<RoleResponse> Create(RoleRequest request)
        {
            using (var appUow = new AppUnitOfWork(_appTransaction.GetDbContext()))
            {
                using (var appTransaction = appUow.BeginTrainsaction())
                {
                    try
                    {
                        var roleRepository = new RepositoryBaseWork<Role>(appUow);
                        var rolePrivilageRepository = new RepositoryBaseWork<RolePrivilege>(appUow);

                        var prevRole = await roleRepository.FirstOrDefaultAsync(r => r.Name == request.Name);

                        if (prevRole == null)
                        {
                            if (request.Privileges != null && request.Privileges.Count > 0)
                            {
                                var role = new Role
                                {
                                    Name = request.Name,
                                    Description = request.Description,
                                    StartDate = DateTime.UtcNow,
                                    EndDate = DateTime.MaxValue,
                                    RecordStatus = RecordStatus.Active,
                                    UpdatedBy = _httpContextAccessor.HttpContext.Session.GetString("UserName"),
                                    TimeZoneInfo = TimeZoneInfo.Local.StandardName,
                                    LastUpdateDate = DateTime.UtcNow,
                                };

                                roleRepository.Add(role);
                                await appUow.SaveChangesAsync();

                                var RoleResponse = new RoleRes() { Id = role.Id, Description = role.Description, Name = role.Name, RecordStatus = role.RecordStatus };
                                var privilegeRes = new List<PrivilegeRes>();

                                foreach (var previlageId in request.Privileges)
                                {
                                    var rolePrivilage = new RolePrivilege
                                    {
                                        RoleId = role.Id,
                                        PrivilegeId = previlageId,
                                        StartDate = DateTime.UtcNow,
                                        EndDate = DateTime.MaxValue,
                                        RecordStatus = RecordStatus.Active,
                                        UpdatedBy = _httpContextAccessor.HttpContext.Session.GetString("UserName"),
                                        TimeZoneInfo = TimeZoneInfo.Local.StandardName,
                                        LastUpdateDate = DateTime.UtcNow,
                                    };
                                    rolePrivilageRepository.Add(rolePrivilage);

                                }
                                await appUow.SaveChangesAsync();
                                appTransaction.Commit();

                                var priviligesResponses = _privilege.GetAll().Privileges.Where(r => request.Privileges.Contains(r.Id)).ToList();

                                privilegeRes = priviligesResponses;
                                RoleResponse.Privileges = privilegeRes;

                                return new RoleResponse { Message = Resources.OperationSucessfullyCompleted, Role = RoleResponse, Status = OperationStatus.SUCCESS };
                            }
                            else
                                return new RoleResponse { Message = Resources.AtleastSelectOnePrivilage, Status = OperationStatus.ERROR };
                        }
                        else
                            return new RoleResponse { Message = Resources.RecordAlreadyExist, Status = OperationStatus.ERROR };
                    }
                    catch (Exception)
                    {
                        appTransaction.Rollback();
                        return new RoleResponse { Message = Resources.OperationEndWithError, Status = OperationStatus.ERROR };
                    }
                }
            }
        }

        public async Task<RoleResponse> Update(RoleRequest request)
        {
            using (var appUow = new AppUnitOfWork(_appTransaction.GetDbContext()))
            {
                using (var appTransaction = appUow.BeginTrainsaction())
                {
                    try
                    {
                        var roleRepository = new RepositoryBaseWork<Role>(appUow);
                        var rolePrivilageRepository = new RepositoryBaseWork<RolePrivilege>(appUow);


                        var prevRole = await roleRepository.FirstOrDefaultAsync(r => r.Id == request.Id);

                        if (prevRole != null)
                        {
                            if (request.Privileges != null && request.Privileges.Count > 0)
                            {
                                prevRole.Description = request.Description;
                                prevRole.UpdatedBy = _httpContextAccessor.HttpContext.Session.GetString("UserName");
                                prevRole.TimeZoneInfo = TimeZoneInfo.Local.StandardName;
                                prevRole.LastUpdateDate = DateTime.UtcNow;

                                roleRepository.Update(prevRole);
                                await appUow.SaveChangesAsync();

                                var prevRolePrevilageList = rolePrivilageRepository.Where(rp => rp.RoleId == request.Id).ToList();

                                foreach (var previlageId in request.Privileges)
                                {
                                    if (prevRolePrevilageList != null)
                                    {
                                        var preRolePrevilage = prevRolePrevilageList.Where(rp => rp.RoleId == prevRole.Id && rp.PrivilegeId == previlageId).FirstOrDefault();
                                        if (preRolePrevilage != null)
                                        {
                                            prevRolePrevilageList.Remove(preRolePrevilage);
                                            continue;
                                        }
                                    }
                                    var rolePrivilage = new RolePrivilege
                                    {
                                        RoleId = request.Id,
                                        PrivilegeId = previlageId,
                                        StartDate = DateTime.UtcNow,
                                        EndDate = DateTime.MaxValue,
                                        RecordStatus = RecordStatus.Active,
                                        UpdatedBy = _httpContextAccessor.HttpContext.Session.GetString("UserName"),
                                        TimeZoneInfo = TimeZoneInfo.Local.StandardName,
                                        LastUpdateDate = DateTime.UtcNow,
                                    };

                                    rolePrivilageRepository.Add(rolePrivilage);
                                    await appUow.SaveChangesAsync();

                                }

                                //remove role-privliage which do not belong to the new list
                                if (prevRolePrevilageList != null)
                                {
                                    foreach (var prevRolePrevilage in prevRolePrevilageList)
                                    {
                                        rolePrivilageRepository.Remove(prevRolePrevilage);
                                        await appUow.SaveChangesAsync();
                                    }
                                }

                                appTransaction.Commit();
                                return new RoleResponse { Message = Resources.OperationSucessfullyCompleted, Status = OperationStatus.SUCCESS };
                            }
                            else
                                return new RoleResponse { Message = Resources.AtleastSelectOnePrivilage, Status = OperationStatus.ERROR };
                        }
                        else
                            return new RoleResponse { Message = Resources.RecordDoesNotExist, Status = OperationStatus.ERROR };
                    }
                    catch (Exception ex)
                    {
                        appTransaction.Rollback();
                        return new RoleResponse { Message = Resources.OperationEndWithError, Status = OperationStatus.ERROR };
                    }
                }
            }
        }

        public async Task<OperationStatusResponse> UpdateStatus(BulkAction bulkAction)
        {
            ApplicationDbContext dbContext = new ApplicationDbContext(_configuration);
            using (var appUow = new AppUnitOfWork(dbContext))
            {
                using (var appTransaction = appUow.BeginTrainsaction())
                {
                    try
                    {
                        RepositoryBase<Role> roleRepository = new RepositoryBase<Role>(_configuration);

                        int numberOfRecordsAffected = 0;

                        foreach (var id in bulkAction.Ids)
                        {
                            var role = await roleRepository.FindAsync(id);

                            if (role != null)
                            {
                                numberOfRecordsAffected++;

                                role.RecordStatus = bulkAction.RecordStatus;
                                role.UpdatedBy = _httpContextAccessor.HttpContext.Session.GetString("UserName");
                                role.TimeZoneInfo = TimeZoneInfo.Local.StandardName;
                                role.LastUpdateDate = DateTime.UtcNow;
                                roleRepository.Update(role);
                                await appUow.SaveChangesAsync();
                            }
                        }

                        if (numberOfRecordsAffected > 0)
                            appTransaction.Commit();

                        return new OperationStatusResponse
                        {
                            Message = string.Format(Resources.OperationSucessfullyCompletedNumberOfRecordAffected, numberOfRecordsAffected),
                            Status = OperationStatus.SUCCESS,
                        };
                    }
                    catch (Exception)
                    {
                        appTransaction.Rollback();
                        return new OperationStatusResponse
                        {
                            Message = Resources.DatabaseOperationFailed,
                            Status = OperationStatus.ERROR,
                        };
                    }
                }
            }
        }
    }
}
