using BusinessLayer;
using Model;
using System.Web.Mvc;

namespace MotorVehicleRegistration.Controllers
{
    public class LoginUserController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            
            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            System.Web.Security.FormsAuthentication.SignOut();
            return RedirectToAction("Login", "LoginUser");
        }
        public ActionResult InvalidLogin()
        {
            ViewBag.message = "Invalid Username or Password";
            return View("Login");
        }
        [HttpPost]
        public ActionResult Logins(LoginDetail objLogin)
        {
            if (ModelState.IsValid)
            {

                UserInfosViewModel obj_details = new UserInfosViewModel();
                UserBLL obj_detail = new UserBLL();
                obj_details = obj_detail.GetDetails(objLogin.Username);

                if (obj_details != null)
                {
                    if (obj_details.Password == objLogin.Password)
                    {
                        Session["Fname"] = obj_details.Firstname;
                        Session["Lname"] = obj_details.Lastname;

                        return RedirectToAction("Home", "User");
                    }
                    else
                    {
                        return RedirectToAction("InvalidLogin", "LoginUser");
                    }
                }
                else

                    return RedirectToAction("InvalidLogin", "LoginUser");
            }
            else
            {
                return View("Login");
            }
           

        }
    }
}