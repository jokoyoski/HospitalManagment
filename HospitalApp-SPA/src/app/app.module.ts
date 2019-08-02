import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { LocationStrategy, HashLocationStrategy } from '@angular/common';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { PerfectScrollbarModule } from 'ngx-perfect-scrollbar';
import { PERFECT_SCROLLBAR_CONFIG } from 'ngx-perfect-scrollbar';
import { PerfectScrollbarConfigInterface } from 'ngx-perfect-scrollbar';

const DEFAULT_PERFECT_SCROLLBAR_CONFIG: PerfectScrollbarConfigInterface = {
  suppressScrollX: true
};

import { AppComponent } from './app.component';

// Import container

import { P404Component } from './views/error/404.component';
import { P500Component } from './views/error/500.component';



import {
  AppAsideModule,
  AppBreadcrumbModule,
  AppHeaderModule,
  AppFooterModule,
  AppSidebarModule,
} from '@coreui/angular';

// Import routing module

// Import 3rd party components
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { ChartsModule } from 'ng2-charts';
import { DashboardModule } from './views/dashboard/dashboard.module';

import { RouterModule, RouterLink } from '@angular/router';
import { appRoutes } from './routes';
import { AlertifyService } from '../Services/Alertify.service';
import { AuthService } from '../Services/Auth.service';
import { RegisterModule } from './register/register.module';
import { HttpClientModule } from '@angular/common/http';
import { LoginModule } from './login/login-module';
import { DefaultLayoutComponent } from './containers';
import { NavComponent } from './views/nav/nav.component';
import { UsersModule } from './views/users/users.module';
import { JwtModule } from '@auth0/angular-jwt';
import { UsersResolvers } from './_resolvers/users.resolvers';
import { UserService } from '../Services/user.service';

export function TokenGetter() {
   return localStorage.getItem('token');      // this is the token
}

@NgModule({
   imports: [
      BrowserModule,
      BrowserAnimationsModule,
      RouterModule.forRoot(appRoutes),
      // routes.tswascreatedanditwasaddedhereandweuserrouterlinkonview\\nAppAsideModule,
      RegisterModule,
      DashboardModule,
      HttpClientModule,
      AppBreadcrumbModule.forRoot(),
      AppFooterModule,
      AppAsideModule,
      AppHeaderModule,
      UsersModule,
      
      AppSidebarModule,
      LoginModule,
      PerfectScrollbarModule,
      BsDropdownModule.forRoot(),
      TabsModule.forRoot(),
      JwtModule.forRoot({




         config: {
            tokenGetter: TokenGetter
         ,
// tslint:disable-next-line: max-line-length  //
       whitelistedDomains: ['jokoyoski200-001-site1.itempurl.com'],  // we just got the token from (Token Getter function above) and we  send request , it is automatically sending token
       blacklistedRoutes: ['jokoyoski200-001-site1.itempurl.com/api/auth']  // we dont want to send token to this address
      }
      }),
      ChartsModule
   ],
   declarations: [
      AppComponent,
      DefaultLayoutComponent,
NavComponent,
      P404Component,
      P500Component,
   
   ],
   providers: [
      AuthService,
      AlertifyService,
      UsersResolvers,
      UserService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
