using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;  
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using ENIMS.Common;
using ENIMS.Core;
using ENIMS.DataObjects;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace ENIMS.Api
{
    //[Authorize]
    [ApiController]
    [Route("Upload/api/V1.0/[controller]")]
    public class StreamingController : ControllerBase
    {
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly long _fileSizeLimit;
        private readonly string[] _permittedExtensions = { ".jpg", ".jpeg", ".gif", ".png" };
        private readonly string _targetFilePath;
        private readonly ILoggerManager _logger;
        private readonly ApplicationDbContext _db;

        public StreamingController(IConfiguration config, ILoggerManager logger, ApplicationDbContext db, IPasswordHasher<User> passwordHasher)
        {
            _passwordHasher = passwordHasher;
            _logger = logger;
            _fileSizeLimit = config.GetValue<long>("FileSizeLimit");

            // To save physical files to a path provided by configuration:
            _targetFilePath = config.GetValue<string>("StoredFilesPath");
            _db = db;
        }

        [HttpPost(nameof(UploadPhysical))]
        [DisableFormValueModelBinding]
       // [ValidateAntiForgeryToken]
        [GenerateAntiforgeryTokenCookie]
        public async Task<IActionResult> UploadPhysical()
        {
            //call upload function
            UploadProcessResponse uploadResult = await FileUploadHelper.ProcessUpload(HttpContext.Request.Body, Request.ContentType, Request.ContentType,_permittedExtensions,_fileSizeLimit,_targetFilePath);
            if (uploadResult.Message == Resources.FileUploadError)
            {
                return BadRequest(uploadResult);
            }
            if (uploadResult.Status == OperationStatus.ERROR)
            {
                return StatusCode(500, uploadResult);
            }
            #region Bind form data to the model
            var formData = new FormData();

            var formValueProvider = new FormValueProvider(BindingSource.Form,
                new FormCollection(uploadResult.formAccumulator.GetResults()),
                CultureInfo.CurrentCulture);

            var bindingSuccessful = await TryUpdateModelAsync(formData, prefix: "", valueProvider: formValueProvider);

            if (!bindingSuccessful)
            {
                // Log error
                uploadResult.Message = Resources.OperationEndWithError;
                uploadResult.Status = OperationStatus.SUCCESS;
                return StatusCode(500, uploadResult);
            } 
            #endregion
            return Ok(uploadResult);
        }

        [HttpPost(nameof(SeedDatabase))]
        public async Task<IActionResult> SeedDatabase() 
        {   
            DatabaseSeedHelper databaseSeed = new DatabaseSeedHelper(_db);
            databaseSeed.SeedData();
            return Ok();
        }

        [HttpPost(nameof(SeedClientPriveledgeDatabase))]
        public IActionResult SeedClientPriveledgeDatabase()
        {
            PriveliedgeHelper priveliedgeHelper = new PriveliedgeHelper(_db);
            Assembly asm = Assembly.GetExecutingAssembly();
            var controlleractionlist = asm.GetTypes()
                    .Where(type => typeof(ControllerBase).IsAssignableFrom(type))
                    .SelectMany(type => type.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public))
                    .Where(m => !m.GetCustomAttributes(typeof(System.Runtime.CompilerServices.CompilerGeneratedAttribute), true).Any())
                    .Select(x => new { Controller = x.DeclaringType.Name, Action = x.Name, ReturnType = x.ReturnType.Name, Attributes = String.Join(",", x.GetCustomAttributes().Select(a => a.GetType().Name.Replace("Attribute", ""))) })
                    .OrderBy(x => x.Controller).ThenBy(x => x.Action).ToList();
            //assign default module while creating
            List<ClientPrivilege> privilaegs = new List<ClientPrivilege>();
            foreach (var controlleraction in controlleractionlist)
            {
                var priveldge = new ClientPrivilege
                {
                    Action = controlleraction.Controller.Replace("Controller","") + "-"+ controlleraction.Action,
                    Module = "Default"
                };
                privilaegs.Add(priveldge);
            }
            priveliedgeHelper.SeedDbClientPriviledge(privilaegs);
            return Ok();
        }

        [HttpPost(nameof(SeedPriveledgeDatabase))]
        public IActionResult SeedPriveledgeDatabase(/*[FromBody] PrivelidgeCreationRequest privilaegs*/)
        {
            PriveliedgeHelper priveliedgeHelper = new PriveliedgeHelper(_db);
            Assembly asm = Assembly.GetExecutingAssembly();
            var controlleractionlist = asm.GetTypes()
                    .Where(type => typeof(ControllerBase).IsAssignableFrom(type))
                    .SelectMany(type => type.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public))
                    .Where(m => !m.GetCustomAttributes(typeof(System.Runtime.CompilerServices.CompilerGeneratedAttribute), true).Any())
                    .Select(x => new { Controller = x.DeclaringType.Name, Action = x.Name, ReturnType = x.ReturnType.Name, Attributes = String.Join(",", x.GetCustomAttributes().Select(a => a.GetType().Name.Replace("Attribute", ""))) })
                    .OrderBy(x => x.Controller).ThenBy(x => x.Action).ToList();

            List<Privilege> privileges = new List<Privilege>();
            foreach (var controlleraction in controlleractionlist)
            {
                var priveldge = new Privilege
                {
                    Action = controlleraction.Controller.Replace("Controller", "") + "-" + controlleraction.Action,
                    Module = "Default"
                };
                privileges.Add(priveldge);
            }
            priveliedgeHelper.SeedDbPriviledge(privileges);
            return Ok();
        }

        [HttpPost(nameof(SeedDbClientPriviledgeRoleCombination))]
        public IActionResult SeedDbClientPriviledgeRoleCombination([FromBody] ClientPrivelidgeRoleCreationRequest clientPrivelidgeRoleCreation)
        {
            PriveliedgeHelper priveliedgeHelper = new PriveliedgeHelper(_db);
            priveliedgeHelper.SeedDbClientPriviledgeRoleCombination(clientPrivelidgeRoleCreation);
            return Ok();
        }

        [HttpPost(nameof(SeedDbPriviledgeRoleCombination))]
        public IActionResult SeedDbPriviledgeRoleCombination([FromBody] PrivelidgeRoleCreationRequest privelidgeRoleCreation)
        {
            PriveliedgeHelper priveliedgeHelper = new PriveliedgeHelper(_db);
            priveliedgeHelper.SeedDbPriviledgeRoleCombination(privelidgeRoleCreation);
            return Ok();
        }

        public class FormData
        {
            public long id { get; set; }
            public string user { get; set; }
        }

        /////////////////////////////////////
        [HttpPost(nameof(SeedCreateSuperUserDatabase))]
        public IActionResult SeedCreateSuperUserDatabase()
        {
            PriveliedgeHelper priveliedgeHelper = new PriveliedgeHelper(_db);

            priveliedgeHelper.SeedDbCreateUser(_passwordHasher);
            return Ok();
        }

        [HttpPost(nameof(SeedAllPrivilagesDatabase))]
        public IActionResult SeedAllPrivilagesDatabase()
        {
            PriveliedgeHelper priveliedgeHelper = new PriveliedgeHelper(_db);

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

            //priveliedgeHelper.SeedDbPriviledge();
            return Ok();
        }
    }
}
