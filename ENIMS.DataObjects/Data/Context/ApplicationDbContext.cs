using ENIMS.DataObjects.Models.MasterData;
using ENIMS.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using CargoProrationAPI.DataObjects.Models.MasterData;

namespace ENIMS.DataObjects
{
    public class ApplicationDbContext : DbContext
    {
        IConfiguration _configuration;
        public ApplicationDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var appDbConfiguratopnSection = _configuration.GetSection("ConnectionStrings");
            var connectionStrings = appDbConfiguratopnSection.Get<ConnectionStrings>();
            optionsBuilder.UseSqlServer(connectionStrings.AppConnectionString).EnableSensitiveDataLogging(true);
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
                throw new ArgumentNullException("ModelBuilder is NULL");
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AccountSubscription>().HasIndex(t => new { t.CompanyName }).IsUnique(true);
            //modelBuilder.Entity<SupplierTechnicalEvaluationResult>().HasOne(t => t.Supplier).WithOne(t => t.Result).HasForeignKey<SupplierTechnicalEvaluationResult>(t => t.SupplierId);
            #region User Managment
            modelBuilder.Entity<User>().HasIndex(u => u.Username).IsUnique(true);
            //modelBuilder.Entity<Role>().HasIndex(r => r.Name).IsUnique(true);
            modelBuilder.Entity<Privilege>().HasIndex(p => p.Action).IsUnique(true);
            #endregion

            #region Master data

            #endregion
            modelBuilder.Seed();
        }

        #region Common
        public DbSet<MasterDataTransactionalHistory> MasterDataTransactionalHistory { get; set; }
        #endregion

        #region  subscription and client token
        //public DbSet<AccountSubscription> AccountSubscription { get; set; }
        public DbSet<PasswordRecovery> PasswordRecovery { get; set; }
        #endregion

        #region User Managment
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Privilege> Privilege { get; set; }
        public DbSet<RolePrivilege> RolePrivilege { get; set; }
        public DbSet<UserToken> UserToken { get; set; }
        public DbSet<Menus> Menus { get; set; }

        //Added
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<Menu> Menu { get; set; }
        #endregion


        #region Client User managment
        public DbSet<ClientUser> ClientUser { get; set; }
        public DbSet<ClientRole> ClientRole { get; set; }
        public DbSet<ClientPrivilege> ClientPrivilege { get; set; }
        public DbSet<ClientRolePrivilege> ClientRolePrivilege { get; set; }
        public DbSet<ClientUserToken> ClientUserToken { get; set; }
        #endregion

        #region Master Data
        //public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<CostCenter> CostCenters { get; set; }
        public DbSet<Person> Persons { get; set; }
        //public DbSet<Office> Offices { get; set; }
        //public DbSet<Country> Countries { get; set; }
        //public DbSet<Station> Stations { get; set; }
        //public DbSet<BusinessCategoryType> BusinessCategoryTypes { get; set; }
        //public DbSet<BusinessCategory> BusinessCategories { get; set; }
        //public DbSet<VendorType> VendorTypes { get; set; }
        //public DbSet<PurchaseGroup> purchaseGroups { get; set; }
        //public DbSet<RequirmentPeriod> RequirmentPeriods { get; set; }
        //public DbSet<SupplierBusinessCategory> SupplierBusinessCategory { get; set; }
        //public DbSet<ProjectTaskMatrix> ProjectTaskMatrix { get; set; }
        #endregion
        #region Operational
       // public DbSet<PurchaseRequisition> PurchaseRequisitions { get; set; }
       // public DbSet<PRDelegateTeam> PRDelegateTeams { get; set; }
       // public DbSet<PRApprover> PRApprovers { get; set; }
       // public DbSet<HotelAccommodation> HotelAccommodationRequests { get; set; }
       // public DbSet<HARApprover> HARApprovers { get; set; }
       // public DbSet<HARDelegateTeam> HARDelegateTeams { get; set; }
       // public DbSet<Project> Projects { get; set; }
       // public DbSet<ProjectTeam> ProjectTeams { get; set; }
       // public DbSet<RequestForDocument> RequestForDocumentations { get; set; }
       // public DbSet<RequestForDocAttachment> RequestForDocAttachments { get; set; }
       // public DbSet<RequestForDocumentApproval> RequestForDocumentApproval { get; set; }
       // //
       // public DbSet<TechnicalCriterion> Criteria { get; set; }
       // public DbSet<TechnicalCriteriaGroup> CriteriaGroup { get; set; }
       // public DbSet<TechnicalEvaluation> TechnicalEvaluation { get; set; }
       // //
       // public DbSet<FinancialHeaders> FinancialHeaders { get; set; }
       // public DbSet<FinancialCriteriaGroup> FinancialCriteriaGroups { get; set; }
       // public DbSet<FinancialCriteria> FinancialCriterias { get; set; }
       // public DbSet<FinancialHeaderValue> FinancialCriteriaItems { get; set; }
       // public DbSet<HotelAccommodationCriteria> HotelAccommodationCriteria { get; set; }
       // public DbSet<TenderInvitation> TenderInvitations { get; set; }
       // public DbSet<SupplierTenderInvitation> SupplierTenderInvitations { get; set; }
       // public DbSet<ShortListApproval> ShortListApprovals { get; set; }
       // public DbSet<ShortListedSupplier> ShortListedSuppliers { get; set; }
       // public DbSet<ShortListApprover> ShortListApprovers { get; set; }
       // public DbSet<TenderInvitationFloat> TenderInvitationFloats { get; set; }
       // public DbSet<FloatationSupplierFile> FloatationSupplierFiles { get; set; }
       // public DbSet<SuppliersProposalAttachment> SuppliersProposalAttachments { get; set; }
       // public DbSet<SuppliersTenderProposal> SuppliersTenderProposals { get; set; }
       // public DbSet<StoredFiles> StoredFiles { get; set; }
       // public DbSet<ProjectApproval> ProjectApprovals { get; set; }
       // public DbSet<ShortListOffices> ShortListOffices { get; set; }
       // public DbSet<TechnicalEvaluationResult> TechnicalEvaluationResult { get; set; }
       // public DbSet<TechnicalEvaluationResultApproval> TechnicalEvaluationResultApproval { get; set; }
       // public DbSet<SupplierTechnicalEvaluationResult> SupplierTechnicalEvaluationResult { get; set; }
       // public DbSet<TechnicalCriterionResult> CriterionResult { get; set; }
       // public DbSet<FinancialEvaluationResult> FinancialEvaluationResult { get; set; }
       // public DbSet<SupplierFinancialEvaluationResult> SupplierFinancialEvaluationResult { get; set; }
       // public DbSet<SupplierFinancialEvaluationResultTerm> SupplierFinancialEvaluationResultTerms { get; set; }
       // public DbSet<FinancialCriterionResult> FinancialCriterionResult { get; set; }
       // public DbSet<Clarification> Clarification { get; set; }
       // //
       // public DbSet<Negotiation> Negotiations { get; set; }
       // public DbSet<NegotiationSupplier> NegotiationSuppliers { get; set; }
       // public DbSet<NegotiationTeamApproval> NegotiationTeamApprovals { get; set; }
       // public DbSet<NegotiationTeam> NegotiationTeams { get; set; }


       // public DbSet<NegotiationCommunication> NegotiationCommunications { get; set; }
       // public DbSet<NegotiationCommunicationHistory> NegotiationCommunicationHistories { get; set; }
       // public DbSet<NegotiationCommunicationHistoryAttachement> NegotiationCommunicationHistoryAttachements { get; set; }


       //public DbSet<NegotiationCriterionResult> NegotiationCriterionResults { get; set; }
       //public DbSet<NegotiationEvaluationResult> NegotiationEvaluationResults { get; set; }
       //public DbSet<NegotiationSupplierEvaluationResult> NegotiationSupplierEvaluationResults { get; set; }
       //public DbSet<SupplierResult> SupplierResults { get; set; }
       //public DbSet<TechnicalResultMessage> TechnicalResultMessage { get; set; }
       //public DbSet<ProjectUpdateRecord> ProjectUpdateRecord { get; set; }
       //public DbSet<ProjectCancelRequestAttachement> ProjectCancelRequestAttachements { get; set; }
       //public DbSet<ProjectCancelRequest> ProjectCancelRequests { get; set; }
       //public DbSet<ProjectCancelRequestOffice> ProjectCancelRequestOffice { get; set; }
       //public DbSet<ProjectCancelRequestApprovers> ProjectCancelRequestApprovers { get; set; }
       //public DbSet<TechnicalEvaluationApproval> TechnicalEvaluationApproval { get; set; }
       //public DbSet<FinancialEvaluationApproval> FinancialEvaluationApproval { get; set; }
       //public DbSet<FinancialEvaluationResultApproval> FinancialEvaluationResultApproval { get; set; }
     
       // #endregion
       // #region Report
       // public DbSet<ExcutiveSummary> ExcutiveSummaries { get; set; }
       // public DbSet<ExcutiveSummaryApproval> ExcutiveSummaryApprovals { get; set; }
       // public DbSet<ExcutiveSummaryAttachement> ExcutiveSummaryAttachements { get; set; }
       // public DbSet<ExcutiveSummaryOffice> ExcutiveSummaryOffices { get; set; }
       // public DbSet<DetailEvaluationReport> DetailEvaluationReports { get; set; }
       // public DbSet<DetailEvaluationOffice> DetailEvaluationOffices { get; set; }
       // public DbSet<DetailEvaluationReportAttachement> DetailEvaluationReportAttachements { get; set; }
        #endregion
    }
}