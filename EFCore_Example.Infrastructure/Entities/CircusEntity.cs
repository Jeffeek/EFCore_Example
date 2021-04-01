#region Using namespaces

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#endregion

namespace EFCore_Example.Infrastructure.Entities
{
    [Table("Circuses")]
    public class CircusEntity : BaseIdentityEntity
    {
        [MaxLength(100)]
        [MinLength(5)]
        [Required]
        public string Address { get; set; }

        public virtual ICollection<ClownPerformanceEntity> Performances { get; set; }

        public virtual ICollection<CircusEventEntity> Events { get; set; }
    }
}