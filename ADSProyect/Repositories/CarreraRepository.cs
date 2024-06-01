
using ADSProyect.DB;
using ADSProyect.Interfaces;
using ADSProyect.Models;
namespace ADSProyect.Repositories
{
    public class CarreraRepository : ICarrera
    {
        /*private List<Carrera> lstCarrera = new List<Carrera>
        {
            new Carrera
            {
                IdCarrera = 1,
                Codigo = "I04001",
                Nombre = "Ingenieria en Sistemas computacionales"
            },
            new Carrera
            {
                IdCarrera = 2,
                Codigo = "I05001",
                Nombre = "Ingenieria en Industrial"
            }
        };*/

        private readonly ApplicationDbContext applicationDbContext;
        public CarreraRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }

        public int ActualizarCarrera(int IdCarrera, Carrera carrera)
        {
            try
            {
                //int indice = lstCarrera.FindIndex(tmp => tmp.IdCarrera == IdCarrera);

                //lstCarrera[indice] = carrera;
                var item = applicationDbContext.Carrera.SingleOrDefault(x => x.IdCarrera == IdCarrera);
                applicationDbContext.Entry(item).CurrentValues.SetValues(carrera);
                applicationDbContext.SaveChanges();

                return IdCarrera;

            }
            catch (Exception e)
            {
                throw;
            }
        }

        public int AgregarCarrera(Carrera carrera)
        {
            try
            {
                //Validar si existen datos en la lista, de ser asi, tomaremos el ultimo ID
                //y lo incrementaremos en una unidad
                /*if (lstCarrera.Count > 0)
                {
                    carrera.IdCarrera = lstCarrera.Last().IdCarrera + 1;
                }

                lstCarrera.Add(carrera);*/

                applicationDbContext.Carrera.Add(carrera);
                applicationDbContext.SaveChanges();


                return carrera.IdCarrera;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool EliminarCarrera(int IdCarrera)
        {
            try
            {
                //Obtener el indice del objeto para eliminar
                //int indice = lstCarrera.FindIndex(tmp => tmp.IdCarrera == IdCarrera);
                //procedemos con la eliminacion
                //lstCarrera.RemoveAt(indice);

                var item = applicationDbContext.Carrera.SingleOrDefault(x => x.IdCarrera == IdCarrera);
                applicationDbContext.Carrera.Remove(item);
                applicationDbContext.SaveChanges();

                return true;

            }
            catch (Exception e)
            {
                throw;
            }
        }
        public Carrera ObtenerTodasLasCarrerasPorID(int IdCarrera)
        {
            try
            {
                //Carrera carrera = lstCarrera.FirstOrDefault(tmp => tmp.IdCarrera == IdCarrera);
                var carrera = applicationDbContext.Carrera.SingleOrDefault(x => x.IdCarrera == IdCarrera);

                return carrera;

            }
            catch (Exception e)
            {
                throw;
            }
        }

        public List<Carrera> ObtenerCarreras()
        {
            try
            {
                //return lstCarrera;
                return applicationDbContext.Carrera.ToList();
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
