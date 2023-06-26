using System;
using System.Collections.Generic;

namespace MindigFenyes.DB;

public partial class Trouble
{
    public int Id { get; set; }

    public int? AddressId { get; set; }

    public DateTime? TroubleDate { get; set; }

    public int? WorkerId { get; set; }

    public DateTime? RepairDate { get; set; }

    public int? RepairType { get; set; }
}
