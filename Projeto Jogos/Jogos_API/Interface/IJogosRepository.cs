using Jogos_API.Domains;

namespace Jogos_API.Interface
{
    public interface IJogosRepository
    {
        void Cadastrar(Jogo novoJogo);

        //Atualizar um jogo
        void Atualizar(Guid id, Jogo jogos);

        //Deletar um jogo
        void Deletar(Guid id);

        //Listar os jogo
        List<Jogo> Listar();

      
        
       
    }
}
