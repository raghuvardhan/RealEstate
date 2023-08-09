import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { ListingComponent } from './components/listing/listing.component';
import { PropertyDetailComponent } from './components/property-detail/property-detail.component';
import { SearchResultsComponent } from './components/search-results/search-results.component';
import { UserProfileComponent } from './components/user-profile/user-profile.component';
import { LoginRegistrationComponent } from './components/login-registration/login-registration.component';
import { AddEditListingComponent } from './components/add-edit-listing/add-edit-listing.component';
import { FormsModule } from '@angular/forms';
import { HttpClient, HttpClientModule } from '@angular/common/http';

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
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
