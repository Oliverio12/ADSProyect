using ADSProyect.Interfaces;
using ADSProyect.Models;

namespace ADSProyect.Repositories
{
    public class GruposRepository : IGrupos
    {
        private List<Grupos> ListaGrupos = new List<Grupos>
        {
            new Grupos
            { 
                IdGrupo = 1,
                IdCarrera = 1,
                IdMateria = 1,
                IdProfesor = 1,
                Ciclo = 02,
                Anio = 2024,
            },
            new Grupos
            {
                IdGrupo = 2,
                IdCarrera = 3,
                IdMateria = 1,
                IdProfesor = 4,
                Ciclo = 01,
                Anio = 2023,
            },
            new Grupos
            {
                IdGrupo = 3,
                IdCarrera = 2,
                IdMateria = 3,
                IdProfesor = 3,
                Ciclo = 01,
                Anio = 2022,
            }

        };
        public int ActualizarGrupo(int IdGrupo, Grupos grupos)
        {
            try
            {
                int indice = ListaGrupos.FindIndex(tmp => tmp.IdGrupo == IdGrupo);
                ListaGrupos[indice] = grupos;

                return IdGrupo;

            }
            catch (Exception e)
            {
                throw;
            }
        }

        public int AgregarGrupo(Grupos grupos)
        {
            try
            {
                if (ListaGrupos.Count > 0)
                {
                    grupos.IdGrupo = ListaGrupos.Last().IdGrupo + 1;
                }
                ListaGrupos.Add(grupos);

                return grupos.IdGrupo;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool EliminarGrupo(int IdGrupo)
        {
            try
            {
                bool bandera = false;
                int index = ListaGrupos.FindIndex(aux => aux.IdGrupo == IdGrupo);

                if (index >= 0)
                {
                    ListaGrupos.RemoveAt(index);
                    bandera = true;
                }

                return bandera;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Grupos ObtenerGrupoPorID(int IdGrupo)
        {
            try
            {
                var grupo = ListaGrupos.FirstOrDefault(tmp => tmp.IdGrupo == IdGrupo);

                return grupo;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Grupos> ObtenerTodosLosGrupos()
        {
            try
            {
                return ListaGrupos;
            }
            catch
            {
                throw;
            }
        }

     
    }
}
