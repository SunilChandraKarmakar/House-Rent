import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PageNotFoundComponent } from './components/page-not-found/page-not-found.component';
import { AddPropertyComponent } from './components/property/add-property/add-property.component';
import { PropertyDetailComponent } from './components/property/property-detail/property-detail.component';
import { PropertyListComponent } from './components/property/property-list/property-list.component';
import { UserLoginComponent } from './components/user/user-login/user-login.component';
import { UserRegistrationComponent } from './components/user/user-registration/user-registration.component';
import { PropertyTypeListComponent } from './components/property-type-list/property-type-list.component';
import { PropertyTypeDetailsComponent } from './components/property-type-details/property-type-details.component';
import { FurnishingTypeListComponent } from './components/furnishing-type-list/furnishing-type-list.component';
import { FurnishingTypeDetailsComponent } from './components/furnishing-type-details/furnishing-type-details.component';

const routes: Routes = [
  { path: "", component: UserLoginComponent },
   
  { path: "rent-property", component: PropertyListComponent, pathMatch: "full" },
  { path: "buy-property", component: PropertyListComponent, pathMatch: "full" },

  { path: "add-property", component: AddPropertyComponent, pathMatch: "full" },
  { path: "property-detail/:id", component: PropertyDetailComponent, pathMatch: "full" },
  
  { path: "user/login", component: UserLoginComponent, pathMatch: "full" },
  { path: "user/registration", component: UserRegistrationComponent, pathMatch: "full" },

  { path: "property-types", component: PropertyTypeListComponent, pathMatch: "full" },
  { path: "property-types/details", component: PropertyTypeDetailsComponent, pathMatch: "full" },
  { path: "property-types/details/:recordId", component: PropertyTypeDetailsComponent, pathMatch: "full" },

  { path: "furnishing-types", component: FurnishingTypeListComponent, pathMatch: "full" },
  { path: "furnishing-type/details", component: FurnishingTypeDetailsComponent, pathMatch: "full" },
  { path: "furnishing-type/details/:recordId", component: FurnishingTypeDetailsComponent, pathMatch: "full" },
  
  { path: "**", component: PageNotFoundComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }