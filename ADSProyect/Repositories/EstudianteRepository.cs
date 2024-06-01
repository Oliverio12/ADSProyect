using ADSProyect.Models;
using ADSProyect.Interfaces;
using ADSProyect.DB;

namespace ADSProyect.Repositories
{
    public class EstudianteRepository : IEstudiante
    {
        /*private List<Estudiante> lstEstudiante = new List<Estudiante>
        {
            new Estudiante
            {
                IdEstudiante = 1,
                NombreEstudiante = "JUAN CARLOS",
                ApellidoEstudiante = "PEREZ SOSA",
                CodigoEstudiante = "PS24I04002",
                CorreoEstudiante = "PS24I04002@usonsonate.edu.sv"
            },
            new Estudiante
            {
                IdEstudiante = 2,
                NombreEstudiante = "RODRIGO OLIVERIO",
                ApellidoEstudiante = "FERNANDEZ ZAVALETA",
                CodigoEstudiante = "FZ21I04001",
                CorreoEstudiante = "FZ21I04001@usonsonate.edu.sv"
            }
        };*/

        private readonly ApplicationDbContext applicationDBContext;

        public EstudianteRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDBContext = applicationDbContext;
        }

        public int ActualizarEstudiante(int idEstudiante, Estudiante estudiante)
        {

            try
            {
                //Obtener el indice del objeto para actualizar
                //int indice = lstEstudiante.FindIndex(tmp => tmp.IdEstudiante == idEstudiante);
                //procedemos con la actualizacion
                //lstEstudiante[indice] = estudiante;

                var item = applicationDBContext.Estudiante.SingleOrDefault(x => x.IdEstudiante == idEstudiante);
                applicationDBContext.Entry(item).CurrentValues.SetValues(estudiante);
                applicationDBContext.SaveChanges(); 

                return idEstudiante;

            }
            catch (Exception e)
            {
                throw;
            }

        }

        public int AgregarEstudiante(Estudiante estudiante)
        {
            try {
                //Validar si existen datos en la lista, de ser asi, tomaremos el ultimo ID
                //y lo incrementaremos en una unidad

                /*if(lstEstudiante.Count > 0)
                {
                    estudiante.IdEstudiante = lstEstudiante.Last().IdEstudiante + 1;
                }
                lstEstudiante.Add(estudiante);*/

                applicationDBContext.Estudiante.Add(estudiante);
                applicationDBContext.SaveChanges();
                
                return estudiante.IdEstudiante;

            }catch(Exception )
            {
                throw; 
            }

        }

        public bool EliminarEstudiante(int idEstudiante)
        {
            try
            {
                //Obtener el indice del objeto para eliminar
                //int indice = lstEstudiante.FindIndex(tmp => tmp.IdEstudiante == idEstudiante);
                //procedemos con la eliminacion
                //lstEstudiante.RemoveAt(indice);

                var item = applicationDBContext.Estudiante.SingleOrDefault(x => x.IdEstudiante == idEstudiante);
                applicationDBContext.Estudiante.Remove(item);
                applicationDBContext.SaveChanges();

                return true;

            }
            catch (Exception e)
            {
                throw;
            }

        }

        public Estudiante ObtenerEstudiantePorID(int idEstudiante)
        {
            try
            {
                //Estudiante estudiante = lstEstudiante.FirstOrDefault(tmp => tmp.IdEstudiante == idEstudiante);
                var estudiante = applicationDBContext.Estudiante.SingleOrDefault(x => x.IdEstudiante == idEstudiante);

                return estudiante;

            }
            catch (Exception e)
            {
                throw;
            }

        }
        public List<Estudiante> ObtenerTodosLosEstudiantes()
        {
            try
            {
                //return lstEstudiante;

                return applicationDBContext.Estudiante.ToList();
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
