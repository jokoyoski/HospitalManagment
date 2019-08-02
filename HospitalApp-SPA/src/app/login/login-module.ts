import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ChartsModule } from 'ng2-charts';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { ButtonsModule } from 'ngx-bootstrap/buttons';

import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login.component';
import { RouterModule } from '@angular/router';




@NgModule({
  imports: [
    FormsModule,
    CommonModule,
    RouterModule,
    ChartsModule,
    BrowserModule,
    BsDropdownModule,
    ButtonsModule.forRoot()
  ],
  declarations: [ LoginComponent ]
})
export class LoginModule { }
