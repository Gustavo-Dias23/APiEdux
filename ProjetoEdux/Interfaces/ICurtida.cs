using ProjetoEdux.Domains; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEdux.Interfaces
{
    interface ICurtida
    {
        void Excluir(int id);
        List<Curtida> Listar();
    }
}
