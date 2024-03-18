using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Domain.Entities
{
	public class ProductCategoryEntity
	{
		public Guid Id { get; set; }
		public Guid ProductId { get; set; }
		public Guid CategoryId { get; set; }
		public virtual ProductEntity? Product { get; set; }
		public virtual CategoryEntity? Category { get; set; }
		public virtual ICollection<CartDetailEntity>? CartDetail { get; set; }
		public virtual ICollection<OrderDetailEntity>? OrderDetail { get; }

	}
}
