using dapperCrud.Dto;
using dapperCrud.Models;

namespace dapperCrud.Services
{
    public interface IUsuarioInterface
    {
        Task<ResponseModel<List<UsuarioListarDto>>> BuscarUsuarios();
        Task<ResponseModel<UsuarioListarDto>> Usuario(int IdUsuario);
        Task<ResponseModel<UsuarioListarDto>> CriarUsuario(UsuarioCriarDto usuarios);
        Task<ResponseModel<Usuarios>> DeletarUsuario(int IdUsuario);
        Task<ResponseModel<UsuarioListarDto>> AtualizarUsuario(int IdUsuario, UsuarioAlterarDto usuarioAlterado);

    }
}
