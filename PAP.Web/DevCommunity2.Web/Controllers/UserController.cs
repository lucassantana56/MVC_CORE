using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PAP.Business.Persistence.Repositories;
using PAP.Business.Repositories;

namespace DevCommunity2.Web.Controllers
{

    [Authorize]
    public class UserController : Controller
    {

        private readonly AccountRepository _accountRepository;

        public UserController(IAccountRepository accountRepo)
        {
            _accountRepository = (AccountRepository)accountRepo;
        }

        public IActionResult GetUserPhoto()
        {
            var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest();
            }

            var user = _accountRepository.GetUserInfo(new Guid(userId));

            if (user == null)
            {
                return BadRequest();
            }

            return Ok(user.PhotoUrl);
        }
    }
}