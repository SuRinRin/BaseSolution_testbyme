using BaseSolution.Domain.Entities.Base;
using BaseSolution.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Domain.Entities
{
	public class UserEntity : EntityBase
	{
        public Guid Id { get; set; }
        public string UserName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public UserStatus Status { get; set; }
		public virtual ICollection<UserRoleEntity>? UserRoles { get; set; }
		public virtual CartEntity? Cart { get; set; }
		public virtual ICollection<OrderEntity>? Orders { get; set; }
	}
}
