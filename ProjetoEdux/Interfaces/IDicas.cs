using ProjetoEdux.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEdux.Interfaces
{
    interface IDicas
    {
        List<Dica> ListarTodos();
        Dica BuscarPorID(int Id);
        Dica Cadastrar(Dica a);
        Dica Alterar(Dica a, int id);
        Dica Excluir(Dica a, int id);

    }
}
