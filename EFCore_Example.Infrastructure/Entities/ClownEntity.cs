#region Using namespaces

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#endregion

namespace EFCore_Example.Infrastructure.Entities
{
    [Table("Clowns")]
    public class ClownEntity : BaseIdentityEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        public virtual ICollection<ClownPerformanceEntity> Performances { get; set; }
    }
}