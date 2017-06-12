using System.Web.Mvc;
using System.Web.Security;
using CCAN_Witel_Karawang.Models.ViewModel;
using CCAN_Witel_Karawang.Models.EntityManager;
namespace CCAN_Witel_Karawang.Controllers
{
    public class AccountController : Controller
    {
        [AllowAnonymous]
        public ActionResult SignUp()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult SignUp(UserSignUpView USV)
        {
            if (ModelState.IsValid)
            {
                UserManager UM = new UserManager();
                if (!UM.IsLoginNameExist(USV.NIK))
                {
                    UM.AddUserAccount(USV);
                    FormsAuthentication.SetAuthCookie(USV.Name, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError("", "Login Name already taken.");
            }
            return View();
        }

        [AllowAnonymous]
        public ActionResult LogIn()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult LogIn(UserLoginView ULV, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                UserManager UM = new UserManager();
                string password = UM.GetUserPassword(ULV.NIK);
                if (string.IsNullOrEmpty(password))
                    ModelState.AddModelError("", "NIK atau password salah.");
                else
                {
                    if (UM.IsPasswordMatch(ULV.NIK, ULV.Password)) // memanggil fungsi cek password hashed Bcrypt
                    {
                        FormsAuthentication.SetAuthCookie(ULV.NIK, false);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Password yang dimasukkan salah.");
                    }
                }
            }
            // If we got this far, something failed, redisplay form
            return View(ULV);
        }

        [Authorize]
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("LogIn", "Account");
        }
    }
}