using Aurora.AdministrationService.Domain.V1.Entities.HealthcareServices;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aurora.AdministrationService.Domain.V1.Entities.HealthcareService 
{
    [Table(name: "HealthcareServicesKeyWords", Schema = "dbo")]

    public class HealthcareServicesKeyWords : IAuditableEntity, IDeletableEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Comment("Unique identifier for the healthcare service.")]
        public long ID { get; set; }
        [Comment("Identifier for the healthcare service (if referenced from another table).")]
        public required long HealthcareServicesID { get; set; }

        [MaxLength(50)]
        [Comment("Keywords associated with the healthcare service for searchability.")]
        public string? Keyword { get; set; }
        [Comment("System-generated version of the record for concurrency control.")]
        public required byte[] RecordVersion { get; set; } = [];
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
        public virtual HealthcareServices? HeathcareServices { get; set; }
       
    }
}
