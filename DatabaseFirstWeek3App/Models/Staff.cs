using System;
using System.Collections.Generic;

namespace DatabaseFirstWeek3App.Models;

public partial class Staff
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public virtual ICollection<Sale> Sales { get; set; } = new List<Sale>();

    public virtual StaffType? StaffType { get; set; }

    public virtual ICollection<StoreStaff> StoreStaffs { get; set; } = new List<StoreStaff>();
}
