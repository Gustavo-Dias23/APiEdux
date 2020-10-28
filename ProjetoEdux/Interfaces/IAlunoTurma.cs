﻿using ProjetoEdux.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoEdux.Interfaces
{
    interface IAlunoTurma
    {
        void Adicionar(AlunoTurma alunoTurma);
        void Excluir(int id);
        void Editar(AlunoTurma alunoTurma);
        List<AlunoTurma> Listar();
        AlunoTurma BuscarID(int id);
    }
}
