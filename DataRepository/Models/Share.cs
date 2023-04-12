using System;
using System.Collections.Generic;

namespace WebSerino.Data;

public partial class Share
{
    public int Id { get; set; }

    public int DeviceId { get; set; }

    public int RecipientId { get; set; }

    public string? Name { get; set; }

    public string? Signature { get; set; }

    public bool? Accepted { get; set; }

    public bool? PermissionControl { get; set; }

    public bool? Disabled { get; set; }

    public DateTime DateAdded { get; set; }

    public DateTime? DateAccepted { get; set; }

    public DateTime? DateDisabled { get; set; }

    public string? Secret { get; set; }

    public int? UserIndex { get; set; }

    public bool Favorite { get; set; }

    public string? Seed { get; set; }

    public virtual Device Device { get; set; } = null!;

    public virtual User Recipient { get; set; } = null!;
}
