import { Component } from '@angular/core';
import { PersonaService } from 'src/personas/persona.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { IPersona } from 'src/personas/persona';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'PersonasAngular';
  myForm: FormGroup;
  listPersonas: IPersona[] = [];
  sub!: Subscription;
  errorMessage: string = 'Server petition failed';
  createErrorMessage : string | null = null;

  constructor(private personaService: PersonaService, private fb: FormBuilder) {
    this.myForm = this.fb.group({
      nombre: ['', Validators.required],
      apellidos: ['', Validators.required],
      edad: ['', Validators.required],
      telefono: ['',]
    });
  }

  ngOnInit(): void {
    this.mostrarPersonas();
  }

  onSubmit() {
    if (this.myForm.valid) {
      const datosPersona = this.myForm.value;
      this.crearPersona(datosPersona);
    }
  }

  private crearPersona(datosPersona:any){
    console.log(this.myForm);
    this.personaService.postPersona(datosPersona).subscribe(
      (response) => {
        // Database insertion successful
        console.log('User inserted into the database:', datosPersona);
        this.mostrarPersonas();
      },
      (error) => {
        // Database insertion failed
        console.error('Database insertion error:', error);
        this.createErrorMessage = this.errorMessage;
      }
    );
  }

  private mostrarPersonas():void{
    this.sub = this.personaService.getPersonas().subscribe({
      next: personas => {
        this.listPersonas = personas;
      },
      error: err => this.errorMessage = err
    });
  }

  ngOnDestroy(): void {
    this.sub.unsubscribe();
  }
}

