﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NexCart.Orders.DTO
{
    public record ProductDTO(Guid ProductID, string? ProductName, string? Category, double UnitPrice, int QuantityInStock);
}
