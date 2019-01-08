using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Data.Entity;
using DevicesManager.Models;
using DevicesManager.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using DevicesManager.ServiceReference;
using System.ServiceModel;

namespace DevicesManager.Controllers
{
    public class DevicesController : Controller
    {
        private ApplicationDbContext _context;
        private ServiceClient serviceClient;

        public DevicesController()
        {
            _context = new ApplicationDbContext();
            //InstanceContext instanceContext = new InstanceContext(this);
            serviceClient = new ServiceClient();
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
            //var dataContract = serviceClient.GetDeviceData(id);

            //var deviceData = new IEnumerable<DeviceData>
            //{

            //};

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

        public string GetFile(int id)
        {
            Stream file;
            try
            {
                //file = serviceClient.Download(id);
                //if (file != null)
                //{
                //    return "New file";
                //}
            }
            catch (System.ServiceModel.CommunicationException e)
            {
                return "Nie udało się pobrać pliku.";
            }
            finally
            {
                serviceClient.Close();
            }

            return "No File";

        }

        [HttpPost]
        public string SendFile(int id, HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
                try
                {
                    var stream = new MemoryStream();
                    file.InputStream.CopyTo(stream);
                    byte[] data = stream.ToArray();

                    serviceClient.Upload(id, data);

                    return "File uploaded successfully";
                }
                catch (Exception ex)
                {
                    return "ERROR:" + ex.Message.ToString();
                }
            else
            {
                return "You have not specified a file.";
            }
        }

        //public ActionResult RefreshDetails(int id)
        //{
        //    var deviceData = new DeviceData()
        //    {
        //        DeviceId = id,
        //        SendDateTime = DateTime.Now
        //    };

        //    List<DeviceData> datatList = _context.DevicesData.Where(d => d.DeviceId == id).ToList();

        //    datatList.Add(deviceData);

        //    var deviceDetails = new DeviceDetailsViewModel
        //    {
        //        Device = _context.Devices.Find(id),
        //        DeviceData = datatList
        //    };

        //    _context.DevicesData.Add(deviceData);
        //    _context.SaveChanges();

        //    return View("Details", deviceDetails);
        //}
    }
}