using System;
using System.Collections.Generic;

namespace WebSerino.Data;

public partial class Login
{
    public int Id { get; set; }

    public string? IpAddress { get; set; }

    public string? LastTried { get; set; }

    public int? FailedAttempts { get; set; }

    public string? PhoneNumber { get; set; }

    public string? CountryCode { get; set; }
}
