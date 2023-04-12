using System;
using System.Collections.Generic;

namespace WebSerino.Data;

public partial class Event
{
    public int Id { get; set; }

    public int DeviceId { get; set; }

    public int EventNumber { get; set; }

    public byte? EventCode { get; set; }

    public string? Content { get; set; }

    public string? SerialNumber { get; set; }

    public DateTime EventDate { get; set; }

    public int Type { get; set; }

    public int LayoutType { get; set; }

    public DateTime DateAdded { get; set; }

    public string Source { get; set; } = null!;

    public string? Sender { get; set; }

    public int? SenderId { get; set; }

    public virtual Device Device { get; set; } = null!;
}
