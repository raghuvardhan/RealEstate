import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { PropertyService } from '../../services/property/property.service';
import { Property } from '../../models/property';

@Component({
  selector: 'app-property-detail',
  templateUrl: './property-detail.component.html',
  styleUrls: ['./property-detail.component.css']
})
export class PropertyDetailComponent implements OnInit {
  property!: Property;

  constructor(
    private route: ActivatedRoute,
    private propertyService: PropertyService
  ) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    this.propertyService.getProperty(Number(id)).subscribe(property => {
      this.property = property;
    });
  }
}
