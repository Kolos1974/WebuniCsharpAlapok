using System;
using System.Collections.Generic;

namespace MindigFenyes.DB;

public partial class Address
{
    public int Id { get; set; }

    public int? PostalCode { get; set; }

    public string? Street { get; set; }

    public string? Number { get; set; }
}
