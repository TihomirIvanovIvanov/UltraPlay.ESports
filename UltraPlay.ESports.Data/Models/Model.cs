using System.ComponentModel.DataAnnotations;

namespace UltraPlay.ESports.Data.Models
{
    public abstract class Model
    {
        [Key]
        public long Id { get; set; }
    }
}
