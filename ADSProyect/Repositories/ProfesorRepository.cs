using ADSProyect.Interfaces;
using ADSProyect.Models;

namespace ADSProyect.Repositories
{
    public class ProfesorRepository : IProfesor
    {
        private List<Profesor> ListaProfesor = new List<Profesor>
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

        };

        public int ActualizarProfesor(int IdProfesor, Profesor profesor)
        {
            try
            {
                int bandera = 0;
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

                return bandera;

            }catch (Exception )
            {
                throw;
            }        
        }

        public int AgregarProfesor(Profesor profesor)
        {
            try
            {
                if (ListaProfesor.Count > 0)
                {
                    profesor.IdProfesor = ListaProfesor.Last().IdProfesor + 1;
                }
                ListaProfesor.Add(profesor);

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
                bool bandera = false;
                int index = ListaProfesor.FindIndex(aux => aux.IdProfesor == IdProfesor);

                if (index >= 0)
                {
                    ListaProfesor.RemoveAt(index);
                    bandera = true;
                }

                return bandera;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Profesor> ObtenerProfesor()
        {
            try
            {
                return ListaProfesor;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Profesor ObtenerProfesorPorID(int IdProfesor)
        {
            try
            {
                var profe = ListaProfesor.FirstOrDefault(tmp => tmp.IdProfesor == IdProfesor);

                return profe;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
