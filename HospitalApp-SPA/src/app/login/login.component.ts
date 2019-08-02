import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../Services/Auth.service';
import { AlertifyService } from '../../Services/Alertify.service';
import { Router } from '@angular/router';
import { FormBuilder, NgModel } from '@angular/forms';
import { User } from '../../Model/User';



@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  model: any = {};
  constructor(public authService: AuthService,
     private alertifyService: AlertifyService, 
     private router: Router, private  fb: FormBuilder) { }   
     // a service was created and was injected to this component and before it has to work, we ust have called it in the app.module.ts
 

  ngOnInit() {
  }
 
  logs(e:any,m:any)
  {
   if(m.value!=""&&e.value!="")
   {
     return true;

   }
   return false;
  }
  login()
  {
    console.log("ok");
    this.authService.login(this.model).subscribe((response:any)=>{
      this.router.navigate(['dashboard']);  // navigate to home
    },(error)=>{
      
     this.alertifyService.error(error.error); 
    })

   
  }
}
