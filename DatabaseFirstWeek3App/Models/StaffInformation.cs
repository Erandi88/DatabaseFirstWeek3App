using System;
using System.Collections.Generic;

namespace DatabaseFirstWeek3App.Models;

public partial class StaffInformation
{
    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public string WorkPlace { get; set; } = null!;
}
