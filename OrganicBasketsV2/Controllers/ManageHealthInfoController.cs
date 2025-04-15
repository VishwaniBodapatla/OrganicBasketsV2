using Microsoft.AspNetCore.Mvc;
using OrganicBasketsV2.Models;

namespace OrganicBasketsV2.Controllers
{
    public class ManageHealthInfoController : Controller
    {
        private readonly OrganicBasketsContext _context;

        public ManageHealthInfoController(OrganicBasketsContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(HealthInfo model)
        {
            var username = User.Identity.Name;
            // I want to add the health info the database
            var healthInfo = new HealthInfo
            {
                UserName = username,
                Age = model.Age,
                Gender = model.Gender,
                WeightKg = model.WeightKg,
                HeightCm = model.HeightCm,
                Bmi = model.WeightKg.HasValue && model.HeightCm.HasValue ? model.WeightKg.Value / (decimal)Math.Pow((double)(model.HeightCm.Value / 100.0), 2) : (decimal?)null,
                DiseaseType = model.DiseaseType,
                Severity = model.Severity,
                PhysicalActivityLevel = model.PhysicalActivityLevel,
                DailyCaloricIntake = model.DailyCaloricIntake,
                CholesterolMgDL = model.CholesterolMgDL,
                BloodPressureMmHg = model.BloodPressureMmHg,
                GlucoseMgDL = model.GlucoseMgDL,
                DietaryRestrictions = model.DietaryRestrictions,
                Allergies = model.Allergies,
                PreferredCuisine = model.PreferredCuisine,
                WeeklyExerciseHours = model.WeeklyExerciseHours,
                AdherenceToDietPlan = 80,
                //DietaryNutrientImbalanceScore = model.DietaryNutrientImbalanceScore,
            };
            _context.HealthInfos.Add(healthInfo);
            await _context.SaveChangesAsync();
            /// Redirect to the user's profile page
            return RedirectToAction("ProductList", "Products");
        }
    }

}
