using System;
using System.Collections.Generic;

namespace DatabaseFirstWeek3App.Models;

public partial class Store
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<StoreStaff> StoreStaffs { get; set; } = new List<StoreStaff>();
}
