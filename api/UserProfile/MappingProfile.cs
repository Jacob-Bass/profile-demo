using AutoMapper;
using Entities.Models;

namespace UserProfile
{
    public class MappingProfile: Profile
    {
        public MappingProfile() {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
        }
    }
}
