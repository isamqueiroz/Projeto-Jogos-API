using Jogos_API.Context;
using Jogos_API.Domains;
using Jogos_API.Interface;


namespace Jogos_API.Repositories
{
    public class JogosRepository : IJogosRepository
    {
        private readonly JogosDbContext _context;

        public JogosRepository(JogosDbContext context)
        {
            _context = context;
        }
        public void Atualizar(Guid id, Jogo jogo)
        {
            try
            {
                Jogo jogoBuscado = _context.Jogo.Find(id);

                if (jogo != null)
                {
                    jogo.NomeDoJogo = jogo.NomeDoJogo;
                    jogo.Plataforma = jogo.Plataforma;
                }

                _context.Jogo.Update(jogo!);

                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }
        }

       

        public void Cadastrar(Jogo novoJogo)
        {
            try
            {
                _context.Jogo.Add(novoJogo);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                Jogo jogoBuscado = _context.Jogo.Find(id)!;

                if (jogoBuscado != null)
                {
                    _context.Jogo.Remove(jogoBuscado);
                }
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Jogo> Listar()
        {
            try
            {
                return _context.Jogo.Select(e => new Jogo
                {
                    JogoId = e.JogoId,
                    NomeDoJogo = e.NomeDoJogo,
                    Plataforma = e.Plataforma
                }).ToList();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);




            }



        }

       
    }
}

