import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ChartsModule } from 'ng2-charts';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { ButtonsModule } from 'ngx-bootstrap/buttons';
import { RegisterComponent } from './register.component';
import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';




@NgModule({
  imports: [
    FormsModule,
    CommonModule,
    ReactiveFormsModule,
    ChartsModule,
    BrowserModule,
    BsDropdownModule,
    ButtonsModule.forRoot()
  ],
  declarations: [ RegisterComponent ]
})
export class RegisterModule { }
