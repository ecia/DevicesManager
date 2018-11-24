using DevicesManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
                var users = userManager.Users.ToList();
                return View(users);
            }
        
        public ActionResult Details(string id)
        {
            var user = _context.Users.ToList().SingleOrDefault(c => c.Id == id);
            if (user == null)
                return HttpNotFound();
            return View(user);
        }

            // GET: User/Edit/5F
            public ActionResult Edit(int id)
            {
                return View();
            }

            // POST: User/Edit/5
            [HttpPost]
            public ActionResult Edit(int id, FormCollection collection)
            {
                try
                {
                    // TODO: Add update logic here

                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }

            // GET: User/Delete/5
            public ActionResult Delete(int id)
            {
                return View();
            }

            // POST: User/Delete/5
            [HttpPost]
            public ActionResult Delete(int id, FormCollection collection)
            {
                try
                {
                    // TODO: Add delete logic here

                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }

        
    }

}