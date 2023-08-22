using System;
using System.Collections.Generic;

namespace DatabaseFirstWeek3App.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public virtual ICollection<ProductSale> ProductSales { get; set; } = new List<ProductSale>();
}
