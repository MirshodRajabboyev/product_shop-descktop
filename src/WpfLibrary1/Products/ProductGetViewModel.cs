using System;
using System.Collections.Generic;

namespace ViewModels.Products;

public class ProductGetViewModel
{
    public long Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public long BrandId { get; set; }

    public string BrandName { get; set; } = string.Empty;

    public long CategoryId { get; set; }

    public string CategoryName { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public double UnitPrice { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
