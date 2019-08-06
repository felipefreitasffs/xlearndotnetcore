using System.ComponentModel.DataAnnotations;

namespace Xlearn.Models {
    public class BaseEntity {
        [KeyAttribute]
        public string Id { get; set; }
    }
}
