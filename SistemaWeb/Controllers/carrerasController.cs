using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SistemaWeb.Contexto;

namespace SistemaWeb.Controllers
{
    [Authorize]
    public class carrerasController : Controller
    {
        private sistema_horarioEntities3 db = new sistema_horarioEntities3();
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);

        // GET: carreras
        public ActionResult Index()
        {
            ViewBag.displayRole = TempData["infoRol"];
            TempData.Keep("infoRol");
            var carreras = db.carreras.Include(c => c.dpto);
            return View(carreras.ToList());
        }

        // GET: carreras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            carrera carrera = db.carreras.Find(id);
            if (carrera == null)
            {
                return HttpNotFound();
            }
            return PartialView(carrera);
        }

        // GET: carreras/Create
        public ActionResult Create()
        {
            ViewBag.cod_dpto = new SelectList(db.dptoes, "cod_dpto", "nombre");
            return PartialView();
        }

        // POST: carreras/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cod_carrera,nombre,tipo_carrera,modalidad,cod_dpto")] carrera carrera)
        {


            SqlCommand cmd6 = new SqlCommand();
            DataTable dataTable6 = new DataTable();
            SqlDataAdapter sqlDA6; con.Open();
            cmd6.CommandText = "select *from carrera where nombre = '" + carrera.nombre + "'";
            cmd6.CommandType = CommandType.Text;
            cmd6.Connection = con;
            sqlDA6 = new SqlDataAdapter(cmd6);
            sqlDA6.Fill(dataTable6);
            con.Close();

            if (dataTable6.Rows.Count == 0)
            {


                if (ModelState.IsValid)
                {
                    db.carreras.Add(carrera);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

            }
            else
            {
                ViewBag.Message = "El registro ya existe!";
                return RedirectToAction("Index");
            }

            ViewBag.cod_dpto = new SelectList(db.dptoes, "cod_dpto", "nombre", carrera.cod_dpto);
            return View(carrera);
        }

        // GET: carreras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            carrera carrera = db.carreras.Find(id);
            if (carrera == null)
            {
                return HttpNotFound();
            }
            ViewBag.cod_dpto = new SelectList(db.dptoes, "cod_dpto", "nombre", carrera.cod_dpto);
            return PartialView(carrera);
        }

        // POST: carreras/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cod_carrera,nombre,tipo_carrera,modalidad,cod_dpto")] carrera carrera)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carrera).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cod_dpto = new SelectList(db.dptoes, "cod_dpto", "nombre", carrera.cod_dpto);
            return View(carrera);
        }

        // GET: carreras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            carrera carrera = db.carreras.Find(id);
            if (carrera == null)
            {
                return HttpNotFound();
            }
            return PartialView(carrera);
        }

        // POST: carreras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            carrera carrera = db.carreras.Find(id);
            db.carreras.Remove(carrera);
            db.SaveChanges();
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
