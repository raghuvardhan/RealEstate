import { Component, OnInit } from '@angular/core';
import { PropertyService } from '../property.service';
import { Router } from '@angular/router';
import { Property } from '../models/property';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  properties: Property[] = [];

  constructor(private propertyService: PropertyService, private router: Router) { }

  ngOnInit(): void {
    this.propertyService.getProperties().subscribe(properties => {
      this.properties = properties;
    });
  }

  viewProperty(id: number): void {
    this.router.navigate(['/property', id]);
  }
}
