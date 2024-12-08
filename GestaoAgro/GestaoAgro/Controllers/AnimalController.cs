﻿using GestaoAgro.DataContexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestaoAgro.Controllers
{
    [ApiController]
    [Route("Animal")]
    public class AnimalController : Controller
    {
        private readonly AppDbContext _context;
        public AnimalController(AppDbContext context) {
            this._context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAnimal()
        {
            try {
                var listarAnimal = await _context.Animal.ToListAsync();

                return Ok(listarAnimal);
            }
            catch (Exception ex) 
            {
                return Problem(ex.Message);
            }
        }
        
    }
}
