using System;
using System.Collections.Generic;

namespace WebSerino.Data;

public partial class Log
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int Code { get; set; }

    public string Action { get; set; } = null!;

    public DateTime DateAdded { get; set; }

    public string? Info { get; set; }

    public virtual User User { get; set; } = null!;
}
