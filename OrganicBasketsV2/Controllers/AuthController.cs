using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using OrganicBasketsV2.Models;
using System;
using System.Linq;
using System.Security.Claims;

namespace OrganicBasketsV2.Controllers
{
    public class AuthController : Controller
    {
        private readonly OrganicBasketsContext _context;

        public AuthController(OrganicBasketsContext context)
        {
            _context = context;
        }

        // GET: Registration
        public IActionResult Registration()
        {
            return View();
        }

        // POST: Registration
        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Check if username or email already exists
                if (_context.Users.Any(u => u.Email == model.Email || u.UserName == model.UserName))
                {
                    ModelState.AddModelError("", "Email or Username already exists.");
                    return View(model);
                }

                // Create User Entry
                var user = new User
                {
                    FullName = model.FullName,
                    Email = model.Email,
                    UserName = model.UserName,
                    PhoneNumber = model.PhoneNumber,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.Password),
                    UserType = "Customer",
                    CreatedAt = DateTime.Now
                };

                _context.Users.Add(user);
                await _context.SaveChangesAsync();  // Save user first

                // Create Address Entry
                var address = new Address
                {
                    AddressLine1 = model.AddressLine1,
                    AddressLine2 = model.AddressLine2,
                    City = model.City,
                    State = model.State,
                    PostalCode = model.PostalCode,
                    Country = model.Country,
                    CreatedAt = DateTime.Now,
                    UserNameOrVendorName = model.UserName, // If UserName is still being used
                    UserType = model.UserType, // Adjust based on logic
                    LocationType = model.LocationType ?? "Home" // Ensure this is set to a valid non-null value
                };

                _context.Addresses.Add(address);
                await _context.SaveChangesAsync(); // Save address

                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [HttpPost]
        public async Task<IActionResult> Login(RegistrationViewModel model)
        {
            if (string.IsNullOrEmpty(model.UserName) || string.IsNullOrEmpty(model.Password))
            {
                ViewBag.ErrorMessage = "Username and Password are required.";
                return View(model);
            }

            var user = _context.Users.FirstOrDefault(u => u.UserName == model.UserName);

            if (user == null || string.IsNullOrEmpty(user.PasswordHash))
            {
                ViewBag.ErrorMessage = "Invalid Username or Password.";
                return View(model);
            }

            // Verify the password hash
            if (BCrypt.Net.BCrypt.Verify(model.Password, user.PasswordHash))
            {
                // Prepare user claims
                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.UserName ?? string.Empty),
            new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString())
        };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true, // Remember me across sessions
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(30)
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);

                TempData["SuccessMessage"] = "Login successful!";

                // Redirect to the CustomerList page after login
                return RedirectToAction("CustomerList", "Products");
            }

            ViewBag.ErrorMessage = "Invalid Username or Password.";
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
