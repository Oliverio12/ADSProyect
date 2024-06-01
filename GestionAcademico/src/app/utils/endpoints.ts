import { environment } from '../../environments/environment.development';

export const endpoints = {
  agregarEstudiante: environment.serverURL.concat(
    'api/Estudiante/agregarEstudiante'
  ),
  actualizarEstudiante: environment.serverURL.concat(
    'api/Estudiante/actualizarEstudiante/:idEstudiante'
  ),
  eliminarEstudiante: environment.serverURL.concat(
    'api/Estudiante/eliminarEstudiante/:idEstudiante'
  ),
  obtenerEstudiantePorID: environment.serverURL.concat(
    'api/Estudiante/obtenerEstudiantePorID/:idEstudiante'
  ),
  obtenerEstudiante: environment.serverURL.concat(
    'api/Estudiante/obtenerEstudiante'
  ),
};
