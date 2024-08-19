using System;
using System.Collections.Generic;

namespace WebAPIMVC8CRUD.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string Color { get; set; } = null!;

    public int Price { get; set; }

    public string Image { get; set; } = null!;

    public int CategoryId { get; set; }
}
