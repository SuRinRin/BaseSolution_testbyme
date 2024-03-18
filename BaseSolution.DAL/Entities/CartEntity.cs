using BaseSolution.Domain.Entities.Base;
using BaseSolution.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Domain.Entities
{
	public class CartEntity : EntityBase
	{
		public Guid Id { get; set; }
		public double TotalPrice { get; set; }
		public int TotalQuantity { get; set; }
		public Guid UserId { get; set; }
		public virtual ICollection<CartDetailEntity>? CartDetails { get; set; }
		public virtual UserEntity? User { get; set; }
	}
}
