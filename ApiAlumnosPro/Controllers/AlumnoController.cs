using ApiAlumnosPro.Context;
using ApiAlumnosPro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiAlumnosPro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {
        private readonly AppDbContext context;
        public AlumnoController(AppDbContext context)
        {
            this.context = context;
        }

        // GET: api/<AlumnoController>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(context.Alumno.ToList());
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // GET api/<AlumnoController>/5
        [HttpGet("{id}", Name = "GetAlumno")]
        public ActionResult Get(int id)
        {
            try
            {
                var Alumno = context.Alumno.FirstOrDefault(f => f.id == id);
                return Ok(Alumno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<AlumnoController>
        [HttpPost]
        public ActionResult Post([FromBody] Alumno alumno)
        {
            try
            {
                context.Alumno.Add(alumno);
                context.SaveChanges();
                return CreatedAtRoute("GetAlumno", new { id = alumno.id }, alumno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<AlumnoController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Alumno alumno)
        {
            try
            {
                if (alumno.id == id)
                {
                    context.Entry(alumno).State = EntityState.Modified;
                    context.SaveChanges();
                    return CreatedAtRoute("GetAlumno", new { id = alumno.id }, alumno);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<AlumnoController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var alumno = context.Alumno.FirstOrDefault(f => f.id == id);
                if (alumno != null)
                {
                    context.Alumno.Remove(alumno);
                    context.SaveChanges();
                    return Ok(id);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
