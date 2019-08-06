using System.ComponentModel.DataAnnotations;

namespace Xlearn.Models {
    public class Profile : BaseEntity {
        [Required]
        public string Name { get; set; }
    }
}
