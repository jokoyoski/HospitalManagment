import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ChartsModule } from 'ng2-charts';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { ButtonsModule } from 'ngx-bootstrap/buttons';


import { NavComponent } from '../nav/nav.component';
import { UsersComponent } from './users.component';
import { CommonModule } from '@angular/common';


@NgModule({
  imports: [
    FormsModule,
    CommonModule,
    ChartsModule,
    BsDropdownModule,
    ButtonsModule.forRoot()
  ],
  declarations: [ UsersComponent]
})
export class UsersModule { }
