using System;
using System.Collections.Generic;

namespace FinalExam.DB;

public partial class Trouble
{
    public int Id { get; set; }

    public int? PostalCode { get; set; }

    public string? Street { get; set; }

    public string? Number { get; set; }

    public DateTime? TroubleDate { get; set; }

    public int? WorkerId { get; set; }

    public DateTime? RepairDate { get; set; }

    public int? RepairTypeId { get; set; }
}
