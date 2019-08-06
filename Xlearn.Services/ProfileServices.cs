using Microsoft.Extensions.Configuration;

using Xlearn.Models;
using Xlearn.Repository;

namespace Xlearn.Services {
    public class ProfileServices : RepositoryBase<Profile> {
        public ProfileServices(IConfiguration configuration) : base(configuration) { }

    }
}
