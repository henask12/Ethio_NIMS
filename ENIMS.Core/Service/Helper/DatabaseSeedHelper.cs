using ENIMS.Common;
using ENIMS.DataObjects;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web.Mvc;

namespace ENIMS.Core
{
    public class DatabaseSeedHelper
    {
        public void SeedData()
        {

        }
        private readonly ApplicationDbContext _db;
        public DatabaseSeedHelper(ApplicationDbContext db)
        {
            _db = db;
        }
    }

    public class PriveliedgeHelper
    {
        private readonly ApplicationDbContext _db;
        public PriveliedgeHelper(ApplicationDbContext db)
        {
            _db = db;
        }
       
        public void SeedDbClientPriviledge(List<ClientPrivilege> clientPrivileges)
        {
            foreach (var privilaeg in clientPrivileges)
            {
                var prevPrivilaegs = _db.ClientPrivilege.Where(c => c.Action == privilaeg.Action).FirstOrDefault();

                if (prevPrivilaegs == null)
                {
                    var newPrivelesge = new ClientPrivilege
                    {
                        Action = privilaeg.Action,
                        Module = privilaeg.Module,
                        RecordStatus = RecordStatus.Active,
                        StartDate = DateTime.UtcNow,
                        EndDate = DateTime.MaxValue,
                    };
                    _db.ClientPrivilege.Add(newPrivelesge);
                }
            }
            _db.SaveChanges();
        }

        public void SeedDbPriviledge(List<Privilege> privileges)
        {
            foreach (var privilaeg in privileges)
            {
                var prevPrivilaegs = _db.Privilege.Where(c => c.Action == privilaeg.Action).FirstOrDefault();

                if (prevPrivilaegs == null)
                {
                    var newPrivelesge = new Privilege
                    {
                        Action = privilaeg.Action,
                        Module = privilaeg.Module,
                        IsMorePermission = privilaeg.IsMorePermission,
                        RecordStatus = RecordStatus.Active,
                        StartDate = DateTime.UtcNow,
                        EndDate = DateTime.MaxValue,
                    };
                    _db.Privilege.Add(newPrivelesge);
                }
            }
            _db.SaveChanges();
        }
        public void SeedDbClientPriviledgeRoleCombination(ClientPrivelidgeRoleCreationRequest clientPrivelidgeRoleCreation)
        {
            //get list of privelidge
            var listOfClientPriviledge = _db.ClientPrivilege.ToList();

            foreach (var privilaeg in listOfClientPriviledge)
            {
                var prevRolePrivilaegs = _db.ClientRolePrivilege.Where(c => c.RoleId == clientPrivelidgeRoleCreation.RoleId && c.PrivilegeId == privilaeg.Id).FirstOrDefault();

                if (prevRolePrivilaegs == null)
                {
                    var rolePrivelesge = new ClientRolePrivilege
                    {
                        PrivilegeId = privilaeg.Id,
                        RoleId = clientPrivelidgeRoleCreation.RoleId,
                        RecordStatus = RecordStatus.Active,
                        StartDate = DateTime.UtcNow,
                        EndDate = DateTime.MaxValue,
                    };
                    _db.ClientRolePrivilege.Add(rolePrivelesge);
                }
            }
            _db.SaveChanges();
        }

        public void SeedDbPriviledgeRoleCombination(PrivelidgeRoleCreationRequest privelidgeRoleCreation)
        {
            try
            {
                ////get list of privelidge
                //var listOfPriviledge = _db.Privilege.Where(p => p.ClientUserId == privelidgeRoleCreation.ClientId).ToList();

                //foreach (var privilaeg in listOfPriviledge)
                //{
                //    var prevRolePrivilaegs = _db.RolePrivilege.Where(c => c.RoleId == privelidgeRoleCreation.RoleId && c.PrivilegeId == privilaeg.Id).FirstOrDefault();

                //    if (prevRolePrivilaegs == null)
                //    {
                //        var rolePrivelesge = new RolePrivilege
                //        {
                //            PrivilegeId = privilaeg.Id,
                //            RoleId = privelidgeRoleCreation.RoleId,
                //            RecordStatus = RecordStatus.Active,
                //            StartDate = DateTime.UtcNow,
                //            EndDate = DateTime.MaxValue,
                //        };
                //        _db.RolePrivilege.Add(rolePrivelesge);
                //    }
                //}
                //_db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        ///////Newly added
        public void SeedDbPriviledge()
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            var controlleractionlist = asm.GetTypes().Where(type => typeof(Controller).IsAssignableFrom(type)) //filter controllers
             .SelectMany(type => type.GetMethods())
             .Where(method => method.IsPublic && !method.IsDefined(typeof(NonActionAttribute)));

            var controlleractionlistforAll = asm.GetTypes()
            .Where(type => typeof(Controller).IsAssignableFrom(type))
            .SelectMany(type => type.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public))
            .Where(method => !method.IsDefined(typeof(NonActionAttribute)))
            .Where(m => !m.GetCustomAttributes(typeof(System.Runtime.CompilerServices.CompilerGeneratedAttribute), true).Any())
            .Select(x => new { Controller = x.DeclaringType.Name, Action = x.Name, ReturnType = x.ReturnType.Name, Attributes = String.Join(",", x.GetCustomAttributes().Select(a => a.GetType().Name.Replace("Attribute", ""))) })
            .OrderBy(x => x.Controller).ThenBy(x => x.Action).ToList();
            var privilegeRequest = new List<PrivilegeRequest>();

            var controller = string.Empty;

            foreach (var controllerAndAction in controlleractionlistforAll)
            {
                _db.Privilege.Add(new Privilege
                {
                    Action = $"{controllerAndAction.Controller.Replace("Controller", "")}-{controllerAndAction.Action}",
                    Description = $"{controllerAndAction.Action}-{controllerAndAction.Controller.Replace("Controller", "")}",
                    RecordStatus = RecordStatus.Active,
                    StartDate = DateTime.UtcNow,
                    TimeZoneInfo = TimeZoneInfo.Local.StandardName,
                    LastUpdateDate = DateTime.UtcNow,
                    EndDate = DateTime.MaxValue,
                    UpdatedBy = "System Default"
                });

                _db.SaveChanges();
            }
        }

        public void SeedDbCreateUser(IPasswordHasher<User> _passwordHasher)
        {
            var privilaegs = _db.Privilege.Where(c => c.RecordStatus == RecordStatus.Active).ToList();

            var role = new Role
            {
                Name = "Supper User",
                Description = "Supper User",
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.MaxValue,
                RecordStatus = RecordStatus.Active,                
                UpdatedBy = "System Default",
                TimeZoneInfo = TimeZoneInfo.Local.StandardName,
                LastUpdateDate = DateTime.UtcNow,
            };

            _db.Role.Add(role);
            _db.SaveChanges();

            foreach (var previlage in privilaegs)
            {
                var rolePrivilage = new RolePrivilege
                {
                    RoleId = role.Id,
                    PrivilegeId = previlage.Id,
                    StartDate = DateTime.UtcNow,
                    EndDate = DateTime.MaxValue,
                    RecordStatus = RecordStatus.Active,
                    UpdatedBy = "System Default",
                    TimeZoneInfo = TimeZoneInfo.Local.StandardName,
                    LastUpdateDate = DateTime.UtcNow,
                };

                _db.RolePrivilege.Add(rolePrivilage);
                _db.SaveChanges();
            }

            var user = _db.Privilege.Where(c => c.RecordStatus == RecordStatus.Active).ToList();

            var newUser = new User
            {
                FirstName = "Super Admin",
                LastName = "Super Admin",
                Username = "SuperAdmin@gmail.com",
                IsAccountLocked = false,
                //AccountType = AccountType.BackOffice,
                Email = "SuperAdmin@gmail.com",
                RecordStatus = RecordStatus.Active,
                IsReadOnly = false,
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.MaxValue,
                TimeZoneInfo = TimeZoneInfo.Local.StandardName,
                RegisteredDate = DateTime.UtcNow,
                RegisteredBy = "System Default",
            };

            newUser.Password = _passwordHasher.HashPassword(newUser, "Abcd@1234");

            _db.User.Add(newUser);
            _db.SaveChanges();

            var userRole = new UserRole
            {
                RoleId = role.Id,
                UserId = newUser.Id,
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.MaxValue,
                RecordStatus = RecordStatus.Active,
                UpdatedBy = "System Default",
                TimeZoneInfo = TimeZoneInfo.Local.StandardName,
                LastUpdateDate = DateTime.UtcNow,
            };

            _db.UserRole.Add(userRole);
            _db.SaveChanges();
        }
    }

    public class PrivelidgeCreationRequest
    {
        public long ClientId { get; set; }
        public List<Privilege> priveledges { get; set; }
    }

    public class PrivelidgeRoleCreationRequest
    {
        public long ClientId { get; set; }
        public long RoleId { get; set; }
    }

    public class ClientPrivelidgeRoleCreationRequest
    {
        public long RoleId { get; set; }
    }
}
