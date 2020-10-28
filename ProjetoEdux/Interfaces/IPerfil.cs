using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjetoEdux.Domains;

namespace ProjetoEdux.Interfaces
{
    interface IPerfil
    {
        List<Perfil> Listar();
        Perfil BuscarID(int id);
    }
}
