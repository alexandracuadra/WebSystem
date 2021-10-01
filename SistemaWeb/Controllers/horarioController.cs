﻿using SistemaWeb.Contexto;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaWeb.Controllers
{
    [Authorize(Roles = "Admin")]
    public class horarioController : Controller
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["con"].ConnectionString);
        private sistema_horarioEntities3 db = new sistema_horarioEntities3();
        // GET: horario
        public ActionResult Index()
        {

            ViewBag.displayRole = TempData["infoRol"];
            TempData.Keep("infoRol");

            ViewBag.cod_dpto = new SelectList(db.dptoes, "cod_dpto", "nombre");
            ViewBag.cod_carrera = new SelectList(db.carreras, "cod_carrera", "nombre");
            ViewBag.tipo_ciclo = new SelectList("12");
            return View();

        }

        [HttpPost]
        public ActionResult Index(string cod_carrera, string tipo_ciclo)
        {

            var idCarrera = Int32.Parse(cod_carrera);
            var semestre = Int32.Parse(tipo_ciclo);
            ValidarHorario(idCarrera, semestre);

            return Index();
        }

        private void ValidarHorario(int idCarrera, int semestre)
        {
            try
            {

            
            //consultar lista de dias
            SqlCommand cmd = new SqlCommand();
            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlDA; con.Open();
            cmd.CommandText = "select * from dia;";
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            sqlDA = new SqlDataAdapter(cmd);
            sqlDA.Fill(dataTable);
            con.Close();

            // consulta para extraer  lista de periodo
            SqlCommand cmd2 = new SqlCommand();
            DataTable dataTable2 = new DataTable();
            SqlDataAdapter sqlDA2; con.Open();
            cmd2.CommandText = "select * from periodo;";
            cmd2.CommandType = CommandType.Text;
            cmd2.Connection = con;
            sqlDA2 = new SqlDataAdapter(cmd2);
            sqlDA2.Fill(dataTable2);
            con.Close();

            //consultar total de la suma de horas 
          

            //consultar total de la suma de grupo
            SqlCommand cmd4 = new SqlCommand();
            DataTable dataTable4 = new DataTable();
            SqlDataAdapter sqlDA4; con.Open();
            cmd4.CommandText = "select sum(grupo) from inportarcion where tipo_ciclo = '" + semestre + "' and cod_carrera='" + idCarrera + "';"; 
            cmd4.CommandType = CommandType.Text;
            cmd4.Connection = con;
            sqlDA4 = new SqlDataAdapter(cmd4);
            sqlDA4.Fill(dataTable4);
            con.Close();
            
            int total_grupo = Convert.ToInt32(dataTable4.Rows[0].ItemArray[0].ToString());
            int total_hora = 0;
            // bariables aleatorias
            Random aulaaleatoria = new Random();
            Random aulaaleatoriap = new Random();
            Random diasaleatorios = new Random();

            //bariable de control de periodos
            int control_periodos = 0;

            //int clases = clasesaleatorias.Next(0, dataTable1.Rows.Count + 1);
            /* //bariable de control de clases practicas
             int p = 0; */


            //bariable de control de clases
            int i = 0;
            //bariable de control de aulas
            int A = 0;
            //int aulas = aulaaleatoria.Next(0, dataTable3.Rows.Count + 1);
            //bariable de control de semana

            int g = 0;



            //while para control de aulas 
            // while (A < dataTable3.Rows.Count)

            do
            {

                //consultarn lista de datos de inportacion de cada de cada carrera
                SqlCommand cmd1 = new SqlCommand();
                DataTable dataTable1 = new DataTable();
                SqlDataAdapter sqlDA1; con.Open();
                cmd1.CommandText = "select p.ciclo, p.cod_materia, i.inss, i.cod_dpto, i.cod_carrera, i.grupo, i.hora_grupo, i.tipo_grupo, p.cod_asig, i.id, i.Tipo_ciclo from pensum p, inportarcion i, carrera c, plans pl where i.cod_carrera = c.cod_carrera and p.cod_plan = pl.cod_plan and pl.cod_carrera = c.cod_carrera and  p.cod_materia = i.cod_asignatura and i.tipo_ciclo = '" + semestre + "' and i.cod_carrera = '" + idCarrera + "' order by p.ciclo, i.grupo;";
                // cmd1.CommandText = "select * from inportarcion where cod_carrera='" + idCarrera + "';";
                cmd1.CommandType = CommandType.Text;
                cmd1.Connection = con;
                sqlDA1 = new SqlDataAdapter(cmd1);
                sqlDA1.Fill(dataTable1);
                con.Close();
                int cod_dpto = Convert.ToInt32(dataTable1.Rows[0].ItemArray[3].ToString());




                //insercion de grupo para optener los valores



                while (g < dataTable1.Rows.Count)
                {


                    int capasidad = 30;
                    string nombre1 = "Gt1";
                    string nombre2 = "Gt2";
                    string nombre3 = "Gt3";
                    string nombre4 = "Gt4";
                    string nombrep1 = "Gp1";
                    string nombrep2 = "Gp2";
                    string nombrep3 = "Gp3";
                    string nombrep4 = "Gp4";
                    int total_gru = 0;



                    int cod_asig = Convert.ToInt32(dataTable1.Rows[g].ItemArray[1].ToString());
                    int grup = Convert.ToInt32(dataTable1.Rows[g].ItemArray[5].ToString());
                    String tipo_grup = dataTable1.Rows[g].ItemArray[7].ToString();
                    int tipo_ciclo = Convert.ToInt32(dataTable1.Rows[g].ItemArray[10].ToString());
                    int cod_impo = Convert.ToInt32(dataTable1.Rows[g].ItemArray[9].ToString());
                    int cod_pensum = Convert.ToInt32(dataTable1.Rows[g].ItemArray[8].ToString());
                    int hora_grupo = Convert.ToInt32(dataTable1.Rows[g].ItemArray[6].ToString());




                    if (grup == 0)
                    {
                        g++;
                    }
                    if (grup != 0)
                    {



                        if (tipo_grup == "Teorico")
                        {
                            //consultar grupos 
                            SqlCommand cmdg2 = new SqlCommand();
                            DataTable dataTableg2 = new DataTable();
                            SqlDataAdapter sqlDAg2; con.Open();
                            cmdg2.CommandText = "select count(cod_grupo) from grupo where cod_asig= " + cod_pensum + " and Tipo_grupo = 'Teorico';";
                            //cmdg2.CommandText = "select cod_grupo, nombre, capacidad, tipo_ciclo, cod_asig from grupo where cod_asig= " + cod_asig + " and nombre like 'gt%';";
                            cmdg2.CommandType = CommandType.Text;
                            cmdg2.Connection = con;
                            sqlDAg2 = new SqlDataAdapter(cmdg2);
                            sqlDAg2.Fill(dataTableg2);
                            con.Close();
                                int contador = Convert.ToInt32(dataTableg2.Rows[0].ItemArray[0].ToString());
                            if ( contador == 0)
                            {

                                SqlCommand cmdg;
                                SqlDataAdapter sqlDAg = new SqlDataAdapter();
                                con.Open();
                                String sqlg = "";
                                sqlg = "INSERT INTO grupo (capacidad, cod_asig, nombre, Tipo_ciclo, hora_grupo, tipo_grupo) VALUES (" + capasidad + ", " + cod_pensum + ", '" + nombre1 + "', " + tipo_ciclo + ", " + hora_grupo + ", '" + tipo_grup + "')";
                                cmdg = new SqlCommand(sqlg, con);
                                sqlDAg.InsertCommand = new SqlCommand(sqlg, con);
                                sqlDAg.InsertCommand.ExecuteNonQuery();
                                cmdg.Dispose();
                                con.Close();
                                grup--;
                                total_grupo--;

                                SqlCommand cmdg1 = new SqlCommand();
                                DataTable dataTableg1 = new DataTable();
                                SqlDataAdapter sqlDAg1; con.Open();
                                cmdg1.CommandText = "UPDATE [dbo].[inportarcion] SET [grupo] = " + grup + " WHERE id = " + cod_impo + "";
                                cmdg1.CommandType = CommandType.Text;
                                cmdg1.Connection = con;
                                sqlDAg1 = new SqlDataAdapter(cmdg1);
                                sqlDAg1.Fill(dataTableg1);
                                con.Close();

                            }

                            if (contador == 1)
                            {
                                SqlCommand cmdg;
                                SqlDataAdapter sqlDAg = new SqlDataAdapter();
                                con.Open();
                                String sqlg = "";
                                sqlg = "INSERT INTO grupo (capacidad, cod_asig, nombre, Tipo_ciclo, hora_grupo, tipo_grupo) VALUES (" + capasidad + ", " + cod_pensum + ", '" + nombre2 + "', " + tipo_ciclo + ", " + hora_grupo + ", '" + tipo_grup + "')";
                                cmdg = new SqlCommand(sqlg, con);
                                sqlDAg.InsertCommand = new SqlCommand(sqlg, con);
                                sqlDAg.InsertCommand.ExecuteNonQuery();
                                cmdg.Dispose();
                                con.Close();
                                grup--;
                                total_grupo--;


                                SqlCommand cmdg1 = new SqlCommand();
                                DataTable dataTableg1 = new DataTable();
                                SqlDataAdapter sqlDAg1; con.Open();
                                cmdg1.CommandText = "UPDATE [dbo].[inportarcion] SET [grupo] = " + grup + " WHERE id = " + cod_impo + "";
                                cmdg1.CommandType = CommandType.Text;
                                cmdg1.Connection = con;
                                sqlDAg1 = new SqlDataAdapter(cmdg1);
                                sqlDAg1.Fill(dataTableg1);
                                con.Close();
                            }


                            if (contador == 2)
                            {
                                SqlCommand cmdg;
                                SqlDataAdapter sqlDAg = new SqlDataAdapter();
                                con.Open();
                                String sqlg = "";
                                sqlg = "INSERT INTO grupo (capacidad, cod_asig, nombre, Tipo_ciclo, hora_grupo, tipo_grupo) VALUES (" + capasidad + ", " + cod_pensum + ", '" + nombre3 + "', " + tipo_ciclo + ", " + hora_grupo + ", '" + tipo_grup + "')";
                                cmdg = new SqlCommand(sqlg, con);
                                sqlDAg.InsertCommand = new SqlCommand(sqlg, con);
                                sqlDAg.InsertCommand.ExecuteNonQuery();
                                cmdg.Dispose();
                                con.Close();
                                grup--;
                                total_grupo--;


                                SqlCommand cmdg1 = new SqlCommand();
                                DataTable dataTableg1 = new DataTable();
                                SqlDataAdapter sqlDAg1; con.Open();
                                cmdg1.CommandText = "UPDATE [dbo].[inportarcion] SET [grupo] = " + grup + " WHERE id = " + cod_impo + "";
                                cmdg1.CommandType = CommandType.Text;
                                cmdg1.Connection = con;
                                sqlDAg1 = new SqlDataAdapter(cmdg1);
                                sqlDAg1.Fill(dataTableg1);
                                con.Close();
                            }

                            if (contador == 3)
                            {
                                SqlCommand cmdg;
                                SqlDataAdapter sqlDAg = new SqlDataAdapter();
                                con.Open();
                                String sqlg = "";
                                sqlg = "INSERT INTO grupo (capacidad, cod_asig, nombre, Tipo_ciclo, hora_grupo, tipo_grupo) VALUES (" + capasidad + ", " + cod_pensum + ", '" + nombre4 + "', " + tipo_ciclo + ", " + hora_grupo + ", '" + tipo_grup + "')";
                                cmdg = new SqlCommand(sqlg, con);
                                sqlDAg.InsertCommand = new SqlCommand(sqlg, con);
                                sqlDAg.InsertCommand.ExecuteNonQuery();
                                cmdg.Dispose();
                                con.Close();
                                grup--;
                                total_grupo--;


                                SqlCommand cmdg1 = new SqlCommand();
                                DataTable dataTableg1 = new DataTable();
                                SqlDataAdapter sqlDAg1; con.Open();
                                cmdg1.CommandText = "UPDATE [dbo].[inportarcion] SET [grupo] = " + grup + " WHERE id = " + cod_impo + "";
                                cmdg1.CommandType = CommandType.Text;
                                cmdg1.Connection = con;
                                sqlDAg1 = new SqlDataAdapter(cmdg1);
                                sqlDAg1.Fill(dataTableg1);
                                con.Close();

                            }

                            //g++;

                        }
                        if (tipo_grup == "Practico")
                        {

                            //consultar grupos 
                            SqlCommand cmdg2 = new SqlCommand();
                            DataTable dataTableg2 = new DataTable();
                            SqlDataAdapter sqlDAg2; con.Open();
                            cmdg2.CommandText = "select count(cod_grupo) from grupo where cod_asig= " + cod_pensum + " and Tipo_grupo = 'Practico';";
                            cmdg2.CommandType = CommandType.Text;
                            cmdg2.Connection = con;
                            sqlDAg2 = new SqlDataAdapter(cmdg2);
                            sqlDAg2.Fill(dataTableg2);
                            con.Close();

                                int contador2 = Convert.ToInt32(dataTableg2.Rows[0].ItemArray[0].ToString());
                                if (contador2 == 0)
                            {
                                SqlCommand cmdg;
                                SqlDataAdapter sqlDAg = new SqlDataAdapter();
                                con.Open();
                                String sqlg = "";
                                sqlg = "INSERT INTO grupo (capacidad, cod_asig, nombre, Tipo_ciclo, hora_grupo, tipo_grupo) VALUES (" + capasidad + ", " + cod_pensum + ", '" + nombrep1 + "', " + tipo_ciclo + ", " + hora_grupo + ", '" + tipo_grup + "')";
                                cmdg = new SqlCommand(sqlg, con);
                                sqlDAg.InsertCommand = new SqlCommand(sqlg, con);
                                sqlDAg.InsertCommand.ExecuteNonQuery();
                                cmdg.Dispose();
                                con.Close();
                                grup--;
                                total_grupo--;


                                SqlCommand cmdg1 = new SqlCommand();
                                DataTable dataTableg1 = new DataTable();
                                SqlDataAdapter sqlDAg1; con.Open();
                                cmdg1.CommandText = "UPDATE [dbo].[inportarcion] SET [grupo] = " + grup + " WHERE id = " + cod_impo + "";
                                cmdg1.CommandType = CommandType.Text;
                                cmdg1.Connection = con;
                                sqlDAg1 = new SqlDataAdapter(cmdg1);
                                sqlDAg1.Fill(dataTableg1);
                                con.Close();

                            }

                            if (contador2 == 1)
                            {
                                SqlCommand cmdg;
                                SqlDataAdapter sqlDAg = new SqlDataAdapter();
                                con.Open();
                                String sqlg = "";
                                sqlg = "INSERT INTO grupo (capacidad, cod_asig, nombre, Tipo_ciclo, hora_grupo, tipo_grupo) VALUES (" + capasidad + ", " + cod_pensum + ", '" + nombrep2 + "', " + tipo_ciclo + ", " + hora_grupo + ", '" + tipo_grup + "')";
                                cmdg = new SqlCommand(sqlg, con);
                                sqlDAg.InsertCommand = new SqlCommand(sqlg, con);
                                sqlDAg.InsertCommand.ExecuteNonQuery();
                                cmdg.Dispose();
                                con.Close();
                                grup--;
                                total_grupo--;


                                SqlCommand cmdg1 = new SqlCommand();
                                DataTable dataTableg1 = new DataTable();
                                SqlDataAdapter sqlDAg1; con.Open();
                                cmdg1.CommandText = "UPDATE [dbo].[inportarcion] SET [grupo] = " + grup + " WHERE id = " + cod_impo + "";
                                cmdg1.CommandType = CommandType.Text;
                                cmdg1.Connection = con;
                                sqlDAg1 = new SqlDataAdapter(cmdg1);
                                sqlDAg1.Fill(dataTableg1);
                                con.Close();
                            }


                            if (contador2 == 2)
                            {
                                SqlCommand cmdg;
                                SqlDataAdapter sqlDAg = new SqlDataAdapter();
                                con.Open();
                                String sqlg = "";
                                sqlg = "INSERT INTO grupo (capacidad, cod_asig, nombre, Tipo_ciclo, hora_grupo, tipo_grupo) VALUES (" + capasidad + ", " + cod_pensum + ", '" + nombrep3 + "', " + tipo_ciclo + ", " + hora_grupo + ", '" + tipo_grup + "')";
                                cmdg = new SqlCommand(sqlg, con);
                                sqlDAg.InsertCommand = new SqlCommand(sqlg, con);
                                sqlDAg.InsertCommand.ExecuteNonQuery();
                                cmdg.Dispose();
                                con.Close();
                                grup--;
                                total_grupo--;


                                SqlCommand cmdg1 = new SqlCommand();
                                DataTable dataTableg1 = new DataTable();
                                SqlDataAdapter sqlDAg1; con.Open();
                                cmdg1.CommandText = "UPDATE [dbo].[inportarcion] SET [grupo] = " + grup + " WHERE id = " + cod_impo + "";
                                cmdg1.CommandType = CommandType.Text;
                                cmdg1.Connection = con;
                                sqlDAg1 = new SqlDataAdapter(cmdg1);
                                sqlDAg1.Fill(dataTableg1);
                                con.Close();
                            }

                            if (contador2 == 3)
                            {
                                SqlCommand cmdg;
                                SqlDataAdapter sqlDAg = new SqlDataAdapter();
                                con.Open();
                                String sqlg = "";
                                sqlg = "INSERT INTO grupo (capacidad, cod_asig, nombre, Tipo_ciclo, hora_grupo, tipo_grupo) VALUES (" + capasidad + ", " + cod_pensum + ", '" + nombrep4 + "', " + tipo_ciclo + ", " + hora_grupo + ", '" + tipo_grup + "')";
                                cmdg = new SqlCommand(sqlg, con);
                                sqlDAg.InsertCommand = new SqlCommand(sqlg, con);
                                sqlDAg.InsertCommand.ExecuteNonQuery();
                                cmdg.Dispose();
                                con.Close();
                                grup--;
                                total_grupo--;



                                SqlCommand cmdg1 = new SqlCommand();
                                DataTable dataTableg1 = new DataTable();
                                SqlDataAdapter sqlDAg1; con.Open();
                                cmdg1.CommandText = "UPDATE [dbo].[inportarcion] SET [grupo] = " + grup + " WHERE id = " + cod_impo + "";
                                cmdg1.CommandType = CommandType.Text;
                                cmdg1.Connection = con;
                                sqlDAg1 = new SqlDataAdapter(cmdg1);
                                sqlDAg1.Fill(dataTableg1);
                                con.Close();
                            }

                            //g++;
                        }

                        g++;
                    }

                    if ( g == dataTable1.Rows.Count)
                    {

                        //int control_periodo_finalisar = control_periodos + 1;
                        g = 0;
                        break;

                    }


                   


                }




            } while (total_grupo != 0);




            do
            {

               
                //A++;

                //consultarn lista de datos de inportacion de cada de cada carrera
                SqlCommand cmd1 = new SqlCommand();
                DataTable dataTable1 = new DataTable();
                SqlDataAdapter sqlDA1; con.Open();               
                cmd1.CommandText = "select p.ciclo, p.cod_materia, i.inss, i.cod_dpto, i.cod_carrera, i.grupo, i.hora_grupo, i.tipo_grupo, p.cod_asig, i.id, i.Tipo_ciclo from pensum p, inportarcion i, carrera c, plans pl where i.cod_carrera = c.cod_carrera and p.cod_plan = pl.cod_plan and pl.cod_carrera = c.cod_carrera and  p.cod_materia = i.cod_asignatura and i.tipo_ciclo = '" + semestre + "' and i.cod_carrera = '" + idCarrera + "' order by p.ciclo, i.grupo;";
                // cmd1.CommandText = "select * from inportarcion where cod_carrera='" + idCarrera + "';";
                cmd1.CommandType = CommandType.Text;
                cmd1.Connection = con;
                sqlDA1 = new SqlDataAdapter(cmd1);
                sqlDA1.Fill(dataTable1);
                con.Close();
                int cod_dpto = Convert.ToInt32(dataTable1.Rows[0].ItemArray[3].ToString());


                //consultar aulas de partamento seleccionado teorica
                SqlCommand cmd3 = new SqlCommand();
                DataTable dataTable3 = new DataTable();
                SqlDataAdapter sqlDA3; con.Open();
                cmd3.CommandText = "select * from aula a, Tipoaula t where a.cod_tipoaula=t.cod_tipoaula and nombre_tipo = 'aula' and cod_dpto= '" + cod_dpto + "';";
                cmd3.CommandType = CommandType.Text;
                cmd3.Connection = con;
                sqlDA3 = new SqlDataAdapter(cmd3);
                sqlDA3.Fill(dataTable3);
                con.Close();

                //consultar aulas de partamento seleccionado practico
                SqlCommand cmd3p = new SqlCommand();
                DataTable dataTable3p = new DataTable();
                SqlDataAdapter sqlDA3p; con.Open();
                cmd3p.CommandText = "select * from aula a, Tipoaula t where a.cod_tipoaula=t.cod_tipoaula and nombre_tipo = 'laboratorio' and cod_dpto= '" + cod_dpto + "';";
                cmd3p.CommandType = CommandType.Text;
                cmd3p.Connection = con;
                sqlDA3p = new SqlDataAdapter(cmd3p);
                sqlDA3p.Fill(dataTable3p);
                con.Close();



                
                // consultar total de la suma de horas
                SqlCommand cmd40 = new SqlCommand();
                DataTable dataTable40 = new DataTable();
                SqlDataAdapter sqlDA40; con.Open();
                // cmd40.CommandText = "select sum(i.hora_grupo) from pensum p, inportarcion i, grupo g, carrera c, plans pl where pl.cod_carrera = c.cod_carrera and pl.cod_plan = p.cod_plan and g.cod_asig = p.cod_asig and p.cod_materia = i.cod_asignatura  and i.tipo_ciclo = '" + semestre + "' and i.cod_carrera='" + idCarrera + "';";
                // cmd40.CommandText = "select sum(i.hora_grupo) from pensum p, inportarcion i, grupo g, carrera c, plans pl where i.tipo_grupo = g.tipo_grupo and p.cod_plan = pl.cod_plan and pl.cod_carrera = c.cod_carrera and g.cod_asig = p.cod_asig and  p.cod_materia = i.cod_asignatura and i.tipo_ciclo = "+ semestre +" and i.cod_carrera = " + idCarrera +";";

                cmd40.CommandText = "select sum(g.hora_grupo) from pensum p, inportarcion i, grupo g, carrera c, plans pl where i.tipo_grupo = g.tipo_grupo and p.cod_plan = pl.cod_plan and pl.cod_carrera = c.cod_carrera and g.cod_asig = p.cod_asig and  p.cod_materia = i.cod_asignatura  and i.tipo_ciclo = " + semestre + " and i.cod_carrera = " + idCarrera + ";";
                cmd40.CommandType = CommandType.Text;
                cmd40.Connection = con;
                sqlDA40 = new SqlDataAdapter(cmd40);
                sqlDA40.Fill(dataTable40);
                con.Close();
               total_hora = Convert.ToInt32(dataTable40.Rows[0].ItemArray[0].ToString());

                //nueva consulta para generacion de horario de grupo y horario y impor
                //consulta correcta para clases teoricas
                //select p.ciclo, p.cod_materia, i.inss, i.cod_dpto, i.cod_carrera, i.grupo, i.hora_grupo, i.tipo_grupo, p.cod_asig, i.id, i.Tipo_ciclo, g.cod_grupo from pensum p, inportarcion i, grupo g, carrera c, plans pl where i.tipo_grupo = g.tipo_grupo and p.cod_plan = pl.cod_plan and pl.cod_carrera = c.cod_carrera and g.cod_asig = p.cod_asig and  p.cod_materia = i.cod_asignatura and i.tipo_ciclo = 1 and i.cod_carrera = 2 order by p.ciclo, i.grupo;
                SqlCommand cmd1HO = new SqlCommand();
                DataTable dataTableHO = new DataTable();
                SqlDataAdapter sqlDA1HO; con.Open();
                cmd1HO.CommandText = "select p.ciclo, p.cod_materia, i.inss, i.cod_dpto, i.cod_carrera, i.grupo, g.hora_grupo, i.tipo_grupo, p.cod_asig, i.id, i.Tipo_ciclo, g.cod_grupo from pensum p, inportarcion i, grupo g, carrera c, plans pl where i.tipo_grupo = g.tipo_grupo and p.cod_plan = pl.cod_plan and pl.cod_carrera = c.cod_carrera and g.cod_asig = p.cod_asig and  p.cod_materia = i.cod_asignatura  and i.tipo_ciclo = '" + semestre + "' and i.cod_carrera = '" + idCarrera + "' order by p.ciclo, i.grupo;";
                // cmd1.CommandText = "select * from inportarcion where cod_carrera='" + idCarrera + "';";
                cmd1HO.CommandType = CommandType.Text;
                cmd1HO.Connection = con;
                sqlDA1HO = new SqlDataAdapter(cmd1HO);
                sqlDA1HO.Fill(dataTableHO);
                con.Close();

                /*
                //consulta correcta para clases practicas 

                SqlCommand cmd1HOT = new SqlCommand();
                DataTable dataTableHOT = new DataTable();
                SqlDataAdapter sqlDA1HOT; con.Open();
                cmd1HOT.CommandText = "select p.ciclo, p.cod_materia, i.inss, i.cod_dpto, i.cod_carrera, i.grupo, i.hora_grupo, i.tipo_grupo, p.cod_asig, i.id, i.Tipo_ciclo, g.cod_grupo from pensum p, inportarcion i, grupo g, carrera c, plans pl where i.tipo_grupo = g.tipo_grupo and p.cod_plan = pl.cod_plan and pl.cod_carrera = c.cod_carrera and g.cod_asig = p.cod_asig and  p.cod_materia = i.cod_asignatura and i.tipo_grupo = 'Practico' and i.tipo_ciclo = '" + semestre + "' and i.cod_carrera = '" + idCarrera + "' order by p.ciclo, i.grupo;";
                // cmd1.CommandText = "select * from inportarcion where cod_carrera='" + idCarrera + "';";
                cmd1HOT.CommandType = CommandType.Text;
                cmd1HOT.Connection = con;
                sqlDA1HOT = new SqlDataAdapter(cmd1HOT);
                sqlDA1HOT.Fill(dataTableHOT);
                con.Close();
                */
                //for para la lista de clases
                while (i < dataTableHO.Rows.Count)
                {

                    /*
                     optener los valores de grupo y pasarlo aun for para saver los grupos 
                     que hay y guardarlo en grupo como en horario 
                     * */

                    int D = diasaleatorios.Next(0, dataTable.Rows.Count);
                    int id_dias = Convert.ToInt32(dataTable.Rows[D].ItemArray[0].ToString());
                    String dias = dataTable.Rows[D].ItemArray[1].ToString();

                    int aulas = aulaaleatoria.Next(0, dataTable3.Rows.Count);
                    int cod_aulas = Convert.ToInt32(dataTable3.Rows[aulas].ItemArray[0].ToString());
                    String aula = dataTable3.Rows[aulas].ItemArray[1].ToString();


                    int aulasp = aulaaleatoriap.Next(0, dataTable3p.Rows.Count);
                    int cod_aulasp = Convert.ToInt32(dataTable3p.Rows[aulasp].ItemArray[0].ToString());
                    String aulap = dataTable3p.Rows[aulasp].ItemArray[1].ToString();

                    String ciclo = dataTableHO.Rows[i].ItemArray[0].ToString();
                    int cod_asignatura = Convert.ToInt32(dataTableHO.Rows[i].ItemArray[1].ToString());
                    String inss = dataTableHO.Rows[i].ItemArray[2].ToString();
                    //int cod_dpto = Convert.ToInt32(dataTable1.Rows[i].ItemArray[3].ToString());                
                    int cod_carrera = Convert.ToInt32(dataTableHO.Rows[i].ItemArray[4].ToString());
                    String grupo = dataTableHO.Rows[i].ItemArray[5].ToString();
                    int hora_grupo = Convert.ToInt32(dataTableHO.Rows[i].ItemArray[6].ToString());
                    //String hora_grupo = dataTable1.Rows[i].ItemArray[7].ToString();
                    String tipo_grupo = dataTableHO.Rows[i].ItemArray[7].ToString();
                    int cod_pemsul = Convert.ToInt32(dataTableHO.Rows[i].ItemArray[8].ToString());
                    int cod_impor = Convert.ToInt32(dataTableHO.Rows[i].ItemArray[9].ToString());
                    int cod_grupo = Convert.ToInt32(dataTableHO.Rows[i].ItemArray[11].ToString());



                    if (tipo_grupo == "Teorico")
                    {

                    
                    
                    //si y while pára controlar periodos

                    if (hora_grupo == 0)
                    {
                        i++;
                        break;
                    }

                    if (hora_grupo == 1)
                    {
                        //ViewBag.Message = "hora grupo del inicio es " + hora_grupo;
                        while (control_periodos < dataTable2.Rows.Count)
                        {
                            int id_periodo = Convert.ToInt32(dataTable2.Rows[control_periodos].ItemArray[0].ToString());
                            String periodo = dataTable2.Rows[control_periodos].ItemArray[1].ToString();

                            // codigo de verificasion de aulas 

                            

                            SqlCommand cmd6 = new SqlCommand();
                            DataTable dataTable6 = new DataTable();
                            SqlDataAdapter sqlDA6; con.Open();
                            cmd6.CommandText = "select *from horario h, periodo p, dia d, pensum pm where h.cod_periodo = p.cod_periodo and h.cod_dias = d.id and h.cod_asig = pm.cod_asig and h.cod_dias =" + id_dias + " and h.cod_aula =" + cod_aulas + " and h.cod_periodo =" + id_periodo + ";";
                            cmd6.CommandType = CommandType.Text;
                            cmd6.Connection = con;
                            sqlDA6 = new SqlDataAdapter(cmd6);
                            sqlDA6.Fill(dataTable6);
                            con.Close();

                            if (dataTable6.Rows.Count == 0)
                            {
                                //insercion

                                SqlCommand cmdI;
                                SqlDataAdapter sqlDAI = new SqlDataAdapter();
                                con.Open();
                                String sql = "";

                                sql = "INSERT INTO horario (cod_asig, cod_aula, cod_dias, cod_grupo, cod_periodo, fecha_ini, inss, cod_ano) VALUES ('" + cod_pemsul + "', " + cod_aulas + ", " + id_dias + ", '" + grupo + "', '" + id_periodo + "','"+ DateTime.Now.ToString("dd/MM/yyyy") +"', '" + inss + "', " + cod_grupo +", 2)";
                                //cmd2.CommandText = "insert  into exportarcion values(null, '" + inss + "', 'cod_dpto', '" + cod_materia + "', '" + grupo + "', '" + cantidad + "', '" + anoestudio + "', 'tipo_ciclo', '" + tipogrupo + "')";
                                cmdI = new SqlCommand(sql, con);
                                sqlDAI.InsertCommand = new SqlCommand(sql, con);
                                sqlDAI.InsertCommand.ExecuteNonQuery();
                                cmdI.Dispose();
                                con.Close();
                                hora_grupo--;
                                total_hora--;

                                SqlCommand cmd7 = new SqlCommand();
                                DataTable dataTable7 = new DataTable();
                                SqlDataAdapter sqlDA7; con.Open();
                                cmd7.CommandText = "UPDATE [dbo].[grupo] SET [hora_grupo] = " + hora_grupo + " WHERE cod_grupo = " + cod_grupo + "";
                                cmd7.CommandType = CommandType.Text;
                                cmd7.Connection = con;
                                sqlDA7 = new SqlDataAdapter(cmd7);
                                sqlDA7.Fill(dataTable7);
                                con.Close();



                                control_periodos++;
                               
                            }


                                if (control_periodos == dataTable2.Rows.Count)
                                {

                                    //int control_periodo_finalisar = control_periodos + 1;

                                    control_periodos = 0;

                                    break;

                                }

                                break;
                            }

                    }
                    else
                    {


                        //ViewBag.Message = "hora grupo del inicio es " + hora_grupo;
                        while (control_periodos < dataTable2.Rows.Count)
                        {
                            int id_periodo = Convert.ToInt32(dataTable2.Rows[control_periodos].ItemArray[0].ToString());
                            String periodo = dataTable2.Rows[control_periodos].ItemArray[1].ToString();

                            // codigo de verificasion de aulas 

                            SqlCommand cmd6 = new SqlCommand();
                            DataTable dataTable6 = new DataTable();
                            SqlDataAdapter sqlDA6; con.Open();
                            cmd6.CommandText = "select *from horario h, periodo p, dia d, pensum pm where h.cod_periodo = p.cod_periodo and h.cod_dias = d.id and h.cod_asig = pm.cod_asig and h.cod_dias =" + id_dias + " and h.cod_aula =" + cod_aulas + " and h.cod_periodo =" + id_periodo + ";";
                            cmd6.CommandType = CommandType.Text;
                            cmd6.Connection = con;
                            sqlDA6 = new SqlDataAdapter(cmd6);
                            sqlDA6.Fill(dataTable6);
                            con.Close();

                            if (dataTable6.Rows.Count == 0)
                            {
                                //insercion
                                SqlCommand cmdI;
                                SqlDataAdapter sqlDAI = new SqlDataAdapter();
                                con.Open();
                                String sql = "";

                                sql = "INSERT INTO horario (cod_asig, cod_aula, cod_dias, cod_grupo, cod_periodo, fecha_ini, inss, cod_ano) VALUES ('" + cod_pemsul + "', " + cod_aulas + ", " + id_dias + ", '" + cod_grupo + "', '" + id_periodo + "', '" + DateTime.Now.ToString("dd/MM/yyyy") + "', '" + inss + "', 2)";
                                //cmd2.CommandText = "insert  into exportarcion values(null, '" + inss + "', 'cod_dpto', '" + cod_materia + "', '" + grupo + "', '" + cantidad + "', '" + anoestudio + "', 'tipo_ciclo', '" + tipogrupo + "')";
                                cmdI = new SqlCommand(sql, con);
                                sqlDAI.InsertCommand = new SqlCommand(sql, con);
                                sqlDAI.InsertCommand.ExecuteNonQuery();
                                cmdI.Dispose();
                                con.Close();
                                hora_grupo--;
                                total_hora--;

                                SqlCommand cmd7 = new SqlCommand();
                                DataTable dataTable7 = new DataTable();
                                SqlDataAdapter sqlDA7; con.Open();
                                    cmd7.CommandText = "UPDATE [dbo].[grupo] SET [hora_grupo] = " + hora_grupo + " WHERE cod_grupo = " + cod_grupo + "";
                                    cmd7.CommandType = CommandType.Text;
                                cmd7.Connection = con;
                                sqlDA7 = new SqlDataAdapter(cmd7);
                                sqlDA7.Fill(dataTable7);
                                con.Close();


                                    

                                if ((control_periodos % 2) != 0)
                                {
                                    control_periodos++;
                                    break;

                                }
                                

                               control_periodos++;
                            }
                            

                                if (control_periodos == dataTable2.Rows.Count)
                                {

                                    //int control_periodo_finalisar = control_periodos + 1;

                                    control_periodos = 0;

                                    break;

                                }

                               // break;
                            }

                    }


                    

                    
                    }
                    /*
                    if ((i + 1) == dataTableHO.Rows.Count)
                    {

                        //int clases_finalisar = control_periodos + 1;

                        i = 0;
                        break;

                    } */

                    if (tipo_grupo == "Practico")
                    {


                        //si y while pára controlar periodos

                        if (hora_grupo == 0)
                        {
                            i++;
                            break;
                        }

                        if (hora_grupo == 1)
                        {
                            //ViewBag.Message = "hora grupo del inicio es " + hora_grupo;
                            while (control_periodos < dataTable2.Rows.Count)
                            {
                                int id_periodo = Convert.ToInt32(dataTable2.Rows[control_periodos].ItemArray[0].ToString());
                                String periodo = dataTable2.Rows[control_periodos].ItemArray[1].ToString();

                                // codigo de verificasion de aulas 



                                SqlCommand cmd6 = new SqlCommand();
                                DataTable dataTable6 = new DataTable();
                                SqlDataAdapter sqlDA6; con.Open();
                                cmd6.CommandText = "select *from horario h, periodo p, dia d, pensum pm where h.cod_periodo = p.cod_periodo and h.cod_dias = d.id and h.cod_asig = pm.cod_asig and h.cod_dias =" + id_dias + " and h.cod_aula =" + cod_aulasp + " and h.cod_periodo =" + id_periodo + ";";
                                cmd6.CommandType = CommandType.Text;
                                cmd6.Connection = con;
                                sqlDA6 = new SqlDataAdapter(cmd6);
                                sqlDA6.Fill(dataTable6);
                                con.Close();

                                if (dataTable6.Rows.Count == 0)
                                {
                                    //insercion

                                    SqlCommand cmdI;
                                    SqlDataAdapter sqlDAI = new SqlDataAdapter();
                                    con.Open();
                                    String sql = "";

                                    sql = "INSERT INTO horario (cod_asig, cod_aula, cod_dias, cod_grupo, cod_periodo, fecha_ini, inss, cod_ano) VALUES ('" + cod_pemsul + "', " + cod_aulasp + ", " + id_dias + ", '" + grupo + "', '" + id_periodo + "', '" + DateTime.Now.ToString("dd/MM/yyyy") + "', '" + inss + "', " + cod_grupo + ", 2)";
                                    //cmd2.CommandText = "insert  into exportarcion values(null, '" + inss + "', 'cod_dpto', '" + cod_materia + "', '" + grupo + "', '" + cantidad + "', '" + anoestudio + "', 'tipo_ciclo', '" + tipogrupo + "')";
                                    cmdI = new SqlCommand(sql, con);
                                    sqlDAI.InsertCommand = new SqlCommand(sql, con);
                                    sqlDAI.InsertCommand.ExecuteNonQuery();
                                    cmdI.Dispose();
                                    con.Close();
                                    hora_grupo--;
                                    total_hora--;

                                    SqlCommand cmd7 = new SqlCommand();
                                    DataTable dataTable7 = new DataTable();
                                    SqlDataAdapter sqlDA7; con.Open();
                                    cmd7.CommandText = "UPDATE [dbo].[grupo] SET [hora_grupo] = " + hora_grupo + " WHERE cod_grupo = " + cod_grupo + "";
                                    cmd7.CommandType = CommandType.Text;
                                    cmd7.Connection = con;
                                    sqlDA7 = new SqlDataAdapter(cmd7);
                                    sqlDA7.Fill(dataTable7);
                                    con.Close();

                                   



                                    control_periodos++;

                                }


                                if (control_periodos == dataTable2.Rows.Count)
                                {

                                    //int control_periodo_finalisar = control_periodos + 1;

                                    control_periodos = 0;

                                    break;

                                }

                                break;

                            }

                        }
                        else
                        {


                            //ViewBag.Message = "hora grupo del inicio es " + hora_grupo;
                            while (control_periodos < dataTable2.Rows.Count)
                            {
                                int id_periodo = Convert.ToInt32(dataTable2.Rows[control_periodos].ItemArray[0].ToString());
                                String periodo = dataTable2.Rows[control_periodos].ItemArray[1].ToString();

                                // codigo de verificasion de aulas 

                                SqlCommand cmd6 = new SqlCommand();
                                DataTable dataTable6 = new DataTable();
                                SqlDataAdapter sqlDA6; con.Open();
                                cmd6.CommandText = "select *from horario h, periodo p, dia d, pensum pm where h.cod_periodo = p.cod_periodo and h.cod_dias = d.id and h.cod_asig = pm.cod_asig and h.cod_dias =" + id_dias + " and h.cod_aula =" + cod_aulasp + " and h.cod_periodo =" + id_periodo + ";";
                                cmd6.CommandType = CommandType.Text;
                                cmd6.Connection = con;
                                sqlDA6 = new SqlDataAdapter(cmd6);
                                sqlDA6.Fill(dataTable6);
                                con.Close();

                                if (dataTable6.Rows.Count == 0)
                                {
                                    //insercion
                                    SqlCommand cmdI;
                                    SqlDataAdapter sqlDAI = new SqlDataAdapter();
                                    con.Open();
                                    String sql = "";

                                    sql = "INSERT INTO horario (cod_asig, cod_aula, cod_dias, cod_grupo, cod_periodo, fecha_ini, inss, cod_ano) VALUES ('" + cod_pemsul + "', " + cod_aulasp + ", " + id_dias + ", '" + cod_grupo + "', '" + id_periodo + "', '" + DateTime.Now.ToString("dd/MM/yyyy") + "', '" + inss + "', 2)";
                                    //cmd2.CommandText = "insert  into exportarcion values(null, '" + inss + "', 'cod_dpto', '" + cod_materia + "', '" + grupo + "', '" + cantidad + "', '" + anoestudio + "', 'tipo_ciclo', '" + tipogrupo + "')";
                                    cmdI = new SqlCommand(sql, con);
                                    sqlDAI.InsertCommand = new SqlCommand(sql, con);
                                    sqlDAI.InsertCommand.ExecuteNonQuery();
                                    cmdI.Dispose();
                                    con.Close();
                                    hora_grupo--;
                                    total_hora--;

                                    SqlCommand cmd7 = new SqlCommand();
                                    DataTable dataTable7 = new DataTable();
                                    SqlDataAdapter sqlDA7; con.Open();
                                    cmd7.CommandText = "UPDATE [dbo].[grupo] SET [hora_grupo] = " + hora_grupo + " WHERE cod_grupo = " + cod_grupo + "";
                                    cmd7.CommandType = CommandType.Text;
                                    cmd7.Connection = con;
                                    sqlDA7 = new SqlDataAdapter(cmd7);
                                    sqlDA7.Fill(dataTable7);
                                    con.Close();

                               

                                    if ((control_periodos % 2) != 0)
                                    {
                                        control_periodos++;
                                        break;

                                    }
                                   

                                    control_periodos++;
                                }
                                else
                                {
                                    break;
                                }
                                if (control_periodos == dataTable2.Rows.Count)
                                {

                                    //int control_periodo_finalisar = control_periodos + 1;

                                    control_periodos = 0;

                                    break;

                                }

                               
                            }


                        }


                       
                    }

                    if (control_periodos == dataTable2.Rows.Count)
                    {

                        //int control_periodo_finalisar = control_periodos + 1;

                        control_periodos = 0;
                    }

                    i++;

                    if (i == dataTableHO.Rows.Count)
                    {

                        //int clases_finalisar = control_periodos + 1;

                        i = 0;
                        break;

                    }

                   

                }
                


            } while (total_hora != 0);


                ViewBag.Message = "Se ha generado el horario correctamente";

            }
            catch
            {
                ViewBag.Message = "No se han encontrado datos para generar el horario";

            }
        }
    }
}