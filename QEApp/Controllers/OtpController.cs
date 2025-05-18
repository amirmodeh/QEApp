using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QEApp.Application.Services.Otp;
using QEApp.Domain.Entities.Users;
using QEApp.Infrastructure.Persistence;
using QEApp.Web.Models;
using System.Threading.Tasks;

namespace QEApp.Web.Controllers
{
    public class OtpController : Controller
    {
        private readonly IOtpService _otpService;
        private readonly QEAppDbContext _qEAppDbContext;
        public OtpController(IOtpService otpService,QEAppDbContext qEAppDbContext)
        {
            _otpService = otpService;
            _qEAppDbContext= qEAppDbContext;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> SendCode(OtpViewModel model)
        {
            if (!ModelState.IsValid)
                return View("Index", model);

            string mobileNumber = model.Mobile; // یا قبلاً تبدیل‌شده

            var otpCode = new Random().Next(100000, 999999).ToString();

            var user = await _qEAppDbContext.Users.FirstOrDefaultAsync(u => u.MobileNumber == mobileNumber);
            if (user == null)
            {
                user = new User { MobileNumber = mobileNumber };
                _qEAppDbContext.Users.Add(user);
            }

            if ((DateTime.UtcNow - user.OtpGeneratedAt)?.TotalSeconds < 60)
            {
                ModelState.AddModelError("", "لطفاً کمی صبر کنید و دوباره تلاش کنید.");
                return View("Index", model);
            }

            user.OtpCode = otpCode;
            user.OtpGeneratedAt = DateTime.UtcNow;

            await _qEAppDbContext.SaveChangesAsync();

            bool result = await _otpService.SendOtpAsync(model.Mobile, otpCode);
            if (!result)
            {
                ModelState.AddModelError("", "ارسال پیامک با خطا مواجه شد.");
                return View("Index", model);
            }

            TempData["OtpSent"] = true;
            TempData["Mobile"] = model.Mobile;
            return RedirectToAction("Verify");
        }

        [HttpGet]
        public IActionResult Verify()
        {
            if (TempData["OtpSent"] == null)
                return RedirectToAction("Index");

            ViewBag.Mobile = TempData["Mobile"];
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Verify(string mobile, string code)
        {
            if (string.IsNullOrWhiteSpace(mobile))
            {
                ModelState.AddModelError(nameof(mobile), "شماره موبایل معتبر نیست.");
                ViewBag.Mobile = mobile;
                return View();
            }

            var user = await _qEAppDbContext.Users.FirstOrDefaultAsync(u => u.MobileNumber == mobile);
            if (user == null)
            {
                ModelState.AddModelError("", "کاربر یافت نشد.");
                ViewBag.Mobile = mobile;
                return View();
            }

            if (user.OtpCode != code)
            {
                ModelState.AddModelError("", "کد وارد شده صحیح نیست.");
                ViewBag.Mobile = mobile;
                return View();
            }

            // ✅ شبیه‌سازی ورود (در آینده با کوکی یا ClaimsIdentity تکمیل میشه)
            // مثلاً: HttpContext.SignInAsync(...)

            return Content("ورود موفق!"); // موقتاً
        }
    }
}