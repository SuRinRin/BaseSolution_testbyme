using BaseSolution.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Domain.Entities
{
	public class CartDetailEntity : EntityBase
	{
        public Guid Id { get; set; }
        public int Quantity { get; set; }   
        public double Price { get; set; }
        public Guid CartId { get; set; }
		public Guid ProductCategoryId { get; set; }
		public virtual CartEntity? Cart { get; set; }
        public virtual ProductCategoryEntity? ProductCategory {  get; set; }
    }
}
