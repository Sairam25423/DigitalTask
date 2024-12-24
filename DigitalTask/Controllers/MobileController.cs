using System.Text.RegularExpressions;
using System.Web.Mvc;
using static System.Net.WebRequestMethods;

namespace DigitalTask.Controllers
{
    public class MobileController : Controller
    {
        public ActionResult ValidateMobile()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ValidateMobile(string mobileNumber, string mobileOtp)
        {
            if (mobileOtp == "1234" && mobileNumber.Length == 10)
            {
                Session["MobileNumber"] = mobileNumber;
                return RedirectToAction("ValidateEmail");
            }
            else
            {
                ModelState.AddModelError("MobileError", "Invalid OTP");
                return View();
            }
        }
        [HttpGet]
        public ActionResult ValidateEmail()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ValidateEmail(string email, string emailOtp)
        {
            if (Regex.IsMatch(email, @"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                if (emailOtp == "1234")
                {
                    Session["Email"] = email;
                    return RedirectToAction("PersonalDetails");
                }
                else
                {
                    ViewBag.ErrorMessage = "Invalid OTP!";
                    return View();
                }
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid Email!";
                return View();
            }
        }
        [HttpGet]
        public ActionResult PersonalDetails()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PersonalDetails(string name, string dob, string pan)
        {
            if (ModelState.IsValid)
            {
                TempData["Name"] = name;
                TempData["DOB"] = dob;
                TempData["PAN"] = pan;
                return RedirectToAction("RegistrationSuccess");
            }
            return View();
        }
        public ActionResult RegistrationSuccess()
        {
            var mobileNumber = Session["MobileNumber"];
            var email = Session["Email"];
            var name = TempData["Name"];
            var dob = TempData["DOB"];
            var pan = TempData["PAN"];

            ViewBag.MobileNumber = mobileNumber;
            ViewBag.Email = email;
            ViewBag.Name = name;
            ViewBag.DOB = dob;
            ViewBag.PAN = pan;

            return View();
        }
    }
}