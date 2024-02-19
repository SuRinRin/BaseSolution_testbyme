using BaseSolution.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Domain.Entities
{
	public class RoleEntity : EntityBase
	{
        public Guid Id { get; set; }
		public string RoleName { get; set; }
		public string Desdescription { get; set; }

		public virtual ICollection<UserRoleEntity> UserRoles { get; set; }
	}
}
