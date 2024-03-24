using ADSProyect.Interfaces;
using ADSProyect.Models;

namespace ADSProyect.Repositories
{
    public class MateriaRepository : IMaterias
    {
        private List<Materias> listMaterias = new List<Materias>
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
        };
        public int Actualizarmateria(int idMateria, Materias materia)
        {
            try
            {
                int bandera = 0;
                int index = listMaterias.FindIndex(tmp => tmp.idMateria == idMateria);

                if (index > 0)
                {
                    listMaterias[index] = materia;
                    bandera = idMateria;
                }
                else
                {
                    bandera = -1;
                }

                return bandera;

            }catch (Exception )
            {
                throw;
            }
        }

        public int AgregarMateria(Materias materia)
        {
            try
            {
                if (listMaterias.Count > 0)
                {
                    materia.idMateria = listMaterias.Last().idMateria + 1;
                }
                listMaterias.Add(materia);

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
                bool bandera = false;
                int index = listMaterias.FindIndex(aux => aux.idMateria == idMateria);

                if (index >= 0)
                {
                    listMaterias.RemoveAt(index);
                    bandera = true;
                }

                return bandera;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Materias ObtenerMateriaPorID(int idMateria)
        {
            try
            {
                var materia = listMaterias.FirstOrDefault(tmp => tmp.idMateria == idMateria);

                return materia;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Materias> ObtenerMaterias()
        {
            try
            {
                return listMaterias;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
