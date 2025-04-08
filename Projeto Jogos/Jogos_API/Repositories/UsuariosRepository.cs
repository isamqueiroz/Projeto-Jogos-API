using Jogos_API.Context;
using Jogos_API.Domains;
using Jogos_API.Interface;
using Microsoft.EntityFrameworkCore;

namespace Jogos_API.Repositories
{
    public class UsuariosRepository : IUsuariosRepository
    {
        private readonly JogosDbContext _context;

        public UsuariosRepository(JogosDbContext context)
        {
            _context = context;
        }
        public void Atualizar(Guid id, Usuario usuario)
        {
            try
            {
                Usuario usuarioBuscado = _context.Usuario.Find(id)!;

                if (usuarioBuscado != null)
                {
                    usuarioBuscado.Nome = usuario.Nome;
                    usuarioBuscado.NickName = usuario.NickName;
                }

                _context.Usuario.Update(usuarioBuscado!);

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public void Cadastrar(Usuario usuario)
        {
            try
            {
                usuario.UsuarioId = Guid.NewGuid();

                _context.Usuario.Add(usuario);

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Deletar(Guid id)
        {
            try
            {
                Usuario usuario = _context.Usuario.Find(id)!;

                if (usuario != null)
                {
                    _context.Usuario.Remove(usuario);
                }
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public List<Usuario> Listar()
        {
            try
            {
                return _context.Usuario.ToList();
            }
            catch (Exception)
            {
                return new List<Usuario>();
            }
        }
    }
}
