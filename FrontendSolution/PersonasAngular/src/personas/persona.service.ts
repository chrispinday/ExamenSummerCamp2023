import { HttpClient } from "@angular/common/http";
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IPersona } from "./persona";

@Injectable({
    providedIn: 'root'
})

export class PersonaService {
    personaApiUrl: string;

    constructor(private http: HttpClient) {
        this.personaApiUrl = 'https://localhost:7240/api/Persona';
    }

    postPersona(datosPersona: any): Observable<any> {
        return this.http.post(this.personaApiUrl, datosPersona);
    }

    getPersonas(): Observable<IPersona[]> {
        return this.http.get<IPersona[]>(this.personaApiUrl);
    }
}