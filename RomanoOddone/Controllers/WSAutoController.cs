using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class WSAutoController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public WSAutoController(ApplicationDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public IEnumerable<Auto> Get()
        {
            return context.Auto.ToList();
        }
        //GET: Traer Auto por Modelo
        [HttpGet("GetByModel/{model}")] //endpoint
        public IEnumerable<Auto> GetByModel(string model)
        {
            var autos = (from a
                              in context.Auto
                              where a.Modelo == model
                              select a).ToList();
            return autos;
        }
        // Insertar
        [HttpPost]
        public ActionResult Post(Auto auto)
        {
            context.Auto.Add(auto);
            context.SaveChanges();
            return Ok();
        }

    }
}
