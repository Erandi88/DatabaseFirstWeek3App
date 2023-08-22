using System;
using System.Collections.Generic;

namespace DatabaseFirstWeek3App.Models;

public partial class StaffType
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public virtual Staff IdNavigation { get; set; } = null!;
}
