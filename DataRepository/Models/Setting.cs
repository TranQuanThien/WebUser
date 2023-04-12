using System;
using System.Collections.Generic;

namespace WebSerino.Data;

public partial class Setting
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Value { get; set; }

    public string? Description { get; set; }
}
