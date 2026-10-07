using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SwiftCart.Models;
using SwiftCart.Models.ViewModels.Account;

namespace SwiftCart.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // =========================================================
        // ABOUT
        // =========================================================

        [HttpGet]
        [AllowAnonymous]
        public IActionResult About()
        {
            var model = new AboutViewModel
            {
                AppName = "SwiftCart",
                Tagline = "Fast, fresh, and convenient grocery delivery.",

                Description =
                    "SwiftCart is an on-demand grocery delivery platform " +
                    "that connects customers with local stores and makes " +
                    "grocery shopping faster, easier, and more convenient.",

                Mission =
                    "To make grocery shopping simple and accessible by " +
                    "connecting customers with trusted local stores and " +
                    "providing reliable delivery.",

                Vision =
                    "To become a trusted digital grocery marketplace that " +
                    "connects communities with the products they need.",

                Services = new List<string>
                {
                    "Grocery Shopping",
                    "Local Store Marketplace",
                    "Fast Delivery",
                    "Real-Time Order Tracking",
                    "Flexible Delivery Slots",
                    "Secure Payments"
                },

                Email = "support@swiftcart.com",
                PhoneNumber = "+233 XX XXX XXXX",
                Location = "Kumasi, Ghana",

                Features = new List<AboutFeatureViewModel>
                {
                    new AboutFeatureViewModel
                    {
                        Title = "Fast Delivery",
                        Description =
                            "Get your groceries delivered quickly and conveniently.",
                        Icon = "bi bi-truck"
                    },

                    new AboutFeatureViewModel
                    {
                        Title = "Local Stores",
                        Description =
                            "Shop from trusted stores in your area.",
                        Icon = "bi bi-shop"
                    },

                    new AboutFeatureViewModel
                    {
                        Title = "Secure Payments",
                        Description =
                            "Pay securely using available payment methods.",
                        Icon = "bi bi-shield-check"
                    },

                    new AboutFeatureViewModel
                    {
                        Title = "Real-Time Tracking",
                        Description =
                            "Track your order and delivery progress.",
                        Icon = "bi bi-geo-alt"
                    }
                },

                TeamMembers = new List<AboutTeamMemberViewModel>()
            };

            return View(model);
        }

        // =========================================================
        // PRIVACY POLICY
        // =========================================================

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Privacy()
        {
            var model = new PrivacyViewModel
            {
                Title = "Privacy Policy",
                AppName = "SwiftCart",

                Introduction =
                    "At SwiftCart, we respect your privacy and are committed " +
                    "to protecting the personal information you provide when " +
                    "using our grocery delivery platform.",

                LastUpdated = DateTime.UtcNow,

                ContactEmail = "privacy@swiftcart.com",
                ContactPhone = "+233 XX XXX XXXX",
                ContactAddress = "Kumasi, Ghana",

                ConsentMessage =
                    "By using SwiftCart, you acknowledge that you have read " +
                    "and understood this Privacy Policy.",

                CookieMessage =
                    "SwiftCart may use cookies and similar technologies to " +
                    "improve your experience and maintain essential functionality.",

                Sections = new List<PrivacySectionViewModel>
                {
                    new PrivacySectionViewModel
                    {
                        Heading = "Information We Collect",

                        Content =
                            "We may collect information that you provide when " +
                            "creating an account, placing an order, or contacting us.",

                        Points = new List<string>
                        {
                            "Name and contact information",
                            "Email address",
                            "Phone number",
                            "Delivery addresses",
                            "Order information",
                            "Payment-related information"
                        }
                    },

                    new PrivacySectionViewModel
                    {
                        Heading = "How We Use Your Information",

                        Content =
                            "We use collected information to provide and improve " +
                            "SwiftCart services.",

                        Points = new List<string>
                        {
                            "Process and deliver orders",
                            "Manage your SwiftCart account",
                            "Communicate with you about orders",
                            "Provide customer support",
                            "Improve our services",
                            "Prevent fraud and unauthorized activity"
                        }
                    },

                    new PrivacySectionViewModel
                    {
                        Heading = "Payment Information",

                        Content =
                            "Payments are processed through supported payment " +
                            "providers. SwiftCart does not unnecessarily store " +
                            "sensitive payment credentials."
                    },

                    new PrivacySectionViewModel
                    {
                        Heading = "Location Information",

                        Content =
                            "Location information may be used when necessary " +
                            "to support delivery and order-tracking features.",

                        Points = new List<string>
                        {
                            "Delivery location",
                            "Store location",
                            "Rider delivery tracking"
                        }
                    },

                    new PrivacySectionViewModel
                    {
                        Heading = "Data Security",

                        Content =
                            "We take reasonable measures to protect your " +
                            "personal information against unauthorized access, " +
                            "alteration, disclosure, or destruction."
                    },

                    new PrivacySectionViewModel
                    {
                        Heading = "Your Privacy Rights",

                        Content =
                            "Depending on applicable law, you may have rights " +
                            "relating to your personal information.",

                        Points = new List<string>
                        {
                            "Request access to your information",
                            "Request correction of inaccurate information",
                            "Request deletion where applicable",
                            "Ask questions about how your information is used"
                        }
                    },

                    new PrivacySectionViewModel
                    {
                        Heading = "Changes to This Privacy Policy",

                        Content =
                            "We may update this Privacy Policy from time to time. " +
                            "Any changes will be reflected on this page."
                    },

                    new PrivacySectionViewModel
                    {
                        Heading = "Contact Us",

                        Content =
                            "If you have questions or concerns about this Privacy Policy, " +
                            "please contact the SwiftCart support team."
                    }
                }
            };

            return View(model);
        }

        // =========================================================
        // LOGIN
        // =========================================================

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string? returnUrl = null)
        {
            ViewBag.ReturnUrl = returnUrl;

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(
            LoginViewModel model,
            string? returnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ReturnUrl = returnUrl;
                return View(model);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                ModelState.AddModelError(
                    string.Empty,
                    "Invalid email or password.");

                ViewBag.ReturnUrl = returnUrl;
                return View(model);
            }

            if (!user.IsActive)
            {
                ModelState.AddModelError(
                    string.Empty,
                    "Your account has been disabled. Please contact support.");

                ViewBag.ReturnUrl = returnUrl;
                return View(model);
            }

            var result = await _signInManager.PasswordSignInAsync(
                user.UserName!,
                model.Password,
                model.RememberMe,
                lockoutOnFailure: true);

            if (result.Succeeded)
            {
                user.LastLoginDate = DateTime.UtcNow;

                await _userManager.UpdateAsync(user);

                if (!string.IsNullOrEmpty(returnUrl) &&
                    Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }

                return await RedirectUserByRole(user);
            }

            if (result.IsLockedOut)
            {
                ModelState.AddModelError(
                    string.Empty,
                    "Your account has been temporarily locked because of multiple failed login attempts.");

                ViewBag.ReturnUrl = returnUrl;
                return View(model);
            }

            if (result.IsNotAllowed)
            {
                ModelState.AddModelError(
                    string.Empty,
                    "You are not currently allowed to sign in.");

                ViewBag.ReturnUrl = returnUrl;
                return View(model);
            }

            ModelState.AddModelError(
                string.Empty,
                "Invalid email or password.");

            ViewBag.ReturnUrl = returnUrl;

            return View(model);
        }

        // =========================================================
        // REGISTER
        // =========================================================

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(
            RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var existingUser = await _userManager.FindByEmailAsync(
                model.Email);

            if (existingUser != null)
            {
                ModelState.AddModelError(
                    nameof(model.Email),
                    "An account with this email already exists.");

                return View(model);
            }

            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
                FullName = model.FullName,

                Role = UserRole.Customer,

                IsActive = true,
                CreatedDate = DateTime.UtcNow
            };

            var result = await _userManager.CreateAsync(
                user,
                model.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(
                        string.Empty,
                        error.Description);
                }

                return View(model);
            }

            var roleResult = await _userManager.AddToRoleAsync(
                user,
                UserRole.Customer.ToString());

            if (!roleResult.Succeeded)
            {
                await _userManager.DeleteAsync(user);

                foreach (var error in roleResult.Errors)
                {
                    ModelState.AddModelError(
                        string.Empty,
                        error.Description);
                }

                return View(model);
            }

            await _signInManager.SignInAsync(
                user,
                isPersistent: false);

            return RedirectToAction(
                "Dashboard",
                "Customer");
        }

        // =========================================================
        // LOGOUT
        // =========================================================

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction(
                "Index",
                "Home");
        }

        // =========================================================
        // FORGOT PASSWORD
        // =========================================================

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(
            ForgotPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByEmailAsync(
                model.Email);

            if (user != null && user.IsActive)
            {
                var token =
                    await _userManager.GeneratePasswordResetTokenAsync(
                        user);

                var resetUrl = Url.Action(
                    nameof(ResetPassword),
                    "Account",
                    new
                    {
                        email = user.Email,
                        token = token
                    },
                    Request.Scheme);

                // TODO:
                // Send resetUrl through your email service.
            }

            return RedirectToAction(
                nameof(ForgotPasswordConfirmation));
        }

        // =========================================================
        // FORGOT PASSWORD CONFIRMATION
        // =========================================================

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        // =========================================================
        // RESET PASSWORD
        // =========================================================

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPassword(
            string? email,
            string? token)
        {
            if (string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(token))
            {
                return RedirectToAction(nameof(Login));
            }

            var model = new ResetPasswordViewModel
            {
                Email = email,
                Token = token
            };

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(
            ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByEmailAsync(
                model.Email);

            if (user == null)
            {
                ModelState.AddModelError(
                    string.Empty,
                    "Invalid password reset request.");

                return View(model);
            }

            var result = await _userManager.ResetPasswordAsync(
                user,
                model.Token,
                model.Password);

            if (result.Succeeded)
            {
                return RedirectToAction(
                    nameof(ResetPasswordConfirmation));
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(
                    string.Empty,
                    error.Description);
            }

            return View(model);
        }

        // =========================================================
        // RESET PASSWORD CONFIRMATION
        // =========================================================

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPasswordConfirmation()
        {
            return View();
        }

        // =========================================================
        // ACCESS DENIED
        // =========================================================

        [HttpGet]
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }

        // =========================================================
        // ROLE-BASED REDIRECTION
        // =========================================================

        private async Task<IActionResult> RedirectUserByRole(
            ApplicationUser user)
        {
            var roles = await _userManager.GetRolesAsync(user);

            if (roles.Contains(UserRole.Admin.ToString()))
            {
                return RedirectToAction(
                    "Dashboard",
                    "Admin");
            }

            if (roles.Contains(UserRole.StoreOwner.ToString()))
            {
                return RedirectToAction(
                    "Dashboard",
                    "Store");
            }

            if (roles.Contains(UserRole.Rider.ToString()))
            {
                return RedirectToAction(
                    "Dashboard",
                    "Rider");
            }

            return RedirectToAction(
                "Dashboard",
                "Customer");
        }
    }
}