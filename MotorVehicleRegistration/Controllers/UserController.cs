using BusinessLayer;
using Model;
using Models;
using System;
using System.Web.Mvc;

namespace MotorVehicleRegistration.Controllers
{
    [ActionFilterModel]
    public class UserController : Controller
    {
        UserBLL userBll = new UserBLL();
        // GET: User
        public ActionResult Home()
        {

            ListViewAllViewModel viewall = userBll.ViewallRegistration();
            ViewBag.message = TempData["message"];
            return View(viewall);
        }
        public ActionResult AddRegistration()
        {
            ViewBag.text = "Add Registration:";
            ViewBag.button = "Add";
            CompleteDetailsViewModel add = userBll.BindDropdown();
            return View(add);
        }
        public ActionResult GetDetails(int id)
        {
            Session["id"] = id;
            ViewAllListViewModel details = userBll.GetRegistrationDetails(id);
            return View(details);
        }
        public JsonResult DeleteRegistration(int id)
        {
            Session["vehicleId"] = id;
            
            int flag =userBll.DeleteVehicle(id);
            //Session["vehicleNumber"] = vehicleNumber;
            //return RedirectToAction("Home", "User");
            return Json(flag, JsonRequestBehavior.AllowGet);
        }
        public ActionResult RegistrationEditing(int id)
        {
            TempData["id"] = id;
            TempData["VehicleId"] = id;
            CompleteDetailsViewModel getDetails = new CompleteDetailsViewModel();
            ViewBag.toEdit = "Editing";
            getDetails = userBll.GetEditDetails(id);
   
            ViewBag.text = "Edit Registration";
            ViewBag.button = "Save";
            return View("AddRegistration", getDetails);
        }


        [HttpPost]
        public ActionResult RegistrationAdd(CompleteDetailsViewModel addRegistration)
        {

            int exists = userBll.checkIfExists(Convert.ToInt32(TempData["id"]));
            if (exists == 0)
            {
                int count = userBll.AddVehicle(addRegistration);
                if (count == 2)
                {
                    TempData["message"] = "Succesfully Added";
                    return RedirectToAction("Home", "User");
                }
                else
                {
                    TempData["message"] = "Cannot be added as the Vehicle number already exists";
                    return RedirectToAction("Home", "User");
                }
            }
            else
            {
                int isEdit = userBll.EditVehicleRegistration(Convert.ToInt32(TempData["VehicleId"]), addRegistration);
                if(isEdit==2)
                {
                    TempData["message"] = "Succesfully Edited";
                    return RedirectToAction("Home", "User");
                }
                else
                {
                    TempData["message"] = "Cannot be Edited";
                    return RedirectToAction("Home", "User");
                }
            }
        }
        [HttpPost]
        public ActionResult Filter(string FilterText)
        {
           ListViewAllViewModel filterList =userBll.SearchRegistration(FilterText);
            return View("Home", filterList);
        }
    }
}


