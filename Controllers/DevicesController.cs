using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using DevicesManager.Models;
using DevicesManager.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using DevicesManager.ServiceReference;

namespace DevicesManager.Controllers
{
    public class DevicesController : Controller
    {
        private ApplicationDbContext _context;
        private ServiceClient serviceClient = new ServiceClient();

        public DevicesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Device
        public ActionResult Random()
        {
            var currentUserId = User.Identity.GetUserId();
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = _context.Users.Find(currentUserId);
            List<Device> devices;

            if (User.IsInRole(RoleName.Admin))
                devices = _context.Devices.ToList();
            else
                devices = _context.Devices.Where(x=>x.UserId == currentUserId).ToList();
            
            var viewModel = new UserDeviceViewModel
            {
                UserName = currentUser.userInformations.Name,
                Devices = devices
            };
            
            return View(viewModel);
        }

        public ActionResult Details(int id)
        {
            var device = _context.Devices.SingleOrDefault(c => c.DeviceId == id);
            IEnumerable<DeviceData> deviceData = _context.DevicesData.Where(c => c.DeviceId == device.DeviceId).ToList();

            var deviceDetails = new DeviceDetailsViewModel
            {
                Device = device,
                DeviceData = deviceData
            };

            if (device == null)
                return HttpNotFound();
            return View(deviceDetails);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Device device)
        {
            if (ModelState.IsValid)
            {
                device.UserId = User.Identity.GetUserId();
                _context.Devices.Add(device);
                _context.SaveChanges();
                return RedirectToAction("Random", "Devices");
            }

            return View(device);
            }

        public string Delete(int id)
        {
            var device = _context.Devices.Find(id);
            _context.Devices.Remove(device);
            _context.SaveChanges();

            return "Success";
        }

        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

        public string GetFile()
        {
            //return serviceClient.Message();
            return "";
        }

        public void SendFile()
        {

        }

        public ActionResult RefreshDetails(int deviceId)
        {
        //    data.Add(serviceClient.GetCPUPerformence());
        //    data.Add(serviceClient.GetRAMPerformence());
            return View();
        }


    }
}