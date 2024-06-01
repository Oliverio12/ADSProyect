import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Observable } from 'rxjs';
import { endpoints } from '../utils/endpoints';
import { Estudiante } from '../interfaces/estudiante.interface';
@Injectable({
  providedIn: 'root',
})
export class EstudianteService {
  private readonly http = inject(HttpClient);
  constructor() {}
  // Obtener lista de estudiantes
  obtenerEstudiantes() {
    return this.http.get<Estudiante[]>(endpoints.obtenerEstudiante);
  }
  // Obtener estudiante por ID
  obtenerEstudiantePorID(idEstudiante: number) {
    return this.http.get<Estudiante>(
      endpoints.obtenerEstudiantePorID.replace(
        ':idEstudiante',
        idEstudiante.toString()
      )
    );
  }
  // Insertar estudiante
  agregarEstudiante(estudiante: Estudiante) {
    // Se arma el objeto a enviar
    let body = {
      nombresEstudiante: estudiante.nombresEstudiante,
      apellidosEstudiante: estudiante.apellidosEstudiante,
      codigoEstudiante: estudiante.codigoEstudiante,
      correoEstudiante: estudiante.correoEstudiante,
    };
    return this.http.post<any>(endpoints.agregarEstudiante, body);
  }
  // Eliminar un estudiante
  eliminarEstudiante(idEstudiante: number) {
    return this.http.delete<any>(
      endpoints.eliminarEstudiante.replace(
        ':idEstudiante',
        idEstudiante.toString()
      )
    );
  }
  actualizarEstudiante(idEstudiante: number, estudiante: Estudiante){
    // Se arma el objeto a enviar
    let body = {
    "idEstudiante": estudiante.idEstudiante,
    "nombresEstudiante": estudiante.nombresEstudiante,
    "apellidosEstudiante": estudiante.apellidosEstudiante,
    "codigoEstudiante": estudiante.codigoEstudiante,
    "correoEstudiante": estudiante.correoEstudiante
    }
    return this.http.patch<number>(endpoints.actualizarEstudiante.replace(':idEstudiante',idEstudiante.toString()), body);
    }
}
