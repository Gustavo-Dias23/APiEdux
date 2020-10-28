using ProjetoEdux.Contexts;
using ProjetoEdux.Domains;
using ProjetoEdux.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEdux.Repositories
{
    public class CurtidaRepositories : ICurtida
    {
        private readonly EduxContext _ctx;
        public CurtidaRepositories()
        {
            _ctx = new EduxContext();
        }
        public Curtida BuscarID(int id)
        {
            try
            {
                return _ctx.Curtida.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Excluir(int id)
        {
            try
            {
                Curtida curtida = BuscarID(id);

                if (curtida == null)
                    throw new Exception("ID Curtida não encontrada.");
                _ctx.Curtida.Remove(curtida);
                _ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Curtida> Listar()
        {
            try
            {
                List<Curtida> curtidas = _ctx.Curtida.ToList();
                return curtidas;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
