using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RomanoOddone.Data;
using RomanoOddone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RomanoOddone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public AutoController(ApplicationDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public IEnumerable<Auto> Get()
        {
            return context.Auto.ToList();
        }
        // Traer por Id 
        [HttpGet("{id}")]
        public ActionResult<Auto> Get(int id)
        {
            return context.Auto.Find(id);
        }
        // modificar Auto
        [HttpPut("{id}")]
        public ActionResult Put(int id, Auto auto)
        {

            if (id != auto.Id)
            {
                return BadRequest();
            }
            context.Entry(auto).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }
        //eliminar
        [HttpDelete("{id}")]
        public ActionResult<Auto> Delete(int id)
        {
            Auto auto = context.Auto.Find(id);
            if (auto == null)
            {
                return NotFound();
            }
            context.Auto.Remove(auto);
            context.SaveChanges();
            return auto;
        }

        //GET: traer por Marca y modelo
        [HttpGet("GetByModelAndBrand/{model}/{brand}")] 
        public IEnumerable<Auto> GetByModelAndBrand(string model, string brand)
        {
            var autos = (from a
                              in context.Auto
                         where a.Modelo == model
                         && a.Marca == brand
                         select a).ToList();
            return autos;
        }

        //GET: Taer por color 
        [HttpGet("GetByColor/{color}")] 
        public IEnumerable<Auto> GetByColor(string color)
        {
            var autos = (from a
                              in context.Auto
                              where a.Color == color
                              select a).ToList();
            return autos;
        }
    }
}
