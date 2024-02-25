using System.ComponentModel.DataAnnotations;

namespace Streamberry.Domain.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}