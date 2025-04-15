using System;
using System.Collections.Generic;

namespace OrganicBasketsV2.Models;

public partial class Alarm
{
    public int AlarmId { get; set; }

    public int UserId { get; set; }

    public int DietId { get; set; }

    public TimeOnly AlarmTime { get; set; }

    public string? AlarmDays { get; set; }
}
