using Jogos_API.Domains;

namespace Jogos_API.Interface
{
    public interface IUsuariosRepository
    {
        void Cadastrar(Usuario usuarios);

        //Atualizar um usuario
        void Atualizar(Guid id, Usuario usuarios);

        //Deletar um usuario 
        void Deletar(Guid id);

        //Listar os usuario
        List<Usuario> Listar();

       

       

      
    }
}
