using System;
using System.Collections.Generic;

namespace DatabaseFirstWeek3App.Models;

public partial class Sale
{
    public int Id { get; set; }

    public DateTime DateOfSale { get; set; }

    public int StaffId { get; set; }

    public int ProductId { get; set; }

    public virtual ICollection<ProductSale> ProductSales { get; set; } = new List<ProductSale>();

    public virtual Staff Staff { get; set; } = null!;
}
