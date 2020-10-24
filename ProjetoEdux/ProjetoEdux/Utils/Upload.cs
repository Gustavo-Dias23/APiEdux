using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoEdux.Contexts;
using ProjetoEdux.Domains;

namespace ProjetoEdux.Utils
{
    public static class Upload
    {
       public static string Local(IFormFile file)
        {
            
                var nomeArquivo = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);
                var caminhoArquivo = Path.Combine(Directory.GetCurrentDirectory(), @"wwwRoot\upload\imagens", nomeArquivo);
                using var streamImagem = new FileStream(caminhoArquivo, FileMode.Create);
                file.CopyTo(streamImagem);
                return "http://localhost:5000/upload/imagens/" + nomeArquivo;
            
        }
    }
}