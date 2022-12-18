import {Component, Input, OnInit} from '@angular/core';
import {IUserReview} from "../../../models/review/userReview";

@Component({
  selector: 'app-reviews-profile',
  templateUrl: './reviews-profile.component.html',
  styleUrls: ['./reviews-profile.component.css']
})
export class ReviewsProfileComponent implements OnInit {

  @Input() userReviews:IUserReview[];

  constructor() {
  }

  ngOnInit(): void {
  }

}
