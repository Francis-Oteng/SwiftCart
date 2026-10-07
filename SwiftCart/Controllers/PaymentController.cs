using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SwiftCart.Controllers
{
    public class PaymentController : Controller
    {
        [Authorize(Roles = "Customer")]
        [HttpPost]
        public async Task<IActionResult> Initialize(int orderId)
        {
            // 1. Find order
            // 2. Calculate amount
            // 3. Call Paystack Initialize Transaction API
            // 4. Save reference
            // 5. Return authorization URL

            return Json(new
            {
                success = true,
                message = "Payment initialized."
            });
        }

        [AllowAnonymous]
        public async Task<IActionResult> Callback(string reference)
        {
            // Redirect user to payment verification.

            return RedirectToAction(
                "Verify",
                new { reference });
        }

        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> Verify(string reference)
        {
            // Call Paystack Verify Transaction API.
            // Update Payment and Order.

            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Webhook()
        {
            // Validate Paystack webhook signature.
            // Process successful payment.

            return Ok();
        }
    }
}