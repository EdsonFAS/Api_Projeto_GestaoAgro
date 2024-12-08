﻿using GestaoAgro.DataContexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using GestaoAgro.Model;
using GestaoAgro.Dtos;

namespace GestaoAgro.Controllers
{
    [ApiController]
    [Route("Usuario")]
    public class UsuarioController : Controller
    {
        private readonly AppDbContext _context;

        public UsuarioController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var listaUsuario = await _context.Usuario.ToListAsync();
                return Ok(listaUsuario);
            }

            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }

}
