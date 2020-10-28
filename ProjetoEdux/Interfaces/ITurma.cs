using ProjetoEdux.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEdux.Interfaces
{
    interface ITurma
    {
        List<Turma> ListarTodos();
        Turma BuscarPorID(int Id);
        Turma Cadastrar(Turma a);
        Turma Alterar(Turma a, int id);
        Turma Excluir(Turma a, int id);

    }
}
