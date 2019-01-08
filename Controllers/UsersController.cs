using DevicesManager.Models;
using DevicesManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.DataProtection;

namespace DevicesManager.Controllers
{
    public class UsersController : Controller
    {
        private ApplicationDbContext _context;
        private UserManager<ApplicationUser> userManager;

        public UsersController()
        {
            _context = new ApplicationDbContext();
            userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this._context));
            var provider = new DpapiDataProtectionProvider("DevicesManager");
            userManager.UserTokenProvider =
                            new DataProtectorTokenProvider<ApplicationUser>(provider.Create("ASP.NET Identity"));
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        
        public ActionResult Random()
            {
            var usersWithRoles = (from user in _context.Users
                                  select new
                                  {
                                      UserId = user.Id,
                                      UserFirstName = user.userInformations.FirstName,
                                      UserSurname = user.userInformations.Surname,
                                      Email = user.Email,
                                      RoleNames = (from userRole in user.Roles
                                                   join role in _context.Roles on userRole.RoleId
                                                   equals role.Id
                                                   select role.Name).ToList()
                                  }).ToList().Select(p => new ManageUsersViewModel()
                                  {
                                      UserId = p.UserId,
                                      UserFirstName = p.UserFirstName,
                                      UserSurname = p.UserSurname,
                                      Email = p.Email,
                                      Role = string.Join(",", p.RoleNames)
                                  });

            return View(usersWithRoles);
            }
        

        public ActionResult Details(string id)
        {
            var allRoles = _context.Roles.OrderBy(r => r.Name).ToList();
            var user = _context.Users.ToList().SingleOrDefault(c => c.Id == id);

            if (user == null)
            {
                user = new ApplicationUser()
                {
                    userInformations = new User()
                    {
                        FirstName = "",
                        Surname = ""
                    },
                    Email = ""
                };
            }

            return View(initEditUserViewModel(user, user.Email));
        }

        [HttpPost]
        public ActionResult Details(String id, EditUserViewModel model)
        {
            ApplicationUser user;

            if (!ModelState.IsValid)
            {
                return View(initEditUserViewModel(model.User, model.Email));
            }
            
            model.User.UserName = model.Email;
            model.User.Email = model.Email;

            if (id == null)
            {
                model.User.PasswordHash = userManager.PasswordHasher.HashPassword(model.Password);
                model.User.SecurityStamp = model.User.PasswordHash;
                user = _context.Users.Add(model.User);
                _context.SaveChanges();
            } 
            else
            {
                var users = _context.Users.ToList();
                user =  users.Single(c => c.Id == id);
                user.userInformations.FirstName = model.User.userInformations.FirstName;
                user.userInformations.Surname = model.User.userInformations.Surname;

                if (model.Password != null)
                {
                    model.Code = userManager.GeneratePasswordResetToken(user.Id);
                    userManager.ResetPassword(user.Id, model.Code, model.Password);
                }
                //userManager.Update(user);
            }
            
            setRoleIfChanged(user.Id, model.RoleID);
            _context.SaveChanges();
            return RedirectToAction("Random","Users");
        }

        public string Delete(string id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            var devices = _context.Devices;

            foreach (var device in devices)
            {
                if(device.UserId == user.Id)
                    _context.Devices.Remove(device);
            }

            _context.Users.Remove(user);
            _context.SaveChanges();

            return "Success";
        }

        private EditUserViewModel initEditUserViewModel(ApplicationUser user, string email)
        {
            return new EditUserViewModel()
            {
                User = user,
                Email = email,
                Roles = _context.Roles.OrderBy(r => r.Name).ToList()
            };
        }

        private void setRoleIfChanged(string id, string roleID )
        {
            string newRole;

            if (roleID == "1")
                newRole = RoleName.Admin;
            else
                newRole = RoleName.User;

            if (!userManager.IsInRole(id, roleID))
            {
                if(userManager.GetRoles(id).Count() > 0)
                {
                    var userRoles = userManager.GetRoles(id);
                    userManager.RemoveFromRole(id, userRoles[0]);
                }
                userManager.AddToRole(id, newRole);
            }
        }
    }
}