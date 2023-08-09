import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PropertyService } from '../../services/property/property.service';
import { Property } from '../../models/property';

@Component({
  selector: 'app-add-edit-listing',
  templateUrl: './add-edit-listing.component.html',
  styleUrls: ['./add-edit-listing.component.css']
})
export class AddEditListingComponent implements OnInit {
  listing: Property = {
    id: 0,
    title: '',
    price: 0,
    location: '',
    propertyType: '',
    numberOfBedrooms: 0,
    numberOfBathrooms: 0,
    description: ''
    // Initialize other properties as needed
  };

  constructor(
    private route: ActivatedRoute,
    private propertyService: PropertyService
  ) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.propertyService.getProperty(Number(id)).subscribe(listing => {
        this.listing = listing;
      });
    }
  }

  onSubmit(): void {
    if (this.listing.id) {
      this.propertyService.updateProperty(this.listing).subscribe(listing => {
        // Handle successful update
      });
    } else {
      this.propertyService.addProperty(this.listing).subscribe(listing => {
        // Handle successful add
      });
    }
  }
}
