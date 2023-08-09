import { Component, OnInit, Input } from '@angular/core';
import { Property } from '../../models/property';

@Component({
  selector: 'app-listing',
  templateUrl: './listing.component.html',
  styleUrls: ['./listing.component.css']
})
export class ListingComponent implements OnInit {
  @Input()
  property!: Property;

  constructor() { }

  ngOnInit(): void {
  }
}
