using Microsoft.Extensions.Configuration;

using Xlearn.Models;
using Xlearn.Repository;

namespace Xlearn.Services {
    public class UserServices : RepositoryBase<User> {
        public UserServices(IConfiguration configuration) : base(configuration) { }

    }
}
