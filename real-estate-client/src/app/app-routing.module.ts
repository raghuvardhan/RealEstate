import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { PropertyDetailComponent } from './property-detail/property-detail.component';
import { SearchResultsComponent } from './search-results/search-results.component';
import { UserProfileComponent } from './user-profile/user-profile.component';
import { LoginRegistrationComponent } from './login-registration/login-registration.component';
import { AddEditListingComponent } from './add-edit-listing/add-edit-listing.component';

const routes: Routes = [
  { path: 'property/:id', component: PropertyDetailComponent },
  { path: 'search', component: SearchResultsComponent },
  { path: 'profile', component: UserProfileComponent },
  { path: 'login', component: LoginRegistrationComponent },
  { path: 'add-listing', component: AddEditListingComponent },
  { path: 'edit-listing/:id', component: AddEditListingComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
