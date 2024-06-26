import { Component, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {HTTP_INTERCEPTORS, HttpClientModule} from '@angular/common/http'
import { AppComponent } from './app.component';
import { Routes,RouterModule } from '@angular/router';
import { PropertyCardCompenent } from './property/property-card/property-card.component';
import { PropertyListComponent } from './property/property-list/property-list.component';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { HousingService } from './services/housing.service';
import { AddPropertyComponent } from './property/add-property/add-property.component';
import { PropertyDetailsComponent } from './property/property-details/property-details.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { UserLoginComponent } from './user/user-login/user-login.component';
import { UserRegisterComponent } from './user/user-register/user-register.component';
import { AlertifyService } from './services/alertify.service';
import { AuthService } from './services/auth.service';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {BsDropdownModule} from 'ngx-bootstrap/dropdown'
import {TabsModule} from 'ngx-bootstrap/tabs';
import {ButtonsModule} from 'ngx-bootstrap/buttons';
import { NgxGalleryModule } from '@kolkov/ngx-gallery';
import { FilterPipe } from './pipes/filter.pipe';
import { SortPipe } from './pipes/sort.pipe';
import { HttpErrorInterceptorService } from './services/httperror-interceptor.service';
import { DatePipe } from '@angular/common';
import { PhotoEditorComponent } from './property/photo-editor/photo-editor.component';
import { FileUploadModule } from 'ng2-file-upload';
import { LandingPageHomeComponent } from './landingPage/landing-page-home/landing-page-home.component';

const appRoutes: Routes=[
  {path:'', component :LandingPageHomeComponent},
  { path: 'buy', component: PropertyListComponent },
  { path: 'rent', component: PropertyListComponent },
  { path: 'login', component: UserLoginComponent },
  { path: 'register', component: UserRegisterComponent },
  {path:'add-property', component :AddPropertyComponent},
  {path:'rent-property', component :PropertyListComponent},
  {path:'property-details/:id', component :PropertyDetailsComponent},
  {path:'user/login', component :UserLoginComponent},
  {path:'user/register', component :UserRegisterComponent},

  {path:'**', component :PropertyListComponent},
 
]

@NgModule({
  declarations: [
    AppComponent,
    PropertyCardCompenent,
    PropertyListComponent,
    NavBarComponent,
    AddPropertyComponent,
    PropertyDetailsComponent,
    UserLoginComponent,
    UserRegisterComponent,
    FilterPipe,
    SortPipe,
    PhotoEditorComponent,
    LandingPageHomeComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    RouterModule.forRoot(appRoutes),
    BrowserAnimationsModule,  
    BsDropdownModule.forRoot(),
    TabsModule.forRoot(),
    ButtonsModule.forRoot(),
    NgxGalleryModule,
    FileUploadModule
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: HttpErrorInterceptorService,
      multi:true
    },
    DatePipe,
    HousingService,
    AlertifyService,
    AuthService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
