import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { ListingComponent } from './listing/listing.component';
import { PropertyDetailComponent } from './property-detail/property-detail.component';
import { SearchResultsComponent } from './search-results/search-results.component';
import { UserProfileComponent } from './user-profile/user-profile.component';
import { LoginRegistrationComponent } from './login-registration/login-registration.component';
import { AddEditListingComponent } from './add-edit-listing/add-edit-listing.component';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    ListingComponent,
    PropertyDetailComponent,
    SearchResultsComponent,
    UserProfileComponent,
    LoginRegistrationComponent,
    AddEditListingComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
