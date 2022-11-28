using AutoMapper;
using ENIMS.Common;
using ENIMS.Common.RequestModel.MasterData;
using ENIMS.DataObjects;
using ENIMS.DataObjects.Models.MasterData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ENIMS.Core
{
    public class UserService : IUserService
    {
        private readonly IAppUnitOfWork _appUow;
        private readonly IAppDbTransactionContext _appTransaction;
        private readonly IRepositoryBase<User> _userRepository;

        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        private readonly IRepositoryBase<UserRole> _userRoleRepository;
        private readonly IRepositoryBase<Role> _roleRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserRoleService _userRoleService;

        public UserService(
            IAppUnitOfWork appUow, IRepositoryBase<Role> roleRepository,
            IAppDbTransactionContext appTransaction, IHttpContextAccessor httpContextAccessor,
            IRepositoryBase<User> userRepository,
            IMapper mapper,
            IRepositoryBase<UserRole> userRoleRepository,
            IPasswordHasher<User> passwordHasher, IConfiguration configuration, IUserRoleService userRoleService)
        {
            _appUow = appUow;
            _appTransaction = appTransaction;
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _mapper = mapper;
            _userRoleRepository = userRoleRepository;
            _configuration = configuration;
            _roleRepository = roleRepository;
            _httpContextAccessor = httpContextAccessor;
            _userRoleService = userRoleService;
        }

        public async Task<OperationStatusResponse> Delete(BulkAction bulkAction)
        {
            foreach (var id in bulkAction.Ids)
            {
                var user = await _userRepository.FirstOrDefaultAsync(u => u.Id == id);

                if (user == null)
                    return new OperationStatusResponse { Message = Resources.RecordDoesNotExist, Status = OperationStatus.ERROR };

                ApplicationDbContext context = new ApplicationDbContext(_configuration);

                using (var appUow = new AppUnitOfWork(context))
                {
                    using (var appTransaction = appUow.BeginTrainsaction())
                    {
                        try
                        {
                            RepositoryBase<UserRole> userRoleRepository = new RepositoryBase<UserRole>(_configuration);
                            RepositoryBase<User> userRepository = new RepositoryBase<User>(_configuration);

                            user.RecordStatus = RecordStatus.Deleted;
                            user.EndDate = DateTime.UtcNow;
                            user.Email = user.Email + "_Old";
                            user.LastUpdateDate = DateTime.UtcNow;
                            user.UpdatedBy = _httpContextAccessor.HttpContext.Session.GetString("UserName");
                            userRepository.Update(user);

                            await appUow.SaveChangesAsync();
                            appTransaction.Commit();
                            return new UserResponse
                            {
                                Message = Resources.OperationSucessfullyCompleted,
                                Status = OperationStatus.SUCCESS
                            };
                        }
                        catch (Exception)
                        {
                            appTransaction.Rollback();
                            return new UserResponse
                            {
                                Message = Resources.ErrorHasOccuredWhileProcessingYourRequest,
                                Status = OperationStatus.ERROR
                            };
                        }
                    }
                }
            }
            return new OperationStatusResponse { Message = Resources.RequestCouldntBeProcessed, Status = OperationStatus.ERROR };
        }

        //public UsersResponse GetAll()
        //{
        //    var usersResponse = new UsersResponse();

        //    //get all users with out Client Users 
        //    var allRoles = _userRoleRepository.Where(r => r.RoleId != 3).Include(i => i.Role).ToList();

        //    var users = _userRepository.
        //        Where(u => (u.RecordStatus == RecordStatus.Active || u.RecordStatus == RecordStatus.Inactive) && allRoles.Select(s => s.UserId).Contains(u.Id)).ToList();



        //    //var userOffices = _userOfficeRepository.All().ToList();
        //    //var offices = _officeRepository.All().ToList();

        //    if (users.Count > 0)
        //    {
        //        foreach (var user in users)
        //        {
        //            var userDetail = new UserRes();
        //            userDetail.Id = user.Id;
        //            userDetail.FirstName = user.FirstName;
        //            userDetail.LastName = user.LastName;
        //            userDetail.Username = user.Email;
        //            userDetail.Email = user.Email;
        //            userDetail.RecordStatus = user.RecordStatus;
        //            userDetail.IsSuperAdmin = user.IsSuperAdmin;
        //            userDetail.IsAccountLocked = user.RecordStatus == RecordStatus.Active ? false : true;

        //            if (user.Id != 0)
        //            {
        //                //var userRoles = _userRoleRepository.Where(ur => ur.UserId == user.Id, new string[] { nameof(Role) }).ToList();
        //                var userRoles = allRoles.Where(ur => ur.UserId == user.Id).ToList();
        //                if (userRoles != null && userRoles.Count > 0)
        //                    foreach (var userRole in userRoles)
        //                        userDetail.Roles.Add(new UserRoleRes { Id = userRole.RoleId, Name = userRole.Role.Name });

        //                //var userOfficeList = userOffices.Where(u => u.UserId == user.Id).Select(s => s.OfficeId).ToList();
        //                //var officesList = offices.Where(u => userOfficeList.Contains(u.Id)).ToList();

        //                //foreach (var item in officesList)
        //                //    userDetail.Offices += item.Name + ",";


        //            }
        //            usersResponse.Users.Add(userDetail);
        //        }
        //    }


        //    usersResponse.Status = OperationStatus.SUCCESS;
        //    usersResponse.Message = Resources.OperationSucessfullyCompleted;

        //    return usersResponse;
        //}

        public UsersResponse GetAllSupervisors()
        {
            var usersResponse = new UsersResponse();

            var role = _roleRepository.Where(r => r.Name == "Supervisor").FirstOrDefault();

            if (role == null)
                return new UsersResponse() { Status = OperationStatus.ERROR, Message = "Role Does not Exist" };
            var allRoles = _userRoleRepository.Where(r => r.RoleId == role.Id).Include(i => i.Role).ToList();

            var users = _userRepository.
                Where(u => (u.RecordStatus == RecordStatus.Active || u.RecordStatus == RecordStatus.Inactive) && allRoles.Select(s => s.UserId).Contains(u.Id)).ToList();


            //get all users with out Client Users 

            if (users.Count > 0)
            {
                foreach (var user in users)
                {
                    var userDetail = new UserRes();
                    userDetail.Id = user.Id;
                    userDetail.FirstName = user.FirstName;
                    userDetail.LastName = user.LastName;
                    userDetail.Username = user.Email;
                    userDetail.Email = user.Email;
                    userDetail.RecordStatus = user.RecordStatus;
                    userDetail.IsSuperAdmin = user.IsSuperAdmin;
                    userDetail.IsAccountLocked = user.RecordStatus == RecordStatus.Active ? false : true;

                    if (user.Id != 0)
                    {
                        //var userRoles = _userRoleRepository.Where(ur => ur.UserId == user.Id, new string[] { nameof(Role) }).ToList();
                        var userRoles = allRoles.Where(ur => ur.UserId == user.Id).ToList();
                        if (userRoles != null && userRoles.Count > 0)
                            foreach (var userRole in userRoles)
                                userDetail.Roles.Add(new UserRoleRes { Id = userRole.RoleId, Name = userRole.Role.Name });
                    }
                    usersResponse.Users.Add(userDetail);
                }
            }

            usersResponse.Status = OperationStatus.SUCCESS;
            usersResponse.Message = Resources.OperationSucessfullyCompleted;
            return usersResponse;
        }

        public UserResponse GetById(long id)
        {
            var user = _userRepository.FirstOrDefault(u => u.Id == id);

            if (user != null)
            {
                var userResponse = new UserResponse
                {
                    Status = OperationStatus.SUCCESS,
                    Message = Resources.OperationSucessfullyCompleted
                };

                var userDetail = new UserRes
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Username = user.Username,
                    Email = user.Email,
                    RecordStatus = user.RecordStatus,
                    IsSuperAdmin = user.IsSuperAdmin,
                    IsAccountLocked = user.RecordStatus == RecordStatus.Active ? false : true,
                    //AccountType = user.AccountType,
                    IsConfirmationEmailSent = user.IsConfirmationEmailSent,
                    IsReadOnly = user.IsReadOnly,
                    PhoneNumber = user.PhoneNumber
                };

                var userRoles = _userRoleRepository.Where(ur => ur.UserId == user.Id, new string[] { nameof(Role) }).ToList();

                if (userRoles != null && userRoles.Count > 0)
                    foreach (var userRole in userRoles)
                        userDetail.Roles.Add(new UserRoleRes { Id = userRole.RoleId, Name = userRole.Role.Name });

                userResponse.User = userDetail;
                return userResponse;
            }
            return new UserResponse { Status = OperationStatus.ERROR, Message = Resources.RecordDoesNotExist };
        }

        public UserResponse GetByUserName(string userName)
        {
            var user = _userRepository.FirstOrDefault(u => u.Username == userName);

            if (user != null)
            {
                var userResponse = new UserResponse
                {
                    Status = OperationStatus.SUCCESS,
                    Message = Resources.OperationSucessfullyCompleted
                };

                var userDetail = new UserRes
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Username = user.Username,
                    Email = user.Email,
                    RecordStatus = user.RecordStatus,
                    IsSuperAdmin = user.IsSuperAdmin,
                    IsAccountLocked = user.RecordStatus == RecordStatus.Active ? false : true,
                    //AccountType = user.AccountType,
                    IsConfirmationEmailSent = user.IsConfirmationEmailSent,
                    IsReadOnly = user.IsReadOnly,
                    PhoneNumber = user.PhoneNumber
                };

                var userRoles = _userRoleRepository.Where(ur => ur.UserId == user.Id, new string[] { nameof(Role) }).ToList();

                if (userRoles != null && userRoles.Count > 0)
                    foreach (var userRole in userRoles)
                        userDetail.Roles.Add(new UserRoleRes { Id = userRole.RoleId, Name = userRole.Role.Name });

                userResponse.User = userDetail;
                return userResponse;
            }

            return new UserResponse { Status = OperationStatus.ERROR, Message = Resources.RecordDoesNotExist };
        }

        public async Task<OperationStatusResponse> UpdateStatus(BulkAction bulkAction)
        {
            if (bulkAction != null && bulkAction.Ids.Count > 0)
            {
                ApplicationDbContext dbContext = new ApplicationDbContext(_configuration);
                using (var appUow = new AppUnitOfWork(dbContext))
                {
                    using (var appTransaction = appUow.BeginTrainsaction())
                    {
                        try
                        {
                            RepositoryBase<User> userRepository = new RepositoryBase<User>(_configuration);

                            int numberOfRecordsAffected = 0;

                            foreach (var id in bulkAction.Ids)
                            {
                                var user = await userRepository.FirstOrDefaultAsync(u => u.Id == id);
                                if (user != null)
                                {
                                    user.RecordStatus = bulkAction.RecordStatus;
                                    user.UpdatedBy = _httpContextAccessor.HttpContext.Session.GetString("UserName");
                                    user.TimeZoneInfo = TimeZoneInfo.Local.StandardName;
                                    user.LastUpdateDate = DateTime.UtcNow;
                                    userRepository.Update(user);
                                    await appUow.SaveChangesAsync();
                                    numberOfRecordsAffected++;
                                }
                            }
                            if (numberOfRecordsAffected > 0)
                            {
                                appTransaction.Commit();
                            }

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
            return new OperationStatusResponse
            {
                Message = Resources.PleaseSelectOneRecordToUpdate,
                Status = OperationStatus.ERROR,
            };
        }

        //
        public async Task<UserResponse> RegisterSupplier(SupplierRegistrationRequest request)
        {
            try
            {
                var previousUser = await _userRepository.FirstOrDefaultAsync(u => u.Email == request.User.Email);
                if (previousUser != null)
                    return new UserResponse { Message = Resources.RecordAlreadyExist, Status = OperationStatus.ERROR };
                if (true)
                    return new UserResponse { Message = Resources.RecordAlreadyExist, Status = OperationStatus.ERROR };
                //try
                //{
                //    using (var uow = new AppUnitOfWork(_appTransaction.GetDbContext()))
                //    {
                //        RepositoryBaseWork<Supplier> supplierRepo = new RepositoryBaseWork<Supplier>(uow);
                //        //var _userRoleRepository = new RepositoryBaseWork<UserRole>(uow);

                //        using (var transaction = uow.BeginTrainsaction())
                //        {
                //            RepositoryBaseWork<UserRole> userRoleRepository = new RepositoryBaseWork<UserRole>(uow);

                //            try
                //            {
                //                var supplierRole = _roleRepository.Where(r => r.Name == "Supplier").FirstOrDefault();

                //                var supplier = _mapper.Map<Supplier>(request);
                //                supplier.SupplierBusinessCategories = new List<SupplierBusinessCategory>();
                //                supplier.StartDate = DateTime.Now;
                //                supplier.EndDate = DateTime.MaxValue;
                //                supplier.RegisteredDate = DateTime.Now;
                //                supplier.RegisteredBy = _httpContextAccessor.HttpContext.Session.GetString("CurrentUsername");
                //                supplier.RecordStatus = RecordStatus.Active;
                //                supplier.IsReadOnly = false;
                //                supplier.User = new User
                //                {
                //                    FirstName = request.User.FirstName,
                //                    LastName = request.User.LastName,
                //                    Username = request.User.Username,
                //                    //UserRole = request.User.UserRole,
                //                    IsAccountLocked = false,
                //                    AccountType = AccountType.Client,
                //                    PersonId = null,
                //                    SupplierId = supplier.Id,
                //                    Email = request.User.Email,
                //                    RecordStatus = RecordStatus.Active,
                //                    IsReadOnly = false,
                //                    StartDate = DateTime.UtcNow,
                //                    EndDate = DateTime.MaxValue,
                //                    TimeZoneInfo = TimeZoneInfo.Local.StandardName,
                //                    RegisteredDate = DateTime.UtcNow,
                //                    RegisteredBy = _httpContextAccessor.HttpContext.Session.GetString("CurrentUsername")
                //                };

                //                supplier.User.Password = _passwordHasher.HashPassword(supplier.User, request.User.Password);
                //                foreach (var businessCategoryId in request.SupplyBusinessCategoryIds)
                //                {
                //                    var supplierBussinesCategory = new SupplierBusinessCategory();
                //                    supplierBussinesCategory.SupplierId = supplier.Id;
                //                    supplierBussinesCategory.BusinessCategoryId = businessCategoryId;
                //                    supplier.SupplierBusinessCategories.Add(supplierBussinesCategory);
                //                }

                //                //supplier.User.RoleId = _appSettings.SupplierRoleId;

                //                supplierRepo.Add(supplier);
                //                if (await uow.SaveChangesAsync() > 0)
                //                {
                //                    if (supplierRole != null)
                //                    {
                //                        var userRole = new UserRole
                //                        {
                //                            RoleId = supplierRole.Id,
                //                            UserId = supplier.User.Id,
                //                            StartDate = DateTime.UtcNow,
                //                            EndDate = DateTime.MaxValue,
                //                            RecordStatus = RecordStatus.Active,
                //                            UpdatedBy = _httpContextAccessor.HttpContext.Session.GetString("UserName"),
                //                            TimeZoneInfo = TimeZoneInfo.Local.StandardName,
                //                            LastUpdateDate = DateTime.UtcNow,
                //                        };

                //                        userRoleRepository.Add(userRole);
                //                        await uow.SaveChangesAsync();
                //                    }

                //                    transaction.Commit();
                //                    return new UserResponse { Message = Resources.OperationSucessfullyCompleted, Status = OperationStatus.SUCCESS };
                //                }

                //                transaction.Rollback();
                //                return new UserResponse { Message = Resources.ErrorHasOccuredWhileProcessingYourRequest, Status = OperationStatus.ERROR };
                //            }
                //            catch (Exception ex)
                //            {
                //                transaction.Rollback();
                //                return new UserResponse { Message = Resources.OperationSucessfullyCompleted, Status = OperationStatus.SUCCESS };
                //            }

                //            return new UserResponse { Message = Resources.OperationSucessfullyCompleted, Status = OperationStatus.SUCCESS };

                //        }
                //    }
                //}
                //catch (Exception ex)
                //{
                //    return new UserResponse { Message = Resources.OperationSucessfullyCompleted, Status = OperationStatus.SUCCESS };
                //}
                return new UserResponse { Message = Resources.OperationSucessfullyCompleted, Status = OperationStatus.SUCCESS };

            }
            catch (Exception ex)
            {
                return new UserResponse { Message = Resources.OperationSucessfullyCompleted, Status = OperationStatus.SUCCESS };
            }
        }



        public Person GetPerson(string userName)
        {
            try
            {
                Person result = new Person();
                //if (!string.IsNullOrEmpty(userName) || !string.IsNullOrWhiteSpace(userName))
                //{
                //    var person = _userRepository.Where(x => x.Username == userName).Cast<User>().Select(x => x.Person).FirstOrDefault();
                //    return person;
                //}
                return result;
            }
            catch (Exception ex)
            {
                Person result = new Person();
                return result;
            }
        }

        public UsersResponse GetAll()
        {
            var usersResponse = new UsersResponse();

            var dd = _httpContextAccessor.HttpContext.Session.GetString("AccountSubscriptionId");

            var users = _userRepository.
                Where(u => (u.RecordStatus == RecordStatus.Active ||
                            u.RecordStatus == RecordStatus.Inactive) /*&& u.AccountSubscriptionId == Convert.ToInt64(_httpContextAccessor.HttpContext.Session.GetString("AccountSubscriptionId")),
                 new string[] { nameof(AccountSubscription) }*/).Include(i => i.UserRole).ToList(); ;


            if (users != null)
            {
                foreach (var user in users)
                {
                    var userDetail = new UserRes();
                    userDetail.Id = user.Id;
                    userDetail.FirstName = user.FirstName;
                    userDetail.LastName = user.LastName;
                    userDetail.Username = user.Username;
                    userDetail.Email = user.Email;
                    userDetail.IsReadOnly = user.IsReadOnly;
                    userDetail.RecordStatus = user.RecordStatus;
                    userDetail.IsConfirmationEmailSent = user.IsConfirmationEmailSent;
                    userDetail.PhoneNumber = user.PhoneNumber;
                    // userDetail.AccountSubscriptionId = user.AccountSubscriptionId;
                    //userDetail.AccountType = user.AccountType;
                    userDetail.IsAccountLocked = user.RecordStatus == RecordStatus.Active ? false : true;

                    if (user != null)
                    {
                        //var role = _roleRepository.Where(ur => ur == user.RoleId).FirstOrDefault();
                        var userRoles = _userRoleRepository.Where(r => r.UserId == user.Id).Include(i => i.Role).ToList();
                        if (userRoles != null && userRoles.Count > 0)
                            foreach (var userRole in userRoles)
                                userDetail.Roles.Add(new UserRoleRes { Id = userRole.RoleId, Name = userRole.Role.Name });

                        //if (role != null)
                        //    userDetail.Role = new UserRoleRes { Id = role.Id, Name = role.Name };
                    }
                    usersResponse.Users.Add(userDetail);
                }
            }

            usersResponse.Status = OperationStatus.SUCCESS;
            usersResponse.Message = Resources.OperationSucessfullyCompleted;
            return usersResponse;
        }
        public async Task<UserResponse> Save(NewUserRequest request)
        {
            using (var uow = new AppUnitOfWork(_appTransaction.GetDbContext()))
            {
                var userRepository = new RepositoryBaseWork<User>(uow);
                var userRoleRepository = new RepositoryBaseWork<UserRole>(uow);
                string userName = request.Username.Trim();

                string appendableDigit = "";
                for (int i = 0; i < (8 - userName.Length); i++)
                    appendableDigit += "0";

                request.Username = appendableDigit + request.Username.Trim();
                var previousUser = await userRepository.FirstOrDefaultAsync(u => u.Username == request.Username);

                if (previousUser != null)
                    return new UserResponse { Message = Resources.RecordAlreadyExist, Status = OperationStatus.ERROR };

                if (request.Roles == null || request.Roles.Count < 1)
                    return new UserResponse { Message = Resources.PleaseSelectAtLeastOneRole, Status = OperationStatus.ERROR };

                using (var transaction = uow.BeginTrainsaction())
                {
                    try
                    {
                        var newUser = new User
                        {
                            FirstName = request.FirstName,
                            LastName = request.LastName,
                            Username = request.Username,
                            IsAccountLocked = false,
                            Email = request.Email,
                            RecordStatus = RecordStatus.Active,
                            IsReadOnly = false,
                            StartDate = DateTime.UtcNow,
                            EndDate = DateTime.MaxValue,
                            TimeZoneInfo = TimeZoneInfo.Local.StandardName,
                            RegisteredDate = DateTime.UtcNow,
                            RegisteredBy = _httpContextAccessor.HttpContext.Session.GetString("CurrentUsername")
                        };

                        newUser.Password = _passwordHasher.HashPassword(newUser, request.Password);

                        //if (newUser.AccountType == AccountType.BackOffice)
                        //    newUser.SupplierId = null;
                        //else
                        //    newUser.PersonId = null;

                        userRepository.Add(newUser);
                        await uow.SaveChangesAsync();

                        foreach (var role in request.Roles)
                        {
                            var userRole = new UserRole
                            {
                                RoleId = role,
                                UserId = newUser.Id,
                                StartDate = DateTime.UtcNow,
                                EndDate = DateTime.MaxValue,
                                RecordStatus = RecordStatus.Active,
                                UpdatedBy = _httpContextAccessor.HttpContext.Session.GetString("UserName"),
                                TimeZoneInfo = TimeZoneInfo.Local.StandardName,
                                LastUpdateDate = DateTime.UtcNow,
                            };

                            userRoleRepository.Add(userRole);
                            await uow.SaveChangesAsync();
                        }

                        await uow.SaveChangesAsync();

                        transaction.Commit();
                        return GetById(newUser.Id);
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return new UserResponse
                        {
                            Message = Resources.ErrorHasOccuredWhileProcessingYourRequest,
                            Status = OperationStatus.ERROR
                        };
                    }

                }
            }
        }

        public async Task<UserResponse> Update(UpdateUserRequest request)
        {
            if (request.Roles == null || request.Roles.Count < 1)
                return new UserResponse { Message = Resources.PleaseSelectAtLeastOneRole, Status = OperationStatus.ERROR };

            using (var appUow = new AppUnitOfWork(_appTransaction.GetDbContext()))
            {
                var userRepository = new RepositoryBaseWork<User>(appUow);
                var userRoleRepository = new RepositoryBaseWork<UserRole>(appUow);

                using (var appTransaction = appUow.BeginTrainsaction())
                {
                    try
                    {
                        var user = await userRepository.FirstOrDefaultAsync(u => u.Id == request.Id);

                        if (user == null)
                            return new UserResponse { Message = Resources.RecordDoesNotExist, Status = OperationStatus.ERROR };

                        //check if the user is trying to update own account
                        if (user.Username == _httpContextAccessor.HttpContext.Session.GetString("CurrentUsername"))
                            return new UserResponse { Message = Resources.CanNotUpdateOwnStatusOrRole, Status = OperationStatus.ERROR };

                        //check if the user is readonly
                        if (user.IsReadOnly == true)
                            return new UserResponse { Message = Resources.CantUpdateOrDeletePreDefinedUser, Status = OperationStatus.ERROR };

                        user.FirstName = request.FirstName;
                        user.LastName = request.LastName;
                        user.Email = request.Email;
                        //user.AccountType = request.AccountType;

                        //user.IsSuperAdmin = request.IsSuperAdmin;

                        user.TimeZoneInfo = TimeZoneInfo.Local.StandardName;
                        user.LastUpdateDate = DateTime.UtcNow;
                        user.UpdatedBy = _httpContextAccessor.HttpContext.Session.GetString("UserName");

                        userRepository.Update(user);
                        //await appUow.SaveChangesAsync();

                        var userRoleList = userRoleRepository.Where(ur => ur.UserId == request.Id).ToList();

                        //delete the old user-role mapping which do not belong to the new update list
                        if (userRoleList != null)
                        {
                            foreach (var userRole in userRoleList)
                            {
                                userRoleRepository.Remove(userRole);
                                await appUow.SaveChangesAsync();
                            }
                        }

                        foreach (var roleId in request.Roles)
                        {
                            var userRole = new UserRole
                            {
                                RoleId = roleId,
                                UserId = user.Id,
                                StartDate = DateTime.UtcNow,
                                EndDate = DateTime.MaxValue,
                                RecordStatus = RecordStatus.Active,
                                UpdatedBy = _httpContextAccessor.HttpContext.Session.GetString("UserName"),
                                TimeZoneInfo = TimeZoneInfo.Local.StandardName,
                                LastUpdateDate = DateTime.UtcNow,
                            };

                            userRoleRepository.Add(userRole);
                            await appUow.SaveChangesAsync();
                        }

                        await appUow.SaveChangesAsync();

                        appTransaction.Commit();

                        return new UserResponse
                        {
                            Message = Resources.OperationSucessfullyCompleted,
                            Status = OperationStatus.SUCCESS
                        };
                    }
                    catch (Exception ex)
                    {
                        appTransaction.Rollback();
                        return new UserResponse
                        {
                            Message = Resources.OperationEndWithError,
                            Status = OperationStatus.ERROR
                        };
                    }
                }
            }
        }

    }
}
