import { Component, OnInit } from '@angular/core';

import { AlertifyService } from '../../Services/Alertify.service';
import { Router } from '@angular/router';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { AuthService } from '../../Services/Auth.service';
import { User } from '../../Model/User';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

model: User;
  registerForm: FormGroup;  // this was the first step of the reactive view, then we change the html page to suit reactive
  // tslint:disable-next-line: max-line-length
  constructor(public authService: AuthService, private alertifyService: AlertifyService, private router: Router, private  fb: FormBuilder) { }   // a service was created and was injected to this component and before it has to work, we ust have called it in the app.module.ts
  // ngForm  is the form itself so we give it a name and we need to add its module FormsModule
  // Id:number;


  ngOnInit() {
    this.createRegisterForm();
  }




  createRegisterForm() {
    this.registerForm = this.fb.group({  // step 2

      Gender : ['male'],
      firstName : ['', Validators.required],   // setting the validators
     lastName : ['', Validators.required],
      email : ['', Validators.required],
      dateOfBirth: [null, Validators.required],

    password : ['', [Validators.required, Validators.minLength(4)]],
    confirmPassword : ['', Validators.required, ],

    }, {validator: this.passwordMatchValidator});
  }
  passwordMatchValidator(g: FormGroup) {  // if password are equal

      return g.get('password').value === g.get('confirmPassword').value ? null : {mismatch: true};
    }


    register() {
      if (this.registerForm.valid) {
       this.model = Object.assign({}, this.registerForm.value);
       console.log(this.model);
      }
  
      this.authService.registerUser(this.model).subscribe((response: any) => {
         this.alertifyService.success(response.success);
         console.log(response);
      },(error=>{
        console.log(error);
      }));

  }}
