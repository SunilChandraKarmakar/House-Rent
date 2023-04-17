import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PageNotFoundComponent } from './components/page-not-found/page-not-found.component';
import { AddPropertyComponent } from './components/property/add-property/add-property.component';
import { PropertyDetailComponent } from './components/property/property-detail/property-detail.component';
import { PropertyListComponent } from './components/property/property-list/property-list.component';
import { UserLoginComponent } from './components/user/user-login/user-login.component';
import { UserRegistrationComponent } from './components/user/user-registration/user-registration.component';

const routes: Routes = [
  { path: "", component: PropertyListComponent },
  { path: "rent-property", component: PropertyListComponent },
  { path: "add-property", component: AddPropertyComponent },
  { path: "property-detail/:id", component: PropertyDetailComponent },
  { path: "user/login", component: UserLoginComponent },
  { path: "user/registration", component: UserRegistrationComponent },
  { path: "**", component: PageNotFoundComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }