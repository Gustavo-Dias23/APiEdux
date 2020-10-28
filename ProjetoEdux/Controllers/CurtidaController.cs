﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoEdux.Contexts;
using ProjetoEdux.Domains;
using ProjetoEdux.Repositories;
using System;
using Microsoft.EntityFrameworkCore;

namespace ProjetoEdux.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurtidaController : ControllerBase
    {
        private readonly CurtidaRepositories _curtidaRepositories;

        public CurtidaController()
        {
            _curtidaRepositories = new CurtidaRepositories();
        }

        /// <summary>
        /// Lista todos itens do Objeto Curtida
        /// </summary>
        /// <returns>Lista Curtida</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var curtidas = _curtidaRepositories.Listar();

                if (curtidas.Count == 0)
                    return NoContent();

                return Ok(new
                {
                    totalCount = curtidas.Count,
                    data = curtidas
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    statusCode = 400,
                    error = "Envie um email para email@email.com informando que ocorreu um erro no endpoint Get/Usuarios"
                });
            }
        }
        /// <summary>
        /// Busca Objeto curtida por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Busca curtida por id</returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                Curtida curtida = _curtidaRepositories.BuscarID(id);

                if (curtida == null)
                    return NotFound();

                return Ok(curtida);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}