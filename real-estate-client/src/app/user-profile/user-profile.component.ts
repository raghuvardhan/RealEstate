import { Component, OnInit } from '@angular/core';
import { UserService } from '../user.service';
import { PropertyService } from '../property.service';
import { Property } from '../models/property';
import { User } from '../models/user';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css']
})
export class UserProfileComponent implements OnInit {
  user!: User;
  listings: Property[] = [];

  constructor(
    private userService: UserService,
    private propertyService: PropertyService
  ) { }

  ngOnInit(): void {
    this.userService.getUserProfile().subscribe(user => {
      this.user = user;
    });

    this.propertyService.getProperties().subscribe(properties => {
      this.listings = properties;
    });
  }
}
