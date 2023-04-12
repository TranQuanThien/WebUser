using System;
using System.Collections.Generic;

namespace WebSerino.Data;

public partial class Keyfob
{
    public int Id { get; set; }

    public int DeviceId { get; set; }

    public string SerialNumber { get; set; } = null!;

    public virtual Device Device { get; set; } = null!;
}
