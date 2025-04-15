using System;
using System.Collections.Generic;

namespace OrganicBasketsV2.Models;

public partial class HealthInfo
{
    public int HealthDataId { get; set; }

    public string UserName { get; set; } = null!;

    public int? Age { get; set; }

    public string? Gender { get; set; }

    public decimal? WeightKg { get; set; }

    public int? HeightCm { get; set; }

    public decimal? Bmi { get; set; }

    public string? DiseaseType { get; set; }

    public string? Severity { get; set; }

    public string? PhysicalActivityLevel { get; set; }

    public int? DailyCaloricIntake { get; set; }

    public int? CholesterolMgDL { get; set; }

    public string? BloodPressureMmHg { get; set; }

    public int? GlucoseMgDL { get; set; }

    public string? DietaryRestrictions { get; set; }

    public string? Allergies { get; set; }

    public string? PreferredCuisine { get; set; }

    public decimal? WeeklyExerciseHours { get; set; }

    public decimal? AdherenceToDietPlan { get; set; }

    public decimal? DietaryNutrientImbalanceScore { get; set; }

    public string? DietRecommendation { get; set; }

    public string? HaveNutAllergy { get; set; }

    public string? AnyDeficiency { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
