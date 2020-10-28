using ProjetoEdux.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEdux.Interfaces
{
    interface IUsuario
    {
        List<Usuario> ListarTodos();
        Usuario BuscarPorID(int Id);
        Usuario Cadastrar(Usuario a);
        Usuario Alterar(Usuario a, int id);
        Usuario Excluir(Usuario a, int id);
    }
}
