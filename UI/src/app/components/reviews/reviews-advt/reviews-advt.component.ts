import {Component, Input, OnInit, Output} from '@angular/core';
import {AdvtReviewService} from "../../../services/review/advtReview.service";
import {IAdvtReview} from "../../../models/review/advtReview";
import {DateHelper} from "../../../helpers/date-helper";

@Component({
  selector: 'app-reviews-advt',
  templateUrl: './reviews-advt.component.html',
  styleUrls: ['./reviews-advt.component.css']
})
export class ReviewsAdvtComponent implements OnInit {

  @Input() advtIdReview: number;
  advtReviews: IAdvtReview[] | null = null;

  constructor(private advtReviewService: AdvtReviewService) {
  }

  ngOnInit(): void {
    this.advtReviewService.getAll({
      advtId: this.advtIdReview
    }).subscribe(advtReviews => {
      console.log(advtReviews+" teeeest")
        if (advtReviews.length != 0) {
          console.log(advtReviews+" teeeest0")
          this.advtReviews = advtReviews;
          advtReviews.forEach((item)=>{
            item.createDate=DateHelper.castDate(item.createDate);
          })
        }
      }
    );
  }

}
