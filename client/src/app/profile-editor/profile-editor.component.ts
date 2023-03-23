import { Component, EventEmitter, Output } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Validators } from '@angular/forms';
import { FormArray } from '@angular/forms';

@Component({
  selector: 'app-profile-editor',
  templateUrl: './profile-editor.component.html',
  styleUrls: ['./profile-editor.component.scss']
})
export class ProfileEditorComponent {
  constructor(private fb: FormBuilder) { }
  
  @Output() formSubmit: EventEmitter<any> = new EventEmitter();

  pf = this.fb.group({
    firstName: ['', Validators.required],
    lastName: ['', Validators.required],
    email: ['', [Validators.required, Validators.email]],
    userName: ['', [Validators.required, Validators.minLength(9), Validators.pattern(/^[a-zA-Z]/)]],
    password: ['', 
    [ Validators.required, 
      Validators.minLength(10),
      Validators.pattern(/^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*=_+?])[A-Za-z\d!@#$%^&*=_+?]/),
    ]
  ]
  });

  get f()
  {
      return this.pf.controls;
  }
  
  onSubmit() {
    this.formSubmit.emit(this.pf.value);
  }
}
