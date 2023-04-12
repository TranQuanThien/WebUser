using System;
using System.Collections.Generic;

namespace WebSerino.Data;

public partial class Device
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public string SerialNumber { get; set; } = null!;

    public DateTime DateAdded { get; set; }

    public string? Nickname { get; set; }

    public string? Avatar { get; set; }

    public bool? Favorite { get; set; }

    public int? Battery { get; set; }

    public string? FirmwareVersion { get; set; }

    public bool? Disabled { get; set; }

    public DateTime? DateDisabled { get; set; }

    public int? DeviceType { get; set; }

    public string? HardwareVersion { get; set; }

    public string? PrivateKey { get; set; }

    public string? MacAddress { get; set; }

    public bool? Wifi { get; set; }

    public bool? HasBridge { get; set; }

    public string? Ssid { get; set; }

    public string? Seed { get; set; }

    public int SeedCounter { get; set; }

    public DateTime? DateActivated { get; set; }

    public virtual ICollection<Event> Events { get; } = new List<Event>();

    public virtual ICollection<Keyfob> Keyfobs { get; } = new List<Keyfob>();

    public virtual ICollection<Share> Shares { get; } = new List<Share>();

    public virtual User User { get; set; } = null!;
}
