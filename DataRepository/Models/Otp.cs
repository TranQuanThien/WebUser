using System;
using System.Collections.Generic;

namespace WebSerino.Data;

public partial class Otp
{
    public int Id { get; set; }

    public string? Code { get; set; }

    public DateTime? DateExpires { get; set; }

    public DateTime DateCreated { get; set; }

    public DateTime? DateUsed { get; set; }

    public string CountryCode { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public int? UserId { get; set; }

    public bool Invalidated { get; set; }

    public string? SmsNetwork { get; set; }

    public int? Type { get; set; }
}
