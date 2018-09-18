using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Aritex.Common.Models;
using Aritex.Domain.Models;

namespace Aritex.API.Controllers
{
    public class Titulo_TelaController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Titulo_Tela
        public IQueryable<Titulo_Tela> GetTitulo_Tela()
        {
            return db.Titulo_Tela;
        }

        // GET: api/Titulo_Tela/5
        [ResponseType(typeof(Titulo_Tela))]
        public async Task<IHttpActionResult> GetTitulo_Tela(int id)
        {
            Titulo_Tela titulo_Tela = await db.Titulo_Tela.FindAsync(id);
            if (titulo_Tela == null)
            {
                return NotFound();
            }

            return Ok(titulo_Tela);
        }

        // PUT: api/Titulo_Tela/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTitulo_Tela(int id, Titulo_Tela titulo_Tela)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != titulo_Tela.IdTitulo)
            {
                return BadRequest();
            }

            db.Entry(titulo_Tela).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Titulo_TelaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Titulo_Tela
        [ResponseType(typeof(Titulo_Tela))]
        public async Task<IHttpActionResult> PostTitulo_Tela(Titulo_Tela titulo_Tela)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Titulo_Tela.Add(titulo_Tela);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = titulo_Tela.IdTitulo }, titulo_Tela);
        }

        // DELETE: api/Titulo_Tela/5
        [ResponseType(typeof(Titulo_Tela))]
        public async Task<IHttpActionResult> DeleteTitulo_Tela(int id)
        {
            Titulo_Tela titulo_Tela = await db.Titulo_Tela.FindAsync(id);
            if (titulo_Tela == null)
            {
                return NotFound();
            }

            db.Titulo_Tela.Remove(titulo_Tela);
            await db.SaveChangesAsync();

            return Ok(titulo_Tela);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Titulo_TelaExists(int id)
        {
            return db.Titulo_Tela.Count(e => e.IdTitulo == id) > 0;
        }
    }
}