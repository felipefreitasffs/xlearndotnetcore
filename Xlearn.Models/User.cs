using System.ComponentModel.DataAnnotations;

namespace Xlearn.Models {
    public class User : BaseEntity {
        [Required]
        public string Name { get; set; }
    }
}
