using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Domain.Entities
{
	public class OrderDetailEntity
	{
		public Guid Id { get; set; }
		public string Note { get; set; }
		public int Quantity { get; set; }
		public double Price { get; set; }
		public Guid OrderId { get; set; }
		public Guid ProductCategoryId { get; set; }
		public virtual OrderEntity? OrderEntity { get; set; }
		public virtual ProductCategoryEntity? ProductCategory { get; set; }

	}
}
