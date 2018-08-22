using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using IndraPU.Context;
using IndraPU.Logic;
using IndraPU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace IndraPU.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private UserLogic _userLogic = new UserLogic();
        private ApplicationUserManager _userManager;
        private ApplicationSignInManager _signInManager;

        public UserController()
        {
        }

        public UserController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        // GET: User
        public ActionResult Index()
        {
            var users = _userLogic.GetAll();

            List<UserViewModel> results = new List<UserViewModel>();

            List<NetRole> roles = GetAllRoles();

            foreach (var item in users)
            {
                UserViewModel result = new UserViewModel();
                result.Id = item.Id;
                result.Email = item.Email;
                result.FirstName = item.FirstName;
                result.LastName = item.LastName;
                result.PhoneNumber = item.PhoneNumber;
                result.CurrentAddress = item.CurrentAddress;
                var userRoles = roles.Where(c => item.Roles.Select(d => d.RoleId).ToList().Contains(c.Id)).ToList();
                result.Role = String.Join(",", userRoles.Select(c => c.Name).ToList());
                results.Add(result);
            }

            return View(results);
        }

        private static List<NetRole> GetAllRoles()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var roleManager = new ApplicationRoleManager(new NetRoleStore(context));
            var roles = roleManager.Roles.OrderBy(c => c.Id).ToList();
            return roles;
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            PrepareSelectList();
            var entity = _userLogic.GetById(id);
            List<NetRole> roles = GetAllRoles();

            UserViewModel result = new UserViewModel();
            result.Id = entity.Id;
            result.Email = entity.Email;
            result.FirstName = entity.FirstName;
            result.LastName = entity.LastName;
            result.PhoneNumber = entity.PhoneNumber;
            result.CurrentAddress = entity.CurrentAddress;
            var userRoles = roles.Where(c => entity.Roles.Select(d => d.RoleId).ToList().Contains(c.Id)).ToList();
            result.Role = String.Join(",", userRoles.Select(c => c.Name).ToList());
            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByNameAsync(model.Email);
                var oldRole = await UserManager.GetRolesAsync(model.Id);
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.PhoneNumber = model.PhoneNumber;
                user.CurrentAddress = model.CurrentAddress;
                var result = await UserManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    if (!oldRole.Contains(model.Role))
                    {
                        await UserManager.RemoveFromRolesAsync(model.Id, oldRole.ToArray());

                        await UserManager.AddToRoleAsync(model.Id, model.Role);
                    }

                    // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                    // Send an email with this link
                    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

                    return RedirectToAction("Index", "User");
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);

        }

        //
        // GET: /Manage/ChangePassword
        public ActionResult ChangePassword(int id)
        {
            AdminResetPasswordViewModel model = new AdminResetPasswordViewModel();
            model.UserId = id;
            return View(model);
        }

        //
        // POST: /Manage/ChangePassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(AdminResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var userId = model.UserId.Value;
            string resetToken = await UserManager.GeneratePasswordResetTokenAsync(model.UserId.Value);
            var result = await UserManager.ResetPasswordAsync(userId, resetToken, model.NewPassword);
            if (result.Succeeded)
            {
                var user = await UserManager.FindByIdAsync(userId);
                if (user != null)
                {
                    await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                }
                return RedirectToAction("Index", new { Message = ManageMessageId.ChangePasswordSuccess });
            }
            AddErrors(result);
            return View(model);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        public enum ManageMessageId
        {
            AddPhoneSuccess,
            ChangePasswordSuccess,
            SetTwoFactorSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
            RemovePhoneSuccess,
            Error
        }

        private void PrepareSelectList()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var roleManager = new ApplicationRoleManager(new NetRoleStore(context));
            var roles = roleManager.Roles.OrderBy(c => c.Id).ToList();

            List<SelectListItem> roleList = new List<SelectListItem>();
            foreach (var item in roles)
            {
                roleList.Add(new SelectListItem { Value = item.Name, Text = item.Name });
            }
            ViewData["Roles"] = roleList;
        }
    }
}