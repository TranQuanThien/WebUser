using System;
using System.Collections.Generic;

namespace WebSerino.Data;

public partial class Session
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string Sessionkey { get; set; } = null!;

    public DateTime DateExpires { get; set; }

    public DateTime DateCreated { get; set; }

    public string? PhoneModel { get; set; }

    public string? SdkVersion { get; set; }

    public string? OsVersion { get; set; }

    public string? OsName { get; set; }

    public string? Vendor { get; set; }

    public string? Lang { get; set; }

    public string? Processors { get; set; }

    public bool? Retina { get; set; }

    public string? AppVersion { get; set; }

    public double? TotalRam { get; set; }

    public bool? FaceId { get; set; }

    public string? ChipName { get; set; }

    public bool Disabled { get; set; }

    public DateTime? LastActive { get; set; }

    public DateTime? DateDisabled { get; set; }

    public DateTime? DatePasswordverified { get; set; }

    public virtual User User { get; set; } = null!;
}
