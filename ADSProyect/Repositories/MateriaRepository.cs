using ADSProyect.DB;
using ADSProyect.Interfaces;
using ADSProyect.Migrations;
using ADSProyect.Models;

namespace ADSProyect.Repositories
{
    public class MateriaRepository : IMaterias
    {
        /*private List<Materias> listMaterias = new List<Materias>
        {
            new Materias
            {
                idMateria = 1,
                nombreMateria = "Desarrollo de software"
            },
             new Materias
            {
                idMateria = 2,
                nombreMateria = "Analisis de sistemas"
            },
              new Materias
            {
                idMateria = 3,
                nombreMateria = "Desarrollo de dispositivos moviles"
            }
        };*/

        private readonly ApplicationDbContext applicationDBContext;

        public MateriaRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDBContext = applicationDbContext;
        }
     
        public int Actualizarmateria(int idMateria, Models.Materias materia)
        {
            try
            {
                /*int bandera = 0;
                int index = listMaterias.FindIndex(tmp => tmp.idMateria == idMateria);

                if (index > 0)
                {
                    listMaterias[index] = materia;
                    bandera = idMateria;
                }
                else
                {
                    bandera = -1;
                }*/
                var item = applicationDBContext.Materias.SingleOrDefault(x => x.idMateria == idMateria);
                applicationDBContext.Entry(item).CurrentValues.SetValues(materia);
                applicationDBContext.SaveChanges();

                return idMateria;

            }
            catch (Exception)
            {
                throw;
            }
        }

      

        public int AgregarMateria(Models.Materias materia)
        {
            try
            {
                /*if (listMaterias.Count > 0)
                {
                    materia.idMateria = listMaterias.Last().idMateria + 1;
                }
                listMaterias.Add(materia);
                */


                applicationDBContext.Materias.Add(materia);
                applicationDBContext.SaveChanges();

                return materia.idMateria;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool EliminarMateria(int idMateria)
        {
            try
            {
                /* bool bandera = false;
                 int index = listMaterias.FindIndex(aux => aux.idMateria == idMateria);

                 if (index >= 0)
                 {
                     listMaterias.RemoveAt(index);
                     bandera = true;
                 }*/

                var item = applicationDBContext.Materias.SingleOrDefault(x => x.idMateria == idMateria);
                applicationDBContext.Materias.Remove(item);
                applicationDBContext.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

      
      

        Models.Materias IMaterias.ObtenerMateriaPorID(int idMateria)
        {

            try
            {
                var materia = applicationDBContext.Materias.SingleOrDefault(x => x.idMateria == idMateria);

                return materia;

            }
            catch (Exception)
            {

                throw;
            }
        }

        List<Models.Materias> IMaterias.ObtenerMaterias()
        {
            try
            {
                return applicationDBContext.Materias.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
