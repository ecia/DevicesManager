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
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        [AllowAnonymous]
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
            var user = _context.Users.ToList().SingleOrDefault(c => c.Id == id);

            if (user == null)
                return HttpNotFound();
            return View(user);
        }

        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            return RedirectToAction("Index");

        }

        public ActionResult Delete(string id)
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

            return Json(new { Success = true });
        }
    }
}