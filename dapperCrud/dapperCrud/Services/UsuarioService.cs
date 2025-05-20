using AutoMapper;
using Dapper;
using dapperCrud.Dto;
using dapperCrud.Models;
using System.Data.SqlClient;


namespace dapperCrud.Services
{
    public class UsuarioService : IUsuarioInterface
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public UsuarioService(IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            _mapper = mapper;
        }
        public async Task<ResponseModel<List<UsuarioListarDto>>> BuscarUsuarios()
        {
            ResponseModel<List<UsuarioListarDto>> response = new ResponseModel<List<UsuarioListarDto>>();

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var usuarios = await connection.QueryAsync<Usuarios>("select * from Usuarios");

                if (usuarios.Count() == 0)
                {
                    response.Mensagem = "Nenhum usuário cadastrado";
                    response.Status = false;
                    return response;
                }

                var usuarioMappeado = _mapper.Map<List<UsuarioListarDto>>(usuarios);
                response.Dados = usuarioMappeado;
                response.Mensagem = "Retorno de usuários com sucesso";
                
            }
            return response;
        }
        private static async Task<IEnumerable<Usuarios>> ListarUsuarios(SqlConnection connection)
        {
            return await connection.QueryAsync<Usuarios>("select * from Usuarios");
        }
        public async Task<ResponseModel<UsuarioListarDto>> Usuario(int IdUsuario)
        {
            ResponseModel<UsuarioListarDto> response = new ResponseModel<UsuarioListarDto>();

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var usuario = await connection.QueryFirstOrDefaultAsync<Usuarios>("select * from Usuarios where id = @Id", new { Id = IdUsuario });

                if (usuario == null) 
                {
                    response.Mensagem = "Usuário não encontrado";
                    response.Status = false;
                    return response;
                }

                var usuarioMapeado = _mapper.Map<UsuarioListarDto>(usuario);

                response.Mensagem = "Usuário encontrado com sucesso";
                response.Dados=usuarioMapeado;
                
            }
            return response;
        }
        public async Task<ResponseModel<UsuarioListarDto>> CriarUsuario(UsuarioCriarDto usuarios)
        {
            ResponseModel<UsuarioListarDto> response = new ResponseModel<UsuarioListarDto>();

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var cadastroUsuario = await connection.QuerySingleOrDefaultAsync("insert into Usuarios (NomeCompleto, Cargo, CPF, Situacao, Salario, Senha, Email)" +
                                                                     " values(@NomeCompleto, @Cargo, @CPF, @Situacao, @Salario, @Senha, @Email)", usuarios);

                if (cadastroUsuario == 0)
                {
                    response.Mensagem = "Ocorreu um erro";
                    response.Status = false;
                    return response;
                }

                var usuariosMapeados = _mapper.Map<UsuarioListarDto>(cadastroUsuario);

                response.Dados = usuariosMapeados;
                response.Mensagem = "Usuarios listados com sucesso";
                
            }
            return response;
        }

        public async Task<ResponseModel<Usuarios>> DeletarUsuario(int IdUsuario)
        {
            ResponseModel<Usuarios> response = new ResponseModel<Usuarios>();

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var excluiUsuario = await connection.ExecuteAsync("Delete from Usuarios where Id = @Id", new {Id = IdUsuario});

                if(excluiUsuario == 0)
                {
                    response.Mensagem = "Usuário não existe ou já foi excluído";
                    response.Status = false;
                }

                response.Mensagem = "Usuário excluído com sucesso";
                
            }
                return response;
        }

        public async Task<ResponseModel<UsuarioListarDto>> AtualizarUsuario(int idUsuario, UsuarioAlterarDto usuarioAlterado)
        {
            ResponseModel<UsuarioListarDto> response = new ResponseModel<UsuarioListarDto>();

            using(var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var alterarUsuario = await connection.ExecuteAsync("Update Usuarios set NomeCompleto=@NomeCompleto, Cargo=@Cargo, CPF=@CPF, " +
                                                                    "Situacao=@Situacao, Salario=@Salario, Senha=@Senha, Email=@Email where Id = @Id", new
                                                                    {
                                                                        Id = idUsuario,
                                                                        usuarioAlterado.NomeCompleto,
                                                                        usuarioAlterado.Cargo,
                                                                        usuarioAlterado.CPF,
                                                                        usuarioAlterado.Situacao,
                                                                        usuarioAlterado.Salario,
                                                                        usuarioAlterado.Senha,
                                                                        usuarioAlterado.Email
                                                                    });

                if(alterarUsuario == 0)
                {
                    response.Mensagem = "Usuário não pode ser alterado";
                    response.Status = false;
                }

                var usuarioMapeado = _mapper.Map<UsuarioListarDto>(usuarioAlterado);

                response.Dados = usuarioMapeado;
                response.Mensagem = "Usuario alterado com sucesso";
            }
            return response;
        }
    }
}
