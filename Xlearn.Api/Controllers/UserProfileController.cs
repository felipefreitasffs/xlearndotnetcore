using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;

using Xlearn.Models;
using Xlearn.Repository;

namespace Xlearn.Api.Controllers {
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase {
        private RepositoryBase<UserProfile> userProfileServices;

        public UserProfileController(RepositoryBase<UserProfile> userProfileServices) {
            this.userProfileServices = userProfileServices;
        }

        /// <summary>
        /// Get all user profile from database.
        /// </summary>
        /// <returns>
        /// List of user profile .
        /// </returns>
        /// <response code="200">Returns the json with the list of user profile</response>
        [HttpGet]
        [ProducesResponseType(200)]
        public ActionResult<IEnumerable<UserProfile>> Get() {
            return Ok(this.userProfileServices.GetAll());
        }

    }
}
