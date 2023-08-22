using System;
using System.Collections.Generic;

namespace DatabaseFirstWeek3App.Models;

public partial class ProductSale
{
    public int Id { get; set; }

    public int ProductId { get; set; }

    public int SalesId { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual Sale Sales { get; set; } = null!;
}
