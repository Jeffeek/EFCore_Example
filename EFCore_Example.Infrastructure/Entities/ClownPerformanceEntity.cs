#region Using namespaces

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#endregion

namespace EFCore_Example.Infrastructure.Entities
{
    public class ClownPerformanceEntity : BaseIdentityEntity
    {
        [Required]
        public int ClownId { get; set; }

        [ForeignKey(nameof(ClownId))]
        public ClownEntity Clown { get; set; }

        [Required]
        public int CircusId { get; set; }

        [ForeignKey(nameof(CircusId))]
        public CircusEntity Circus { get; set; }

        [MaxLength(50)]
        [MinLength(5)]
        [Required]
        public string Title { get; set; }
    }
}