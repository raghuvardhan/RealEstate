import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PropertyService } from '../../services/property/property.service';
import { Property } from '../../models/property';

@Component({
  selector: 'app-property-detail',
  templateUrl: './property-detail.component.html',
  styleUrls: ['./property-detail.component.css']
})
export class PropertyDetailComponent implements OnInit {
  @Input() property!: Property;

  constructor(
    private propertyService: PropertyService
  ) { }

  ngOnInit(): void {
    this.property = this.propertyService.selectedProperty;
    console.log(this.property);
  }
}
