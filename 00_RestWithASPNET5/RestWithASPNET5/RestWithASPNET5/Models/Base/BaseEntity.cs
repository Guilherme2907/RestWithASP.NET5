using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASPNET5.Models
{
    public class BaseEntity
    {
        [Column("id")]
        public long Id { get; set; }
    }
}
