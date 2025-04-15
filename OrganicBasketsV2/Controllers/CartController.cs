using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrganicBasketsV2.Models;

namespace OrganicBasketsV2.Controllers
{
    public class CartController : Controller
    {
        private readonly OrganicBasketsContext _context;

        public CartController(OrganicBasketsContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> AddToCart(int productId, int quantity)
        {
            var username = User.Identity.Name;

            var existingCartItem = await _context.Carts
                .FirstOrDefaultAsync(c => c.ProductId == productId && c.UserName == username);

            if (existingCartItem != null)
            {
                // If the item is already in the cart, update the quantity
                existingCartItem.Quantity += quantity;
            }
            else
            {
                // Add a new item to the cart
                var cartItem = new Cart
                {
                    ProductId = productId,
                    Quantity = quantity,
                    AddedAt = DateTime.Now,
                    UserName = username
                };
                _context.Carts.Add(cartItem);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("CustomerList", "Products");
        }

        [HttpGet]
        public async Task<IActionResult> GetCartDetails()
        {
            var username = User.Identity.Name;
            var cartItems = await _context.Carts
                .Where(c => c.UserName == username)
                .Join(_context.Products,
                      cart => cart.ProductId,
                      product => product.ProductId,
                      (cart, product) => new
                      {
                          ProductName = product.ProductName,
                          Quantity = cart.Quantity,
                          Price = product.Price
                      })
                .ToListAsync();

            return Json(cartItems);
        }
        [HttpGet]
        public async Task<IActionResult> YourCart()
        {
            var username = User.Identity.Name;

            var cartItems = await _context.Carts
                .Where(c => c.UserName == username)
                .Join(_context.Products,
                      cart => cart.ProductId,
                      product => product.ProductId,
                      (cart, product) => new ProductAndCartViewModel
                      {
                          Product = product,
                          Cart = cart
                      })
                .ToListAsync();

            return View(cartItems);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(int productId)
        {
            var username = User.Identity.Name;

            var cartItem = await _context.Carts
                .FirstOrDefaultAsync(c => c.ProductId == productId && c.UserName == username);

            if (cartItem != null)
            {
                _context.Carts.Remove(cartItem);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("YourCart");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCartQuantity([FromBody] UpdateCartQuantityRequest request)
        {
            var username = User.Identity.Name;

            var cartItem = await _context.Carts
                .FirstOrDefaultAsync(c => c.ProductId == request.ProductId && c.UserName == username);

            if (cartItem != null)
            {
                if (request.Quantity > 0)
                {
                    cartItem.Quantity = request.Quantity;
                }
                else
                {
                    // Remove the item from the cart if quantity is 0
                    _context.Carts.Remove(cartItem);
                }

                await _context.SaveChangesAsync();
            }

            return Ok();
        }


        public class UpdateCartQuantityRequest
        {
            public int ProductId { get; set; }
            public int Quantity { get; set; }
        }

        [HttpGet]
        public IActionResult ConfirmCheckout()
        {
            string currentUserName = User.Identity.Name;
            var cartItems = _context.Carts.Where(c => c.UserName == currentUserName).ToList();

            if (!cartItems.Any())
            {
                TempData["ErrorMessage"] = "Your cart is empty. Please add items before proceeding to checkout.";
                return RedirectToAction("Index");
            }

            // Passing cart details to the confirmation page
            var cartSummary = new
            {
                TotalItems = cartItems.Count,
                TotalAmount = cartItems.Sum(c => c.Quantity * _context.Products.FirstOrDefault(p => p.ProductId == c.ProductId).Price)
            };

            return View(cartSummary);
        }

        [HttpPost]
        public IActionResult PlaceOrder()
        {
            string currentUserName = User.Identity.Name;
            var cartItems = _context.Carts.Where(c => c.UserName == currentUserName).ToList();

            if (!cartItems.Any())
            {
                TempData["ErrorMessage"] = "Your cart is empty. Please add items before placing an order.";
                return RedirectToAction("Index");
            }

            // Create a new order
            var newOrder = new Order
            {
                OrderDate = DateTime.Now,
                OrderededAt = DateTime.Now,
                TotalAmount = cartItems.Sum(c => c.Quantity * _context.Products.FirstOrDefault(p => p.ProductId == c.ProductId).Price),
                OrderStatus = "Pending",
                UserName = currentUserName
            };

            _context.Orders.Add(newOrder);
            _context.SaveChanges(); // Save to generate OrderId

            // Add order details and update product stock
            foreach (var cartItem in cartItems)
            {
                var product = _context.Products.FirstOrDefault(p => p.ProductId == cartItem.ProductId);
                if (product != null)
                {
                    // Add order detail
                    var orderDetail = new OrderDetail
                    {
                        OrderId = newOrder.OrderId,
                        ProductId = product.ProductId,
                        Quantity = cartItem.Quantity,
                        Price = product.Price
                    };

                    _context.OrderDetails.Add(orderDetail);

                    // Update the product stock
                    product.Stock -= cartItem.Quantity; // Subtract the ordered quantity from the product stock
                }
            }

            _context.SaveChanges();

            // Clear user's cart
            _context.Carts.RemoveRange(cartItems);
            _context.SaveChanges();

            // Redirect to success page
            return RedirectToAction("OrderSuccess");
        }

        [HttpGet]
        public IActionResult OrderSuccess()
        {
            return View();
        }



    }
}
