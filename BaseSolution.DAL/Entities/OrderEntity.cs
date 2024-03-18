using BaseSolution.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Domain.Entities
{
	public class OrderEntity
	{
		public Guid Id { get; set; }
		public double TotalPrice { get; set; }
		public int TotalQuantity { get; set; }
		public OrderStatus Status { get; set; }
		public Guid UserId { get; set; }
		public virtual ICollection<OrderDetailEntity>? OrderDetail { get; set; }		
		public virtual UserEntity? User { get; set; }
	}
}
