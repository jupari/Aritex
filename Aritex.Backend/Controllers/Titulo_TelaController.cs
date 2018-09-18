using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Aritex.Backend.Models;
using Aritex.Common.Models;

namespace Aritex.Backend.Controllers
{
    public class Titulo_TelaController : Controller
    {
        private LocalDataContext db = new LocalDataContext();

        // GET: Titulo_Tela
        public async Task<ActionResult> Index()
        {
            return View(await db.Titulo_Tela.ToListAsync());
        }

        // GET: Titulo_Tela/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Titulo_Tela titulo_Tela = await db.Titulo_Tela.FindAsync(id);
            if (titulo_Tela == null)
            {
                return HttpNotFound();
            }
            return View(titulo_Tela);
        }

        // GET: Titulo_Tela/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Titulo_Tela/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "IdTitulo,Descripcion,Genero,Tipo_Cuello,Peso,Factor,Consumo,PxK,Activo")] Titulo_Tela titulo_Tela)
        {
            if (ModelState.IsValid)
            {
                db.Titulo_Tela.Add(titulo_Tela);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(titulo_Tela);
        }

        // GET: Titulo_Tela/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Titulo_Tela titulo_Tela = await db.Titulo_Tela.FindAsync(id);
            if (titulo_Tela == null)
            {
                return HttpNotFound();
            }
            return View(titulo_Tela);
        }

        // POST: Titulo_Tela/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "IdTitulo,Descripcion,Genero,Tipo_Cuello,Peso,Factor,Consumo,PxK,Activo")] Titulo_Tela titulo_Tela)
        {
            if (ModelState.IsValid)
            {
                db.Entry(titulo_Tela).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(titulo_Tela);
        }

        // GET: Titulo_Tela/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Titulo_Tela titulo_Tela = await db.Titulo_Tela.FindAsync(id);
            if (titulo_Tela == null)
            {
                return HttpNotFound();
            }
            return View(titulo_Tela);
        }

        // POST: Titulo_Tela/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Titulo_Tela titulo_Tela = await db.Titulo_Tela.FindAsync(id);
            db.Titulo_Tela.Remove(titulo_Tela);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
