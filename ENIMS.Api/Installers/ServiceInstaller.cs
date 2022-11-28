using ENIMS.Common;
using ENIMS.Common.RequestModel.Account;
using ENIMS.Common.RequestModel.MasterData;
using ENIMS.Common.RequestModel.Operational;
using ENIMS.Common.ResponseModel;
using ENIMS.Common.ResponseModel.Account;
using ENIMS.Common.ResponseModel.MasterData;
using ENIMS.Common.ResponseModel.Operational;
using ENIMS.Common.ResponseModel.Operational.Negotiation;
using ENIMS.Core;
using ENIMS.Core.Interface.Account;
using ENIMS.Core.Interface.MasterData;
using ENIMS.Core.Service;
using ENIMS.Core.Service.Account;
using ENIMS.Core.Service.Helper;
//using ENIMS.Core.Service.MasterData;
//using ENIMS.Core.Service.Operational;
using ENIMS.DataObjects;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ENIMS.Core.Interface.Helper;

namespace ENIMS.Api.Installers
{
    public class ServiceInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            #region common
            services.AddScoped<AuthorizationAttribute>();
            services.AddScoped(typeof(ITokenService<ClientTokenService>), typeof(ClientTokenService));
            services.AddScoped(typeof(ITokenService<UserTokenService>), typeof(UserTokenService));
            //services.AddScoped(typeof(IAuthorizationService<UserAuthorizationService>), typeof(UserAuthorizationService));
            //services.AddScoped(typeof(IAuthorizationService<ClientAuthorizationService>), typeof(ClientAuthorizationService));

            #endregion
            #region subscription
            //services.AddScoped<ISubscriptionService, SubscriptionService>();
            #endregion

            #region user managment
            //services.AddScoped<IPasswordService, PasswordService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IPasswordService, PasswordService>();

            services.AddSingleton(typeof(IPasswordHasher<User>), typeof(Core.PasswordHasher<User>));

            services.AddScoped<IRolePrivilegeService, RolePrivilegeService>();
            services.AddScoped<IUserRoleService, UserRoleService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped(typeof(IAuthorizationService), typeof(AuthorizationService));

            #endregion

            #region user managment
            services.AddScoped<IPasswordService, PasswordService>();
            //services.AddScoped<IAccountService<AccountService>, AccountService>();

            services.AddScoped(typeof(IBaseService<RoleRequest, RoleResponse, RolesResponse>), typeof(RoleService));

            services.AddSingleton(typeof(IPasswordHasher<User>), typeof(Core.PasswordHasher<User>));
            services.AddScoped(typeof(IBaseService<UserRequest, UserResponse, UsersResponse>), typeof(UserService));
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPrivilegeService, PrivilegeService>();
            //services.AddScoped<IRoleService, RoleService>();
            //services.AddScoped<IPasswordServiceClient, ClientPasswordService>();
            //services.AddScoped<IAccountService<AccountServiceClient>, AccountServiceClient>();
            //services.AddScoped(typeof(IBaseService<ClientRoleRequest, ClientRoleResponse, ClientRolesResponse>), typeof(ClientRoleService));
            //services.AddSingleton(typeof(IPasswordHasher<ClientUser>), typeof(Core.PasswordHasher<ClientUser>));
            //services.AddScoped(typeof(IBaseService<ClientUserRequest, ClientUserResponse, ClientUsersResponse>), typeof(ClientUserService));
            //services.AddScoped<IPrivilegeServiceClient, ClientPrivilegeService>();
            #endregion

            #region Master data




            //services.AddScoped(typeof(Core.Interface.MasterData.ICrud<OfficeResponse,OfficesResponse, OfficeRequest>), typeof(OfficeService));;
            //services.AddScoped(typeof(Core.Interface.MasterData.ICrud<CostCenterResponse,CostCentersResponse, CostCenterRequest>), typeof(CostCenterService));
            //services.AddScoped(typeof(Core.Interface.MasterData.ICrud<PersonResponse,PersonsResponse, PersonRequest>), typeof(PersonService));
            //services.AddScoped(typeof(Core.Interface.MasterData.ICrud<CountryResponse, CountriesResponse, CountryRequest>), typeof(CountryService));
            //services.AddScoped(typeof(Core.Interface.MasterData.ICrud<StationResponse, StationsResponse, StationRequest>), typeof(StationService));
            //services.AddScoped(typeof(Core.Interface.MasterData.ICrud<BusinessCategoryTypeResponse, BusinessCategoryTypesResponse, SupplyBusinessCategoryTypeRequest>), typeof(SupplyBusinessCategoryTypeService));
            //services.AddScoped(typeof(Core.Interface.MasterData.ICrud<BusinessCategoryResponse, BusinessCategoriesResponse, BusinessCategoryRequest>), typeof(SupplyBusinessCategoryService));
            //services.AddScoped(typeof(Core.Interface.MasterData.ICrud<VendorTypeResponse, VendorTypesResponse, VendorTypeRequest>), typeof(VendorTypeService));
            //services.AddScoped(typeof(Core.Interface.MasterData.ICrud<PurchaseGroupResponse, PurchaseGroupsResponse, PurchaseGroupRequest>), typeof(PurchaseGroupService));
            //// services.AddScoped(typeof(ICrud<PurchaseTypeResponse, PurchaseTypesResponse, PurchaseTypeRequest>), typeof(PurchaseTypeService));;
            //services.AddScoped(typeof(Core.Interface.MasterData.ICrud<RequirmentPeriodResponse, RequirmentPeriodsResponse, RequirmentPeriodRequest>), typeof(RequirmentPeriodService));
            //services.AddScoped(typeof(IRequirementPeriod<RequirmentPeriodsResponse>), typeof(RequirmentPeriodService));
            //services.AddScoped(typeof(Core.Interface.MasterData.ICrud<ProcurementSectionResponse, ProcurementSectionsResponse, ProcurementSectionRequest>), typeof(ProcurementSectionService));
            //services.AddScoped(typeof(IProcurementSection<ProcurementSectionsResponse>), typeof(ProcurementSectionService));;
            //services.AddScoped(typeof(IBulkInsertion<SupplierResponse, SupplierRequest>), typeof(SupplierService));
            //services.AddScoped(typeof(IBulkInsertion<OfficeResponse, OfficeRequest>), typeof(OfficeService));
            //services.AddScoped(typeof(IBulkInsertion<CostCenterResponse, CostCenterRequest>), typeof(CostCenterService));
            //services.AddScoped(typeof(IBulkInsertion<PersonResponse, PersonRequest>), typeof(PersonService));
            //services.AddScoped(typeof(IBulkInsertion<StationResponse, StationDto>), typeof(StationService));
            //services.AddScoped(typeof(ISupplierRegistration<SupplierRegistrationRequest, SupplierResponse>), typeof(SupplierService));
            //services.AddScoped(typeof(ISupplier), typeof(SupplierService));
            //services.AddScoped(typeof(IProjectsProcess), typeof(ProjectProcessService));
            //services.AddScoped(typeof(INotificaton), typeof(NotificationService));
            #endregion

            #region Operational
            //services.AddScoped(typeof(IPurchaseRequisition<PurchaseRequisitionResponse, PurchaseRequisitionsResponse, PurchaseRequisitionRequest>), typeof(PurchaseRequisitionService)); ;
            //services.AddScoped(typeof(IHotelAccommodation<HotelAccommodationResponse, HotelAccommodationsResponse, HotelAccommodationRequest>), typeof(HotelAccommodationService)); ;
            //services.AddScoped(typeof(IRequest<RejectRequest, AssignRequest,SelfAssignRequest ,PurchaseRequisitionResponse>), typeof(PurchaseRequisitionService)); ;
            //services.AddScoped(typeof(IRequestApproval), typeof(PurchaseRequisitionService));
            //services.AddScoped(typeof(IRequest<RejectRequest, AssignRequest,SelfAssignRequest, HotelAccommodationResponse>), typeof(HotelAccommodationService)); ;
            //services.AddScoped(typeof(IProject<ProjectInitiationResponse, ProjectInitiationsResponse, ProjectInitiationRequest>), typeof(ProjectService));
            //services.AddScoped(typeof(IProjectTeam<ProjectTeamResponse, ProjectTeamResponse, ProjectTeamRequest>), typeof(ProjectTeamService));
            //services.AddScoped(typeof(IRequestForDocument<RequestForDocResponse, RequestForDocsResponse, RequestForDocRequest>), typeof(RequestForDocumentService));
            //services.AddScoped(typeof(IEvaluation<TechnicalEvaluationResponse, TechnicalEvaluationsResponse, TechnicalEvaluationRequest, TechnicalEvaluationUpdateRequest>), typeof(TechnicalEvaluationService));
            //services.AddScoped(typeof(IEvaluation<FinancialEvaluationResponse, FinancialEvaluationsResponse, FinancialEvaluationRequest, FinancialEvaluationUpdateRequest>), typeof(FinancialEvaluationService));
            //services.AddScoped(typeof(Core.Interface.Operational.ICrud<CriterionResponse, CriterionsResponse,CriterionRequest, CriterionRequest>), typeof(CriteriaService));
            //services.AddScoped(typeof(Core.Interface.Operational.ICrud<CriteriaGroupResponse, CriteriaGroupsResponse,CriteriaGroupRequest, CriteriaGroupUpdateRequest>), typeof(CriteriaGroupService));
            //services.AddScoped(typeof(Core.Interface.Operational.ICrud<FinancialEvaluationResponse, FinancialEvaluationsResponse,FinancialEvaluationRequest, FinancialEvaluationUpdateRequest>), typeof(FinancialEvaluationService));
            //services.AddScoped(typeof(Core.Interface.Operational.ICrud<FinancialCriteriaGroupResponse, FinancialCriteriaGroupsResponse,FinancialCriteriaGroupRequest, FinancialCriteriaGroupUpdateRequest>), typeof(FinancialCriteriaGroupService));
            //services.AddScoped(typeof(Core.Interface.Operational.ICrud<FinancialCriteriaResponse, FinancialCriteriasResponse, FinancialCriteriaRequest, FinancialCriteriaUpdateRequest>), typeof(FinancialCriteriaService));
            ////services.AddScoped(typeof(Core.Interface.Operational.ICrud<FinancialCriteriaItemResponse, FinancialCriteriaItemsResponse, FinancialCriteriaItemRequest, FinancialCriteriaItemRequest>), typeof(FinancialCriteriaItemService));
            //services.AddScoped(typeof(IHotelEvaluation<HotelAccommodationCriteriaRequest, HotelAccommodationCriteriaResponse, HotelAccommodationCriteriasResponse>), typeof(HotelEvaluationService));
            //services.AddScoped(typeof(ITenderInvitation<TenderInvitationResponse, TenderInvitationRequest>), typeof(TenderInvitationService));
            //services.AddScoped(typeof(IApproval), typeof(ApprovalService));
            //services.AddScoped(typeof(ITechnicalEvaluation), typeof(SupplierTechnicalEvaluationService));
            //services.AddScoped(typeof(IFinancialEvaluation<FinancialResultResponse, FinancialResultDetailResponse>), typeof(SupplierFinancialEvaluationService));
            //services.AddScoped(typeof(IFinancialEvaluation<FinancialResultResponse, NegotiationResultDetailResponse>), typeof(NegotiationEvaluationService));
            //services.AddScoped(typeof(IClarification), typeof(ClarificationService));
            //services.AddScoped(typeof(INegotiation), typeof(NegotiationService));
            //services.AddScoped(typeof(INegotiationCommunication), typeof(NegotiationCommunicationService));
            //services.AddScoped(typeof(IResult), typeof(ResultService));


            #endregion

            #region Report
            //services.AddScoped(typeof(IReport), typeof(ReportService));
            #endregion
        }
    }
}
