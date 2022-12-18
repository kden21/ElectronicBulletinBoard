import {Component, Input, OnInit} from '@angular/core';
import {IUserReview} from "../../../models/review/userReview";
import {UserService} from "../../../services/user.service";
import {IUser} from "../../../models/user";
import {BehaviorSubject} from "rxjs";
import {environment} from "../../../../environments/environment";
import {DateHelper} from "../../../helpers/date-helper";

@Component({
  selector: 'app-review-profile',
  templateUrl: './review-profile.component.html',
  styleUrls: ['./review-profile.component.css']
})
export class ReviewProfileComponent implements OnInit {

  @Input() userReview: IUserReview
  user: IUser

  isLoadAuthor$:BehaviorSubject<boolean>=new BehaviorSubject<boolean>(false);

  constructor(private userService: UserService) {
  }

  ngOnInit(): void {
    this.userReview.createDate=DateHelper.castDate(this.userReview.createDate);
      this.userService.getById(this.userReview.authorId).subscribe(user => {
        this.user = user;
        this.isLoadAuthor$.next(true);
      });
  }

  onNavigateToUser(userId:number){
    window.open(`${environment.angularUrl}/users/${userId}`);
  }

}
