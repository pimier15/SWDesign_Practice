using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FP_csharp1.C1
{
	class Ex1
	{
		//decimal RecomputeTotal( Order order , List<OrderLine> linesToDelete )
		//{
		//	var result = 0m;
		//	foreach ( var line in order.OrderLines)
		//	{
		//
		//	}
		//}

		class Product
		{
			public decimal Price { get; }
		}

		class OrderLine
		{
			public Product Product { get; }
			public int Quantity { get; }
		}

		class Order
		{
			public IEnumerable<OrderLine> OrderLines { get; }
		}
	}
}
