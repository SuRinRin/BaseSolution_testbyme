using AutoMapper;
using BaseSolution.Application.DataTransferObjects.User;
using BaseSolution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Infrastructure.Extensions.AutoMapperProfiles
{
	public class UsersProfiles : Profile
	{
        public UsersProfiles()
        {
            CreateMap<UserEntity,UserDTO>();
            CreateMap<UserCreateRequest,UserEntity>();
        }
    }
}
