using System;
using System.Collections.Generic;

namespace WebSerino.Data;

public partial class UserTemp
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public DateTime? Dob { get; set; }

    public int? ManagerId { get; set; }
}
