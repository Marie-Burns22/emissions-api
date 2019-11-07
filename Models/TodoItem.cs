using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TodoApi.Models
{
    public class Emission
    {
        public long Id { get; set; }
        
        [Required]
        public string Food { get; set; }

        public float Amount { get; set;}
        [DefaultValue(false)]
        public bool IsComplete { get; set; }
    }
}