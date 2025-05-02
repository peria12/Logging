using Aurora.AdministrationService.Domain.V1.Entities.HealthcareServices;
using Aurora.AdministrationService.Domain.V1.Entities.Locations;
using Aurora.AdministrationService.Domain.V1.Entities.PractitionerRoles;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aurora.AdministrationService.Domain.V1.Entities.HealthcareService
{
    [Table(name: "HealthcareServices", Schema = "dbo")]
    public class HealthcareServices : IAuditableEntity, IDeletableEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Comment("Unique identifier for the healthcare service.")]
        public long ID { get; set; }
        [Comment("Name of the healthcare service.")]
        [MaxLength(100)]
        public required string Name { get; set; }
        [MaxLength(20)]
        [Comment("Identifier for the healthcare service.")]
        public required string Identifier { get; set; }
        [MaxLength(500)]
        [Comment("Detailed description of the healthcare service.")]
        public string? LaymanDescription { get; set; }
      
        [Comment("status of the record (e.g., Active, Inactive, Pending).")]
        public required bool Status { get; set; }
        [Comment("System-generated version of the record for concurrency control.")]
        public required byte[] RecordVersion { get; set; } = Array.Empty<byte>();
        [Comment("Indicates if the record is deleted (0 = No, 1 = Yes).")]
        public required bool IsDeleted { get; set; }
        [MaxLength(50)]
        [Comment("The user who created the record.")]
        public string? CreatedBy { get; set; }
        [Comment("The date and time when the record was created.")]
        public required DateTime CreatedDate { get; set; }
        [MaxLength(50)]
        [Comment("The user who last updated the record.")]
        public string? UpdatedBy { get; set; }
        [Comment("The date and time when the record was last updated.")]
        public DateTime? UpdatedDate { get; set; }
        public virtual HealthcareServicesKeyWords? HealthcareServicesKeyWords { get; set; }
        public virtual ICollection<HealthcareServicesLocation>? HealthcareServicesLocation { get; set; }
        public virtual ICollection<PractitionerRoleSpecialty> PractitionerRoleSpecialty { get; set; } = new List<PractitionerRoleSpecialty>();
    }
}
