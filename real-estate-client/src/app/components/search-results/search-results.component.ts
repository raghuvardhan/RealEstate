import { Component, EventEmitter, OnInit } from '@angular/core';
import { SearchFilterService } from '../../services/search/search-filter.service';
import { Property } from '../../models/property';

@Component({
  selector: 'app-search-results',
  templateUrl: './search-results.component.html',
  styleUrls: ['./search-results.component.css']
})
export class SearchResultsComponent implements OnInit {
  properties: Property[] = [];
  searchQuery = '';

  searchQueryChange = new EventEmitter<string>();

  constructor(private searchFilterService: SearchFilterService) { }

  ngOnInit(): void {
  }

  onSearch(): void {
    this.searchFilterService.searchProperties(this.searchQuery).subscribe(properties => {
      this.properties = properties;
    });
  }
}
