using System;
using System.Collections.Generic;

namespace WebSerino.Data;

public partial class Activation
{
    public int Id { get; set; }

    public string SerialNumber { get; set; } = null!;

    public DateTime? DateAdded { get; set; }

    public string DeviceType { get; set; } = null!;

    public bool Disabled { get; set; }

    public DateTime? DateModified { get; set; }
}
