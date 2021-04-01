#region Using namespaces

using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

#endregion

namespace EFCore_Example.Infrastructure.Entities
{
    [Index(nameof(Id))]
    public abstract class BaseIdentityEntity
    {
        [Key]
        public int Id { get; set; }
    }
}