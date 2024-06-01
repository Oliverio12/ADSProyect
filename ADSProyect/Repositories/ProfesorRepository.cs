using ADSProyect.DB;
using ADSProyect.Interfaces;
using ADSProyect.Migrations;
using ADSProyect.Models;

namespace ADSProyect.Repositories
{
    public class ProfesorRepository : IProfesor
    {
        /*private List<Profesor> ListaProfesor = new List<Profesor>
        {
            new Profesor
            {
                IdProfesor = 1,
                NombreProfesor = "Ivan Orlando",
                ApellidoProfesor = "Alvarado Niño",
                Email = "IvanNiño@usonsonate.edu.sv"
            },
            new Profesor
            {
                IdProfesor = 2,
                NombreProfesor = "Alavaro Hernan",
                ApellidoProfesor = "Zavala Ruballo",
                Email = "AlavaroRuballo@usonsonate.edu.sv"
            },
            new Profesor
            {
                IdProfesor = 3,
                NombreProfesor = "Antonio Humberto",
                ApellidoProfesor = "Morán Najarro",
                Email = "AntonioMorán@usonsonate.edu.sv"
            },
            new Profesor
            {
                IdProfesor = 4,
                NombreProfesor = "Jorge Alfonso",
                ApellidoProfesor = "Menjivar Mirón",
                Email = "JorgeMirón@usonsonate.edu.sv"
            }

        };*/

        private readonly ApplicationDbContext applicationDBContext;

        public ProfesorRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDBContext = applicationDbContext;
        }

     

        public int ActualizarProfesor(int IdProfesor, Models.Profesor profesor)
        {
            try
            {
                /* int bandera = 0;
                 int index = ListaProfesor.FindIndex(tmp => tmp.IdProfesor == IdProfesor);

                 if (index > 0)
                 {
                     ListaProfesor[index] = profesor;
                     bandera = IdProfesor;
                 }
                 else
                 {
                     bandera = -1;
                 }

                 return bandera;*/
                var item = applicationDBContext.Profesor.SingleOrDefault(x => x.IdProfesor == IdProfesor);
                applicationDBContext.Entry(item).CurrentValues.SetValues(profesor);
                applicationDBContext.SaveChanges();

                return IdProfesor;

            }
            catch (Exception)
            {
                throw;
            }
        }

       


        public int AgregarProfesor(Models.Profesor profesor)
        {

            try
            {
                /* if (ListaProfesor.Count > 0)
                 {
                     profesor.IdProfesor = ListaProfesor.Last().IdProfesor + 1;
                 }
                 ListaProfesor.Add(profesor);

                 */

                applicationDBContext.Profesor.Add(profesor);
                applicationDBContext.SaveChanges();
                return profesor.IdProfesor;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool EliminarProfesor(int IdProfesor)
        {
            try
            {
                /*bool bandera = false;
                int index = ListaProfesor.FindIndex(aux => aux.IdProfesor == IdProfesor);

                if (index >= 0)
                {
                    ListaProfesor.RemoveAt(index);
                    bandera = true;
                }*/
                var item = applicationDBContext.Profesor.SingleOrDefault(x => x.IdProfesor== IdProfesor);
                applicationDBContext.Profesor.Remove(item);
                applicationDBContext.SaveChanges();

                return true;

            }
            catch (Exception)
            {

                throw;
            }
        }

       

        List<Models.Profesor> IProfesor.ObtenerProfesor()
        {
            try
            {
                return applicationDBContext.Profesor.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        Models.Profesor IProfesor.ObtenerProfesorPorID(int IdProfesor)
        {
            try
            {
                var profesor = applicationDBContext.Profesor.SingleOrDefault(x => x.IdProfesor == IdProfesor);

                return profesor;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
