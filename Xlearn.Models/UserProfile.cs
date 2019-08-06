namespace Xlearn.Models {
    public class UserProfile : BaseEntity {
        public int UserId { get; set; }

        public int ProfileId { get; set; }

        public string Configuration { get; set; }

        public User User { get; set; }

        public Profile Profile { get; set; }
    }
}
