using System;
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
                            UserProfiles.Id,
                            UserProfiles.UserId,
                            UserProfiles.ProfileId,
                            UserProfiles.Configuration,
                            Users.Id,
                            Users.Name,
                            Profiles.Id,
                            Profiles.Name
                        FROM
                            UserProfiles
                        INNER JOIN Users on
                            UserProfiles.UserId = Users.Id
                        INNER JOIN Profiles on
                            Profiles.Id = UserProfiles.ProfileId
                    ",
                    map: (UserProfile, Users, Profiles) => {
                        UserProfile.User = Users;
                        UserProfile.Profile = Profiles;
                        return UserProfile;
                    });
            }
        }

        public override UserProfile GetById(UInt64 userProfileId) {
            using(var db = new MySqlConnection(ConnectionString)) {
                return db.Query<UserProfile, User, Profile, UserProfile>(
                    @"  SELECT
                            UserProfiles.Id,
                            UserProfiles.UserId,
                            UserProfiles.ProfileId,
                            UserProfiles.Configuration,
                            Users.Id,
                            Users.Name,
                            Profiles.Id,
                            Profiles.Name
                        FROM
                            UserProfiles
                        INNER JOIN Users on
                            UserProfiles.UserId = Users.Id
                        INNER JOIN Profiles on
                            Profiles.Id = UserProfiles.ProfileId
                        WHERE UserProfiles.Id = @id
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
