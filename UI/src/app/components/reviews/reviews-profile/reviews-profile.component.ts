import {Component, Input, OnInit} from '@angular/core';
import {UserReviewService} from "../../../services/review/userReview.service";
import {IUserReview} from "../../../models/review/userReview";
import {AdvtReviewService} from "../../../services/review/advtReview.service";

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
