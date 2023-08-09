import { Component, OnInit, Input } from '@angular/core';
import { Property } from '../../models/property';
import { PropertyService } from 'src/app/services/property/property.service';
import { Route, Router } from '@angular/router';

@Component({
  selector: 'app-listing',
  templateUrl: './listing.component.html',
  styleUrls: ['./listing.component.css']
})
export class ListingComponent implements OnInit {
  @Input()
  property!: Property;

  constructor(private propertyService: PropertyService, private router: Router) { }

  ngOnInit(): void {
  }

  selectProperty(property: any) {
    this.propertyService.selectedProperty = property;
    this.router.navigate(['/property', property.id]);
  }
}
