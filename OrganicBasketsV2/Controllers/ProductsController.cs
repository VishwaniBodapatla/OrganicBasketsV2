using Microsoft.AspNetCore.Mvc;
using OrganicBasketsV2.Models;
using Microsoft.EntityFrameworkCore;

namespace OrganicBasketsV2.Controllers
{
    public class ProductsController : Controller
    {
        private readonly OrganicBasketsContext _context;

        // Constructor for dependency injection of the database context
        public ProductsController(OrganicBasketsContext context)
        {
            _context = context;
        }

        // GET method to show the Add Product form
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        // POST method to handle form submission and insert data into the database
        [HttpPost]
        [HttpPost]
        public async Task<IActionResult> Add(AddProductViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // Handle multiple selections for PartOfDiet
                var selectedDiets = Request.Form["PartOfDiet"];
                var dietList = selectedDiets.ToList();  // List of selected diets

                // Handle multiple selections for RichInHealthBenefits
                var selectedHealthBenefits = Request.Form["RichInHealthBenefits"];
                var HealthBenefitsList = selectedHealthBenefits.ToList();  // List of selected health benefits


                var product = new Product
                {
                    Category = viewModel.Category,
                    ProductName = viewModel.ProductName,
                    Description = viewModel.Description,
                    Price = viewModel.Price,
                    Stock = viewModel.Stock,
                    VendorId = 0,
                    ProductImage = viewModel.ProductImage,
                    PackagingUnit = viewModel.Packaging_Unit,
                    PartOfDiet = string.Join(",", dietList),  // Join multiple selected diets as a comma-separated string
                    RichInHealthBenefits = string.Join(",", HealthBenefitsList),
                    IsVegan = viewModel.IsVegan,
                    IsGlutenFree = viewModel.IsGlutenFree
                };

                // Add product to the database
                _context.Products.Add(product);
                await _context.SaveChangesAsync();

                // Redirect to another action (e.g., Index) after successful insertion
                return RedirectToAction("List", "Products");
            }

            // If validation fails
            return RedirectToAction("List", "Products");
        }

        //I can use this later as admin
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var products = await _context.Products.ToListAsync();
            // convert products model into a view
            return View(products);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _context.Products.FindAsync(id);
            return View(product);
        }
        [HttpGet]
        public async Task<IActionResult> CustomerList()
        {
            // Fetch all products from the database
            var products = await _context.Products.ToListAsync();

            // Check if the user is authenticated and their role
            if (User.Identity.IsAuthenticated)
            {
                var isCustomer = User.IsInRole("Customer");

                // If the user is a customer, show the list with 'Add to Cart' options
                if (isCustomer)
                {
                    return View("ProductList", products);  // Customer's view with add to cart option
                }
            }

            // For non-logged-in or non-customer users, show regular product list view
            return View("ProductList", products);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Product viewModel)
        {
            var selectedDiets = Request.Form["PartOfDiet"];
            var dietList = selectedDiets.ToList();  // List of selected diets

            // Handle multiple selections for RichInHealthBenefits
            var selectedHealthBenefits = Request.Form["RichInHealthBenefits"];
            var HealthBenefitsList = selectedHealthBenefits.ToList();  // List of selected health benefits
            var product = await _context.Products.FindAsync(viewModel.ProductId);
            if (product is not null)
            {
                product.ProductName = viewModel.ProductName;
                product.Category = viewModel.Category;
                product.Description = viewModel.Description;
                product.Price = viewModel.Price;
                product.Stock = viewModel.Stock;
                product.ProductImage = viewModel.ProductImage;
                product.VendorId = 0;
                product.PackagingUnit = viewModel.PackagingUnit;
                product.PartOfDiet = string.Join(",", dietList);  // Join multiple selected diets as a comma-separated string
                product.RichInHealthBenefits = string.Join(",", HealthBenefitsList);
                product.IsVegan = viewModel.IsVegan;
                product.IsGlutenFree = viewModel.IsGlutenFree;

                await _context.SaveChangesAsync();

            }
            return RedirectToAction("List", "Products");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("List", "Products");
        }

        

    }
}
