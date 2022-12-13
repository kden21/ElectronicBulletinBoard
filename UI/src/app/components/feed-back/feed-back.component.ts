import {Component, EventEmitter, OnInit, Output} from '@angular/core';
import {BehaviorSubject, Subscription} from "rxjs";
import {ICategoryReport} from "../../models/reports/categoryReport";
import {AuthService} from "../../services/auth.service";
import {FormControl, FormGroup, Validators} from "@angular/forms";
import {StatusUserReport} from "../../models/filters/reports/userReportFilter";
import {EmailSendlerService} from "../../services/email-sendler.service";
import {IUser} from "../../models/user";

@Component({
  selector: 'app-feed-back',
  templateUrl: './feed-back.component.html',
  styleUrls: ['./feed-back.component.css']
})
export class FeedBackComponent implements OnInit {

  private subscription: Subscription;
  author:IUser;
  isUploaded=false;
  load=false;
  @Output() writeFeedBack = new EventEmitter<boolean>();
  errorText:BehaviorSubject<string|null>=new  BehaviorSubject<string | null>(null);

  form = new FormGroup({
    text: new FormControl<string>("",[Validators.required]),
    subject: new FormControl<string>("",[Validators.required])
  })
  constructor(private authService:AuthService,
              private emailService:EmailSendlerService) { }

  ngOnInit(): void {
   this.author = this.authService.userLogin$.value!;
  }

  showWriteFeedBack(showElement: boolean){
    this.writeFeedBack.emit(showElement)
  }

  submit(){
    console.log('Отправляюююю')
    this.errorText.next(null);
    if(this.form.invalid){
      this.errorText.next("Заполните все поля");
      return;
    }
    this.load=true;
    this.emailService.sendFeedBack({
      subject: this.form.value['subject'] as string,
      text: this.form.value['text'] as string,
      userEmail: this.author.email,
      userId: this.author.id!,
      userName: this.author.name
    }).subscribe(res=> {
      this.isUploaded=true;//showWriteReport(true)
    } )
  }

}
