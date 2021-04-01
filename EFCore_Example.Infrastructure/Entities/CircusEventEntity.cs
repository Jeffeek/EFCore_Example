#region Using namespaces

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#endregion

namespace EFCore_Example.Infrastructure.Entities
{
    public class CircusEventEntity : BaseIdentityEntity
    {
        [Required]
        public string Title { get; set; }

        public int CircusId { get; set; }

        [ForeignKey(nameof(CircusId))]
        public CircusEntity Circus { get; set; }

        [Required]
        public DateTime Start { get; set; }

        [Required]
        public DateTime End { get; set; }
    }
}