using System;
using System.Collections.Generic;

namespace WebSerino.Data;

public partial class Firmware
{
    public int Id { get; set; }

    public string Product { get; set; } = null!;

    public int Major { get; set; }

    public int Minor { get; set; }

    public int Revision { get; set; }

    public DateTime DateAdded { get; set; }

    public int RequiredMajor { get; set; }

    public int RequiredMinor { get; set; }

    public int RequiredRevision { get; set; }

    public string? AccountType { get; set; }

    public bool Enabled { get; set; }

    public string? Description { get; set; }

    public string? File1 { get; set; }

    public string? File2 { get; set; }

    public string? File3 { get; set; }

    public string? File4 { get; set; }

    public string? Type1 { get; set; }

    public string? Type2 { get; set; }

    public string? Type3 { get; set; }

    public string? Type4 { get; set; }

    public string? VersionNumber { get; set; }
}
