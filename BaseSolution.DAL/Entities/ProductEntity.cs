﻿using BaseSolution.Domain.Entities.Base;
using BaseSolution.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Domain.Entities
{
	public class ProductEntity : EntityBase
	{
        public Guid Id { get; set; }

		public string Name { get; set; }

		public int Quantity { get; set; }

		public string Describe { get; set; }

		public double Price { get; set; }
		public string Series { get; set; }
		public string TradeMark { get; set; }
		public ProductStatus Status { get; set; }
		public virtual ICollection<ProductCategoryEntity>? ProductCategories { get; set; }
    }
}
