using Aurora.AdministrationService.CrossCutting.Constants;
using Aurora.AdministrationService.Domain.Entities;
using Aurora.AdministrationService.Domain.V1.Entities.Contents;
using Aurora.AdministrationService.Domain.V1.Entities.DrugMasters;
using Aurora.AdministrationService.Domain.V1.Entities.InsurancePanels;
using Aurora.AdministrationService.Domain.V1.Entities.Locations;
using Aurora.AdministrationService.Domain.V1.Entities.Organizations;
using Aurora.AdministrationService.Domain.V1.Entities.PaymentGateways;
using Aurora.AdministrationService.Domain.V1.Entities.PractitionerNotifications;
using Aurora.AdministrationService.Domain.V1.Entities.PractitionerRoles;
using Aurora.AdministrationService.Domain.V1.Entities.Practitioners;
using Aurora.AdministrationService.Domain.V1.Entities.ProcedureChargeMasters;
using Aurora.AdministrationService.Domain.V1.Entities.ServiceChargeMasters;
using Aurora.AdministrationService.Domain.V1.Entities.Users;
using Aurora.AdministrationService.Domain.V1.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using Aurora.AdministrationService.Domain.V1.Entities.Languade;
using System.Diagnostics.CodeAnalysis;
using Aurora.AdministrationService.Domain.V1.Entities.CountryMasters;
using Microsoft.AspNetCore.Razor.Language;
using System.Data;
using System.Text.RegularExpressions;
using Aurora.AdministrationService.Domain.V1.Entities.UserGroups;
using Aurora.AdministrationService.Domain.V1.Entities.AccessControls;
using Aurora.AdministrationService.Domain.V1.Entities.Marketings;
using Aurora.AdministrationService.Domain.V1.Entities.HealthcareService;
using Aurora.AdministrationService.Domain.Old.Entities;
using Aurora.AdministrationService.Domain.V1.Entities.HealthcareServices;

namespace Aurora.AdministrationService.Infrastructure
{

    /// <summary>
    /// Creation of connection string region wise and configure entities
    /// </summary>
    public abstract class BaseDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly HttpContextAccessor _httpContextAccessor = new();
        private const string DateTimeColumnType = "datetime2";
        private const string GetUtcDate = "(getUtcdate())";
        #region DBSet

        public virtual DbSet<AdminDoctorLocation> AdminDoctorLocations { get; set; }
        public virtual DbSet<AdminDoctorProfile> AdminDoctorProfiles { get; set; }
        public virtual DbSet<AdminDoctorSchedule> AdminDoctorSchedules { get; set; }
        public virtual DbSet<AdminDoctorSpeciality> AdminDoctorSpecialities { get; set; }
        public virtual DbSet<AdminFaq> AdminFaqs { get; set; }
        public virtual DbSet<AdminImageMaintenance> AdminImageMaintenances { get; set; }
        public virtual DbSet<AdminLocation> AdminLocations { get; set; }
        public virtual DbSet<AdminOrganization> AdminOrganizations { get; set; }
        public virtual DbSet<AdminOrganizationHoliday> AdminOrganizationHolidays { get; set; }
        public virtual DbSet<AdminSpeciality> AdminSpecialities { get; set; }
        public virtual DbSet<AdminUser> AdminUsers { get; set; }
        public virtual DbSet<Domain.Old.Entities.Agreement> Agreements { get; set; }
        public virtual DbSet<AppointmentSlot> AppointmentSlots { get; set; }
        public virtual DbSet<BannerClickReport> BannerClickReports { get; set; }
        public virtual DbSet<CountryList> CountryLists { get; set; }
        public virtual DbSet<DependentAndOther> DependentAndOthers { get; set; }
        public virtual DbSet<DependentRelation> DependentRelations { get; set; }
        public virtual DbSet<EmployeeTypeMaster> EmployeeTypeMasters { get; set; }
        public virtual DbSet<FdCaption> FdCaptions { get; set; }
        public virtual DbSet<FdForm> FdForms { get; set; }
        public virtual DbSet<FdMainMenu> FdMainMenus { get; set; }
        public virtual DbSet<FdModule> FdModules { get; set; }
        public virtual DbSet<Identifier> Identifiers { get; set; }
        public virtual DbSet<InsuranceCoverage> InsuranceCoverages { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<MarketingMainBanner> MarketingMainBanners { get; set; }
        public virtual DbSet<MessageMaster> MessageMasters { get; set; }
        public virtual DbSet<Mrn> Mrns { get; set; }
        public virtual DbSet<OrganizationInsurancePlan> OrganizationInsurancePlans { get; set; }
        public virtual DbSet<OtpEntry> OtpEntries { get; set; }
        public virtual DbSet<PatientDoctorAppointment> PatientDoctorAppointments { get; set; }
        public virtual DbSet<PatientUser> PatientUsers { get; set; }
        public virtual DbSet<PatientsUser> PatientsUsers { get; set; }
        public virtual DbSet<RdReport> RdReports { get; set; }
        public virtual DbSet<ScheduleException> ScheduleExceptions { get; set; }
        public virtual DbSet<Domain.Old.Entities.User> Users { get; set; }
        public virtual DbSet<UserToken> UserTokens { get; set; }
        public virtual DbSet<AdminLogoImageMaintenance> AdminLogoImageMaintenances { get; set; }
        public virtual DbSet<Logo> Logos { get; set; }
        public virtual DbSet<FloorMap> FloorMap { get; set; }

        #endregion DBSet
        public virtual DbSet<ImageMaintenance> ImageMaintenances { get; set; }
        public virtual DbSet<FrequencyMaster> FrequencyMasters { get; set; }
        public virtual DbSet<InsurancePanelLocation> InsurancePanelLocations { get; set; }
        public virtual DbSet<InsurancePanel> InsurancePanels { get; set; }
        public virtual DbSet<Organization> Organizations { get; set; }
        public virtual DbSet<OrganizationAddress> OrganizationAddresses { get; set; }
        public virtual DbSet<OrganizationContact> OrganizationContacts { get; set; }
        public virtual DbSet<OrganizationTelecom> OrganizationTelecoms { get; set; }

        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<LocationAddress> LocationAddresses { get; set; }
        public virtual DbSet<LocationHoursOfOperation> LocationHoursOfOperations { get; set; }
        public virtual DbSet<LocationIdentifier> LocationIdentifiers { get; set; }
        public virtual DbSet<LocationImage> LocationImages { get; set; }
        public virtual DbSet<LocationTelecom> LocationTelecoms { get; set; }
        public virtual DbSet<LocationType> LocationTypes { get; set; }

        public virtual DbSet<Content> Contents { get; set; }
        public virtual DbSet<Reasons> ContentReasons { get; set; }

        public virtual DbSet<Domain.V1.Entities.Agreement> AgreementNew { get; set; }
        public virtual DbSet<AgreementLanguage> AgreementLanguages { get; set; }
        public virtual DbSet<FAQ> FAQNew { get; set; }
        public virtual DbSet<FAQLanguage> FAQLanguages { get; set; }
        public virtual DbSet<FAQUserTypes> FAQUserTypes { get; set; }

        public virtual DbSet<Banner> Banners { get; set; }
        public virtual DbSet<EducationalQualification> EducationalQualifications { get; set; }
        public virtual DbSet<ExperienceDetails> ExperienceDetail { get; set; }
        public virtual DbSet<Interest> Interests { get; set; }
        public virtual DbSet<ManageDoctorLocation> ManageDoctorLocations { get; set; }
        public virtual DbSet<ManageDoctorProfile> ManageDoctorProfiles { get; set; }
        public virtual DbSet<ManageDoctorSpeciality> ManageDoctorSpecialities { get; set; }
        public virtual DbSet<ManageRank> ManageRanks { get; set; }
        public virtual DbSet<Publications> Publications { get; set; }
        public virtual DbSet<Section> MarketSections { get; set; }
        public virtual DbSet<PractitionerAddresses> PractitionerAddress { get; set; }
        public virtual DbSet<PractitionerCommunication> PractitionerCommunications { get; set; }
        public virtual DbSet<PractitionerIdentifier> PractitionerIdentifiers { get; set; }
        public virtual DbSet<PractitionerLocation> PractitionerLocations { get; set; }
        public virtual DbSet<PractitionerNames> PractitionerName { get; set; }
        public virtual DbSet<PractitionerPhotos> PractitionerPhoto { get; set; }
        public virtual DbSet<PractitionerQualification> PractitionerQualifications { get; set; }
        public virtual DbSet<PractitionerSpeciality> PractitionerSpecialities { get; set; }
        public virtual DbSet<PractitionerTelecom> PractitionerTelecoms { get; set; }
        public virtual DbSet<Practitioner> Practitioners { get; set; }
        public virtual DbSet<PaymentGateway> PaymentGateways { get; set; }
        public virtual DbSet<LanguageV1> LanguageV1 { get; set; }
        public virtual DbSet<PractitionerRoleHealthcareService> PractitionerRoleHealthcareService { get; set; }
        public virtual DbSet<PaymentGatewayConfig> PaymentGatewayConfigs { get; set; }
        public virtual DbSet<ConfiguredEvent> ConfiguredEvents { get; set; }
        public virtual DbSet<NotificationManager> NotificationManagers { get; set; }
        public virtual DbSet<NotificationTemplate> NotificationTemplates { get; set; }
        public virtual DbSet<NotificationTemplateLanguage> NotificationTemplateLanguages { get; set; }
        public virtual DbSet<HealthcareServices> HealthcareServices { get; set; }
        public virtual DbSet<HealthcareServicesKeyWords> HealthcareServicesKeyWords { get; set; }
        public virtual DbSet<HealthcareServicesLocation> HealthcareServicesLocation { get; set; }
        public virtual DbSet<PractitionerAvailability> PractitionerAvailabilities { get; set; }
        public virtual DbSet<PractitionerAvailabilityDay> PractitionerAvailabilityDays { get; set; }
        public virtual DbSet<PractitionerAvailabilityOccurance> PractitionerAvailabilityOccurances { get; set; }
        public virtual DbSet<PractitionerAvailabilityBreak> PractitionerAvailabilityBreaks { get; set; }
        public virtual DbSet<PractitionerNotAvailable> PractitionerNotAvailables { get; set; }
        public virtual DbSet<PractitionerRoleNotAvailable> PractitionerRoleNotAvailables { get; set; }
        public virtual DbSet<PractitionerRole> PractitionerRoles { get; set; }
        public virtual DbSet<PractitionerRoleLocation> PractitionerRoleLocation { get; set; }
        public virtual DbSet<PractitionerRoleAvailableTime> PractitionerRoleAvailableTimes { get; set; }
        public virtual DbSet<PractitionerRoleCode> PractitionerRoleCodes { get; set; }
        public virtual DbSet<PractitionerRoleSpecialty> PractitionerRoleSpecialty { get; set; }
        public virtual DbSet<RoleMaster> RoleMasters { get; set; }
        public virtual DbSet<PractitionerNotification> PractitionerNotifications { get; set; }
        public virtual DbSet<DrugMaster> DrugMasters { get; set; }
        public virtual DbSet<ProcedureChargeMaster> ProcedureChargeMasters { get; set; }
        public virtual DbSet<ServiceChargeMaster> ServiceChargeMasters { get; set; }
        public virtual DbSet<Domain.V1.Entities.Marketings.WhatsHappening> WhatsHappeningsNew { get; set; }
        public virtual DbSet<Domain.V1.Entities.Users.User> UserNew { get; set; }
        public virtual DbSet<UserNames> UserNames { get; set; }
        public virtual DbSet<UserIdentifier> UserIdentifiers { get; set; }
        public virtual DbSet<UserTelecom> UserTelecoms { get; set; }
        public virtual DbSet<ForgetPassword> ForgetPassword { get; set; }
        public virtual DbSet<CountryMaster> CountryMasters { get; set; }
        public virtual DbSet<Domain.V1.Entities.Dependent.Dependent> Dependents { get; set; }
        public virtual DbSet<ManageVisibility> ManageVisibility { get; set; }
        public virtual DbSet<ManageVisibilityUserGroups> ManageVisibilityUserGroups { get; set; } 
        public virtual DbSet<CategoryMaster> CategoryMasters { get; set; }
        public virtual DbSet<ResourceMapping> ResourceMappings { get; set; }
        public virtual DbSet<GroupRoleMapping> GroupRoleMappings { get; set; }
        public virtual DbSet<Domain.V1.Entities.UserGroups.Group> Groups { get; set; }
        public virtual DbSet<DependentResources> DependentResources { get; set; }
        public virtual DbSet<UserProfile> UserProfiles { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<RoleResourceMapping> RoleResourceMappings { get; set; }
        public virtual DbSet<ResourceType> ResourceTypes { get; set; }
        public virtual DbSet<AccessControlMaster> AccessControlMasters { get; set; }
        public virtual DbSet<AccessControlHeader> AccessControlHeaders { get; set; }
        public virtual DbSet<AccessControlParameter> AccessControlParameters { get; set; }

        #region New DBSet

        #endregion
        protected BaseDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected BaseDbContext(DbContextOptions options)
      : base(options)
        {

        }

        protected BaseDbContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected abstract override void OnConfiguring(DbContextOptionsBuilder optionsBuilder);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ApplyEntityConfigurations(modelBuilder);
        }

        /// <summary>
        /// Apply the configuration for entities
        /// </summary>
        /// <param name="modelBuilder"></param>
        private static void ApplyEntityConfigurations(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryMaster>(entity =>
            {
                entity.ToTable("CategoryMaster");

                entity.HasKey(e => e.ID).HasName("PK_CategoryMaster_ID");

                entity.Property(e => e.ID)
                    .ValueGeneratedOnAdd()
                    .HasComment("Unique identifier for each record.");

                entity.Property(e => e.Code)
                    .HasMaxLength(20)
                    .HasComment("The unique code associated with the record.");

                entity.Property(e => e.Definition)
                    .HasMaxLength(200)
                    .HasComment("A detailed definition or description of the record.");

                entity.Property(e => e.RecordVersion)
                    .IsRowVersion()
                    .ValueGeneratedOnAddOrUpdate()
                    .IsConcurrencyToken()
                    .HasComment("Represents the version of the record for concurrency control.");
            });


            modelBuilder.Entity<AdminDoctorLocation>(entity =>
            {
                entity.HasKey(e => e.DoctorLocationId).HasName("PK__Admin_Do__B23B7D2B006F5C30");

                entity.ToTable("Admin_DoctorLocations");

                entity.Property(e => e.DateCreated)
                    .HasDefaultValueSql(GetUtcDate)
                    .HasColumnType("datetime");
                entity.Property(e => e.IsActive).HasDefaultValue(true);
                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");
                entity.Property(e => e.Role).HasMaxLength(100);

                entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.AdminDoctorLocationCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK__Admin_Doc__Creat__76969D2E");

                entity.HasOne(d => d.DoctorProfile).WithMany(p => p.AdminDoctorLocations)
                    .HasForeignKey(d => d.DoctorProfileId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Admin_Doc__Docto__74AE54BC");

                entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.AdminDoctorLocationLastModifiedByNavigations)
                    .HasForeignKey(d => d.LastModifiedBy)
                    .HasConstraintName("FK__Admin_Doc__LastM__778AC167");

                entity.HasOne(d => d.Location).WithMany(p => p.AdminDoctorLocations)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Admin_Doc__Locat__75A278F5");
            });

            modelBuilder.Entity<AdminDoctorProfile>(entity =>
            {
                entity.HasKey(e => e.DoctorProfileId).HasName("PK__Admin_Do__1839404D158731BD");

                entity.ToTable("Admin_DoctorProfiles");

                entity.HasIndex(e => e.Identifier, "UQ__Admin_Do__821FB0192811379F").IsUnique();

                entity.Property(e => e.Active).HasDefaultValue(true);
                entity.Property(e => e.Address).HasMaxLength(255);
                entity.Property(e => e.City).HasMaxLength(100);
                entity.Property(e => e.Country).HasMaxLength(50);
                entity.Property(e => e.DateCreated)
                    .HasDefaultValueSql(GetUtcDate)
                    .HasColumnType("datetime");
                entity.Property(e => e.Email).HasMaxLength(100);
                entity.Property(e => e.FirstName).HasMaxLength(50);
                entity.Property(e => e.Gender).HasMaxLength(20);
                entity.Property(e => e.Identifier).HasMaxLength(50);
                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(500)
                    .HasColumnName("imageURL");
                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");
                entity.Property(e => e.LastName).HasMaxLength(50);
                entity.Property(e => e.MiddleName).HasMaxLength(50);
                entity.Property(e => e.PhoneNumber).HasMaxLength(15);
                entity.Property(e => e.PostalCode).HasMaxLength(20);
                entity.Property(e => e.State).HasMaxLength(50);

                entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.AdminDoctorProfileCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK__Admin_Doc__Creat__628FA481");

                entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.AdminDoctorProfileLastModifiedByNavigations)
                    .HasForeignKey(d => d.LastModifiedBy)
                    .HasConstraintName("FK__Admin_Doc__LastM__6383C8BA");

                entity.HasOne(d => d.Organization).WithMany(p => p.AdminDoctorProfiles)
                    .HasForeignKey(d => d.OrganizationId)
                    .HasConstraintName("FK__Admin_Doc__Organ__619B8048");
            });

            modelBuilder.Entity<AdminDoctorSchedule>(entity =>
            {
                entity.HasKey(e => e.ScheduleId).HasName("PK__Admin_Do__9C8A5B49C49636A1");

                entity.ToTable("Admin_DoctorSchedule");

                entity.Property(e => e.Active).HasDefaultValue(true);
                entity.Property(e => e.Actor).HasMaxLength(255);
                entity.Property(e => e.Comment).HasMaxLength(1024);
                entity.Property(e => e.CreatedAt).HasDefaultValueSql(GetUtcDate);
                entity.Property(e => e.Identifier).HasMaxLength(255);
                entity.Property(e => e.ServiceCategory).HasMaxLength(255);
                entity.Property(e => e.ServiceType).HasMaxLength(255);
                entity.Property(e => e.Specialty).HasMaxLength(255);
                entity.Property(e => e.UpdatedAt).HasDefaultValueSql(GetUtcDate);

                entity.HasOne(d => d.DoctorProfile).WithMany(p => p.AdminDoctorSchedules)
                    .HasForeignKey(d => d.DoctorProfileId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Admin_Doc__Docto__634EBE90");
            });

            modelBuilder.Entity<AdminDoctorSpeciality>(entity =>
            {
                entity.HasKey(e => e.DoctorSpecialityId).HasName("PK__Admin_Do__CACF440AE8F51875");

                entity.ToTable("Admin_DoctorSpecialities");

                entity.Property(e => e.DateCreated)
                    .HasDefaultValueSql(GetUtcDate)
                    .HasColumnType("datetime");
                entity.Property(e => e.IsActive).HasDefaultValue(true);
                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");
                entity.Property(e => e.Speciality).HasMaxLength(100);

                entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.AdminDoctorSpecialityCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK__Admin_Doc__Creat__693CA210");

                entity.HasOne(d => d.DoctorProfile).WithMany(p => p.AdminDoctorSpecialities)
                    .HasForeignKey(d => d.DoctorProfileId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Admin_Doc__Docto__68487DD7");

                entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.AdminDoctorSpecialityLastModifiedByNavigations)
                    .HasForeignKey(d => d.LastModifiedBy)
                    .HasConstraintName("FK__Admin_Doc__LastM__6A30C649");
            });

            modelBuilder.Entity<AdminFaq>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Admin_FA__3214EC27465A3BC6");

                entity.ToTable("Admin_FAQ");

                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql(GetUtcDate)
                    .HasColumnType("datetime");
                entity.Property(e => e.Header).HasMaxLength(255);
                entity.Property(e => e.IsActive).HasDefaultValue(true);
                entity.Property(e => e.Platforms).HasMaxLength(255);
                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
                entity.Property(e => e.Users).HasMaxLength(255);

                entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.AdminFaqCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK__Admin_Admin_FAQ__CreatedBy__5AEE82B9");

                entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.AdminFaqUpdatedByNavigations)
                    .HasForeignKey(d => d.UpdatedBy)
                    .HasConstraintName("FK__Admin_Admin_FAQ__UpdatedBy__5BE2A6F2");
            });

            modelBuilder.Entity<AdminImageMaintenance>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Admin_Im__3214EC079DB013C1");

                entity.ToTable("Admin_ImageMaintenance");

                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql(GetUtcDate)
                    .HasColumnType("datetime");
                entity.Property(e => e.Description).HasMaxLength(255);
                entity.Property(e => e.ImageName).HasMaxLength(100);
                entity.Property(e => e.ImageType).HasMaxLength(50);
                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(2083)
                    .HasColumnName("ImageURL");
                entity.Property(e => e.IsActive).HasDefaultValue(true);
                entity.Property(e => e.ScreenType).HasMaxLength(100);
                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.AdminImageMaintenanceCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Admin_Admin_ImageMaintenance__CreatedBy__5AEE82B9");

                entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.AdminImageMaintenanceUpdatedByNavigations)
                    .HasForeignKey(d => d.UpdatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Admin_Admin_ImageMaintenance__UpdatedBy__5BE2A6F2");
            });
            modelBuilder.Entity<AdminLocation>(entity =>
            {
                entity.HasKey(e => e.LocationId).HasName("PK__Admin_Lo__E7FEA4977E6C078B");

                entity.ToTable("Admin_Locations");

                entity.Property(e => e.Active).HasDefaultValue(true);
                entity.Property(e => e.Address).HasMaxLength(255);
                entity.Property(e => e.AddressLine1).HasMaxLength(100);
                entity.Property(e => e.AddressLine2).HasMaxLength(100);
                entity.Property(e => e.City).HasMaxLength(100);
                entity.Property(e => e.Country).HasMaxLength(50);
                entity.Property(e => e.CreatedAt).HasDefaultValueSql(GetUtcDate);
                entity.Property(e => e.DateCreated)
                    .HasDefaultValueSql(GetUtcDate)
                    .HasColumnType("datetime");
                entity.Property(e => e.Identifier).HasMaxLength(50);
                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");
                entity.Property(e => e.LocationType).HasMaxLength(50);
                entity.Property(e => e.Mode).HasMaxLength(20);
                entity.Property(e => e.Name).HasMaxLength(100);
                entity.Property(e => e.PhoneNumber).HasMaxLength(15);
                entity.Property(e => e.PhysicalType).HasMaxLength(50);
                entity.Property(e => e.PostalCode).HasMaxLength(20);
                entity.Property(e => e.State).HasMaxLength(50);
                entity.Property(e => e.Status).HasMaxLength(20);
                entity.Property(e => e.UpdatedAt).HasDefaultValueSql(GetUtcDate);

                entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.AdminLocationCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK__Admin_Loc__Creat__6EF57B66");

                entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.AdminLocationLastModifiedByNavigations)
                    .HasForeignKey(d => d.LastModifiedBy)
                    .HasConstraintName("FK__Admin_Loc__LastM__6FE99F9F");

                entity.HasOne(d => d.PartOfLocation).WithMany(p => p.InversePartOfLocation)
                    .HasForeignKey(d => d.PartOfLocationId)
                    .HasConstraintName("FK_Admin_Locations_PartOfLocationId");
            });

            modelBuilder.Entity<AdminOrganization>(entity =>
            {
                entity.HasKey(e => e.OrganizationId).HasName("PK__Admin_Or__CADB0B12E6A14400");

                entity.ToTable("Admin_Organizations");

                entity.Property(e => e.Active).HasDefaultValue(true);
                entity.Property(e => e.Address).HasMaxLength(255);
                entity.Property(e => e.City).HasMaxLength(100);
                entity.Property(e => e.Country).HasMaxLength(50);
                entity.Property(e => e.DateCreated)
                    .HasDefaultValueSql(GetUtcDate)
                    .HasColumnType("datetime");
                entity.Property(e => e.Email).HasMaxLength(100);
                entity.Property(e => e.ImageUrl).HasMaxLength(2000);
                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");
                entity.Property(e => e.Name).HasMaxLength(100);
                entity.Property(e => e.PhoneNumber).HasMaxLength(15);
                entity.Property(e => e.PostalCode).HasMaxLength(20);
                entity.Property(e => e.State).HasMaxLength(50);
                entity.Property(e => e.Type).HasMaxLength(50);
                entity.Property(e => e.WebsiteUrl).HasMaxLength(2000);

                entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.AdminOrganizationCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK__Admin_Org__Creat__5AEE82B9");

                entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.AdminOrganizationLastModifiedByNavigations)
                    .HasForeignKey(d => d.LastModifiedBy)
                    .HasConstraintName("FK__Admin_Org__LastM__5BE2A6F2");
            });

            modelBuilder.Entity<AdminOrganizationHoliday>(entity =>
            {
                entity.HasKey(e => e.HolidayScheduleId).HasName("PK__Admin_Or__210B742025BB60DE");

                entity.ToTable("Admin_OrganizationHolidays");

                entity.Property(e => e.Comment).HasMaxLength(500);
                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql(GetUtcDate)
                    .HasColumnType("datetime");
                entity.Property(e => e.HolidayName).HasMaxLength(255);
                entity.Property(e => e.HolidayType).HasMaxLength(100);
                entity.Property(e => e.UpdatedAt)
                    .HasDefaultValueSql(GetUtcDate)
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Organization).WithMany(p => p.AdminOrganizationHolidays)
                    .HasForeignKey(d => d.OrganizationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Organization");
            });

            modelBuilder.Entity<AdminSpeciality>(entity =>
            {
                entity.HasKey(e => e.SpecialityId).HasName("PK__Admin_Sp__67ED609B69609634");

                entity.ToTable("Admin_Specialities");

                entity.Property(e => e.Code).HasMaxLength(50);
                entity.Property(e => e.DateCreated)
                    .HasDefaultValueSql(GetUtcDate)
                    .HasColumnType("datetime");
                entity.Property(e => e.Description).HasMaxLength(255);
                entity.Property(e => e.DisplayName).HasMaxLength(100);
                entity.Property(e => e.IsActive).HasDefaultValue(true);
                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.AdminSpecialityCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK__Admin_Spe__Creat__0E6E26BF");

                entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.AdminSpecialityLastModifiedByNavigations)
                    .HasForeignKey(d => d.LastModifiedBy)
                    .HasConstraintName("FK__Admin_Spe__LastM__0F624AF8");
            });

            modelBuilder.Entity<AdminUser>(entity =>
            {
                entity.HasKey(e => e.AdminId).HasName("PK__Admin_Us__719FE488B6140466");

                entity.ToTable("Admin_Users");

                entity.HasIndex(e => e.Username, "UQ__Admin_Us__536C85E486F3250C").IsUnique();

                entity.HasIndex(e => e.Email, "UQ__Admin_Us__A9D10534D8756BB1").IsUnique();

                entity.Property(e => e.Active).HasDefaultValue(true);
                entity.Property(e => e.DateCreated)
                    .HasDefaultValueSql(GetUtcDate)
                    .HasColumnType("datetime");
                entity.Property(e => e.Email).HasMaxLength(100);
                entity.Property(e => e.FirstName).HasMaxLength(50);
                entity.Property(e => e.LastLogin).HasColumnType("datetime");
                entity.Property(e => e.LastLoginFailedTime).HasColumnType("datetime");
                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");
                entity.Property(e => e.LastName).HasMaxLength(50);
                entity.Property(e => e.Password).HasMaxLength(100);
                entity.Property(e => e.PhoneNumber).HasMaxLength(15);
                entity.Property(e => e.Role).HasMaxLength(50);
                entity.Property(e => e.Username).HasMaxLength(50);

                entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.InverseCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK__Admin_Use__Creat__5535A963");

                entity.HasOne(d => d.LastModifiedByNavigation).WithMany(p => p.InverseLastModifiedByNavigation)
                    .HasForeignKey(d => d.LastModifiedBy)
                    .HasConstraintName("FK__Admin_Use__LastM__5629CD9C");
            });

            modelBuilder.Entity<Domain.Old.Entities.Agreement>(entity =>
            {
                entity.ToTable("Agreement");

                entity.Property(e => e.AgreementUniqueId).HasMaxLength(50);
                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql(GetUtcDate)
                    .HasColumnType("datetime");
                entity.Property(e => e.Frequency).HasMaxLength(50);
                entity.Property(e => e.IsActive).HasDefaultValue(true);
                entity.Property(e => e.Language).HasMaxLength(50);
                entity.Property(e => e.Name).HasMaxLength(100);
                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.AgreementCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK__Admin_Agreement__CreatedBy__5AEE82B9");

                entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.AgreementUpdatedByNavigations)
                    .HasForeignKey(d => d.UpdatedBy)
                    .HasConstraintName("FK__Admin_Agreement__UpdatedBy__5BE2A6F2");
            });



            modelBuilder.Entity<AppointmentSlot>(entity =>
            {
                entity.HasKey(e => e.SlotId).HasName("PK__Appointm__0A124AAFB18E6454");

                entity.ToTable("AppointmentSlot");

                entity.Property(e => e.Period)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entity.Property(e => e.ServiceCategory)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.ServiceType)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.SlotEnd).HasColumnType("datetime");
                entity.Property(e => e.SlotStart).HasColumnType("datetime");
                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.DoctorSpeciality).WithMany(p => p.AppointmentSlots)
                    .HasForeignKey(d => d.DoctorSpecialityId)
                    .HasConstraintName("FK__Appointme__Docto__3493CFA7");
            });

            modelBuilder.Entity<BannerClickReport>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__BannerCl__D06F930596485F73");

                entity.ToTable("BannerClickReport");

                entity.Property(e => e.BannerId).HasColumnName("BannerID");
                entity.Property(e => e.CreatedBy).HasMaxLength(255);
                entity.Property(e => e.DateCreated)
                    .HasDefaultValueSql(GetUtcDate)
                    .HasColumnType("datetime");
                entity.Property(e => e.LastModifiedBy).HasMaxLength(255);
                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");
                entity.Property(e => e.PatientId).HasColumnName("PatientID");
            });

            modelBuilder.Entity<CountryList>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__CountryL__3214EC078F28D2A8");

                entity.ToTable("CountryList");

                entity.Property(e => e.CountryCode).HasMaxLength(10);
                entity.Property(e => e.CountryName).HasMaxLength(100);
                entity.Property(e => e.ImageUrl).HasMaxLength(500);
                entity.Property(e => e.Nationality).HasMaxLength(100);
            });

            modelBuilder.Entity<DependentAndOther>(entity =>
            {
                entity.HasKey(e => e.DependentId).HasName("PK__Dependen__9BC67C1177149B33");

                entity.ToTable("DependentAndOther");

                entity.Property(e => e.DependentId).HasColumnName("DependentID");
                entity.Property(e => e.ContactNumber).HasMaxLength(50);
                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql(GetUtcDate)
                    .HasColumnType("datetime");
                entity.Property(e => e.CreatedBy).HasMaxLength(50);
                entity.Property(e => e.PatientId)
                    .HasMaxLength(50)
                    .HasColumnName("PatientID");
                entity.Property(e => e.RelationId)
                    .HasMaxLength(50)
                    .HasColumnName("RelationID");
                entity.Property(e => e.RelationshipCode).HasMaxLength(50);
                entity.Property(e => e.UpdatedAt)
                    .HasDefaultValueSql(GetUtcDate)
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Patient).WithMany(p => p.DependentAndOtherPatients)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DependentAndOther_PatientUser");

                entity.HasOne(d => d.Relation).WithMany(p => p.DependentAndOtherRelations)
                    .HasForeignKey(d => d.RelationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DependentAndOther_RelationUser");
            });

            modelBuilder.Entity<DependentRelation>(entity =>
            {
                entity.HasKey(e => e.DependentId).HasName("PK__Dependen__9BC67CF1CB15AAA9");

                entity.ToTable("Dependent_Relation");

                entity.Property(e => e.ContactNumber).HasMaxLength(50);
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");
                entity.Property(e => e.CreatedBy).HasMaxLength(50);
                entity.Property(e => e.PatientId).HasMaxLength(50);
                entity.Property(e => e.RelationshipCode).HasMaxLength(50);
                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
                entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            });

            modelBuilder.Entity<EmployeeTypeMaster>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_EmployeeTypeMaster_ID");

                entity.ToTable("EmployeeTypeMaster");

                entity.HasIndex(e => e.EmployeeTypeCode, "UK_EmployeeTypeMaster_EmployeeTypeCode").IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.CreatedBy).HasMaxLength(50);
                entity.Property(e => e.EmployeeTypeCode).HasMaxLength(20);
                entity.Property(e => e.EmployeeTypeName).HasMaxLength(300);
                entity.Property(e => e.FacilityCode).HasMaxLength(20);
                entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            });

            modelBuilder.Entity<FdCaption>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_FD_Caption_ID");

                entity.ToTable("FD_Caption");

                entity.HasIndex(e => e.EnUs, "UK_FD_Caption_en_US")
                    .IsUnique()
                    .HasFilter("([en-US] IS NOT NULL)");

                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.CreatedBy).HasMaxLength(50);
                entity.Property(e => e.EnUs)
                    .HasMaxLength(300)
                    .HasColumnName("en-US");
                entity.Property(e => e.FacilityCode).HasMaxLength(20);
                entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            });

            modelBuilder.Entity<FdForm>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_FD_Forms_ID");

                entity.ToTable("FD_Forms");

                entity.HasIndex(e => e.CaptionId, "IX_FD_Forms_CaptionID");

                entity.HasIndex(e => e.ModuleId, "IX_FD_Forms_ModuleID");

                entity.HasIndex(e => e.FormName, "UK_FD_Forms_FormName")
                    .IsUnique()
                    .HasFilter("([FormName] IS NOT NULL)");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");
                entity.Property(e => e.CaptionId).HasColumnName("CaptionID");
                entity.Property(e => e.FacilityCode).HasMaxLength(20);
                entity.Property(e => e.FdxFileName).HasMaxLength(100);
                entity.Property(e => e.FormName).HasMaxLength(300);
                entity.Property(e => e.ModuleId).HasColumnName("ModuleID");

                entity.HasOne(d => d.Caption).WithMany(p => p.FdForms)
                    .HasForeignKey(d => d.CaptionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FD_Forms_CaptionID_FD_Caption_ID");

                entity.HasOne(d => d.Module).WithMany(p => p.FdForms)
                    .HasForeignKey(d => d.ModuleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FD_Forms_ModuleID_FD_Module_ID");
            });

            modelBuilder.Entity<FdMainMenu>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_FD_MainMenus_ID");

                entity.ToTable("FD_MainMenus");

                entity.HasIndex(e => e.CaptionId, "IX_FD_MainMenus_CaptionID");

                entity.HasIndex(e => e.InvokeId, "IX_FD_MainMenus_InvokeID");

                entity.HasIndex(e => e.ParentId, "IX_FD_MainMenus_ParentID");

                entity.HasIndex(e => e.ToolTipId, "IX_FD_MainMenus_ToolTipID");

                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.CaptionId).HasColumnName("CaptionID");
                entity.Property(e => e.FacilityCode).HasMaxLength(20);
                entity.Property(e => e.IconId).HasColumnName("IconID");
                entity.Property(e => e.InvokeId).HasColumnName("InvokeID");
                entity.Property(e => e.IsEmrd).HasColumnName("IsEMRD");
                entity.Property(e => e.MenuDescription).HasMaxLength(500);
                entity.Property(e => e.MenuIconFileName).HasMaxLength(300);
                entity.Property(e => e.MenuIconPath).HasMaxLength(300);
                entity.Property(e => e.MenuName).HasMaxLength(300);
                entity.Property(e => e.ParentId).HasColumnName("ParentID");
                entity.Property(e => e.ShortcutKeys).HasMaxLength(50);
                entity.Property(e => e.ToolTipId).HasColumnName("ToolTipID");

                entity.HasOne(d => d.Caption).WithMany(p => p.FdMainMenus)
                    .HasForeignKey(d => d.CaptionId)
                    .HasConstraintName("FK_FD_MainMenus_CaptionID_FD_Caption_ID");

                entity.HasOne(d => d.Invoke).WithMany(p => p.FdMainMenus)
                    .HasForeignKey(d => d.InvokeId)
                    .HasConstraintName("FK_FD_MainMenus_InvokeID_FD_Forms_ID");

                entity.HasOne(d => d.InvokeNavigation).WithMany(p => p.FdMainMenus)
                    .HasForeignKey(d => d.InvokeId)
                    .HasConstraintName("FK_FD_MainMenus_InvokeID_RD_Report_ID");

                entity.HasOne(d => d.Parent).WithMany(p => p.InverseParent)
                    .HasForeignKey(d => d.ParentId)
                    .HasConstraintName("FK_FD_MainMenus_ParentID_FD_MainMenus_ID");

                entity.HasOne(d => d.ToolTip).WithMany(p => p.FdMainMenus)
                    .HasForeignKey(d => d.ToolTipId)
                    .HasConstraintName("FK_FD_MainMenus_ToolTipID_MessageMaster_ID");
            });

            modelBuilder.Entity<FdModule>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_FD_Module_ID");

                entity.ToTable("FD_Module");

                entity.HasIndex(e => e.CaptionId, "IX_FD_Module_CaptionID");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");
                entity.Property(e => e.CaptionId).HasColumnName("CaptionID");
                entity.Property(e => e.FacilityCode).HasMaxLength(20);
                entity.Property(e => e.MainMenuId).HasColumnName("MainMenuID");
                entity.Property(e => e.ModuleName).HasMaxLength(100);

                entity.HasOne(d => d.Caption).WithMany(p => p.FdModules)
                    .HasForeignKey(d => d.CaptionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FD_Module_CaptionID_FD_Caption_ID");
            });

            modelBuilder.Entity<Identifier>(entity =>
            {
                entity.HasKey(e => e.IdentifierId).HasName("PK__Identifi__5EB5E676827ADBED");

                entity.ToTable("Identifier");

                entity.HasIndex(e => e.IdentifierValue, "UQ__Identifi__86D95C4392DCBDB6").IsUnique();

                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql(GetUtcDate)
                    .HasColumnType("datetime");
                entity.Property(e => e.IdentifierType).HasMaxLength(50);
                entity.Property(e => e.IdentifierValue).HasMaxLength(20);
                entity.Property(e => e.IsActive).HasDefaultValue(true);
                entity.Property(e => e.PatientId).HasMaxLength(50);
                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.HasOne(d => d.Patient).WithMany(p => p.Identifiers)
                    .HasForeignKey(d => d.PatientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Identifie__Patie__5DEAEAF5");
            });

            modelBuilder.Entity<InsuranceCoverage>(entity =>
            {
                entity.HasKey(e => e.CoverageId).HasName("PK__Insuranc__45403DBB721D9CFB");

                entity.ToTable("InsuranceCoverage");

                entity.Property(e => e.ClassType)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.ClassValue)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.DateCreated)
                    .HasDefaultValueSql(GetUtcDate)
                    .HasColumnType("datetime");
                entity.Property(e => e.LastModifiedDate)
                    .HasDefaultValueSql(GetUtcDate)
                    .HasColumnType("datetime");
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Network)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.PeriodEndDate).HasColumnType("datetime");
                entity.Property(e => e.PeriodStartDate).HasColumnType("datetime");
                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.SubscriberRelationship)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Type)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.HasKey(e => e.LanguageId).HasName("PK__Language__B93855AB97FEF5A7");

                entity.Property(e => e.LanguageCode).HasMaxLength(2);
                entity.Property(e => e.LanguageName).HasMaxLength(100);
                entity.Property(e => e.Region).HasMaxLength(100);

                entity.HasOne(d => d.DoctorProfile).WithMany(p => p.Languages)
                    .HasForeignKey(d => d.DoctorProfileId)
                    .HasConstraintName("FK_Languages_DoctorId");
            });

            modelBuilder.Entity<MarketingMainBanner>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Marketin__A14FE2E4D7441D2B");

                entity.ToTable("MarketingMainBanner");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");
                entity.Property(e => e.EndDate).HasColumnType("datetime");
                entity.Property(e => e.ImageUrl).HasMaxLength(2000);
                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");
                entity.Property(e => e.StartDate).HasColumnType("datetime");
                entity.Property(e => e.Title).HasMaxLength(800);
                entity.Property(e => e.Url).HasMaxLength(1000);
            });

            modelBuilder.Entity<MessageMaster>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_MessageMaster_ID");

                entity.ToTable("MessageMaster");

                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.CreatedBy).HasMaxLength(50);
                entity.Property(e => e.DefaultMessage).HasMaxLength(300);
                entity.Property(e => e.Description).HasMaxLength(250);
                entity.Property(e => e.EnUs)
                    .HasMaxLength(300)
                    .HasColumnName("en-US");
                entity.Property(e => e.FacilityCode).HasMaxLength(20);
                entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            });

            modelBuilder.Entity<Mrn>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__MRN__3214EC07CCC47BDE");

                entity.ToTable("MRN");

                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql(GetUtcDate)
                    .HasColumnType("datetime");
                entity.Property(e => e.CreatedBy).HasMaxLength(100);
                entity.Property(e => e.HospitalName).HasMaxLength(255);
                entity.Property(e => e.IsActive).HasDefaultValue(true);
                entity.Property(e => e.Mrnnumber)
                    .HasMaxLength(50)
                    .HasColumnName("MRNNumber");
                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
                entity.Property(e => e.UpdatedBy).HasMaxLength(100);
                entity.Property(e => e.UserId).HasMaxLength(50);

                entity.HasOne(d => d.Hospital).WithMany(p => p.Mrns)
                    .HasForeignKey(d => d.HospitalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MRN_Organization");

                entity.HasOne(d => d.User).WithMany(p => p.Mrns)
                    .HasPrincipalKey(p => p.UserId)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MRN_User");
            });

            modelBuilder.Entity<OrganizationInsurancePlan>(entity =>
            {
                entity.HasKey(e => e.OrganizationInsurancePlanId).HasName("PK__Organiza__507C2082767C27AB");

                entity.ToTable("OrganizationInsurancePlan");

                entity.Property(e => e.CoverageArea).HasMaxLength(255);
                entity.Property(e => e.Network).HasMaxLength(255);
                entity.Property(e => e.Status).HasMaxLength(50);

                entity.HasOne(d => d.InsurancePlan).WithMany(p => p.OrganizationInsurancePlans)
                    .HasForeignKey(d => d.InsurancePlanId)
                    .HasConstraintName("FK__Organizat__Insur__17C286CF");

                entity.HasOne(d => d.Organization).WithMany(p => p.OrganizationInsurancePlans)
                    .HasForeignKey(d => d.OrganizationId)
                    .HasConstraintName("FK__Organizat__Organ__16CE6296");
            });

            modelBuilder.Entity<OtpEntry>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__OtpEntry__3214EC0702CF1C1C");

                entity.ToTable("OtpEntry");

                entity.Property(e => e.CreatedBy).HasColumnType("datetime");
                entity.Property(e => e.DateUsed).HasColumnType("datetime");
                entity.Property(e => e.ExpiryTime).HasColumnType("datetime");
                entity.Property(e => e.IdentificationNo).HasMaxLength(50);
                entity.Property(e => e.IsUsed).HasDefaultValue(false);
                entity.Property(e => e.LastFailedTime).HasColumnType("datetime");
                entity.Property(e => e.Otp).HasMaxLength(10);
                entity.Property(e => e.RetryAttempts).HasDefaultValue(0);
                entity.Property(e => e.UpdatedBy).HasColumnType("datetime");
                entity.Property(e => e.UserId).HasMaxLength(50);
            });

            modelBuilder.Entity<PatientDoctorAppointment>(entity =>
            {
                entity.HasKey(e => e.AppointmentId).HasName("PK__Patient___8ECDFCC2B929B886");

                entity.ToTable("Patient_DoctorAppointments");

                entity.Property(e => e.CheckInTime).HasColumnType("datetime");
                entity.Property(e => e.DateCreated).HasColumnType("datetime");
                entity.Property(e => e.Description).HasMaxLength(255);
                entity.Property(e => e.EndDateTime).HasColumnType("datetime");
                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");
                entity.Property(e => e.Notes).HasMaxLength(1000);
                entity.Property(e => e.PatientId).HasMaxLength(50);
                entity.Property(e => e.PaymentMethod).HasMaxLength(255);
                entity.Property(e => e.ReasonCode).HasMaxLength(100);
                entity.Property(e => e.SlotId).HasColumnName("SlotId ");
                entity.Property(e => e.SlotType).HasMaxLength(50);
                entity.Property(e => e.StartDateTime).HasColumnType("datetime");
                entity.Property(e => e.Status).HasMaxLength(50);
                entity.Property(e => e.VisitType).HasMaxLength(50);

                entity.HasOne(d => d.AppointmentLocation).WithMany(p => p.PatientDoctorAppointments)
                    .HasForeignKey(d => d.AppointmentLocationId)
                    .HasConstraintName("FK_Patient_DoctorAppointments_Admin_Locations");

                entity.HasOne(d => d.DoctorProfile).WithMany(p => p.PatientDoctorAppointments)
                    .HasForeignKey(d => d.DoctorProfileId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Patient_D__Docto__1B29035F");

                entity.HasOne(d => d.Patient).WithMany(p => p.PatientDoctorAppointments)
                    .HasPrincipalKey(p => p.UserId)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK_PatientID_UserID");

                entity.HasOne(d => d.Slot).WithMany(p => p.PatientDoctorAppointments)
                    .HasForeignKey(d => d.SlotId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Patient_D__SlotI__1C1D2798");
            });

            modelBuilder.Entity<PatientUser>(entity =>
            {
                entity.HasKey(e => e.PatientId).HasName("PK__Patient___970EC366A080C7AA");

                entity.ToTable("Patient_User");

                entity.HasIndex(e => e.IdentifierIc, "UQ__Patient___F99678620064A01C").IsUnique();

                entity.Property(e => e.PatientId).HasMaxLength(50);
                entity.Property(e => e.Active).HasDefaultValue(true);
                entity.Property(e => e.Address).HasMaxLength(255);
                entity.Property(e => e.BirthPlace).HasMaxLength(100);
                entity.Property(e => e.City).HasMaxLength(100);
                entity.Property(e => e.Country).HasMaxLength(100);
                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql(GetUtcDate)
                    .HasColumnType("datetime");
                entity.Property(e => e.CreatedBy).HasMaxLength(50);
                entity.Property(e => e.Email).HasMaxLength(100);
                entity.Property(e => e.Ethnicity).HasMaxLength(50);
                entity.Property(e => e.FirstName).HasMaxLength(100);
                entity.Property(e => e.Gender).HasMaxLength(10);
                entity.Property(e => e.Id)
                    .HasMaxLength(50)
                    .HasColumnName("ID");
                entity.Property(e => e.IdentifierIc)
                    .HasMaxLength(20)
                    .HasColumnName("Identifier_IC");
                entity.Property(e => e.IdentifierMrn)
                    .HasMaxLength(20)
                    .HasColumnName("Identifier_MRN");
                entity.Property(e => e.IdentifierPassport)
                    .HasMaxLength(20)
                    .HasColumnName("Identifier_Passport");
                entity.Property(e => e.ImageUrl).HasMaxLength(200);
                entity.Property(e => e.Language).HasMaxLength(50);
                entity.Property(e => e.LastName).HasMaxLength(100);
                entity.Property(e => e.MaritalStatus).HasMaxLength(50);
                entity.Property(e => e.MiddleName).HasMaxLength(100);
                entity.Property(e => e.Name).HasMaxLength(100);
                entity.Property(e => e.Nationality).HasMaxLength(50);
                entity.Property(e => e.PassportIssuedCountry).HasMaxLength(100);
                entity.Property(e => e.PassportNumber).HasMaxLength(50);
                entity.Property(e => e.Password).HasMaxLength(100);
                entity.Property(e => e.PhoneNumber).HasMaxLength(15);
                entity.Property(e => e.PostalCode).HasMaxLength(20);
                entity.Property(e => e.PreferredName).HasMaxLength(20);
                entity.Property(e => e.Religion).HasMaxLength(50);
                entity.Property(e => e.Salutation).HasMaxLength(10);
                entity.Property(e => e.State).HasMaxLength(100);
                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
                entity.Property(e => e.UpdatedBy).HasMaxLength(50);
                entity.Property(e => e.Username).HasMaxLength(50);
            });

            modelBuilder.Entity<PatientsUser>(entity =>
            {
                entity.HasKey(e => e.PatientId).HasName("PK__Patients__970EC36604F74760");

                entity.ToTable("Patients_Users");

                entity.Property(e => e.Address).HasMaxLength(255);
                entity.Property(e => e.City).HasMaxLength(100);
                entity.Property(e => e.Country).HasMaxLength(100);
                entity.Property(e => e.CreatedAt).HasColumnType("datetime");
                entity.Property(e => e.CreatedBy).HasMaxLength(50);
                entity.Property(e => e.Email).HasMaxLength(100);
                entity.Property(e => e.Gender).HasMaxLength(10);
                entity.Property(e => e.ImageUrl).HasMaxLength(200);
                entity.Property(e => e.MaritalStatus).HasMaxLength(50);
                entity.Property(e => e.Name).HasMaxLength(100);
                entity.Property(e => e.Nationality).HasMaxLength(50);
                entity.Property(e => e.PhoneNumber).HasMaxLength(15);
                entity.Property(e => e.PostalCode).HasMaxLength(20);
                entity.Property(e => e.PreferredName).HasMaxLength(20);
                entity.Property(e => e.State).HasMaxLength(100);
                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
                entity.Property(e => e.UpdatedBy).HasMaxLength(50);
            });

            modelBuilder.Entity<RdReport>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_RD_Report_ID");

                entity.ToTable("RD_Report");

                entity.HasIndex(e => e.CaptionId, "IX_RD_Report_CaptionID");

                entity.HasIndex(e => e.ReportName, "UK_RD_Report_ReportName").IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.CaptionId).HasColumnName("CaptionID");
                entity.Property(e => e.CreatedBy).HasMaxLength(50);
                entity.Property(e => e.FacilityCode).HasMaxLength(20);
                entity.Property(e => e.FormId).HasColumnName("FormID");
                entity.Property(e => e.Rdlfile)
                    .HasColumnType("xml")
                    .HasColumnName("RDLFile");
                entity.Property(e => e.ReportModuleId).HasColumnName("ReportModuleID");
                entity.Property(e => e.ReportName).HasMaxLength(100);
                entity.Property(e => e.UpdatedBy).HasMaxLength(50);

                entity.HasOne(d => d.Caption).WithMany(p => p.RdReports)
                    .HasForeignKey(d => d.CaptionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RD_Report_CaptionID_FD_Caption_ID");
            });

            modelBuilder.Entity<ScheduleException>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Schedule__3214EC0725FE8F47");

                entity.ToTable("ScheduleException");

                entity.Property(e => e.DateCreated)
                    .HasDefaultValueSql(GetUtcDate)
                    .HasColumnType("datetime");
                entity.Property(e => e.EndDateTime).HasColumnType("datetime");
                entity.Property(e => e.ExceptionType).HasMaxLength(50);
                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");
                entity.Property(e => e.ReasonCode).HasMaxLength(50);
                entity.Property(e => e.StartDateTime).HasColumnType("datetime");
                entity.Property(e => e.Status).HasMaxLength(20);

                entity.HasOne(d => d.Schedule).WithMany(p => p.ScheduleExceptions)
                    .HasForeignKey(d => d.ScheduleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ScheduleException_Schedule");
            });

            modelBuilder.Entity<Domain.Old.Entities.User>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Users__1788CC4C3405AFD1");

                entity.HasIndex(e => e.UserId, "UQ_User_UserId").IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.BirthOfDate).HasColumnType("datetime");
                entity.Property(e => e.CmndPassportNumberBirthCertificate)
                    .HasMaxLength(100)
                    .HasColumnName("CMND_PassportNumber_BirthCertificate");
                entity.Property(e => e.Country).HasMaxLength(10);
                entity.Property(e => e.Email).HasMaxLength(40);
                entity.Property(e => e.Gender).HasMaxLength(3);
                entity.Property(e => e.LastLoginFailedTime).HasColumnType("datetime");
                entity.Property(e => e.MyKadMyKidMyPr)
                    .HasMaxLength(100)
                    .HasColumnName("MyKad_MyKid_MyPR");
                entity.Property(e => e.Name).HasMaxLength(50);
                entity.Property(e => e.Nationality)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.NomorKtpNomorPassporNomorSimNomorSuratLahir)
                    .HasMaxLength(100)
                    .HasColumnName("NomorKTP_NomorPasspor_NomorSIM_NomorSuratLahir");
                entity.Property(e => e.Passcode).HasMaxLength(100);
                entity.Property(e => e.PassportExpiryDate).HasColumnType("datetime");
                entity.Property(e => e.PassportIssueCountry)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.PassportNumber).HasMaxLength(100);
                entity.Property(e => e.PhoneNumber).HasMaxLength(12);
                entity.Property(e => e.PreferredName).HasMaxLength(50);
                entity.Property(e => e.ProfileImage).HasMaxLength(100);
                entity.Property(e => e.RegistrationDate)
                    .HasDefaultValueSql(GetUtcDate)
                    .HasColumnType("datetime");
                entity.Property(e => e.SosbuttonEnabled).HasColumnName("SOSButtonEnabled");
                entity.Property(e => e.UserId).HasMaxLength(50);
            });

            modelBuilder.Entity<UserToken>(entity =>
            {
                entity.HasKey(e => e.TokenId).HasName("PK__UserToke__658FEEEA1F5EA351");

                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql(GetUtcDate)
                    .HasColumnType("datetime");
                entity.Property(e => e.ExpiresAt).HasColumnType("datetime");
                entity.Property(e => e.IsRevoked).HasDefaultValue(false);
                entity.Property(e => e.IssuedAt).HasColumnType("datetime");
                entity.Property(e => e.ModifiedAt)
                    .HasDefaultValueSql(GetUtcDate)
                    .HasColumnType("datetime");
                entity.Property(e => e.RevokedAt).HasColumnType("datetime");
                entity.Property(e => e.UserId).HasMaxLength(50);
            });

            modelBuilder.Entity<Domain.Old.Entities.WhatsHappening>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__WhatsHap__3214EC073A4F56B7");

                entity.ToTable("WhatsHappening");

                entity.Property(e => e.Category).HasMaxLength(100);
                entity.Property(e => e.DateCreated).HasColumnType("datetime");
                entity.Property(e => e.Description).HasMaxLength(1000);
                entity.Property(e => e.EndDate).HasColumnType("datetime");
                entity.Property(e => e.ImageUrl).HasMaxLength(2000);
                entity.Property(e => e.LastModifiedDate).HasColumnType("datetime");
                entity.Property(e => e.Name).HasMaxLength(100);
                entity.Property(e => e.StartDate).HasColumnType("datetime");
                entity.Property(e => e.Url).HasMaxLength(2000);

                entity.HasOne(d => d.Organization).WithMany(p => p.WhatsHappenings)
                    .HasForeignKey(d => d.OrganizationId)
                    .HasConstraintName("FK_WhatsHappening_Admin_Organizations");
            });

            modelBuilder.Entity<AdminLogoImageMaintenance>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Admin_logo__3214EC079DB013C1");

                entity.ToTable("Admin_LogoImageMaintenance");
                entity.Property(t => t.ConcurrencyStamp).IsRowVersion();
                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql(GetUtcDate)
                    .HasColumnType("datetime");
                entity.Property(e => e.ImageName).HasMaxLength(100);
                entity.Property(e => e.ImageUrl)
                    .HasMaxLength(2083)
                    .HasColumnName("ImageURL");
                entity.Property(e => e.IsActive).HasDefaultValue(true);
                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.AdminLogoImageMaintenanceCreatedByNavigations)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Admin_Admin_LogoImageMaintenance__CreatedBy__5AEE82B9");

                entity.HasOne(d => d.Organization).WithMany(p => p.AdminLogoImageMaintenances)
                    .HasForeignKey(d => d.OrganizationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Admin_Organizations_Admin_LogoImageMaintenance__CreatedBy__5AEE82B1");

                entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.AdminLogoImageMaintenanceUpdatedByNavigations)
                    .HasForeignKey(d => d.UpdatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Admin_Admin_LogoImageMaintenance__UpdatedBy__5BE2A6F2");
            });

            modelBuilder.Entity<Logo>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__logo");
                entity.Property(e => e.RecordVersion).IsRowVersion().ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
                entity.Property(e => e.UpdatedDate).HasDefaultValueSql(GetUtcDate);
                entity.Property(e => e.IsDeleted).HasDefaultValue(0);
                entity.HasOne(d => d.Organization).WithMany(p => p.Logo)
                    .HasForeignKey(d => d.OrganizationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Admin_Organizations_Admin_Logo__OrganizationId");

            });

            modelBuilder.Entity<FloorMap>(entity =>
            {
                entity.HasKey(e => e.ID)
                    .HasName("PK__FloorMap__3214EC27D459689A");
                entity.ToTable("FloorMap");
                entity.Property(e => e.CreatedAt).HasDefaultValueSql(GetUtcDate);
                entity.Property(e => e.UpdatedAt).HasDefaultValueSql(GetUtcDate);

            });




            //New DB

            modelBuilder.Entity<ImageMaintenance>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_ImageMaintenance");
                entity.Property(e => e.RecordVersion).IsRowVersion().ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
                entity.Property(e => e.UpdatedDate).HasDefaultValueSql(GetUtcDate);
                entity.Property(e => e.IsDeleted).HasDefaultValue(0);


            });
            modelBuilder.Entity<FrequencyMaster>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_FrequencyMaster");
                entity.Property(e => e.UpdatedDate).HasDefaultValueSql(GetUtcDate);
                entity.Property(e => e.IsDeleted).HasDefaultValue(0);


            });
            modelBuilder.Entity<InsurancePanel>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_InsurancePanel");
                entity.Property(e => e.RecordVersion).IsRowVersion().ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
                entity.Property(e => e.UpdatedDate).HasDefaultValueSql(GetUtcDate);
                entity.Property(e => e.IsDeleted).HasDefaultValue(0);


            });

            modelBuilder.Entity<InsurancePanelLocation>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_InsurancePanelLocation");
                entity.Property(e => e.RecordVersion).IsRowVersion().ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
                entity.Property(e => e.UpdatedDate).HasDefaultValueSql(GetUtcDate);
                entity.Property(e => e.IsDeleted).HasDefaultValue(0);
                entity.HasOne(d => d.InsurancePanel).WithMany(p => p.InsurancePanelLocation)
                                .HasForeignKey(d => d.InsurancePanelID)
                                .HasConstraintName("FK_InsurancePanelLocation_InsurancePanel");

            });
            modelBuilder.Entity<Organization>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_Organization");
                entity.Property(e => e.RecordVersion).IsRowVersion().ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
                entity.Property(e => e.UpdatedDate).HasDefaultValueSql(GetUtcDate);
                entity.Property(e => e.IsDeleted).HasDefaultValue(0);


            });
            modelBuilder.Entity<OrganizationAddress>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_OrganizationAddress");
                entity.Property(e => e.RecordVersion).IsRowVersion().ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
                entity.Property(e => e.UpdatedDate).HasDefaultValueSql(GetUtcDate);
                entity.Property(e => e.IsDeleted).HasDefaultValue(0);
                entity.HasOne(d => d.Organization).WithMany(p => p.OrganizationAddress)
                 .HasForeignKey(d => d.OrganizationID)
                 .HasConstraintName("FK_OrganizationAddress_Organization");

            });
            modelBuilder.Entity<OrganizationContact>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_OrganizationContact");
                entity.Property(e => e.RecordVersion).IsRowVersion().ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
                entity.Property(e => e.UpdatedDate).HasDefaultValueSql(GetUtcDate);
                entity.Property(e => e.IsDeleted).HasDefaultValue(0);
                entity.HasOne(d => d.Organization).WithMany(p => p.OrganizationContact)
                 .HasForeignKey(d => d.OrganizationID)
                 .HasConstraintName("FK_OrganizationContact_Organization");


            });
            modelBuilder.Entity<OrganizationTelecom>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_OrganizationTelecom");
                entity.Property(e => e.RecordVersion).IsRowVersion().ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
                entity.Property(e => e.UpdatedDate).HasDefaultValueSql(GetUtcDate);
                entity.Property(e => e.IsDeleted).HasDefaultValue(0);
                entity.HasOne(d => d.Organization).WithMany(p => p.OrganizationTelecom)
                .HasForeignKey(d => d.OrganizationID)
                .HasConstraintName("FK_OrganizationTelecom_Organization");

            });
            modelBuilder.Entity<Location>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_Location");
                entity.Property(e => e.RecordVersion).IsRowVersion().ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
                entity.Property(e => e.UpdatedDate).HasDefaultValueSql(GetUtcDate);


            });
            modelBuilder.Entity<LocationAddress>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_LocationAddress");
                entity.Property(e => e.RecordVersion).IsRowVersion().ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
                entity.Property(e => e.UpdatedDate).HasDefaultValueSql(GetUtcDate);
                entity.HasOne(d => d.Location).WithMany(p => p.LocationAddress)
                .HasForeignKey(d => d.LocationID)
                .HasConstraintName("FK_LocationAddress_Location");

            });
            modelBuilder.Entity<LocationHoursOfOperation>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_LocationHoursOfOperation");
                entity.Property(e => e.RecordVersion).IsRowVersion().ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
                entity.Property(e => e.UpdatedDate).HasDefaultValueSql(GetUtcDate);
                entity.Property(e => e.IsDeleted).HasDefaultValue(0);
                entity.HasOne(d => d.Location).WithMany(p => p.LocationHoursOfOperation)
                .HasForeignKey(d => d.LocationID)
                .HasConstraintName("FK_LocationHoursOfOperation_Location");

            });
            modelBuilder.Entity<LocationIdentifier>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_LocationIdentifier");
                entity.Property(e => e.RecordVersion).IsRowVersion().ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
                entity.Property(e => e.UpdatedDate).HasDefaultValueSql(GetUtcDate);
                entity.Property(e => e.IsDeleted).HasDefaultValue(0);
                entity.HasOne(d => d.Location).WithMany(p => p.LocationIdentifier)
                .HasForeignKey(d => d.LocationID)
                .HasConstraintName("FK_LocationIdentifier_Location");

            });
            modelBuilder.Entity<LocationImage>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_LocationImage");
                entity.Property(e => e.RecordVersion).IsRowVersion().ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
                entity.Property(e => e.UpdatedDate).HasDefaultValueSql(GetUtcDate);
                entity.HasOne(d => d.Location).WithMany(p => p.LocationImage)
                .HasForeignKey(d => d.LocationID)
                .HasConstraintName("FK_LocationImage_Location");

            });
            modelBuilder.Entity<LocationTelecom>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_LocationTelecom");
                entity.Property(e => e.RecordVersion).IsRowVersion().ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
                entity.Property(e => e.UpdatedDate).HasDefaultValueSql(GetUtcDate);
                entity.HasOne(d => d.Location).WithMany(p => p.LocationTelecom)
                .HasForeignKey(d => d.LocationID)
                .HasConstraintName("FK_LocationTelecom_Location");

            });
            modelBuilder.Entity<LocationType>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_LocationType");
                entity.Property(e => e.RecordVersion).IsRowVersion().ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
                entity.Property(e => e.UpdatedDate).HasDefaultValueSql(GetUtcDate);
                entity.Property(e => e.IsDeleted).HasDefaultValue(0);
            });

            modelBuilder.Entity<Reasons>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_Reasons");
                entity.Property(e => e.RecordVersion).IsRowVersion().ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
                entity.Property(e => e.UpdatedDate).HasDefaultValueSql(GetUtcDate);
                entity.Property(e => e.IsDeleted).HasDefaultValue(0);
                entity.HasOne(d => d.Content).WithMany(p => p.Reasons)
                            .HasForeignKey(d => d.ContentID)
                            .HasConstraintName("FK_Reasons_ContentID");


            });
            modelBuilder.Entity<Content>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_Content");
                entity.Property(e => e.RecordVersion).IsRowVersion().ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
                entity.Property(e => e.UpdatedDate).HasDefaultValueSql(GetUtcDate);
                entity.Property(e => e.IsDeleted).HasDefaultValue(0);


            });
            modelBuilder.Entity<Domain.V1.Entities.Agreement>(entity =>
            {
                entity.HasKey(e => e.ID).HasName("PK_AgreementNew");
                entity.ToTable("AgreementV1");
                entity.Property(e => e.RecordVersion).IsRowVersion().ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
                entity.Property(e => e.UpdatedDate).HasDefaultValueSql(GetUtcDate);
                entity.Property(e => e.IsDeleted).HasDefaultValue(0);

            });

            modelBuilder.Entity<AgreementLanguage>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_AgreementLanguage");
                entity.Property(e => e.RecordVersion).IsRowVersion().ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
                entity.Property(e => e.UpdatedDate).HasDefaultValueSql(GetUtcDate);
                entity.Property(e => e.IsDeleted).HasDefaultValue(0);
                entity.HasOne(d => d.Agreement).WithMany(p => p.AgreementLanguage)
                 .HasForeignKey(d => d.AgreementID);
            });

            modelBuilder.Entity<FAQ>(entity =>
            {
                entity.HasKey(e => e.ID).HasName("PK_FAQ");
                entity.Property(e => e.RecordVersion).IsRowVersion().ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
                entity.Property(e => e.UpdatedDate).HasDefaultValueSql(GetUtcDate);
                entity.Property(e => e.IsDeleted).HasDefaultValue(0);

            });

            modelBuilder.Entity<FAQLanguage>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_FAQLanguage");
                entity.Property(e => e.RecordVersion).IsRowVersion().ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
                entity.Property(e => e.UpdatedDate).HasDefaultValueSql(GetUtcDate);
                entity.Property(e => e.IsDeleted).HasDefaultValue(0);
                entity.HasOne(d => d.FAQ).WithMany(p => p.FAQLanguages)
                 .HasForeignKey(d => d.FAQID)
                 .HasConstraintName("FK_FAQLanguage_FAQ");
                entity.HasOne(d => d.FAQ).WithMany(p => p.FAQLanguages)
                .HasForeignKey(d => d.FAQID)
                .HasConstraintName("FK_FAQUserTypes_FAQ");

            });
            modelBuilder.Entity<FAQUserTypes>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_FAQUserTypes");
                entity.Property(e => e.RecordVersion).IsRowVersion().ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
                entity.Property(e => e.UpdatedDate).HasDefaultValueSql(GetUtcDate);
                entity.Property(e => e.IsDeleted).HasDefaultValue(0);


            });

            modelBuilder.Entity<Banner>(entity =>
            {
                entity.HasKey(e => e.ID).HasName("PK_Banner");
                entity.Property(e => e.RecordVersion).IsRowVersion().ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
                entity.Property(e => e.UpdatedDate).HasDefaultValueSql(GetUtcDate);
                entity.Property(e => e.IsDeleted).HasDefaultValue(0);

            });
            modelBuilder.Entity<EducationalQualification>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_EducationalQualification");
                entity.Property(e => e.RecordVersion).IsRowVersion().ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
                entity.Property(e => e.UpdatedDate).HasDefaultValueSql(GetUtcDate);
                entity.Property(e => e.IsDeleted).HasDefaultValue(0);
                entity.HasOne(d => d.ManageDoctorProfile).WithMany(p => p.EducationalQualification)
                .HasForeignKey(d => d.ManageDoctorProfileID)
                .HasConstraintName("FK_EducationalQualification_ManageDoctorProfile");

            });
            modelBuilder.Entity<ExperienceDetails>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_ExperienceDetails");
                entity.Property(e => e.RecordVersion).IsRowVersion().ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
                entity.Property(e => e.UpdatedDate).HasDefaultValueSql(GetUtcDate);
                entity.Property(e => e.IsDeleted).HasDefaultValue(0);
                entity.HasOne(d => d.ManageDoctorProfile).WithMany(p => p.ExperienceDetails)
                .HasForeignKey(d => d.ManageDoctorProfileID)
                .HasConstraintName("FK_ExperienceDetails_ManageDoctorProfile");

            });
            modelBuilder.Entity<Interest>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_Interest");
                entity.Property(e => e.RecordVersion).IsRowVersion().ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
                entity.Property(e => e.UpdatedDate).HasDefaultValueSql(GetUtcDate);
                entity.Property(e => e.IsDeleted).HasDefaultValue(0);
                entity.HasOne(d => d.ManageDoctorProfile).WithMany(p => p.Interest)
                .HasForeignKey(d => d.ManageDoctorProfileID)
                .HasConstraintName("FK_Interest_ManageDoctorProfile");

            });
            modelBuilder.Entity<ManageDoctorLocation>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_ManageDoctorLocation");
                entity.Property(e => e.RecordVersion).IsRowVersion().ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
                entity.Property(e => e.UpdatedDate).HasDefaultValueSql(GetUtcDate);
                entity.Property(e => e.IsDeleted).HasDefaultValue(0);
                entity.HasOne(d => d.ManageDoctorProfile).WithMany(p => p.ManageDoctorLocation)
                .HasForeignKey(d => d.ManageDoctorProfileID)
                .HasConstraintName("FK_ManageDoctorLocation_ManageDoctorProfile");

            });
            modelBuilder.Entity<ManageDoctorProfile>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_ManageDoctorProfile");
                entity.Property(e => e.RecordVersion).IsRowVersion().ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
                entity.Property(e => e.UpdatedDate).HasDefaultValueSql(GetUtcDate);
                entity.Property(e => e.IsDeleted).HasDefaultValue(0);
                entity.HasOne(d => d.Practitioner).WithMany(p => p.ManageDoctorProfile)
                                .HasForeignKey(d => d.PractitionerID)
                                .HasConstraintName("FK_ManageDoctorProfile_Practitioner");

            });
            modelBuilder.Entity<ManageDoctorSpeciality>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_ManageDoctorSpeciality");
                entity.Property(e => e.RecordVersion).IsRowVersion().ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
                entity.Property(e => e.UpdatedDate).HasDefaultValueSql(GetUtcDate);
                entity.Property(e => e.IsDeleted).HasDefaultValue(0);
                entity.HasOne(d => d.ManageDoctorProfile).WithMany(p => p.ManageDoctorSpeciality)
                                .HasForeignKey(d => d.ManageDoctorProfileID)
                                .HasConstraintName("FK_ManageDoctorSpeciality_ManageDoctorProfile");

            });
            modelBuilder.Entity<ManageRank>(entity =>
            {
                entity.HasKey(e => e.ID).HasName("PK_ManageRank");
                entity.Property(e => e.RecordVersion).IsRowVersion().ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
                entity.Property(e => e.UpdatedDate).HasDefaultValueSql(GetUtcDate);
                entity.Property(e => e.IsDeleted).HasDefaultValue(0);
                entity.HasOne(d => d.ManageDoctorProfile).WithMany(p => p.ManageRank)
                                .HasForeignKey(d => d.ManageDoctorProfileID)
                                .HasConstraintName("FK_ManageRank_ManageDoctorProfile");


            });
            modelBuilder.Entity<Publications>(entity =>
            {
                entity.HasKey(e => e.ID).HasName("PK_Publications");
                entity.Property(e => e.RecordVersion).IsRowVersion().ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
                entity.Property(e => e.UpdatedDate).HasDefaultValueSql(GetUtcDate);
                entity.Property(e => e.IsDeleted).HasDefaultValue(0);
                entity.HasOne(d => d.ManageDoctorProfile).WithMany(p => p.Publications)
                                .HasForeignKey(d => d.ManageDoctorProfileID)
                                .HasConstraintName("FK_Publications_ManageDoctorProfile");

            });
            modelBuilder.Entity<Section>(entity =>
            {
                entity.HasKey(e => e.ID).HasName("PK_Section");
                entity.Property(e => e.RecordVersion).IsRowVersion().ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
                entity.Property(e => e.UpdatedDate).HasDefaultValueSql(GetUtcDate);
                entity.Property(e => e.IsDeleted).HasDefaultValue(0);
                entity.HasOne(d => d.ManageDoctorProfile).WithMany(p => p.Section)
                                .HasForeignKey(d => d.ManageDoctorProfileID)
                                .HasConstraintName("FK_Section_ManageDoctorProfile");

            });

            modelBuilder.Entity<Practitioner>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_Practitioner");
                entity.Property(e => e.RecordVersion).IsRowVersion().ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
                entity.Property(e => e.UpdatedDate).HasDefaultValueSql(GetUtcDate);
                entity.Property(e => e.IsDeleted).HasDefaultValue(0);
            });

            modelBuilder.Entity<PractitionerAddresses>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_PractitionerAddresses");
                entity.Property(e => e.RecordVersion).IsRowVersion().ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
                entity.Property(e => e.UpdatedDate).HasDefaultValueSql(GetUtcDate);
                entity.Property(e => e.IsDeleted).HasDefaultValue(0);
                entity.HasOne(d => d.Practitioner).WithMany(p => p.PractitionerAddresses)
                .HasForeignKey(d => d.PractitionerID)
                .HasConstraintName("FK_PractitionerAddresses_Practitioner");

            });
            modelBuilder.Entity<PractitionerCommunication>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_PractitionerCommunication");
                entity.Property(e => e.RecordVersion).IsRowVersion().ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
                entity.Property(e => e.UpdatedDate).HasDefaultValueSql(GetUtcDate);
                entity.Property(e => e.IsDeleted).HasDefaultValue(0);
                entity.HasOne(d => d.Practitioner).WithMany(p => p.PractitionerCommunication)
                .HasForeignKey(d => d.PractitionerID)
                .HasConstraintName("FK_PractitionerCommunication_Practitioner");

            });
            modelBuilder.Entity<PractitionerIdentifier>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_PractitionerIdentifier");
                entity.Property(e => e.RecordVersion).IsRowVersion().ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
                entity.Property(e => e.UpdatedDate).HasDefaultValueSql(GetUtcDate);
                entity.Property(e => e.IsDeleted).HasDefaultValue(0);
                entity.HasOne(d => d.Practitioner).WithMany(p => p.PractitionerIdentifier)
                .HasForeignKey(d => d.PractitionerID)
                .HasConstraintName("FK_PractitionerIdentifier_Practitioner");

            });
            modelBuilder.Entity<PractitionerLocation>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_PractitionerLocation");
                entity.Property(e => e.RecordVersion).IsRowVersion().ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
                entity.Property(e => e.UpdatedDate).HasDefaultValueSql(GetUtcDate);
                entity.Property(e => e.IsDeleted).HasDefaultValue(0);
                entity.HasOne(d => d.Practitioner).WithMany(p => p.PractitionerLocation)
                .HasForeignKey(d => d.PractitionerID)
                .HasConstraintName("FK_PractitionerLocation_Practitioner");

            });
            modelBuilder.Entity<PractitionerRoleLocation>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_PractitionerRoleLocation");
                entity.Property(e => e.RecordVersion).IsRowVersion().ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
                entity.Property(e => e.UpdatedDate).HasDefaultValueSql(GetUtcDate);
                entity.Property(e => e.IsDeleted).HasDefaultValue(0);
                entity.HasOne(d => d.Location).WithMany(p => p.PractitionerRoleLocation)
                .HasForeignKey(d => d.locationID)
                .HasConstraintName("FK_PractitionerRoleLocation_Practitioner");

            });
            modelBuilder.Entity<PractitionerNames>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_PractitionerNames");
                entity.Property(e => e.RecordVersion).IsRowVersion().ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
                entity.Property(e => e.UpdatedDate).HasDefaultValueSql(GetUtcDate);
                entity.Property(e => e.IsDeleted).HasDefaultValue(0);
                entity.HasOne(d => d.Practitioner).WithMany(p => p.PractitionerNames)
                .HasForeignKey(d => d.PractitionerID)
                .HasConstraintName("FK_PractitionerNames_Practitioner");

            });
            modelBuilder.Entity<PractitionerPhotos>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_PractitionerPhotos");
                entity.Property(e => e.RecordVersion).IsRowVersion().ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
                entity.Property(e => e.UpdatedDate).HasDefaultValueSql(GetUtcDate);
                entity.Property(e => e.IsDeleted).HasDefaultValue(0);
                entity.HasOne(d => d.Practitioner).WithMany(p => p.PractitionerPhotos)
                .HasForeignKey(d => d.PractitionerID)
                .HasConstraintName("FK_PractitionerPhotos_Practitioner");

            });
            modelBuilder.Entity<PractitionerQualification>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_PractitionerQualification");
                entity.Property(e => e.RecordVersion).IsRowVersion().ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
                entity.Property(e => e.UpdatedDate).HasDefaultValueSql(GetUtcDate);
                entity.Property(e => e.IsDeleted).HasDefaultValue(0);
                entity.HasOne(d => d.Practitioner).WithMany(p => p.PractitionerQualification)
                .HasForeignKey(d => d.PractitionerID)
                .HasConstraintName("FK_PractitionerQualification_Practitioner");

            });

            modelBuilder.Entity<PractitionerSpeciality>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_PractitionerSpeciality");
                entity.Property(e => e.RecordVersion).IsRowVersion().ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
                entity.Property(e => e.UpdatedDate).HasDefaultValueSql(GetUtcDate);
                entity.Property(e => e.IsDeleted).HasDefaultValue(0);
                entity.HasOne(d => d.Practitioner).WithMany(p => p.PractitionerSpeciality)
                .HasForeignKey(d => d.PractitionerID)
                .HasConstraintName("FK_PractitionerSpeciality_Practitioner");

            });

            modelBuilder.Entity<PractitionerTelecom>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_PractitionerTelecom");
                entity.Property(e => e.RecordVersion).IsRowVersion().ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
                entity.Property(e => e.UpdatedDate).HasDefaultValueSql(GetUtcDate);
                entity.Property(e => e.IsDeleted).HasDefaultValue(0);
                entity.HasOne(d => d.Practitioner).WithMany(p => p.PractitionerTelecom)
                .HasForeignKey(d => d.PractitionerID)
                .HasConstraintName("FK_PractitionerTelecom_Practitioner");

            });
            modelBuilder.Entity<PaymentGatewayConfig>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_PaymentGatewayConfig");
                entity.Property(e => e.RecordVersion).IsRowVersion().ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
                entity.Property(e => e.UpdatedDate).HasDefaultValueSql(GetUtcDate);
                entity.Property(e => e.IsDeleted).HasDefaultValue(0);
                entity.HasOne(d => d.PaymentGateway).WithMany(p => p.PaymentGatewayConfig)
                .HasForeignKey(d => d.PaymentGatewayID)
                .HasConstraintName("FK_PaymentGatewayConfig_PaymentGateway");

            });
            modelBuilder.Entity<PaymentGateway>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_PaymentGateway");
                entity.Property(e => e.RecordVersion).IsRowVersion().ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
                entity.Property(e => e.UpdatedDate).HasDefaultValueSql(GetUtcDate);
                entity.Property(e => e.IsDeleted).HasDefaultValue(0);
            });

            modelBuilder.Entity<ConfiguredEvent>(entity =>
            {
                entity.HasKey(e => e.ID).HasName("PK_Configured Event");
                entity.Property(e => e.RecordVersion).IsRowVersion().ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
                entity.Property(e => e.UpdatedDate).HasDefaultValueSql(GetUtcDate);
                entity.Property(e => e.IsDeleted).HasDefaultValue(0);


            });
            modelBuilder.Entity<NotificationManager>(entity =>
            {
                entity.HasKey(e => e.ID).HasName("PK_NotificationManager");
                entity.Property(e => e.RecordVersion).IsRowVersion().ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
                entity.Property(e => e.UpdatedDate).HasDefaultValueSql(GetUtcDate);
                entity.Property(e => e.IsDeleted).HasDefaultValue(0);


            });
            modelBuilder.Entity<NotificationTemplate>(entity =>
            {
                entity.HasKey(e => e.ID).HasName("PK_NotificationTemplate");
                entity.Property(e => e.RecordVersion).IsRowVersion().ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
                entity.Property(e => e.UpdatedDate).HasDefaultValueSql(GetUtcDate);
                entity.Property(e => e.IsDeleted).HasDefaultValue(0);


            });
            modelBuilder.Entity<NotificationTemplateLanguage>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_NotificationTemplateLanguage");
                entity.Property(e => e.RecordVersion).IsRowVersion().ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
                entity.Property(e => e.UpdatedDate).HasDefaultValueSql(GetUtcDate);
                entity.Property(e => e.IsDeleted).HasDefaultValue(0);


            });



            modelBuilder.Entity<PractitionerAvailability>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_PractitionerAvailability");
                entity.Property(e => e.RecordVersion).IsRowVersion().ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
                entity.Property(e => e.UpdatedDate).HasDefaultValueSql(GetUtcDate);
                entity.Property(e => e.IsDeleted).HasDefaultValue(0);



            });
            modelBuilder.Entity<PractitionerAvailabilityBreak>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_PractitionerAvailabilityBreak");
                entity.Property(e => e.RecordVersion).IsRowVersion().ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
                entity.Property(e => e.UpdatedDate).HasDefaultValueSql(GetUtcDate);
                entity.Property(e => e.IsDeleted).HasDefaultValue(0);
                entity.HasOne(d => d.PractitionerAvailabilityDay).WithMany(p => p.PractitionerAvailabilityBreak)
                                .HasForeignKey(d => d.PractitionerAvailabilityDayID)
                                .HasConstraintName("FK_PractitionerAvailabilityBreak_PractitionerAvailabilityDay");

            });
            modelBuilder.Entity<PractitionerAvailabilityDay>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_PractitionerAvailabilityDay");
                entity.Property(e => e.RecordVersion).IsRowVersion().ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
                entity.Property(e => e.UpdatedDate).HasDefaultValueSql(GetUtcDate);
                entity.Property(e => e.IsDeleted).HasDefaultValue(0);
                entity.HasOne(d => d.PractitionerAvailability).WithMany(p => p.PractitionerAvailabilityDay)
                                .HasForeignKey(d => d.PractitionerAvailabilityID)
                                .HasConstraintName("FK_PractitionerAvailabilityDay_PractitionerAvailability");

            });
            modelBuilder.Entity<PractitionerAvailabilityOccurance>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_PractitionerAvailabilityOccurance");
                entity.Property(e => e.RecordVersion).IsRowVersion().ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
                entity.Property(e => e.UpdatedDate).HasDefaultValueSql(GetUtcDate);
                entity.Property(e => e.IsDeleted).HasDefaultValue(0);
                entity.HasOne(d => d.PractitionerAvailabilityDay).WithMany(p => p.PractitionerAvailabilityOccurance)
                                .HasForeignKey(d => d.PractitionerAvailabilityDayID)
                                .HasConstraintName("FK_PractitionerAvailabilityOccurance_PractitionerAvailabilityDay");

            });
            modelBuilder.Entity<PractitionerNotAvailable>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_PractitionerNotAvailable");
                entity.Property(e => e.RecordVersion).IsRowVersion().ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
                entity.Property(e => e.UpdatedDate).HasDefaultValueSql(GetUtcDate);
                entity.Property(e => e.IsDeleted).HasDefaultValue(0);
                entity.HasOne(d => d.Practitioner).WithMany(p => p.PractitionerNotAvailable)
                                .HasForeignKey(d => d.PractitionerID)
                                .HasConstraintName("FK_PractitionerNotAvailable_Practitioner");


            });
            modelBuilder.Entity<PractitionerRole>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_PractitionerRole");
                entity.Property(e => e.RecordVersion).IsRowVersion().ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
                entity.Property(e => e.UpdatedDate).HasDefaultValueSql(GetUtcDate);
                entity.Property(e => e.IsDeleted).HasDefaultValue(0);
                entity.HasOne(d => d.Practitioner).WithMany(p => p.PractitionerRole)
                                .HasForeignKey(d => d.PractitionerID).HasPrincipalKey(d => d.ResourceID)
                                .HasConstraintName("FK_PractitionerRole_Practitioner");
                entity.HasOne(d => d.Organization).WithMany(p => p.PractitionerRole)
                                .HasForeignKey(d => d.OrganizationID)
                                .HasConstraintName("FK_PractitionerRole_Organization");
                entity.HasOne(d => d.Location).WithMany(p => p.PractitionerRole)
                             .HasForeignKey(d => d.LocationID).HasPrincipalKey(d=>d.ResourceID)
                             .HasConstraintName("IX_PractitionerRole_Location");

            });
            modelBuilder.Entity<PractitionerRoleAvailableTime>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_PractitionerRoleAvailableTime");
                entity.Property(e => e.RecordVersion).IsRowVersion().ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
                entity.Property(e => e.UpdatedDate).HasDefaultValueSql(GetUtcDate);
                entity.Property(e => e.IsDeleted).HasDefaultValue(0);
                entity.HasOne(d => d.PractitionerRole).WithMany(p => p.PractitionerRoleAvailableTime)
                                .HasForeignKey(d => d.PractitionerRoleID)
                                .HasConstraintName("FK_PractitionerRoleAvailableTime_PractitionerRole");

            });
            modelBuilder.Entity<PractitionerRoleCode>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_PractitionerRoleCode");
                entity.Property(e => e.RecordVersion).IsRowVersion().ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
                entity.Property(e => e.UpdatedDate).HasDefaultValueSql(GetUtcDate);
                entity.Property(e => e.IsDeleted).HasDefaultValue(0);
                entity.HasOne(d => d.PractitionerRole)
                .WithOne(p => p.PractitionerRoleCode)  // One-to-one navigation on both sides
                .HasForeignKey<PractitionerRoleCode>(d => d.PractitionerRoleID) // Foreign key in PractitionerRoleSpecialty
                .HasConstraintName("FK_PractitionerRole_PractitionerRoleCode");
                entity.HasOne(d => d.RoleMaster).WithMany(p => p.PractitionerRoleCode)
                                .HasForeignKey(d => d.Code)
                                .HasPrincipalKey(d => d.Code)
                                .HasConstraintName("FK_PractitionerRoleCode_RoleMaster");

            });

            modelBuilder.Entity<PractitionerRoleSpecialty>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_PractitionerRoleSpecialty");
                entity.Property(e => e.RecordVersion).IsRowVersion().ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
                entity.Property(e => e.UpdatedDate).HasDefaultValueSql(GetUtcDate);
                entity.Property(e => e.IsDeleted).HasDefaultValue(0);
                entity.HasOne(d => d.PractitionerRole)
                .WithOne(p => p.PractitionerRoleSpecialty)  // One-to-one navigation on both sides
                .HasForeignKey<PractitionerRoleSpecialty>(d => d.PractitionerRoleID) // Foreign key in PractitionerRoleSpecialty
                .HasConstraintName("FK_PractitionerRole_PractitionerRoleSpecialty");
                entity.HasOne(d => d.HealthcareService).WithMany(p => p.PractitionerRoleSpecialty)
                                  .HasForeignKey(d => d.Specialty)
                                  .HasPrincipalKey(d => d.Name)
                                  .HasConstraintName("FK_PractitionerRoleSpecialty_HealthcareServices");
            });

            modelBuilder.Entity<HealthcareServices>(entity =>
            {
                entity.HasKey(e => e.ID).HasName("PK_HealthcareServices");
                entity.HasIndex(e => e.Name, "UQ_HealthcareServices_Name").IsUnique();
                entity.Property(e => e.Name).HasMaxLength(100);
                entity.Property(e => e.RecordVersion).IsRowVersion().ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
                entity.Property(e => e.UpdatedDate).HasDefaultValueSql(GetUtcDate);
                entity.Property(e => e.IsDeleted).HasDefaultValue(0);
                entity.Property(e => e.Status).HasDefaultValue(1);
               

            });
            modelBuilder.Entity<HealthcareServicesLocation>(entity =>
            {
                entity.HasKey(e => e.ID).HasName("PK_HealthcareServicesLocation");
                entity.Property(e => e.RecordVersion).IsRowVersion().ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
                entity.Property(e => e.UpdatedDate).HasDefaultValueSql(GetUtcDate);
                entity.Property(e => e.IsDeleted).HasDefaultValue(0);
                entity.HasOne(d => d.HeathcareServices).WithMany(p => p.HealthcareServicesLocation)
                             .HasForeignKey(d => d.HealthcareServicesID)
                             .HasConstraintName("FK_HealthcareServicesLocation_HeathcareServices");
            });                        

            modelBuilder.Entity<HealthcareServicesKeyWords>(entity =>
            {
                entity.HasKey(e => e.ID).HasName("PK_HealthcareServicesKeyWords");
                entity.Property(e => e.RecordVersion).IsRowVersion().ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
                entity.Property(e => e.UpdatedDate).HasDefaultValueSql(GetUtcDate);
                entity.Property(e => e.IsDeleted).HasDefaultValue(0);
                entity.HasOne(d => d.HeathcareServices).WithOne(p => p.HealthcareServicesKeyWords)
                               .HasForeignKey<HealthcareServicesKeyWords>(d => d.HealthcareServicesID)
                               .HasConstraintName("FK_HealthcareServicesKeyWords_HeathcareServices");

            });

            modelBuilder.Entity<PractitionerNotification>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_PractitionerNotification");
                entity.Property(e => e.RecordVersion).IsRowVersion().ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
                entity.Property(e => e.UpdatedDate).HasDefaultValueSql(GetUtcDate);
                entity.Property(e => e.IsDeleted).HasDefaultValue(0);
            });

            modelBuilder.Entity<DrugMaster>(entity =>
            {
                entity.ToTable("DrugMaster");

                entity.HasKey(e => e.ID).HasName("PK_DrugMaster");

                entity.Property(e => e.ID)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ResourceID)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.MasterType)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ItemCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ItemDescription)
                    .HasMaxLength(255);

                entity.Property(e => e.ItemTypeCode)
                    .HasMaxLength(50);

                entity.Property(e => e.ItemTypeDescription)
                    .HasMaxLength(255);

                entity.Property(e => e.MedicationCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MedicationDescription)
                    .HasMaxLength(255);

                entity.Property(e => e.MedicationCategory)
                    .HasMaxLength(50);

                entity.Property(e => e.MedicationType)
                    .HasMaxLength(50);

                entity.Property(e => e.Strength)
                    .HasMaxLength(50);

                entity.Property(e => e.DrugForm)
                    .HasMaxLength(50);

                entity.Property(e => e.Caution)
                    .HasMaxLength(255);

                entity.Property(e => e.DosageUnit)
                    .HasMaxLength(50);

                entity.Property(e => e.DoseValue)
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.FrequencyDesc)
                    .HasMaxLength(100);

                entity.Property(e => e.FrequencyValue)
                    .HasColumnType("decimal(10, 2)");

                entity.Property(e => e.DurationUnit)
                    .HasMaxLength(50);

                entity.Property(e => e.DurationValue);

                entity.Property(e => e.Route)
                    .HasMaxLength(50);

                entity.Property(e => e.DrugFormGroup)
                    .HasMaxLength(50);

                entity.Property(e => e.Instructions)
                    .HasMaxLength(500);

                entity.Property(e => e.IsSTATDrug);

                entity.Property(e => e.IsAlertRequired);

                entity.Property(e => e.IsPoisonDrug);

                entity.Property(e => e.IsPsychotropicDrug);

                entity.Property(e => e.IsDangerousDrug);

                entity.Property(e => e.IsAnesthesiaDrug);

                entity.Property(e => e.IsActive);

                entity.Property(e => e.FacilityCode)
                    .HasMaxLength(20);

                entity.Property(e => e.BrandShare)
                    .HasMaxLength(20);

                entity.Property(e => e.RecordVersion)
                    .IsRequired()
                    .IsRowVersion().ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();

                entity.Property(e => e.IsDeleted).HasDefaultValue(0);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedDate)
                    .IsRequired().HasColumnType(DateTimeColumnType);

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50);

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType(DateTimeColumnType).HasDefaultValueSql(GetUtcDate);

                entity.HasIndex(e => e.ItemCode)
                    .IsUnique()
                    .HasDatabaseName("UQ_DrugMaster_ItemCode");

                entity.HasIndex(e => e.MedicationCode)
                    .IsUnique()
                    .HasDatabaseName("UQ_DrugMaster_MedicationCode");
            });

            modelBuilder.Entity<ProcedureChargeMaster>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_ProcedureChargeMaster");
                entity.Property(e => e.RecordVersion).IsRowVersion().ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
                entity.Property(e => e.UpdatedDate).HasDefaultValueSql(GetUtcDate);
                entity.Property(e => e.IsDeleted).HasDefaultValue(0);


            });

            modelBuilder.Entity<ServiceChargeMaster>(entity =>
            {
                entity.ToTable("ServiceChargeMaster");

                entity.HasKey(e => e.ID).HasName("PK_ServiceChargeMaster");

                entity.Property(e => e.ID)
                    .HasColumnName("ID").ValueGeneratedOnAdd();


                entity.Property(e => e.MasterType)
                    .HasMaxLength(50);

                entity.Property(e => e.ItemCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ItemDescription)
                    .HasMaxLength(255);

                entity.Property(e => e.ItemTypeCode)
                    .HasMaxLength(50);

                entity.Property(e => e.ItemTypeDescription)
                    .HasMaxLength(255);

                entity.Property(e => e.TestCode)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.TestDescription)
                    .HasMaxLength(255);

                entity.Property(e => e.ServiceType)
                    .HasMaxLength(50);

                entity.Property(e => e.Category)
                    .HasMaxLength(100);

                entity.Property(e => e.Department)
                    .HasMaxLength(100);

                entity.Property(e => e.TurnAroundTime)
                    .HasColumnType("int");

                entity.Property(e => e.Restricted)
                    .HasColumnType("bit");

                entity.Property(e => e.TestMethodAvailable)
                    .HasMaxLength(200);

                entity.Property(e => e.FacilityCode)
                    .HasMaxLength(20);

                entity.Property(e => e.RecordVersion)
                    .IsRequired()
                    .IsRowVersion()
                    .ValueGeneratedOnAddOrUpdate()
                    .IsConcurrencyToken();

                entity.Property(e => e.IsDeleted)
                    .IsRequired()
                    .HasDefaultValue(0);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedDate)
                    .IsRequired()
                    .HasColumnType("datetime2");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50);

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("datetime2")
                    .HasDefaultValueSql(GetUtcDate);

                entity.HasIndex(e => e.ItemCode)
                    .IsUnique()
                    .HasDatabaseName("UQ_ServiceChargeMaster_ItemCode");
            });

            modelBuilder.Entity<Domain.V1.Entities.Marketings.WhatsHappening>(entity =>
            {
                entity.HasKey(e => e.ID).HasName("PK_WhatsHappening");
                entity.ToTable("WhatsHappeningV1");
                entity.Property(e => e.RecordVersion).IsRowVersion().ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
                entity.Property(e => e.UpdatedDate).HasDefaultValueSql(GetUtcDate);
                entity.Property(e => e.IsDeleted).HasDefaultValue(0);
                entity.HasOne(d => d.Location).WithMany(p => p.WhatsHappening)
                                .HasForeignKey(d => d.HospitalID)
                                .HasConstraintName("FK_WhatsHappening_Location");
                entity.HasOne(d => d.Category).WithMany(p => p.WhatsHappening)
                      .HasForeignKey(d => d.CategoryID)
                      .HasConstraintName("FK_WhatsHappening_Category");
            });

                modelBuilder.Entity<Domain.V1.Entities.Users.User>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_UserV1");
                entity.ToTable("UserV1");
                entity.Property(e => e.RecordVersion).IsRowVersion().ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
                entity.Property(e => e.UpdatedDate).HasDefaultValueSql(GetUtcDate);
                entity.Property(e => e.IsDeleted).HasDefaultValue(0);


            });
            modelBuilder.Entity<UserNames>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_UserNames");
                entity.Property(e => e.RecordVersion).IsRowVersion().ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
                entity.Property(e => e.UpdatedDate).HasDefaultValueSql(GetUtcDate);
                entity.Property(e => e.IsDeleted).HasDefaultValue(0);


            });
            modelBuilder.Entity<UserIdentifier>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_UserIdentifier");
                entity.Property(e => e.RecordVersion).IsRowVersion().ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
                entity.Property(e => e.UpdatedDate).HasDefaultValueSql(GetUtcDate);
                entity.Property(e => e.IsDeleted).HasDefaultValue(0);


            });
            modelBuilder.Entity<UserTelecom>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_UserTelecom");
                entity.Property(e => e.RecordVersion).IsRowVersion().ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
                entity.Property(e => e.UpdatedDate).HasDefaultValueSql(GetUtcDate);
                entity.Property(e => e.IsDeleted).HasDefaultValue(0);


            });

            modelBuilder.Entity<ForgetPassword>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_ForgetPassword");
                entity.Property(e => e.RecordVersion).IsRowVersion().ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
                entity.Property(e => e.UpdatedDate).HasDefaultValueSql(GetUtcDate);
                entity.Property(e => e.IsDeleted).HasDefaultValue(0);


            });
            modelBuilder.Entity<RoleMaster>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_RoleMaster");
                entity.Property(e => e.RecordVersion).IsRowVersion().ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
                entity.Property(e => e.UpdatedDate).HasDefaultValueSql(GetUtcDate);
                entity.Property(e => e.IsDeleted).HasDefaultValue(0);
            });

            modelBuilder.Entity<CountryMaster>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_CountryMaster");
                entity.Property(e => e.RecordVersion).IsRowVersion().ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
                entity.Property(e => e.UpdatedDate).HasDefaultValueSql(GetUtcDate);
                entity.Property(e => e.IsDeleted).HasDefaultValue(0);
            });

            modelBuilder.Entity<Domain.V1.Entities.Dependent.Dependent>(entity =>
            {
                entity.HasKey(e => e.ID).HasName("PK_Dependents");
                entity.ToTable("Dependents");
                entity.Property(e => e.RecordVersion).IsRowVersion().ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
                entity.Property(e => e.UpdatedDate).HasDefaultValueSql(GetUtcDate);
                entity.Property(e => e.IsDeleted).HasDefaultValue(0);
                entity.HasOne<Domain.V1.Entities.Users.User>(u => u.ParentUser)
                    .WithMany(d => d.ChildOrOtherUsers)
                    .HasForeignKey(e => e.UserID)
                    .OnDelete(DeleteBehavior.ClientSetNull);
                entity.HasOne<Domain.V1.Entities.Users.User>(u => u.DependentUser)
                    .WithMany(d => d.DependentUsers)
                    .HasForeignKey(e => e.DependentUserID)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            }
            );
            modelBuilder.Entity<ManageVisibility>(entity =>
            {
                entity.HasKey(e => e.ID).HasName("PK_ManageVisibility");
                entity.Property(e => e.RecordVersion).IsRowVersion().ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
                entity.Property(e => e.UpdatedDate).HasDefaultValueSql(GetUtcDate);
                entity.Property(e => e.IsDeleted).HasDefaultValue(0);
                entity.HasOne(d => d.Practitioner).WithMany(p => p.ManageVisibility)
                .HasForeignKey(d => d.PractitionerID).HasPrincipalKey(c => c.ResourceID)
                .HasConstraintName("IX_ManageVisibility_Practitioner");
                entity.HasOne(d => d.Location).WithMany(p => p.ManageVisibility)
               .HasForeignKey(d => d.LocationID).HasPrincipalKey(c => c.ResourceID)
               .HasConstraintName("IX_ManageVisibility_Location");

            });
            modelBuilder.Entity<ManageVisibilityUserGroups>(entity =>
            {
                entity.HasKey(e => e.ID).HasName("PK_ManageVisibilityUserGroups");
                entity.Property(e => e.RecordVersion).IsRowVersion().ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
                entity.Property(e => e.UpdatedDate).HasDefaultValueSql(GetUtcDate);
                entity.Property(e => e.IsDeleted).HasDefaultValue(0);
                entity.HasOne(d => d.ManageVisibility).WithMany(p => p.ManageVisibilityUserGroups)
                .HasForeignKey(d => d.ManageVisibilityID)
                .HasConstraintName("IX_ManageVisibilityGroups_ManageVisibilityuser");
            });



            modelBuilder.Entity<ResourceMapping>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_ResourceMapping");
                entity.Property(e => e.UpdatedDate).HasDefaultValueSql(GetUtcDate);
                entity.Property(e => e.IsDeleted).HasDefaultValue(0);
                entity.HasOne(d => d.ParentResourceMapping).WithMany(p => p.ParentResourceMappings)
                                .HasForeignKey(d => d.ParentID)
                                .HasConstraintName("FK_ResourceMapping_ParentResourceMapping");
                entity.HasOne(d => d.ResourceType).WithMany(p => p.ResourceMappings)
                                .HasForeignKey(d => d.ResourceTypeID)
                                .HasConstraintName("FK_ResourceMapping_ResourceType");

            });
            modelBuilder.Entity<GroupRoleMapping>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_GroupRoleMapping");
                entity.Property(e => e.UpdatedDate).HasDefaultValueSql(GetUtcDate);
                entity.Property(e => e.IsDeleted).HasDefaultValue(0);
                entity.HasOne(d => d.Group).WithMany(p => p.GroupRoleMappings)
                                .HasForeignKey(d => d.GroupID)
                                .HasConstraintName("FK_GroupRoleMapping_Group");
                entity.HasOne(d => d.Roles).WithMany(p => p.GroupRoleMappings)
                                .HasForeignKey(d => d.RoleID)
                                .HasConstraintName("FK_GroupRoleMapping_Roles");


            });
            modelBuilder.Entity<Domain.V1.Entities.UserGroups.Group>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_Group");
                entity.Property(e => e.UpdatedDate).HasDefaultValueSql(GetUtcDate);
                entity.Property(e => e.IsDeleted).HasDefaultValue(0);


            });

            modelBuilder.Entity<DependentResources>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_DependentResources");
                entity.Property(e => e.UpdatedDate).HasDefaultValueSql(GetUtcDate);
                entity.Property(e => e.IsDeleted).HasDefaultValue(0);
                entity.HasOne(d => d.ResourceMapping).WithMany(p => p.DependentResources)
                                .HasForeignKey(d => d.ResourceMappingID)
                                .HasConstraintName("FK_DependentResources_ResourceMapping");


            });

            modelBuilder.Entity<UserProfile>(entity =>
            {
                    entity.HasKey(e => e.Id).HasName("PK_UserProfile");
                    entity.Property(e => e.UpdatedDate).HasDefaultValueSql("(getdate())");
                entity.Property(e => e.IsDeleted).HasDefaultValue(0);
                entity.HasOne(d => d.Group).WithMany(p => p.UserProfiles)
                               .HasForeignKey(d => d.UserID)
                               .HasConstraintName("FK_UserProfile_Group");

            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_Roles");
                entity.Property(e => e.UpdatedDate).HasDefaultValueSql(GetUtcDate);
                entity.Property(e => e.IsDeleted).HasDefaultValue(0);


            });

            modelBuilder.Entity<RoleResourceMapping>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_RoleResourceMapping");
                entity.Property(e => e.UpdatedDate).HasDefaultValueSql(GetUtcDate);
                entity.Property(e => e.IsDeleted).HasDefaultValue(0);
                entity.HasOne(d => d.Roles).WithMany(p => p.RoleResourceMappings)
                               .HasForeignKey(d => d.RoleID)
                               .HasConstraintName("FK_RoleResourceMapping_Roles");
                entity.HasOne(d => d.ResourceMapping).WithMany(p => p.RoleResourceMappings)
                               .HasForeignKey(d => d.ResourceID)
                               .HasConstraintName("FK_RoleResourceMapping_ResourceMapping");

            });

            modelBuilder.Entity<ResourceType>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_ResourceType");
                entity.Property(e => e.UpdatedDate).HasDefaultValueSql(GetUtcDate);
                entity.Property(e => e.IsDeleted).HasDefaultValue(0);


            });

            modelBuilder.Entity<AccessControlMaster>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_AccessControlMaster");
                entity.Property(e => e.RecordVersion).IsRowVersion().ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
                entity.Property(e => e.UpdatedDate).HasDefaultValueSql(GetUtcDate);
                entity.Property(e => e.IsDeleted).HasDefaultValue(0);


            });
            modelBuilder.Entity<AccessControlHeader>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_AccessControlHeader");
                entity.Property(e => e.RecordVersion).IsRowVersion().ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
                entity.Property(e => e.UpdatedDate).HasDefaultValueSql(GetUtcDate);
                entity.Property(e => e.IsDeleted).HasDefaultValue(0);
                entity.HasOne(d => d.Roles).WithMany(p => p.AccessControlHeaders)
                              .HasForeignKey(d => d.RoleID)
                              .HasConstraintName("FK_AccessControlHeader_Roles"); 
                entity.HasOne(d => d.AccessControlMaster).WithMany(p => p.AccessControlHeaders)
                                .HasForeignKey(d => d.AccessControlMasterID)
                                .HasConstraintName("FK_AccessControlHeader_AccessControlMaster");
            });
            modelBuilder.Entity<AccessControlParameter>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK_AccessControlParameter");
                entity.Property(e => e.RecordVersion).IsRowVersion().ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();
                entity.Property(e => e.UpdatedDate).HasDefaultValueSql(GetUtcDate);
                entity.Property(e => e.IsDeleted).HasDefaultValue(0);
                entity.HasOne(d => d.AccessControlHeaders).WithMany(p => p.AccessControlParameters)
                              .HasForeignKey(d => d.AccessControlHeaderID)
                              .HasConstraintName("FK_AccessControlParameter_Roles");

            });
        }

        /// <summary>
        /// Create a connection string based on region code
        /// </summary>
        /// <param name="isReadOnlyIntent"></param>
        /// <returns></returns>
        protected string? PrepareConnectionString(bool isReadOnlyIntent)
        {
            string? connectionString = null;
            try
            {
                if (_httpContextAccessor.HttpContext?.Request.Headers
                    .TryGetValue("RegionCode", out StringValues regionCode) ?? false)
                {
                    string connectionName = $"{AppConstants.ConnectionStringPrefix}{regionCode}{AppConstants.MicroserviceCode}ConnectionString";
                    connectionString = _configuration.GetSection(connectionName).Value;

                    if (!string.IsNullOrEmpty(connectionString))
                    {
                        var connectionParts = connectionString
                            .Split(';', StringSplitOptions.RemoveEmptyEntries)
                            .Where(x => !x.Equals("ApplicationIntent", StringComparison.OrdinalIgnoreCase))
                            .ToList();

                        string applicationIntent = isReadOnlyIntent
                            ? "ApplicationIntent=readonly"
                            : "ApplicationIntent=readwrite";
                        connectionParts.Add(applicationIntent);

                        if (isReadOnlyIntent)
                        {
                            int count = connectionParts.Count;
                            while (count > 1)
                            {
                                int i = Random.Shared.Next(count--);
                                (connectionParts[i], connectionParts[count]) = (connectionParts[count], connectionParts[i]);
                            }
                        }
                        connectionString = string.Join(';', connectionParts);
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("BaseDbContext.PrepareConnectionString()",
                    "Error occured while preparing database connection");
                throw;
            }
            return connectionString;
        }
    }
}