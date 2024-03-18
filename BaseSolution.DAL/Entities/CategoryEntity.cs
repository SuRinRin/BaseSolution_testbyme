using BaseSolution.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Domain.Entities
{
	public class CategoryEntity : EntityBase
	{
        public Guid Id { get; set; }
		public string Name { get; set; }
		public virtual ICollection<ProductCategoryEntity>? ProductCategories { get; set; }
    }
}
