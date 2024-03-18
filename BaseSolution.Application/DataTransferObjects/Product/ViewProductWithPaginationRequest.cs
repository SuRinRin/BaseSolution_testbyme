using BaseSolution.Application.ValueObjects.Pagination;
using BaseSolution.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Application.DataTransferObjects.Product
{
	public class ViewProductWithPaginationRequest : PaginationRequest
	{
		public string Name { get; set; }
		public int Quantity { get; set; }
		public string Describe { get; set; }
		public double Price { get; set; }
		public string Series { get; set; }
		public string TradeMark { get; set; }
		public string CategoryName { get; set; }
		public ProductStatus Status { get; set; }
	}
}
