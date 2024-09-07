
using Infra.Repositories;

namespace Aplicacao.Services
{
    public class UsuarioService(UsuarioRepository usuarioRepository)
    {
        private readonly UsuarioRepository usuarioRepository = usuarioRepository;

        public void BuscarUsuariosService()
        {
            usuarioRepository.Buscar();
        }
        public void BuscarUsuariosIdService(int id)
        {
            usuarioRepository.BuscarId(id);
        }
        public void InserirUsuariosService(string nome, string email, string senha, int nivelAcesso_pk_nivel, int cargos_pk_cargos)
        {
            usuarioRepository.Inserir(nome, email, senha, nivelAcesso_pk_nivel, cargos_pk_cargos);
        }
        public void EditarUsuariosService(int pk_usuario, string nome, string email, string senha, int nivelAcesso_pk_nivel, int cargos_pk_cargos)
        {
            usuarioRepository.Editar(pk_usuario, nome, email, senha, nivelAcesso_pk_nivel, cargos_pk_cargos);
        }
        public void ApagarUsuariosService(int pk_usuario)
        {
            usuarioRepository.Apagar(pk_usuario);
        }

    }
}