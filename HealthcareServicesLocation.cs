using Aurora.AdministrationService.Domain.V1.Entities.Locations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aurora.AdministrationService.Domain.V1.Entities.HealthcareServices
{
    [Table(name: "HealthcareServicesLocation", Schema = "dbo")]

    public class HealthcareServicesLocation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Comment("Unique identifier for the Healthcare Services Location.")]
        public long ID { get; set; }
        [Comment("Identifier linking to the specific healthcare service associated with the location.")]
        public long HealthcareServicesID { get; set; }
        [MaxLength(20)]
        [Comment("Location where the service is available.")]
        public required string LocationID { get; set; }
        [Timestamp]
        [Comment("System-generated version of the record for concurrency control.")]
        public required byte[] RecordVersion { get; set; } = Array.Empty<byte>();
        [Comment("Indicates if the record is deleted (0 = No, 1 = Yes).")]
        public required bool IsDeleted { get; set; }
        [MaxLength(50)]
        [Comment("The user who created the content record.")]
        public string? CreatedBy { get; set; }
        [Comment("The date and time when the content record was created.")]
        public required DateTime CreatedDate { get; set; }
        [MaxLength(50)]
        [Comment("The user who updated the content record.")]
        public string? UpdatedBy { get; set; }
        [Comment("The date and time when the content record was updated.")]
        public DateTime? UpdatedDate { get; set; }
        public virtual HealthcareService.HealthcareServices? HeathcareServices { get; set; }
        public virtual Location? HealthcareServiceLocation { get; set; }
    }
}
