using System;
using System.Collections.Generic;

namespace OrganicBasketsV2.Models;

public partial class SupportTicket
{
    public int TicketId { get; set; }

    public int UserId { get; set; }

    public string IssueDescription { get; set; } = null!;

    public string? TicketStatus { get; set; }

    public DateTime? CreatedAt { get; set; }
}
