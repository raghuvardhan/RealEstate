import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { PropertyDetailComponent } from './components/property-detail/property-detail.component';
import { SearchResultsComponent } from './components/search-results/search-results.component';
import { UserProfileComponent } from './components/user-profile/user-profile.component';
import { LoginRegistrationComponent } from './components/login-registration/login-registration.component';
import { AddEditListingComponent } from './components/add-edit-listing/add-edit-listing.component';
import { HomeComponent } from './components/home/home.component';

const routes: Routes = [
  { path: 'property/:id', component: PropertyDetailComponent },
  { path: 'search', component: SearchResultsComponent },
  { path: 'profile', component: UserProfileComponent },
  { path: 'login', component: LoginRegistrationComponent },
  { path: 'add-listing', component: AddEditListingComponent },
  { path: 'edit-listing/:id', component: AddEditListingComponent },
  { path: '', component: HomeComponent },   // default path
  { path: '**', redirectTo: '' } ];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
