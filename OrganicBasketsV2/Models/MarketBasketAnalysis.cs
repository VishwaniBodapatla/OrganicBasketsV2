using System;
using System.Collections.Generic;

namespace OrganicBasketsV2.Models;

public partial class MarketBasketAnalysis
{
    public int RuleId { get; set; }

    public string? AntecedentProducts { get; set; }

    public string? ConsequentProducts { get; set; }

    public decimal? Confidence { get; set; }

    public decimal? Support { get; set; }
}
