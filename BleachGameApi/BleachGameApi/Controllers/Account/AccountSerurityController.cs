using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BleachGameApi.SignalRStuff;
using CoreRepo.Database.Tables.Account;
using CoreServices.AccountServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace BleachGameApi.Controllers.Account
{
    [Produces("application/json")]
    [Route("api/AccountSerurity")]
    public class AccountSerurityController : Controller
    {


        private IHubContext<CharacterHub> _hubContext;
        private readonly AccountSerurityService _accountSerurity;
        public AccountSerurityController(AccountSerurityService accountSerurityService, IHubContext<CharacterHub> hubContext)
        {
            _hubContext = hubContext;
            _accountSerurity = accountSerurityService;
        }


        [HttpGet]
        [Route("signalTesting")]
        public JsonResult SignalRTestinging()
        {
            var clients = _hubContext.Clients;
            clients.All.InvokeAsync("Send", true);
            return Json(new {success = true});
        }


        [HttpPost]
        [Route("Register")]
        public JsonResult Register([FromBody] User model)
        {
            if (model.Email == null || model.Password == null) return Json(new {success = false, reason= "Model Invalid"});
            var registered = _accountSerurity.Register(model);
            return Json(new {success = registered != null});
        }

        [HttpPost]
        [Route("Login")]
        public JsonResult Login([FromBody] User model)
        {
            if (model.Email == null || model.Password == null) return Json(new { success = false, reason = "Model Invalid" });
            var session = _accountSerurity.Login(model);
            return session != null ? Json(new { success = true, token = session.Token }) : Json(new { success = false });
        }

        [HttpPost]
        [Route("UpdatePassword")]
        public JsonResult UpdatePassword([FromBody] string password)
        {
            var token = Request.Headers["Token"].First();
            if(_accountSerurity.CheckToken(token) == null) return Json(new {success = false, reason = "Invalid Token"});

            if (password == null) return Json(new { success = false, reason = "Model Invalid" });
            return Json(new { success = _accountSerurity.UpdatePassword(password, token) });
        }

        [HttpPost]
        [Route("VerifyEmail")]
        public JsonResult VerifyEmail([FromBody] string verifyString)
        {
            if (verifyString == null) return Json(new { success = false, reason = "Model Invalid" });
            var verified = _accountSerurity.VerifyEmailAddress(verifyString);
            return Json(new { success = verified });
        }
        [HttpPost]
        [Route("ResendEmailVerification")]
        public JsonResult ResendEmailVerification([FromBody] string email)
        {
            if (email == null) return Json(new { success = false, reason = "Model Invalid" });
            var user = _accountSerurity.GetUserByEmail(email);
            if (user == null) return Json(new{ success = false, reason = "Account does not exist"});
            if (user.IsVerified) return Json(new {success = false, reason = "Already verified"});

            var verified = _accountSerurity.ResendEmailVerify(user);
            return Json(new { success = verified });
        }

    }
}