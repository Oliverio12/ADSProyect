using ADSProyect.Models;
using ADSProyect.Interfaces;

namespace ADSProyect.Repositories
{
    public class EstudianteRepository : IEstudiante
    {
        private List<Estudiante> lstEstudiante = new List<Estudiante>
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
        };

        public int ActualizarEstudiante(int idEstudiante, Estudiante estudiante)
        {

            try
            {
                //Obtener el indice del objeto para actualizar
                int indice = lstEstudiante.FindIndex(tmp => tmp.IdEstudiante == idEstudiante);
                //procedemos con la actualizacion
                lstEstudiante[indice] = estudiante;

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
                if(lstEstudiante.Count > 0)
                {
                    estudiante.IdEstudiante = lstEstudiante.Last().IdEstudiante + 1;
                }

                lstEstudiante.Add(estudiante);
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
                int indice = lstEstudiante.FindIndex(tmp => tmp.IdEstudiante == idEstudiante);
                //procedemos con la eliminacion
                lstEstudiante.RemoveAt(indice);

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
                Estudiante estudiante = lstEstudiante.FirstOrDefault(tmp => tmp.IdEstudiante == idEstudiante);
                
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
                return lstEstudiante;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
