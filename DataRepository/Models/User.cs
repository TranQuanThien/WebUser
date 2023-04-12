using System;
using System.Collections.Generic;

namespace WebSerino.Data;

public partial class User
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public DateTime DateCreated { get; set; }

    public string? CountryCode { get; set; }

    public string? AccountId { get; set; }

    public string? AccountType { get; set; }

    public string? Avatar { get; set; }

    public bool Deleted { get; set; }

    public DateTime? DateDeleterequested { get; set; }

    public DateTime? DateDeleted { get; set; }

    public bool DeleteRequested { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<Device> Devices { get; } = new List<Device>();

    public virtual ICollection<Log> Logs { get; } = new List<Log>();

    public virtual ICollection<Session> Sessions { get; } = new List<Session>();

    public virtual ICollection<Share> Shares { get; } = new List<Share>();
}
