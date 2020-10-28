using ProjetoEdux.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEdux.Interfaces
{
    interface IProfessorturma
    {
        List<Professorturma> ListarTodos();
        Professorturma BuscarPorID(int Id);
        Professorturma Cadastrar(Professorturma a);
        Professorturma Alterar(Professorturma a, int id);
        Professorturma Excluir(Professorturma a, int id);
    }
}
