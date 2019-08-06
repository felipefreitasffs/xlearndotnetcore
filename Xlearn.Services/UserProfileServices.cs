using System.Collections.Generic;
using System.Linq;
using Dapper;

using Microsoft.Extensions.Configuration;

using MySql.Data.MySqlClient;

using Xlearn.Models;
using Xlearn.Repository;

namespace Xlearn.Services {
    public class UserProfileServices : RepositoryBase<UserProfile> {
        public UserProfileServices(IConfiguration configuration) : base(configuration) { }

        public override IEnumerable<UserProfile> GetAll() {
            using(var db = new MySqlConnection(ConnectionString)) {
                return db.Query<UserProfile, User, Profile, UserProfile>(
                    @"  SELECT
                            UserProfile.Id,
                            UserProfile.UserId,
                            UserProfile.ProfileId,
                            UserProfile.Configuration,
                            User.Id,
                            User.Description,
                            Profile.Id,
                            Profile.Description
                        FROM
                            UserProfile
                        INNER JOIN User on
                            UserProfile.UserId = User.Id
                        INNER JOIN Profile on
                            Profile.Id = UserProfile.ProfileId
                    ",
                    map: (UserProfile, User, Profile) => {
                        UserProfile.User = User;
                        UserProfile.Profile = Profile;
                        return UserProfile;
                    });
            }
        }

        public override UserProfile GetById(string userProfileId) {
            using(var db = new MySqlConnection(ConnectionString)) {
                return db.Query<UserProfile, User, Profile, UserProfile>(
                    @"  SELECT
                            UserProfile.Id,
                            UserProfile.UserId,
                            UserProfile.ProfileId,
                            UserProfile.Configuration,
                            User.Id,
                            User.Description,
                            Profile.Id,
                            Profile.Description
                        FROM
                            UserProfile
                        INNER JOIN User on
                            UserProfile.UserId = User.Id
                        INNER JOIN Profile on
                            Profile.Id = UserProfile.ProfileId
                        WHERE UserProfile.Id = @id
                    ",
                    map: (UserProfile, User, Profile) => {
                        UserProfile.User = User;
                        UserProfile.Profile = Profile;
                        return UserProfile;
                    },
                    new { @id = userProfileId }).FirstOrDefault();
            }
        }
    }
}
