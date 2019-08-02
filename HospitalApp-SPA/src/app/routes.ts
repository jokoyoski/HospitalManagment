import {Routes} from '@angular/router';

import { DashboardComponent } from './views/dashboard/dashboard.component';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { DefaultLayoutComponent } from './containers';
import { NavComponent } from './views/nav/nav.component';
import { AuthGuard } from './_guards/auth.guard';
import { UsersComponent } from './views/users/users.component';
import { UsersResolvers } from './_resolvers/users.resolvers';


  export const appRoutes: Routes = [

{path: '', component : LoginComponent },
{
path:'',
runGuardsAndResolvers: 'always',

children:[
// tslint:disable-next-line: max-line-length
{path: 'dashboard', component : NavComponent,children:[    //this is used for layout where navbar is layout and dashboard is the main page
  { path: '', component: DashboardComponent, canActivate: [AuthGuard] }
  
] },  // we specify this for url that has parameter
{path: 'users', component : NavComponent,children:[    //this is used for layout where navbar is layout and dashboard is the main page
  { path: '', component: UsersComponent, canActivate: [AuthGuard] }
  
],resolve: {user: UsersResolvers} },

]
},


{path: 'Register', component : RegisterComponent },
{path: '**', redirectTo: '', pathMatch: 'full' }


];
