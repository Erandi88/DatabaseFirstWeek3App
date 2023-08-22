using System;
using System.Collections.Generic;

namespace DatabaseFirstWeek3App.Models;

public partial class StoreStaff
{
    public int Id { get; set; }

    public int StoreId { get; set; }

    public int StaffId { get; set; }

    public virtual Staff Staff { get; set; } = null!;

    public virtual Store Store { get; set; } = null!;
}
