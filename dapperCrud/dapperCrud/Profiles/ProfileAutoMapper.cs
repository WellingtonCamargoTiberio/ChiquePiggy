using AutoMapper;
using dapperCrud.Dto;
using dapperCrud.Models;
using static dapperCrud.Dto.UsuarioAlterarDto;

namespace dapperCrud.Profiles
{
    public class ProfileAutoMapper : Profile
    {
        public ProfileAutoMapper()
        {
            CreateMap<Usuarios, UsuarioListarDto>();
            CreateMap<UsuarioCriarDto, Usuarios>();
            CreateMap<UsuarioAlterarDto, Usuarios>();
            CreateMap<UsuarioAlterarDto, UsuarioListarDto>();

        }
    }
}
