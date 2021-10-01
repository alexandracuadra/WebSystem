using SistemaWeb.Contexto;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaWeb.clases;
using System.Data;

namespace SistemaWeb.Controllers
{
    public class EditHorarioProfesorController : Controller
    {

        //  private lista_horario objlistaH;
        public object MessageBoxIcon { get; private set; }
        public object MessageBox { get; private set; }
       

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        private sistema_horarioEntities3 db = new sistema_horarioEntities3();
        // GET: EditHorarioProfesor

        public class per
        {
            string nombre { set; get; }
        }
        public ActionResult Index()
        {
            ViewBag.displayRole = TempData["infoRol"];
            TempData.Keep("infoRol");
            ViewBag.cod_dpto = new SelectList(db.dptoes, "cod_dpto", "nombre");                       
            ViewBag.profesor = new SelectList(db.profesores, "inss", "nombre");
            ViewBag.tipo_ciclo = new SelectList("12");
            ViewBag.año_estudio = new SelectList(db.anolectivoes, "cod_ano", "ano");
            String verificacion = "inactivo";
            Session["verificacion"] = verificacion;
           

            return View();
        }

        
        [HttpPost]

        public ActionResult EditProfesorHorario(editHorariofin ehf, horariogeneracion ph)
        {
            TempData["HorarioFin"] =ehf;
            TempData["HorarioGenerado"] = ph;
           

                if (Session["verificacion"].Equals("inactivo"))
            {
                //Borrar
                SqlCommand cmdcod = new SqlCommand();
                DataTable dataTablecod = new DataTable();
                SqlDataAdapter sqlDAcod; con.Open();
                //  cmd.CommandText = "select c.nombre, d.nombre from dpto d, carrera c where c.cod_dpto = d.cod_dpto and c.cod_carrera = " + carrera +";";
                cmdcod.CommandText = "DELETE FROM [dbo].[edithorario] where año_estudio BETWEEN 1 AND 10000;";
                cmdcod.CommandType = CommandType.Text;
                cmdcod.Connection = con;
                sqlDAcod = new SqlDataAdapter(cmdcod);
                sqlDAcod.Fill(dataTablecod);
                con.Close();


                Session["depar"] = ph.cod_dpto;
                Session["profe"] = ph.profesor;
                Session["ciclo"] = ph.tipo_ciclo;
                Session["año"] = ph.año_estudio;


                //consultar lista de horarios lunes
                SqlCommand cmd = new SqlCommand();
                DataTable dataTable = new DataTable();
                SqlDataAdapter sqlDA; con.Open();
                //  cmd.CommandText = "select c.nombre, d.nombre from dpto d, carrera c where c.cod_dpto = d.cod_dpto and c.cod_carrera = " + carrera +";";
                cmd.CommandText = "select p.nombre, a.nombre, m.nombre, g.nombre, pe.periodo, dd.dias, h.cod_horario from horario h inner join grupo g on h.cod_grupo = g.cod_grupo inner join pensum pen on h.cod_asig = pen.cod_asig inner join materia m on m.cod_materia = pen.cod_materia  inner join  profesores p on h.inss = p.inss inner join dpto d on p.cod_dpto = d.cod_dpto inner join plans pl on pen.cod_plan = pl.cod_plan inner join carrera c on c.cod_carrera = pl.cod_carrera inner join periodo pe on pe.cod_periodo = h.cod_periodo inner join aula a on h.cod_aula = a.cod_aula inner join  dia dd on dd.id = h.cod_dias inner join  anolectivo an_lec on an_lec.cod_ano = h.cod_ano where dd.dias ='lunes' and d.cod_dpto = " + ph.cod_dpto + " and p.inss = '" + ph.profesor + "' and g.tipo_ciclo = " + ph.tipo_ciclo + " and an_lec.cod_ano= '" + ph.año_estudio + "' order by id;";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                sqlDA = new SqlDataAdapter(cmd);
                sqlDA.Fill(dataTable);
                con.Close();

                //consultar lista de horarios martes
                SqlCommand cmd2 = new SqlCommand();
                DataTable dataTable2 = new DataTable();
                SqlDataAdapter sqlDA2; con.Open();
                //  cmd.CommandText = "select c.nombre, d.nombre from dpto d, carrera c where c.cod_dpto = d.cod_dpto and c.cod_carrera = " + carrera +";";
                cmd2.CommandText = "select p.nombre, a.nombre, m.nombre, g.nombre, pe.periodo, dd.dias, h.cod_horario  from horario h inner join grupo g on h.cod_grupo = g.cod_grupo inner join pensum pen on h.cod_asig = pen.cod_asig inner join materia m on m.cod_materia = pen.cod_materia  inner join  profesores p on h.inss = p.inss inner join dpto d on p.cod_dpto = d.cod_dpto inner join plans pl on pen.cod_plan = pl.cod_plan inner join carrera c on c.cod_carrera = pl.cod_carrera inner join periodo pe on pe.cod_periodo = h.cod_periodo inner join aula a on h.cod_aula = a.cod_aula inner join  dia dd on dd.id = h.cod_dias inner join  anolectivo an_lec on an_lec.cod_ano = h.cod_ano where dd.dias ='martes' and d.cod_dpto = " + ph.cod_dpto + " and p.inss = '" + ph.profesor + "' and g.tipo_ciclo = " + ph.tipo_ciclo + " and an_lec.cod_ano= '" + ph.año_estudio + "' order by id;";
                cmd2.CommandType = CommandType.Text;
                cmd2.Connection = con;
                sqlDA2 = new SqlDataAdapter(cmd2);
                sqlDA2.Fill(dataTable2);
                con.Close();

                //consultar lista de horarios miercoles
                SqlCommand cmd3 = new SqlCommand();
                DataTable dataTable3 = new DataTable();
                SqlDataAdapter sqlDA3; con.Open();
                //  cmd.CommandText = "select c.nombre, d.nombre from dpto d, carrera c where c.cod_dpto = d.cod_dpto and c.cod_carrera = " + carrera +";";
                cmd3.CommandText = "select p.nombre, a.nombre, m.nombre, g.nombre, pe.periodo, dd.dias, h.cod_horario  from horario h inner join grupo g on h.cod_grupo = g.cod_grupo inner join pensum pen on h.cod_asig = pen.cod_asig inner join materia m on m.cod_materia = pen.cod_materia  inner join  profesores p on h.inss = p.inss inner join dpto d on p.cod_dpto = d.cod_dpto inner join plans pl on pen.cod_plan = pl.cod_plan inner join carrera c on c.cod_carrera = pl.cod_carrera inner join periodo pe on pe.cod_periodo = h.cod_periodo inner join aula a on h.cod_aula = a.cod_aula inner join  dia dd on dd.id = h.cod_dias inner join  anolectivo an_lec on an_lec.cod_ano = h.cod_ano where dd.dias ='miercoles' and d.cod_dpto = " + ph.cod_dpto + " and p.inss = '" + ph.profesor + "' and g.tipo_ciclo = " + ph.tipo_ciclo + " and an_lec.cod_ano= '" + ph.año_estudio + "' order by id;";
                cmd3.CommandType = CommandType.Text;
                cmd3.Connection = con;
                sqlDA3 = new SqlDataAdapter(cmd3);
                sqlDA3.Fill(dataTable3);
                con.Close();

                //consultar lista de horarios jueves
                SqlCommand cmd4 = new SqlCommand();
                DataTable dataTable4 = new DataTable();
                SqlDataAdapter sqlDA4; con.Open();
                //  cmd.CommandText = "select c.nombre, d.nombre from dpto d, carrera c where c.cod_dpto = d.cod_dpto and c.cod_carrera = " + carrera +";";
                cmd4.CommandText = "select p.nombre, a.nombre, m.nombre, g.nombre, pe.periodo, dd.dias, h.cod_horario  from horario h inner join grupo g on h.cod_grupo = g.cod_grupo inner join pensum pen on h.cod_asig = pen.cod_asig inner join materia m on m.cod_materia = pen.cod_materia  inner join  profesores p on h.inss = p.inss inner join dpto d on p.cod_dpto = d.cod_dpto inner join plans pl on pen.cod_plan = pl.cod_plan inner join carrera c on c.cod_carrera = pl.cod_carrera inner join periodo pe on pe.cod_periodo = h.cod_periodo inner join aula a on h.cod_aula = a.cod_aula inner join  dia dd on dd.id = h.cod_dias  inner join  anolectivo an_lec on an_lec.cod_ano = h.cod_ano where dd.dias ='jueves' and d.cod_dpto = " + ph.cod_dpto + " and p.inss = '" + ph.profesor + "' and g.tipo_ciclo = " + ph.tipo_ciclo + " and an_lec.cod_ano= '" + ph.año_estudio + "' order by id;";
                cmd4.CommandType = CommandType.Text;
                cmd4.Connection = con;
                sqlDA4 = new SqlDataAdapter(cmd4);
                sqlDA4.Fill(dataTable4);
                con.Close();

                //consultar lista de horarios viernes
                SqlCommand cmd5 = new SqlCommand();
                DataTable dataTable5 = new DataTable();
                SqlDataAdapter sqlDA5; con.Open();
                //  cmd.CommandText = "select c.nombre, d.nombre from dpto d, carrera c where c.cod_dpto = d.cod_dpto and c.cod_carrera = " + carrera +";";
                cmd5.CommandText = "select p.nombre, a.nombre, m.nombre, g.nombre, pe.periodo, dd.dias, h.cod_horario  from horario h inner join grupo g on h.cod_grupo = g.cod_grupo inner join pensum pen on h.cod_asig = pen.cod_asig inner join materia m on m.cod_materia = pen.cod_materia  inner join  profesores p on h.inss = p.inss inner join dpto d on p.cod_dpto = d.cod_dpto inner join plans pl on pen.cod_plan = pl.cod_plan inner join carrera c on c.cod_carrera = pl.cod_carrera inner join periodo pe on pe.cod_periodo = h.cod_periodo inner join aula a on h.cod_aula = a.cod_aula inner join  dia dd on dd.id = h.cod_dias  inner join  anolectivo an_lec on an_lec.cod_ano = h.cod_ano where dd.dias ='viernes' and d.cod_dpto = " + ph.cod_dpto + " and p.inss = '" + ph.profesor + "' and g.tipo_ciclo = " + ph.tipo_ciclo + " and an_lec.cod_ano= '" + ph.año_estudio + "' order by id;";
                cmd5.CommandType = CommandType.Text;
                cmd5.Connection = con;
                sqlDA5 = new SqlDataAdapter(cmd5);
                sqlDA5.Fill(dataTable5);
                con.Close();


                //consultar lista de horarios periodo
                SqlCommand cmd1 = new SqlCommand();
                DataTable dataTable1 = new DataTable();
                SqlDataAdapter sqlDA1; con.Open();
                //  cmd.CommandText = "select c.nombre, d.nombre from dpto d, carrera c where c.cod_dpto = d.cod_dpto and c.cod_carrera = " + carrera +";";
                cmd1.CommandText = "select cod_periodo, periodo from periodo order by cod_periodo;";
                cmd1.CommandType = CommandType.Text;
                cmd1.Connection = con;
                sqlDA1 = new SqlDataAdapter(cmd1);
                sqlDA1.Fill(dataTable1);
                con.Close();


                ViewBag.TablaL = dataTable;
                ViewBag.TablaM = dataTable2;
                ViewBag.TablaMI = dataTable3;
                ViewBag.TablaJ = dataTable4;
                ViewBag.TablaV = dataTable5;
                ViewBag.Tabla1 = dataTable1;


            }


            if (Session["verificacion"].Equals("activo"))
            {                          

                string horan = ehf.id;
                string pro = ehf.profesor;
                string periodo = ehf.cod_periodo;
                string aula = ehf.aula;

                int ho = Int32.Parse((Session["le"]).ToString());


                //consultar bariables de recargos
                SqlCommand cmdcod = new SqlCommand();
                DataTable dataTablecod = new DataTable();
                SqlDataAdapter sqlDAcod; con.Open();
                //  cmd.CommandText = "select c.nombre, d.nombre from dpto d, carrera c where c.cod_dpto = d.cod_dpto and c.cod_carrera = " + carrera +";";
                cmdcod.CommandText = "select cod_dpto, profesor, tipo_ciclo, año_estudio from edithorario;";
                cmdcod.CommandType = CommandType.Text;
                cmdcod.Connection = con;
                sqlDAcod = new SqlDataAdapter(cmdcod);
                sqlDAcod.Fill(dataTablecod);
                con.Close();
                ph.cod_dpto = dataTablecod.Rows[0].ItemArray[0].ToString();
                ph.profesor = dataTablecod.Rows[0].ItemArray[1].ToString();
                ph.tipo_ciclo = dataTablecod.Rows[0].ItemArray[2].ToString();
                ph.año_estudio = dataTablecod.Rows[0].ItemArray[3].ToString();

                if (aula != null)
                {
                    // codigo de verificasion de aulas 

                    SqlCommand cmd6 = new SqlCommand();
                    DataTable dataTable6 = new DataTable();
                    SqlDataAdapter sqlDA6; con.Open();
                    cmd6.CommandText = "select cod_aula from aula where nombre ='" + aula + "' ;";
                    cmd6.CommandType = CommandType.Text;
                    cmd6.Connection = con;
                    sqlDA6 = new SqlDataAdapter(cmd6);
                    sqlDA6.Fill(dataTable6);
                    con.Close();
                    int cod_aula = Int32.Parse(dataTable6.Rows[0].ItemArray[0].ToString());


                    // codigo de periodo

                    SqlCommand cmd7 = new SqlCommand();
                    DataTable dataTable7 = new DataTable();
                    SqlDataAdapter sqlDA7; con.Open();
                    cmd7.CommandText = "select cod_periodo from periodo where periodo ='" + periodo + "' ;";
                    cmd7.CommandType = CommandType.Text;
                    cmd7.Connection = con;
                    sqlDA7 = new SqlDataAdapter(cmd7);
                    sqlDA7.Fill(dataTable7);
                    con.Close();
                    int cod_periodo = Int32.Parse(dataTable7.Rows[0].ItemArray[0].ToString());



                    SqlCommand cmd8 = new SqlCommand();
                    DataTable dataTable8 = new DataTable();
                    SqlDataAdapter sqlDA8; con.Open();
                    cmd8.CommandText = "select *from horario where cod_horario = " + ho + " ;";
                    cmd8.CommandType = CommandType.Text;
                    cmd8.Connection = con;
                    sqlDA8 = new SqlDataAdapter(cmd8);
                    sqlDA8.Fill(dataTable8);
                    con.Close();



                    int ano = Convert.ToInt32(dataTable8.Rows[0].ItemArray[8].ToString());
                    int asignatura = Convert.ToInt32(dataTable8.Rows[0].ItemArray[4].ToString());
                    int cod_grupo = Convert.ToInt32(dataTable8.Rows[0].ItemArray[6].ToString());
                    string fecha = dataTable8.Rows[0].ItemArray[3].ToString();
                    string inss = dataTable8.Rows[0].ItemArray[7].ToString();


                    //insercion

                    SqlCommand cmdI;
                    SqlDataAdapter sqlDAI = new SqlDataAdapter();
                    con.Open();
                    String sql = "";

                    sql = "INSERT INTO horario (cod_asig, cod_aula, cod_dias, cod_grupo, cod_periodo, fecha_ini, inss, cod_ano) VALUES (" + asignatura + ", " + cod_aula + ", " + horan + ", " + cod_grupo + ", " + cod_periodo + ",'" + fecha + "', '" + inss + "', " + ano + ");";
                    //cmd2.CommandText = "insert  into exportarcion values(null, '" + inss + "', 'cod_dpto', '" + cod_materia + "', '" + grupo + "', '" + cantidad + "', '" + anoestudio + "', 'tipo_ciclo', '" + tipogrupo + "')";
                    cmdI = new SqlCommand(sql, con);
                    sqlDAI.InsertCommand = new SqlCommand(sql, con);
                    sqlDAI.InsertCommand.ExecuteNonQuery();
                    cmdI.Dispose();
                    con.Close();

                    int? c = 0;
                    cod_aula = 0;


                    //Borrar
                    SqlCommand cmdcod1 = new SqlCommand();
                    DataTable dataTablecod1 = new DataTable();
                    SqlDataAdapter sqlDAcod1; con.Open();
                    //  cmd.CommandText = "select c.nombre, d.nombre from dpto d, carrera c where c.cod_dpto = d.cod_dpto and c.cod_carrera = " + carrera +";";
                    cmdcod1.CommandText = "DELETE FROM [dbo].[horario] where cod_horario = " + ho + ";";
                    cmdcod1.CommandType = CommandType.Text;
                    cmdcod1.Connection = con;
                    sqlDAcod1 = new SqlDataAdapter(cmdcod1);
                    sqlDAcod1.Fill(dataTablecod1);
                    con.Close();



                    Session["depar"] = ph.cod_dpto;
                    Session["profe"] = ph.profesor;
                    Session["ciclo"] = ph.tipo_ciclo;
                    Session["año"] = ph.año_estudio;


                    //consultar lista de horarios lunes
                    SqlCommand cmd = new SqlCommand();
                    DataTable dataTable = new DataTable();
                    SqlDataAdapter sqlDA; con.Open();
                    //  cmd.CommandText = "select c.nombre, d.nombre from dpto d, carrera c where c.cod_dpto = d.cod_dpto and c.cod_carrera = " + carrera +";";
                    cmd.CommandText = "select p.nombre, a.nombre, m.nombre, g.nombre, pe.periodo, dd.dias, h.cod_horario from horario h inner join grupo g on h.cod_grupo = g.cod_grupo inner join pensum pen on h.cod_asig = pen.cod_asig inner join materia m on m.cod_materia = pen.cod_materia  inner join  profesores p on h.inss = p.inss inner join dpto d on p.cod_dpto = d.cod_dpto inner join plans pl on pen.cod_plan = pl.cod_plan inner join carrera c on c.cod_carrera = pl.cod_carrera inner join periodo pe on pe.cod_periodo = h.cod_periodo inner join aula a on h.cod_aula = a.cod_aula inner join  dia dd on dd.id = h.cod_dias inner join  anolectivo an_lec on an_lec.cod_ano = h.cod_ano where dd.dias ='lunes' and d.cod_dpto = " + ph.cod_dpto + " and p.inss = '" + ph.profesor + "' and g.tipo_ciclo = " + ph.tipo_ciclo + " and an_lec.cod_ano= '" + ph.año_estudio + "' order by id;";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    sqlDA = new SqlDataAdapter(cmd);
                    sqlDA.Fill(dataTable);
                    con.Close();

                    //consultar lista de horarios martes
                    SqlCommand cmd2 = new SqlCommand();
                    DataTable dataTable2 = new DataTable();
                    SqlDataAdapter sqlDA2; con.Open();
                    //  cmd.CommandText = "select c.nombre, d.nombre from dpto d, carrera c where c.cod_dpto = d.cod_dpto and c.cod_carrera = " + carrera +";";
                    cmd2.CommandText = "select p.nombre, a.nombre, m.nombre, g.nombre, pe.periodo, dd.dias, h.cod_horario  from horario h inner join grupo g on h.cod_grupo = g.cod_grupo inner join pensum pen on h.cod_asig = pen.cod_asig inner join materia m on m.cod_materia = pen.cod_materia  inner join  profesores p on h.inss = p.inss inner join dpto d on p.cod_dpto = d.cod_dpto inner join plans pl on pen.cod_plan = pl.cod_plan inner join carrera c on c.cod_carrera = pl.cod_carrera inner join periodo pe on pe.cod_periodo = h.cod_periodo inner join aula a on h.cod_aula = a.cod_aula inner join  dia dd on dd.id = h.cod_dias inner join  anolectivo an_lec on an_lec.cod_ano = h.cod_ano where dd.dias ='martes' and d.cod_dpto = " + ph.cod_dpto + " and p.inss = '" + ph.profesor + "' and g.tipo_ciclo = " + ph.tipo_ciclo + " and an_lec.cod_ano= '" + ph.año_estudio + "' order by id;";
                    cmd2.CommandType = CommandType.Text;
                    cmd2.Connection = con;
                    sqlDA2 = new SqlDataAdapter(cmd2);
                    sqlDA2.Fill(dataTable2);
                    con.Close();

                    //consultar lista de horarios miercoles
                    SqlCommand cmd3 = new SqlCommand();
                    DataTable dataTable3 = new DataTable();
                    SqlDataAdapter sqlDA3; con.Open();
                    //  cmd.CommandText = "select c.nombre, d.nombre from dpto d, carrera c where c.cod_dpto = d.cod_dpto and c.cod_carrera = " + carrera +";";
                    cmd3.CommandText = "select p.nombre, a.nombre, m.nombre, g.nombre, pe.periodo, dd.dias, h.cod_horario  from horario h inner join grupo g on h.cod_grupo = g.cod_grupo inner join pensum pen on h.cod_asig = pen.cod_asig inner join materia m on m.cod_materia = pen.cod_materia  inner join  profesores p on h.inss = p.inss inner join dpto d on p.cod_dpto = d.cod_dpto inner join plans pl on pen.cod_plan = pl.cod_plan inner join carrera c on c.cod_carrera = pl.cod_carrera inner join periodo pe on pe.cod_periodo = h.cod_periodo inner join aula a on h.cod_aula = a.cod_aula inner join  dia dd on dd.id = h.cod_dias inner join  anolectivo an_lec on an_lec.cod_ano = h.cod_ano where dd.dias ='miercoles' and d.cod_dpto = " + ph.cod_dpto + " and p.inss = '" + ph.profesor + "' and g.tipo_ciclo = " + ph.tipo_ciclo + " and an_lec.cod_ano= '" + ph.año_estudio + "' order by id;";
                    cmd3.CommandType = CommandType.Text;
                    cmd3.Connection = con;
                    sqlDA3 = new SqlDataAdapter(cmd3);
                    sqlDA3.Fill(dataTable3);
                    con.Close();

                    //consultar lista de horarios jueves
                    SqlCommand cmd4 = new SqlCommand();
                    DataTable dataTable4 = new DataTable();
                    SqlDataAdapter sqlDA4; con.Open();
                    //  cmd.CommandText = "select c.nombre, d.nombre from dpto d, carrera c where c.cod_dpto = d.cod_dpto and c.cod_carrera = " + carrera +";";
                    cmd4.CommandText = "select p.nombre, a.nombre, m.nombre, g.nombre, pe.periodo, dd.dias, h.cod_horario  from horario h inner join grupo g on h.cod_grupo = g.cod_grupo inner join pensum pen on h.cod_asig = pen.cod_asig inner join materia m on m.cod_materia = pen.cod_materia  inner join  profesores p on h.inss = p.inss inner join dpto d on p.cod_dpto = d.cod_dpto inner join plans pl on pen.cod_plan = pl.cod_plan inner join carrera c on c.cod_carrera = pl.cod_carrera inner join periodo pe on pe.cod_periodo = h.cod_periodo inner join aula a on h.cod_aula = a.cod_aula inner join  dia dd on dd.id = h.cod_dias  inner join  anolectivo an_lec on an_lec.cod_ano = h.cod_ano where dd.dias ='jueves' and d.cod_dpto = " + ph.cod_dpto + " and p.inss = '" + ph.profesor + "' and g.tipo_ciclo = " + ph.tipo_ciclo + " and an_lec.cod_ano= '" + ph.año_estudio + "' order by id;";
                    cmd4.CommandType = CommandType.Text;
                    cmd4.Connection = con;
                    sqlDA4 = new SqlDataAdapter(cmd4);
                    sqlDA4.Fill(dataTable4);
                    con.Close();

                    //consultar lista de horarios viernes
                    SqlCommand cmd5 = new SqlCommand();
                    DataTable dataTable5 = new DataTable();
                    SqlDataAdapter sqlDA5; con.Open();
                    //  cmd.CommandText = "select c.nombre, d.nombre from dpto d, carrera c where c.cod_dpto = d.cod_dpto and c.cod_carrera = " + carrera +";";
                    cmd5.CommandText = "select p.nombre, a.nombre, m.nombre, g.nombre, pe.periodo, dd.dias, h.cod_horario  from horario h inner join grupo g on h.cod_grupo = g.cod_grupo inner join pensum pen on h.cod_asig = pen.cod_asig inner join materia m on m.cod_materia = pen.cod_materia  inner join  profesores p on h.inss = p.inss inner join dpto d on p.cod_dpto = d.cod_dpto inner join plans pl on pen.cod_plan = pl.cod_plan inner join carrera c on c.cod_carrera = pl.cod_carrera inner join periodo pe on pe.cod_periodo = h.cod_periodo inner join aula a on h.cod_aula = a.cod_aula inner join  dia dd on dd.id = h.cod_dias  inner join  anolectivo an_lec on an_lec.cod_ano = h.cod_ano where dd.dias ='viernes' and d.cod_dpto = " + ph.cod_dpto + " and p.inss = '" + ph.profesor + "' and g.tipo_ciclo = " + ph.tipo_ciclo + " and an_lec.cod_ano= '" + ph.año_estudio + "' order by id;";
                    cmd5.CommandType = CommandType.Text;
                    cmd5.Connection = con;
                    sqlDA5 = new SqlDataAdapter(cmd5);
                    sqlDA5.Fill(dataTable5);
                    con.Close();


                    //consultar lista de horarios periodo
                    SqlCommand cmd1 = new SqlCommand();
                    DataTable dataTable1 = new DataTable();
                    SqlDataAdapter sqlDA1; con.Open();
                    //  cmd.CommandText = "select c.nombre, d.nombre from dpto d, carrera c where c.cod_dpto = d.cod_dpto and c.cod_carrera = " + carrera +";";
                    cmd1.CommandText = "select cod_periodo, periodo from periodo order by cod_periodo;";
                    cmd1.CommandType = CommandType.Text;
                    cmd1.Connection = con;
                    sqlDA1 = new SqlDataAdapter(cmd1);
                    sqlDA1.Fill(dataTable1);
                    con.Close();


                    ViewBag.TablaL = dataTable;
                    ViewBag.TablaM = dataTable2;
                    ViewBag.TablaMI = dataTable3;
                    ViewBag.TablaJ = dataTable4;
                    ViewBag.TablaV = dataTable5;
                    ViewBag.Tabla1 = dataTable1;
                  


                }

            }
            else

            {
                //insercion
                SqlCommand cmdinser;
                SqlDataAdapter sqlDAinser = new SqlDataAdapter();
                con.Open();
                String sql = "";
                sql = "INSERT INTO edithorario (cod_dpto, profesor, tipo_ciclo, año_estudio) VALUES (" + ph.cod_dpto + ", '" + ph.profesor + "', " + ph.tipo_ciclo + ", " + ph.año_estudio + ")";
                //cmd2.CommandText = "insert  into exportarcion values(null, '" + inss + "', 'cod_dpto', '" + cod_materia + "', '" + grupo + "', '" + cantidad + "', '" + anoestudio + "', 'tipo_ciclo', '" + tipogrupo + "')";
                cmdinser = new SqlCommand(sql, con);
                sqlDAinser.InsertCommand = new SqlCommand(sql, con);
                sqlDAinser.InsertCommand.ExecuteNonQuery();
                cmdinser.Dispose();
                // ViewBag.cod_faculta = new SelectList(db.facultas, "cod_faculta", "nombre", dpto.cod_faculta);
                //return View(dpto);


                con.Close();

                Session["depar"] = ph.cod_dpto;
                Session["profe"] = ph.profesor;
                Session["ciclo"] = ph.tipo_ciclo;
                Session["año"] = ph.año_estudio;


                //consultar lista de horarios lunes
                SqlCommand cmd = new SqlCommand();
                DataTable dataTable = new DataTable();
                SqlDataAdapter sqlDA; con.Open();
                //  cmd.CommandText = "select c.nombre, d.nombre from dpto d, carrera c where c.cod_dpto = d.cod_dpto and c.cod_carrera = " + carrera +";";
                cmd.CommandText = "select p.nombre, a.nombre, m.nombre, g.nombre, pe.periodo, dd.dias, h.cod_horario from horario h inner join grupo g on h.cod_grupo = g.cod_grupo inner join pensum pen on h.cod_asig = pen.cod_asig inner join materia m on m.cod_materia = pen.cod_materia  inner join  profesores p on h.inss = p.inss inner join dpto d on p.cod_dpto = d.cod_dpto inner join plans pl on pen.cod_plan = pl.cod_plan inner join carrera c on c.cod_carrera = pl.cod_carrera inner join periodo pe on pe.cod_periodo = h.cod_periodo inner join aula a on h.cod_aula = a.cod_aula inner join  dia dd on dd.id = h.cod_dias inner join  anolectivo an_lec on an_lec.cod_ano = h.cod_ano where dd.dias ='lunes' and d.cod_dpto = " + ph.cod_dpto + " and p.inss = '" + ph.profesor + "' and g.tipo_ciclo = " + ph.tipo_ciclo + " and an_lec.cod_ano= '" + ph.año_estudio + "' order by id;";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                sqlDA = new SqlDataAdapter(cmd);
                sqlDA.Fill(dataTable);
                con.Close();

                //consultar lista de horarios martes
                SqlCommand cmd2 = new SqlCommand();
                DataTable dataTable2 = new DataTable();
                SqlDataAdapter sqlDA2; con.Open();
                //  cmd.CommandText = "select c.nombre, d.nombre from dpto d, carrera c where c.cod_dpto = d.cod_dpto and c.cod_carrera = " + carrera +";";
                cmd2.CommandText = "select p.nombre, a.nombre, m.nombre, g.nombre, pe.periodo, dd.dias, h.cod_horario  from horario h inner join grupo g on h.cod_grupo = g.cod_grupo inner join pensum pen on h.cod_asig = pen.cod_asig inner join materia m on m.cod_materia = pen.cod_materia  inner join  profesores p on h.inss = p.inss inner join dpto d on p.cod_dpto = d.cod_dpto inner join plans pl on pen.cod_plan = pl.cod_plan inner join carrera c on c.cod_carrera = pl.cod_carrera inner join periodo pe on pe.cod_periodo = h.cod_periodo inner join aula a on h.cod_aula = a.cod_aula inner join  dia dd on dd.id = h.cod_dias inner join  anolectivo an_lec on an_lec.cod_ano = h.cod_ano where dd.dias ='martes' and d.cod_dpto = " + ph.cod_dpto + " and p.inss = '" + ph.profesor + "' and g.tipo_ciclo = " + ph.tipo_ciclo + " and an_lec.cod_ano= '" + ph.año_estudio + "' order by id;";
                cmd2.CommandType = CommandType.Text;
                cmd2.Connection = con;
                sqlDA2 = new SqlDataAdapter(cmd2);
                sqlDA2.Fill(dataTable2);
                con.Close();

                //consultar lista de horarios miercoles
                SqlCommand cmd3 = new SqlCommand();
                DataTable dataTable3 = new DataTable();
                SqlDataAdapter sqlDA3; con.Open();
                //  cmd.CommandText = "select c.nombre, d.nombre from dpto d, carrera c where c.cod_dpto = d.cod_dpto and c.cod_carrera = " + carrera +";";
                cmd3.CommandText = "select p.nombre, a.nombre, m.nombre, g.nombre, pe.periodo, dd.dias, h.cod_horario  from horario h inner join grupo g on h.cod_grupo = g.cod_grupo inner join pensum pen on h.cod_asig = pen.cod_asig inner join materia m on m.cod_materia = pen.cod_materia  inner join  profesores p on h.inss = p.inss inner join dpto d on p.cod_dpto = d.cod_dpto inner join plans pl on pen.cod_plan = pl.cod_plan inner join carrera c on c.cod_carrera = pl.cod_carrera inner join periodo pe on pe.cod_periodo = h.cod_periodo inner join aula a on h.cod_aula = a.cod_aula inner join  dia dd on dd.id = h.cod_dias inner join  anolectivo an_lec on an_lec.cod_ano = h.cod_ano where dd.dias ='miercoles' and d.cod_dpto = " + ph.cod_dpto + " and p.inss = '" + ph.profesor + "' and g.tipo_ciclo = " + ph.tipo_ciclo + " and an_lec.cod_ano= '" + ph.año_estudio + "' order by id;";
                cmd3.CommandType = CommandType.Text;
                cmd3.Connection = con;
                sqlDA3 = new SqlDataAdapter(cmd3);
                sqlDA3.Fill(dataTable3);
                con.Close();

                //consultar lista de horarios jueves
                SqlCommand cmd4 = new SqlCommand();
                DataTable dataTable4 = new DataTable();
                SqlDataAdapter sqlDA4; con.Open();
                //  cmd.CommandText = "select c.nombre, d.nombre from dpto d, carrera c where c.cod_dpto = d.cod_dpto and c.cod_carrera = " + carrera +";";
                cmd4.CommandText = "select p.nombre, a.nombre, m.nombre, g.nombre, pe.periodo, dd.dias, h.cod_horario  from horario h inner join grupo g on h.cod_grupo = g.cod_grupo inner join pensum pen on h.cod_asig = pen.cod_asig inner join materia m on m.cod_materia = pen.cod_materia  inner join  profesores p on h.inss = p.inss inner join dpto d on p.cod_dpto = d.cod_dpto inner join plans pl on pen.cod_plan = pl.cod_plan inner join carrera c on c.cod_carrera = pl.cod_carrera inner join periodo pe on pe.cod_periodo = h.cod_periodo inner join aula a on h.cod_aula = a.cod_aula inner join  dia dd on dd.id = h.cod_dias  inner join  anolectivo an_lec on an_lec.cod_ano = h.cod_ano where dd.dias ='jueves' and d.cod_dpto = " + ph.cod_dpto + " and p.inss = '" + ph.profesor + "' and g.tipo_ciclo = " + ph.tipo_ciclo + " and an_lec.cod_ano= '" + ph.año_estudio + "' order by id;";
                cmd4.CommandType = CommandType.Text;
                cmd4.Connection = con;
                sqlDA4 = new SqlDataAdapter(cmd4);
                sqlDA4.Fill(dataTable4);
                con.Close();

                //consultar lista de horarios viernes
                SqlCommand cmd5 = new SqlCommand();
                DataTable dataTable5 = new DataTable();
                SqlDataAdapter sqlDA5; con.Open();
                //  cmd.CommandText = "select c.nombre, d.nombre from dpto d, carrera c where c.cod_dpto = d.cod_dpto and c.cod_carrera = " + carrera +";";
                cmd5.CommandText = "select p.nombre, a.nombre, m.nombre, g.nombre, pe.periodo, dd.dias, h.cod_horario  from horario h inner join grupo g on h.cod_grupo = g.cod_grupo inner join pensum pen on h.cod_asig = pen.cod_asig inner join materia m on m.cod_materia = pen.cod_materia  inner join  profesores p on h.inss = p.inss inner join dpto d on p.cod_dpto = d.cod_dpto inner join plans pl on pen.cod_plan = pl.cod_plan inner join carrera c on c.cod_carrera = pl.cod_carrera inner join periodo pe on pe.cod_periodo = h.cod_periodo inner join aula a on h.cod_aula = a.cod_aula inner join  dia dd on dd.id = h.cod_dias  inner join  anolectivo an_lec on an_lec.cod_ano = h.cod_ano where dd.dias ='viernes' and d.cod_dpto = " + ph.cod_dpto + " and p.inss = '" + ph.profesor + "' and g.tipo_ciclo = " + ph.tipo_ciclo + " and an_lec.cod_ano= '" + ph.año_estudio + "' order by id;";
                cmd5.CommandType = CommandType.Text;
                cmd5.Connection = con;
                sqlDA5 = new SqlDataAdapter(cmd5);
                sqlDA5.Fill(dataTable5);
                con.Close();


                //consultar lista de horarios periodo
                SqlCommand cmd1 = new SqlCommand();
                DataTable dataTable1 = new DataTable();
                SqlDataAdapter sqlDA1; con.Open();
                //  cmd.CommandText = "select c.nombre, d.nombre from dpto d, carrera c where c.cod_dpto = d.cod_dpto and c.cod_carrera = " + carrera +";";
                cmd1.CommandText = "select cod_periodo, periodo from periodo order by cod_periodo;";
                cmd1.CommandType = CommandType.Text;
                cmd1.Connection = con;
                sqlDA1 = new SqlDataAdapter(cmd1);
                sqlDA1.Fill(dataTable1);
                con.Close();

                ViewBag.TablaL = dataTable;
                ViewBag.TablaM = dataTable2;
                ViewBag.TablaMI = dataTable3;
                ViewBag.TablaJ = dataTable4;
                ViewBag.TablaV = dataTable5;
                ViewBag.Tabla1 = dataTable1;

              
            }



            return View();
        }


        public ActionResult EditResult()
        {
            var ehff=TempData["HorarioFin"];
            var phh=TempData["HorarioGenerado"];
            editHorariofin ehf = (editHorariofin)ehff;
            horariogeneracion ph = (horariogeneracion)phh;

            if (Session["verificacion"].Equals("inactivo"))
            {
                //Borrar
                SqlCommand cmdcod = new SqlCommand();
                DataTable dataTablecod = new DataTable();
                SqlDataAdapter sqlDAcod; con.Open();
                //  cmd.CommandText = "select c.nombre, d.nombre from dpto d, carrera c where c.cod_dpto = d.cod_dpto and c.cod_carrera = " + carrera +";";
                cmdcod.CommandText = "DELETE FROM [dbo].[edithorario] where año_estudio BETWEEN 1 AND 10000;";
                cmdcod.CommandType = CommandType.Text;
                cmdcod.Connection = con;
                sqlDAcod = new SqlDataAdapter(cmdcod);
                sqlDAcod.Fill(dataTablecod);
                con.Close();


                Session["depar"] = ph.cod_dpto;
                Session["profe"] = ph.profesor;
                Session["ciclo"] = ph.tipo_ciclo;
                Session["año"] = ph.año_estudio;


                //consultar lista de horarios lunes
                SqlCommand cmd = new SqlCommand();
                DataTable dataTable = new DataTable();
                SqlDataAdapter sqlDA; con.Open();
                //  cmd.CommandText = "select c.nombre, d.nombre from dpto d, carrera c where c.cod_dpto = d.cod_dpto and c.cod_carrera = " + carrera +";";
                cmd.CommandText = "select p.nombre, a.nombre, m.nombre, g.nombre, pe.periodo, dd.dias, h.cod_horario from horario h inner join grupo g on h.cod_grupo = g.cod_grupo inner join pensum pen on h.cod_asig = pen.cod_asig inner join materia m on m.cod_materia = pen.cod_materia  inner join  profesores p on h.inss = p.inss inner join dpto d on p.cod_dpto = d.cod_dpto inner join plans pl on pen.cod_plan = pl.cod_plan inner join carrera c on c.cod_carrera = pl.cod_carrera inner join periodo pe on pe.cod_periodo = h.cod_periodo inner join aula a on h.cod_aula = a.cod_aula inner join  dia dd on dd.id = h.cod_dias inner join  anolectivo an_lec on an_lec.cod_ano = h.cod_ano where dd.dias ='lunes' and d.cod_dpto = " + ph.cod_dpto + " and p.inss = '" + ph.profesor + "' and g.tipo_ciclo = " + ph.tipo_ciclo + " and an_lec.cod_ano= '" + ph.año_estudio + "' order by id;";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                sqlDA = new SqlDataAdapter(cmd);
                sqlDA.Fill(dataTable);
                con.Close();

                //consultar lista de horarios martes
                SqlCommand cmd2 = new SqlCommand();
                DataTable dataTable2 = new DataTable();
                SqlDataAdapter sqlDA2; con.Open();
                //  cmd.CommandText = "select c.nombre, d.nombre from dpto d, carrera c where c.cod_dpto = d.cod_dpto and c.cod_carrera = " + carrera +";";
                cmd2.CommandText = "select p.nombre, a.nombre, m.nombre, g.nombre, pe.periodo, dd.dias, h.cod_horario  from horario h inner join grupo g on h.cod_grupo = g.cod_grupo inner join pensum pen on h.cod_asig = pen.cod_asig inner join materia m on m.cod_materia = pen.cod_materia  inner join  profesores p on h.inss = p.inss inner join dpto d on p.cod_dpto = d.cod_dpto inner join plans pl on pen.cod_plan = pl.cod_plan inner join carrera c on c.cod_carrera = pl.cod_carrera inner join periodo pe on pe.cod_periodo = h.cod_periodo inner join aula a on h.cod_aula = a.cod_aula inner join  dia dd on dd.id = h.cod_dias inner join  anolectivo an_lec on an_lec.cod_ano = h.cod_ano where dd.dias ='martes' and d.cod_dpto = " + ph.cod_dpto + " and p.inss = '" + ph.profesor + "' and g.tipo_ciclo = " + ph.tipo_ciclo + " and an_lec.cod_ano= '" + ph.año_estudio + "' order by id;";
                cmd2.CommandType = CommandType.Text;
                cmd2.Connection = con;
                sqlDA2 = new SqlDataAdapter(cmd2);
                sqlDA2.Fill(dataTable2);
                con.Close();

                //consultar lista de horarios miercoles
                SqlCommand cmd3 = new SqlCommand();
                DataTable dataTable3 = new DataTable();
                SqlDataAdapter sqlDA3; con.Open();
                //  cmd.CommandText = "select c.nombre, d.nombre from dpto d, carrera c where c.cod_dpto = d.cod_dpto and c.cod_carrera = " + carrera +";";
                cmd3.CommandText = "select p.nombre, a.nombre, m.nombre, g.nombre, pe.periodo, dd.dias, h.cod_horario  from horario h inner join grupo g on h.cod_grupo = g.cod_grupo inner join pensum pen on h.cod_asig = pen.cod_asig inner join materia m on m.cod_materia = pen.cod_materia  inner join  profesores p on h.inss = p.inss inner join dpto d on p.cod_dpto = d.cod_dpto inner join plans pl on pen.cod_plan = pl.cod_plan inner join carrera c on c.cod_carrera = pl.cod_carrera inner join periodo pe on pe.cod_periodo = h.cod_periodo inner join aula a on h.cod_aula = a.cod_aula inner join  dia dd on dd.id = h.cod_dias inner join  anolectivo an_lec on an_lec.cod_ano = h.cod_ano where dd.dias ='miercoles' and d.cod_dpto = " + ph.cod_dpto + " and p.inss = '" + ph.profesor + "' and g.tipo_ciclo = " + ph.tipo_ciclo + " and an_lec.cod_ano= '" + ph.año_estudio + "' order by id;";
                cmd3.CommandType = CommandType.Text;
                cmd3.Connection = con;
                sqlDA3 = new SqlDataAdapter(cmd3);
                sqlDA3.Fill(dataTable3);
                con.Close();

                //consultar lista de horarios jueves
                SqlCommand cmd4 = new SqlCommand();
                DataTable dataTable4 = new DataTable();
                SqlDataAdapter sqlDA4; con.Open();
                //  cmd.CommandText = "select c.nombre, d.nombre from dpto d, carrera c where c.cod_dpto = d.cod_dpto and c.cod_carrera = " + carrera +";";
                cmd4.CommandText = "select p.nombre, a.nombre, m.nombre, g.nombre, pe.periodo, dd.dias, h.cod_horario  from horario h inner join grupo g on h.cod_grupo = g.cod_grupo inner join pensum pen on h.cod_asig = pen.cod_asig inner join materia m on m.cod_materia = pen.cod_materia  inner join  profesores p on h.inss = p.inss inner join dpto d on p.cod_dpto = d.cod_dpto inner join plans pl on pen.cod_plan = pl.cod_plan inner join carrera c on c.cod_carrera = pl.cod_carrera inner join periodo pe on pe.cod_periodo = h.cod_periodo inner join aula a on h.cod_aula = a.cod_aula inner join  dia dd on dd.id = h.cod_dias  inner join  anolectivo an_lec on an_lec.cod_ano = h.cod_ano where dd.dias ='jueves' and d.cod_dpto = " + ph.cod_dpto + " and p.inss = '" + ph.profesor + "' and g.tipo_ciclo = " + ph.tipo_ciclo + " and an_lec.cod_ano= '" + ph.año_estudio + "' order by id;";
                cmd4.CommandType = CommandType.Text;
                cmd4.Connection = con;
                sqlDA4 = new SqlDataAdapter(cmd4);
                sqlDA4.Fill(dataTable4);
                con.Close();

                //consultar lista de horarios viernes
                SqlCommand cmd5 = new SqlCommand();
                DataTable dataTable5 = new DataTable();
                SqlDataAdapter sqlDA5; con.Open();
                //  cmd.CommandText = "select c.nombre, d.nombre from dpto d, carrera c where c.cod_dpto = d.cod_dpto and c.cod_carrera = " + carrera +";";
                cmd5.CommandText = "select p.nombre, a.nombre, m.nombre, g.nombre, pe.periodo, dd.dias, h.cod_horario  from horario h inner join grupo g on h.cod_grupo = g.cod_grupo inner join pensum pen on h.cod_asig = pen.cod_asig inner join materia m on m.cod_materia = pen.cod_materia  inner join  profesores p on h.inss = p.inss inner join dpto d on p.cod_dpto = d.cod_dpto inner join plans pl on pen.cod_plan = pl.cod_plan inner join carrera c on c.cod_carrera = pl.cod_carrera inner join periodo pe on pe.cod_periodo = h.cod_periodo inner join aula a on h.cod_aula = a.cod_aula inner join  dia dd on dd.id = h.cod_dias  inner join  anolectivo an_lec on an_lec.cod_ano = h.cod_ano where dd.dias ='viernes' and d.cod_dpto = " + ph.cod_dpto + " and p.inss = '" + ph.profesor + "' and g.tipo_ciclo = " + ph.tipo_ciclo + " and an_lec.cod_ano= '" + ph.año_estudio + "' order by id;";
                cmd5.CommandType = CommandType.Text;
                cmd5.Connection = con;
                sqlDA5 = new SqlDataAdapter(cmd5);
                sqlDA5.Fill(dataTable5);
                con.Close();


                //consultar lista de horarios periodo
                SqlCommand cmd1 = new SqlCommand();
                DataTable dataTable1 = new DataTable();
                SqlDataAdapter sqlDA1; con.Open();
                //  cmd.CommandText = "select c.nombre, d.nombre from dpto d, carrera c where c.cod_dpto = d.cod_dpto and c.cod_carrera = " + carrera +";";
                cmd1.CommandText = "select cod_periodo, periodo from periodo order by cod_periodo;";
                cmd1.CommandType = CommandType.Text;
                cmd1.Connection = con;
                sqlDA1 = new SqlDataAdapter(cmd1);
                sqlDA1.Fill(dataTable1);
                con.Close();


                ViewBag.TablaL = dataTable;
                ViewBag.TablaM = dataTable2;
                ViewBag.TablaMI = dataTable3;
                ViewBag.TablaJ = dataTable4;
                ViewBag.TablaV = dataTable5;
                ViewBag.Tabla1 = dataTable1;


            }


            if (Session["verificacion"].Equals("activo"))
            {

                string horan = ehf.id;
                string pro = ehf.profesor;
                string periodo = ehf.cod_periodo;
                string aula = ehf.aula;

                int ho = Int32.Parse((Session["le"]).ToString());

                //consultar bariables de recargos
                SqlCommand cmdcod = new SqlCommand();
                DataTable dataTablecod = new DataTable();
                SqlDataAdapter sqlDAcod; con.Open();
                //  cmd.CommandText = "select c.nombre, d.nombre from dpto d, carrera c where c.cod_dpto = d.cod_dpto and c.cod_carrera = " + carrera +";";
                cmdcod.CommandText = "select cod_dpto, profesor, tipo_ciclo, año_estudio from edithorario;";
                cmdcod.CommandType = CommandType.Text;
                cmdcod.Connection = con;
                sqlDAcod = new SqlDataAdapter(cmdcod);
                sqlDAcod.Fill(dataTablecod);
                con.Close();
                ph.cod_dpto = dataTablecod.Rows[0].ItemArray[0].ToString();
                ph.profesor = dataTablecod.Rows[0].ItemArray[1].ToString();
                ph.tipo_ciclo = dataTablecod.Rows[0].ItemArray[2].ToString();
                ph.año_estudio = dataTablecod.Rows[0].ItemArray[3].ToString();

                if (aula != null)
                {
                    // codigo de verificasion de aulas 

                    SqlCommand cmd6 = new SqlCommand();
                    DataTable dataTable6 = new DataTable();
                    SqlDataAdapter sqlDA6; con.Open();
                    cmd6.CommandText = "select cod_aula from aula where nombre ='" + aula + "' ;";
                    cmd6.CommandType = CommandType.Text;
                    cmd6.Connection = con;
                    sqlDA6 = new SqlDataAdapter(cmd6);
                    sqlDA6.Fill(dataTable6);
                    con.Close();
                    int cod_aula = Int32.Parse(dataTable6.Rows[0].ItemArray[0].ToString());


                    // codigo de periodo

                    SqlCommand cmd7 = new SqlCommand();
                    DataTable dataTable7 = new DataTable();
                    SqlDataAdapter sqlDA7; con.Open();
                    cmd7.CommandText = "select cod_periodo from periodo where periodo ='" + periodo + "' ;";
                    cmd7.CommandType = CommandType.Text;
                    cmd7.Connection = con;
                    sqlDA7 = new SqlDataAdapter(cmd7);
                    sqlDA7.Fill(dataTable7);
                    con.Close();
                    int cod_periodo = Int32.Parse(dataTable7.Rows[0].ItemArray[0].ToString());



                    SqlCommand cmd8 = new SqlCommand();
                    DataTable dataTable8 = new DataTable();
                    SqlDataAdapter sqlDA8; con.Open();
                    cmd8.CommandText = "select *from horario where cod_horario = " + ho + " ;";
                    cmd8.CommandType = CommandType.Text;
                    cmd8.Connection = con;
                    sqlDA8 = new SqlDataAdapter(cmd8);
                    sqlDA8.Fill(dataTable8);
                    con.Close();



                    int ano = Convert.ToInt32(dataTable8.Rows[0].ItemArray[8].ToString());
                    int asignatura = Convert.ToInt32(dataTable8.Rows[0].ItemArray[4].ToString());
                    int cod_grupo = Convert.ToInt32(dataTable8.Rows[0].ItemArray[6].ToString());
                    string fecha = dataTable8.Rows[0].ItemArray[3].ToString();
                    string inss = dataTable8.Rows[0].ItemArray[7].ToString();


                    //insercion

                    SqlCommand cmdI;
                    SqlDataAdapter sqlDAI = new SqlDataAdapter();
                    con.Open();
                    String sql = "";

                    sql = "INSERT INTO horario (cod_asig, cod_aula, cod_dias, cod_grupo, cod_periodo, fecha_ini, inss, cod_ano) VALUES (" + asignatura + ", " + cod_aula + ", " + horan + ", " + cod_grupo + ", " + cod_periodo + ",'" + fecha + "', '" + inss + "', " + ano + ");";
                    //cmd2.CommandText = "insert  into exportarcion values(null, '" + inss + "', 'cod_dpto', '" + cod_materia + "', '" + grupo + "', '" + cantidad + "', '" + anoestudio + "', 'tipo_ciclo', '" + tipogrupo + "')";
                    cmdI = new SqlCommand(sql, con);
                    sqlDAI.InsertCommand = new SqlCommand(sql, con);
                    sqlDAI.InsertCommand.ExecuteNonQuery();
                    cmdI.Dispose();
                    con.Close();

                    int? c = 0;
                    cod_aula = 0;


                    //Borrar
                    SqlCommand cmdcod1 = new SqlCommand();
                    DataTable dataTablecod1 = new DataTable();
                    SqlDataAdapter sqlDAcod1; con.Open();
                    //  cmd.CommandText = "select c.nombre, d.nombre from dpto d, carrera c where c.cod_dpto = d.cod_dpto and c.cod_carrera = " + carrera +";";
                    cmdcod1.CommandText = "DELETE FROM [dbo].[horario] where cod_horario = " + ho + ";";
                    cmdcod1.CommandType = CommandType.Text;
                    cmdcod1.Connection = con;
                    sqlDAcod1 = new SqlDataAdapter(cmdcod1);
                    sqlDAcod1.Fill(dataTablecod1);
                    con.Close();



                    Session["depar"] = ph.cod_dpto;
                    Session["profe"] = ph.profesor;
                    Session["ciclo"] = ph.tipo_ciclo;
                    Session["año"] = ph.año_estudio;


                    //consultar lista de horarios lunes
                    SqlCommand cmd = new SqlCommand();
                    DataTable dataTable = new DataTable();
                    SqlDataAdapter sqlDA; con.Open();
                    //  cmd.CommandText = "select c.nombre, d.nombre from dpto d, carrera c where c.cod_dpto = d.cod_dpto and c.cod_carrera = " + carrera +";";
                    cmd.CommandText = "select p.nombre, a.nombre, m.nombre, g.nombre, pe.periodo, dd.dias, h.cod_horario from horario h inner join grupo g on h.cod_grupo = g.cod_grupo inner join pensum pen on h.cod_asig = pen.cod_asig inner join materia m on m.cod_materia = pen.cod_materia  inner join  profesores p on h.inss = p.inss inner join dpto d on p.cod_dpto = d.cod_dpto inner join plans pl on pen.cod_plan = pl.cod_plan inner join carrera c on c.cod_carrera = pl.cod_carrera inner join periodo pe on pe.cod_periodo = h.cod_periodo inner join aula a on h.cod_aula = a.cod_aula inner join  dia dd on dd.id = h.cod_dias inner join  anolectivo an_lec on an_lec.cod_ano = h.cod_ano where dd.dias ='lunes' and d.cod_dpto = " + ph.cod_dpto + " and p.inss = '" + ph.profesor + "' and g.tipo_ciclo = " + ph.tipo_ciclo + " and an_lec.cod_ano= '" + ph.año_estudio + "' order by id;";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    sqlDA = new SqlDataAdapter(cmd);
                    sqlDA.Fill(dataTable);
                    con.Close();

                    //consultar lista de horarios martes
                    SqlCommand cmd2 = new SqlCommand();
                    DataTable dataTable2 = new DataTable();
                    SqlDataAdapter sqlDA2; con.Open();
                    //  cmd.CommandText = "select c.nombre, d.nombre from dpto d, carrera c where c.cod_dpto = d.cod_dpto and c.cod_carrera = " + carrera +";";
                    cmd2.CommandText = "select p.nombre, a.nombre, m.nombre, g.nombre, pe.periodo, dd.dias, h.cod_horario  from horario h inner join grupo g on h.cod_grupo = g.cod_grupo inner join pensum pen on h.cod_asig = pen.cod_asig inner join materia m on m.cod_materia = pen.cod_materia  inner join  profesores p on h.inss = p.inss inner join dpto d on p.cod_dpto = d.cod_dpto inner join plans pl on pen.cod_plan = pl.cod_plan inner join carrera c on c.cod_carrera = pl.cod_carrera inner join periodo pe on pe.cod_periodo = h.cod_periodo inner join aula a on h.cod_aula = a.cod_aula inner join  dia dd on dd.id = h.cod_dias inner join  anolectivo an_lec on an_lec.cod_ano = h.cod_ano where dd.dias ='martes' and d.cod_dpto = " + ph.cod_dpto + " and p.inss = '" + ph.profesor + "' and g.tipo_ciclo = " + ph.tipo_ciclo + " and an_lec.cod_ano= '" + ph.año_estudio + "' order by id;";
                    cmd2.CommandType = CommandType.Text;
                    cmd2.Connection = con;
                    sqlDA2 = new SqlDataAdapter(cmd2);
                    sqlDA2.Fill(dataTable2);
                    con.Close();

                    //consultar lista de horarios miercoles
                    SqlCommand cmd3 = new SqlCommand();
                    DataTable dataTable3 = new DataTable();
                    SqlDataAdapter sqlDA3; con.Open();
                    //  cmd.CommandText = "select c.nombre, d.nombre from dpto d, carrera c where c.cod_dpto = d.cod_dpto and c.cod_carrera = " + carrera +";";
                    cmd3.CommandText = "select p.nombre, a.nombre, m.nombre, g.nombre, pe.periodo, dd.dias, h.cod_horario  from horario h inner join grupo g on h.cod_grupo = g.cod_grupo inner join pensum pen on h.cod_asig = pen.cod_asig inner join materia m on m.cod_materia = pen.cod_materia  inner join  profesores p on h.inss = p.inss inner join dpto d on p.cod_dpto = d.cod_dpto inner join plans pl on pen.cod_plan = pl.cod_plan inner join carrera c on c.cod_carrera = pl.cod_carrera inner join periodo pe on pe.cod_periodo = h.cod_periodo inner join aula a on h.cod_aula = a.cod_aula inner join  dia dd on dd.id = h.cod_dias inner join  anolectivo an_lec on an_lec.cod_ano = h.cod_ano where dd.dias ='miercoles' and d.cod_dpto = " + ph.cod_dpto + " and p.inss = '" + ph.profesor + "' and g.tipo_ciclo = " + ph.tipo_ciclo + " and an_lec.cod_ano= '" + ph.año_estudio + "' order by id;";
                    cmd3.CommandType = CommandType.Text;
                    cmd3.Connection = con;
                    sqlDA3 = new SqlDataAdapter(cmd3);
                    sqlDA3.Fill(dataTable3);
                    con.Close();

                    //consultar lista de horarios jueves
                    SqlCommand cmd4 = new SqlCommand();
                    DataTable dataTable4 = new DataTable();
                    SqlDataAdapter sqlDA4; con.Open();
                    //  cmd.CommandText = "select c.nombre, d.nombre from dpto d, carrera c where c.cod_dpto = d.cod_dpto and c.cod_carrera = " + carrera +";";
                    cmd4.CommandText = "select p.nombre, a.nombre, m.nombre, g.nombre, pe.periodo, dd.dias, h.cod_horario  from horario h inner join grupo g on h.cod_grupo = g.cod_grupo inner join pensum pen on h.cod_asig = pen.cod_asig inner join materia m on m.cod_materia = pen.cod_materia  inner join  profesores p on h.inss = p.inss inner join dpto d on p.cod_dpto = d.cod_dpto inner join plans pl on pen.cod_plan = pl.cod_plan inner join carrera c on c.cod_carrera = pl.cod_carrera inner join periodo pe on pe.cod_periodo = h.cod_periodo inner join aula a on h.cod_aula = a.cod_aula inner join  dia dd on dd.id = h.cod_dias  inner join  anolectivo an_lec on an_lec.cod_ano = h.cod_ano where dd.dias ='jueves' and d.cod_dpto = " + ph.cod_dpto + " and p.inss = '" + ph.profesor + "' and g.tipo_ciclo = " + ph.tipo_ciclo + " and an_lec.cod_ano= '" + ph.año_estudio + "' order by id;";
                    cmd4.CommandType = CommandType.Text;
                    cmd4.Connection = con;
                    sqlDA4 = new SqlDataAdapter(cmd4);
                    sqlDA4.Fill(dataTable4);
                    con.Close();

                    //consultar lista de horarios viernes
                    SqlCommand cmd5 = new SqlCommand();
                    DataTable dataTable5 = new DataTable();
                    SqlDataAdapter sqlDA5; con.Open();
                    //  cmd.CommandText = "select c.nombre, d.nombre from dpto d, carrera c where c.cod_dpto = d.cod_dpto and c.cod_carrera = " + carrera +";";
                    cmd5.CommandText = "select p.nombre, a.nombre, m.nombre, g.nombre, pe.periodo, dd.dias, h.cod_horario  from horario h inner join grupo g on h.cod_grupo = g.cod_grupo inner join pensum pen on h.cod_asig = pen.cod_asig inner join materia m on m.cod_materia = pen.cod_materia  inner join  profesores p on h.inss = p.inss inner join dpto d on p.cod_dpto = d.cod_dpto inner join plans pl on pen.cod_plan = pl.cod_plan inner join carrera c on c.cod_carrera = pl.cod_carrera inner join periodo pe on pe.cod_periodo = h.cod_periodo inner join aula a on h.cod_aula = a.cod_aula inner join  dia dd on dd.id = h.cod_dias  inner join  anolectivo an_lec on an_lec.cod_ano = h.cod_ano where dd.dias ='viernes' and d.cod_dpto = " + ph.cod_dpto + " and p.inss = '" + ph.profesor + "' and g.tipo_ciclo = " + ph.tipo_ciclo + " and an_lec.cod_ano= '" + ph.año_estudio + "' order by id;";
                    cmd5.CommandType = CommandType.Text;
                    cmd5.Connection = con;
                    sqlDA5 = new SqlDataAdapter(cmd5);
                    sqlDA5.Fill(dataTable5);
                    con.Close();


                    //consultar lista de horarios periodo
                    SqlCommand cmd1 = new SqlCommand();
                    DataTable dataTable1 = new DataTable();
                    SqlDataAdapter sqlDA1; con.Open();
                    //  cmd.CommandText = "select c.nombre, d.nombre from dpto d, carrera c where c.cod_dpto = d.cod_dpto and c.cod_carrera = " + carrera +";";
                    cmd1.CommandText = "select cod_periodo, periodo from periodo order by cod_periodo;";
                    cmd1.CommandType = CommandType.Text;
                    cmd1.Connection = con;
                    sqlDA1 = new SqlDataAdapter(cmd1);
                    sqlDA1.Fill(dataTable1);
                    con.Close();


                    ViewBag.TablaL = dataTable;
                    ViewBag.TablaM = dataTable2;
                    ViewBag.TablaMI = dataTable3;
                    ViewBag.TablaJ = dataTable4;
                    ViewBag.TablaV = dataTable5;
                    ViewBag.Tabla1 = dataTable1;



                }

            }
            else

            {
                //insercion
                SqlCommand cmdinser;
                SqlDataAdapter sqlDAinser = new SqlDataAdapter();
                con.Open();
                String sql = "";
                sql = "INSERT INTO edithorario (cod_dpto, profesor, tipo_ciclo, año_estudio) VALUES (" + ph.cod_dpto + ", '" + ph.profesor + "', " + ph.tipo_ciclo + ", " + ph.año_estudio + ")";
                //cmd2.CommandText = "insert  into exportarcion values(null, '" + inss + "', 'cod_dpto', '" + cod_materia + "', '" + grupo + "', '" + cantidad + "', '" + anoestudio + "', 'tipo_ciclo', '" + tipogrupo + "')";
                cmdinser = new SqlCommand(sql, con);
                sqlDAinser.InsertCommand = new SqlCommand(sql, con);
                sqlDAinser.InsertCommand.ExecuteNonQuery();
                cmdinser.Dispose();
                // ViewBag.cod_faculta = new SelectList(db.facultas, "cod_faculta", "nombre", dpto.cod_faculta);
                //return View(dpto);


                con.Close();

                Session["depar"] = ph.cod_dpto;
                Session["profe"] = ph.profesor;
                Session["ciclo"] = ph.tipo_ciclo;
                Session["año"] = ph.año_estudio;


                //consultar lista de horarios lunes
                SqlCommand cmd = new SqlCommand();
                DataTable dataTable = new DataTable();
                SqlDataAdapter sqlDA; con.Open();
                //  cmd.CommandText = "select c.nombre, d.nombre from dpto d, carrera c where c.cod_dpto = d.cod_dpto and c.cod_carrera = " + carrera +";";
                cmd.CommandText = "select p.nombre, a.nombre, m.nombre, g.nombre, pe.periodo, dd.dias, h.cod_horario from horario h inner join grupo g on h.cod_grupo = g.cod_grupo inner join pensum pen on h.cod_asig = pen.cod_asig inner join materia m on m.cod_materia = pen.cod_materia  inner join  profesores p on h.inss = p.inss inner join dpto d on p.cod_dpto = d.cod_dpto inner join plans pl on pen.cod_plan = pl.cod_plan inner join carrera c on c.cod_carrera = pl.cod_carrera inner join periodo pe on pe.cod_periodo = h.cod_periodo inner join aula a on h.cod_aula = a.cod_aula inner join  dia dd on dd.id = h.cod_dias inner join  anolectivo an_lec on an_lec.cod_ano = h.cod_ano where dd.dias ='lunes' and d.cod_dpto = " + ph.cod_dpto + " and p.inss = '" + ph.profesor + "' and g.tipo_ciclo = " + ph.tipo_ciclo + " and an_lec.cod_ano= '" + ph.año_estudio + "' order by id;";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                sqlDA = new SqlDataAdapter(cmd);
                sqlDA.Fill(dataTable);
                con.Close();

                //consultar lista de horarios martes
                SqlCommand cmd2 = new SqlCommand();
                DataTable dataTable2 = new DataTable();
                SqlDataAdapter sqlDA2; con.Open();
                //  cmd.CommandText = "select c.nombre, d.nombre from dpto d, carrera c where c.cod_dpto = d.cod_dpto and c.cod_carrera = " + carrera +";";
                cmd2.CommandText = "select p.nombre, a.nombre, m.nombre, g.nombre, pe.periodo, dd.dias, h.cod_horario  from horario h inner join grupo g on h.cod_grupo = g.cod_grupo inner join pensum pen on h.cod_asig = pen.cod_asig inner join materia m on m.cod_materia = pen.cod_materia  inner join  profesores p on h.inss = p.inss inner join dpto d on p.cod_dpto = d.cod_dpto inner join plans pl on pen.cod_plan = pl.cod_plan inner join carrera c on c.cod_carrera = pl.cod_carrera inner join periodo pe on pe.cod_periodo = h.cod_periodo inner join aula a on h.cod_aula = a.cod_aula inner join  dia dd on dd.id = h.cod_dias inner join  anolectivo an_lec on an_lec.cod_ano = h.cod_ano where dd.dias ='martes' and d.cod_dpto = " + ph.cod_dpto + " and p.inss = '" + ph.profesor + "' and g.tipo_ciclo = " + ph.tipo_ciclo + " and an_lec.cod_ano= '" + ph.año_estudio + "' order by id;";
                cmd2.CommandType = CommandType.Text;
                cmd2.Connection = con;
                sqlDA2 = new SqlDataAdapter(cmd2);
                sqlDA2.Fill(dataTable2);
                con.Close();

                //consultar lista de horarios miercoles
                SqlCommand cmd3 = new SqlCommand();
                DataTable dataTable3 = new DataTable();
                SqlDataAdapter sqlDA3; con.Open();
                //  cmd.CommandText = "select c.nombre, d.nombre from dpto d, carrera c where c.cod_dpto = d.cod_dpto and c.cod_carrera = " + carrera +";";
                cmd3.CommandText = "select p.nombre, a.nombre, m.nombre, g.nombre, pe.periodo, dd.dias, h.cod_horario  from horario h inner join grupo g on h.cod_grupo = g.cod_grupo inner join pensum pen on h.cod_asig = pen.cod_asig inner join materia m on m.cod_materia = pen.cod_materia  inner join  profesores p on h.inss = p.inss inner join dpto d on p.cod_dpto = d.cod_dpto inner join plans pl on pen.cod_plan = pl.cod_plan inner join carrera c on c.cod_carrera = pl.cod_carrera inner join periodo pe on pe.cod_periodo = h.cod_periodo inner join aula a on h.cod_aula = a.cod_aula inner join  dia dd on dd.id = h.cod_dias inner join  anolectivo an_lec on an_lec.cod_ano = h.cod_ano where dd.dias ='miercoles' and d.cod_dpto = " + ph.cod_dpto + " and p.inss = '" + ph.profesor + "' and g.tipo_ciclo = " + ph.tipo_ciclo + " and an_lec.cod_ano= '" + ph.año_estudio + "' order by id;";
                cmd3.CommandType = CommandType.Text;
                cmd3.Connection = con;
                sqlDA3 = new SqlDataAdapter(cmd3);
                sqlDA3.Fill(dataTable3);
                con.Close();

                //consultar lista de horarios jueves
                SqlCommand cmd4 = new SqlCommand();
                DataTable dataTable4 = new DataTable();
                SqlDataAdapter sqlDA4; con.Open();
                //  cmd.CommandText = "select c.nombre, d.nombre from dpto d, carrera c where c.cod_dpto = d.cod_dpto and c.cod_carrera = " + carrera +";";
                cmd4.CommandText = "select p.nombre, a.nombre, m.nombre, g.nombre, pe.periodo, dd.dias, h.cod_horario  from horario h inner join grupo g on h.cod_grupo = g.cod_grupo inner join pensum pen on h.cod_asig = pen.cod_asig inner join materia m on m.cod_materia = pen.cod_materia  inner join  profesores p on h.inss = p.inss inner join dpto d on p.cod_dpto = d.cod_dpto inner join plans pl on pen.cod_plan = pl.cod_plan inner join carrera c on c.cod_carrera = pl.cod_carrera inner join periodo pe on pe.cod_periodo = h.cod_periodo inner join aula a on h.cod_aula = a.cod_aula inner join  dia dd on dd.id = h.cod_dias  inner join  anolectivo an_lec on an_lec.cod_ano = h.cod_ano where dd.dias ='jueves' and d.cod_dpto = " + ph.cod_dpto + " and p.inss = '" + ph.profesor + "' and g.tipo_ciclo = " + ph.tipo_ciclo + " and an_lec.cod_ano= '" + ph.año_estudio + "' order by id;";
                cmd4.CommandType = CommandType.Text;
                cmd4.Connection = con;
                sqlDA4 = new SqlDataAdapter(cmd4);
                sqlDA4.Fill(dataTable4);
                con.Close();

                //consultar lista de horarios viernes
                SqlCommand cmd5 = new SqlCommand();
                DataTable dataTable5 = new DataTable();
                SqlDataAdapter sqlDA5; con.Open();
                //  cmd.CommandText = "select c.nombre, d.nombre from dpto d, carrera c where c.cod_dpto = d.cod_dpto and c.cod_carrera = " + carrera +";";
                cmd5.CommandText = "select p.nombre, a.nombre, m.nombre, g.nombre, pe.periodo, dd.dias, h.cod_horario  from horario h inner join grupo g on h.cod_grupo = g.cod_grupo inner join pensum pen on h.cod_asig = pen.cod_asig inner join materia m on m.cod_materia = pen.cod_materia  inner join  profesores p on h.inss = p.inss inner join dpto d on p.cod_dpto = d.cod_dpto inner join plans pl on pen.cod_plan = pl.cod_plan inner join carrera c on c.cod_carrera = pl.cod_carrera inner join periodo pe on pe.cod_periodo = h.cod_periodo inner join aula a on h.cod_aula = a.cod_aula inner join  dia dd on dd.id = h.cod_dias  inner join  anolectivo an_lec on an_lec.cod_ano = h.cod_ano where dd.dias ='viernes' and d.cod_dpto = " + ph.cod_dpto + " and p.inss = '" + ph.profesor + "' and g.tipo_ciclo = " + ph.tipo_ciclo + " and an_lec.cod_ano= '" + ph.año_estudio + "' order by id;";
                cmd5.CommandType = CommandType.Text;
                cmd5.Connection = con;
                sqlDA5 = new SqlDataAdapter(cmd5);
                sqlDA5.Fill(dataTable5);
                con.Close();


                //consultar lista de horarios periodo
                SqlCommand cmd1 = new SqlCommand();
                DataTable dataTable1 = new DataTable();
                SqlDataAdapter sqlDA1; con.Open();
                //  cmd.CommandText = "select c.nombre, d.nombre from dpto d, carrera c where c.cod_dpto = d.cod_dpto and c.cod_carrera = " + carrera +";";
                cmd1.CommandText = "select cod_periodo, periodo from periodo order by cod_periodo;";
                cmd1.CommandType = CommandType.Text;
                cmd1.Connection = con;
                sqlDA1 = new SqlDataAdapter(cmd1);
                sqlDA1.Fill(dataTable1);
                con.Close();

                ViewBag.TablaL = dataTable;
                ViewBag.TablaM = dataTable2;
                ViewBag.TablaMI = dataTable3;
                ViewBag.TablaJ = dataTable4;
                ViewBag.TablaV = dataTable5;
                ViewBag.Tabla1 = dataTable1;


            }



            return View();
            //return RedirectToAction("EditProfesorHorario");
        }

        [HttpGet]
        public ActionResult Edit(String listaedit)
        {
            Session["le"] = listaedit;
            //string ho = (Session["le"]).ToString();

            horariogeneracion hg = new horariogeneracion();
            editHorariofin horario = new editHorariofin();

          String verificacion = "activo";
           Session["verificacion"] = verificacion;
            string depar = (Session["depar"]).ToString();
            string profe = (Session["profe"]).ToString();
            string ciclo = (Session["ciclo"]).ToString();
            string año = (Session["año"]).ToString();

            hg.cod_dpto = depar;
            hg.profesor = profe;
            hg.tipo_ciclo = ciclo;
            hg.año_estudio = año;

            ViewBag.id = new SelectList(db.dias, "id", "dias");
            ViewBag.profesor = new SelectList(db.profesores, "inss", "nombre");
            ViewBag.Title = "Editar Horario";
            return PartialView(horario);
        }




        public JsonResult Getdias(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;

            int dia = id;

            Session["d"] = dia;

            periodo peri = new periodo();
            List<String> periodos = new List<string>();
            List<String> p = new List<string>();

            SqlCommand cmdp = new SqlCommand();
            DataTable dataTablep = new DataTable();
            SqlDataAdapter sqlDAp; con.Open();
            //  cmd.CommandText = "select c.nombre, d.nombre from dpto d, carrera c where c.cod_dpto = d.cod_dpto and c.cod_carrera = " + carrera +";";
            cmdp.CommandText = "select *from periodo;";
            cmdp.CommandType = CommandType.Text;
            cmdp.Connection = con;
            sqlDAp = new SqlDataAdapter(cmdp);
            sqlDAp.Fill(dataTablep);
            con.Close();

            for (int i = 0; i < dataTablep.Rows.Count; i++)
            {
                string nombre = dataTablep.Rows[i].ItemArray[1].ToString();
                periodos.Add(nombre);
            }

            SqlCommand cmdv = new SqlCommand();
            DataTable dataTablev = new DataTable();
            SqlDataAdapter sqlDAv; con.Open();
            //  cmd.CommandText = "select c.nombre, d.nombre from dpto d, carrera c where c.cod_dpto = d.cod_dpto and c.cod_carrera = " + carrera +";";
            cmdv.CommandText = "select h.cod_periodo, p.periodo from horario h, periodo p where h.cod_periodo=p.cod_periodo and cod_dias = " + id + ";";
            cmdv.CommandType = CommandType.Text;
            cmdv.Connection = con;
            sqlDAv = new SqlDataAdapter(cmdv);
            sqlDAv.Fill(dataTablev);
            con.Close();

            List<String> cod_periodo = new List<string>();


            for (int i = 0; i < dataTablev.Rows.Count; i++)
            {
                string nombre = dataTablev.Rows[i].ItemArray[1].ToString();
                cod_periodo.Add(nombre);
            }
            //List<periodo> carreraList = periodo.Except(cod_periodo);
            var diferperiodo = periodos.Except(cod_periodo);
          
            peri.nombre = diferperiodo;




            return Json(peri.nombre, JsonRequestBehavior.AllowGet);
        }





        public JsonResult Getperiodo(string cod_periodo)
        {
            db.Configuration.ProxyCreationEnabled = false;

            periodo peri = new periodo();
            List<String> periodos = new List<string>();
            List<String> p = new List<string>();
            string d = (Session["d"]).ToString();
            SqlCommand cmdp = new SqlCommand();
            DataTable dataTablep = new DataTable();
            SqlDataAdapter sqlDAp; con.Open();
            //  cmd.CommandText = "select c.nombre, d.nombre from dpto d, carrera c where c.cod_dpto = d.cod_dpto and c.cod_carrera = " + carrera +";";
            cmdp.CommandText = "select *from aula;";
            cmdp.CommandType = CommandType.Text;
            cmdp.Connection = con;
            sqlDAp = new SqlDataAdapter(cmdp);
            sqlDAp.Fill(dataTablep);
            con.Close();

            for (int i = 0; i < dataTablep.Rows.Count; i++)
            {
                string nombre = dataTablep.Rows[i].ItemArray[1].ToString();
                periodos.Add(nombre);
            }

            SqlCommand cmdv = new SqlCommand();
            DataTable dataTablev = new DataTable();
            SqlDataAdapter sqlDAv; con.Open();
            //  cmd.CommandText = "select c.nombre, d.nombre from dpto d, carrera c where c.cod_dpto = d.cod_dpto and c.cod_carrera = " + carrera +";";
            cmdv.CommandText = "select a.cod_aula, a.nombre from horario h, periodo p, aula a where h.cod_aula=a.cod_aula and h.cod_periodo=p.cod_periodo and cod_dias = '" + d + "' and p.periodo = '" + cod_periodo + "';";
            cmdv.CommandType = CommandType.Text;
            cmdv.Connection = con;
            sqlDAv = new SqlDataAdapter(cmdv);
            sqlDAv.Fill(dataTablev);
            con.Close();

            List<String> cod_period = new List<string>();


            for (int i = 0; i < dataTablev.Rows.Count; i++)
            {
                string nombre = dataTablev.Rows[i].ItemArray[1].ToString();
                cod_period.Add(nombre);
            }

            var diferperiodo = periodos.Except(cod_period);

            peri.nombre = diferperiodo;



            return Json(peri.nombre, JsonRequestBehavior.AllowGet);
        }



    }
}