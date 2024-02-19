using BaseSolution.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Domain.Entities
{
	public class UserRoleEntity : EntityBase
	{
		public Guid Id { get; set; }
		public Guid UserId { get; set; }
		public Guid RoleId { get; set; }
		public virtual UserEntity? User { get; set; }
		public virtual RoleEntity? Role { get;set; }
	}
}
