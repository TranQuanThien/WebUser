using System;
using System.Collections.Generic;

namespace WebSerino.Data;

public partial class Verification
{
    public int Id { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public string CountryCode { get; set; } = null!;

    public byte Type { get; set; }

    public string Value { get; set; } = null!;

    public DateTime DateAdded { get; set; }

    public bool Success { get; set; }

    public DateTime? DateUsed { get; set; }
}
