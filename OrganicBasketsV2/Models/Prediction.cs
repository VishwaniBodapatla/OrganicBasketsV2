using System;
using System.Collections.Generic;

namespace OrganicBasketsV2.Models;

public partial class Prediction
{
    public int PredictionId { get; set; }

    public string UserName { get; set; } = null!;

    public string? PredictedDiet { get; set; }

    public int? Rank { get; set; }

    public decimal? PredictionPercentage { get; set; }

    public DateTime? UpdatedAt { get; set; }
}
