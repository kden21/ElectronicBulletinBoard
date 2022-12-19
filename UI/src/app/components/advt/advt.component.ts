import {Component, OnInit, Output} from '@angular/core';
import {IAdvt, StatusAdvt} from "../../models/advt";
import {ActivatedRoute, Router} from "@angular/router";
import {BehaviorSubject, Subscription} from "rxjs";
import {AdvtService} from "../../services/advt.service";
import {IUser} from "../../models/user";
import {UserService} from "../../services/user.service";
import {PhotoService} from "../../services/photo.service";
import {StatusUser} from "../../models/filters/userFilter";
import {AuthService} from "../../services/auth.service";
import {DateHelper} from "../../helpers/date-helper";
import {ChatService} from "../../services/chat.service";
import {SignalrService} from "../../services/signalr.service";

@Component({
  selector: 'app-advt',
  templateUrl: './advt.component.html',
  styleUrls: ['./advt.component.css']
})
export class AdvtComponent implements OnInit {

  private routeSub: Subscription;
  private id: number;
  editAdvt: boolean = false;
  writeReview: boolean = false;
  writeReport: boolean = false;
  showPhoto: boolean = false;
  createDateAdvt: string;
  deleteAdvtAction: boolean = false;
  showDeleteAction: boolean = false;
  isUserDeleted$: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);

  advtShow: IAdvt;
  viewingUser: IUser;
  @Output() userOwnAdvtId: number;
  isLoadAdvt$: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  isLoadAdvtPhotos$: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  isFavoriteAdvt$: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  photoIndex$: BehaviorSubject<number> = new BehaviorSubject<number>(0);

  userVoters:IUser[]=[];

  constructor(private route: ActivatedRoute,
              private advtService: AdvtService,
              private userService: UserService,
              private photoService: PhotoService,
              public authService:AuthService,
              private chatService:ChatService,
              private router:Router
  ) {
    this.routeSub = this.route.params.subscribe(params => {
      this.id = parseInt(params['id'])
    });
  }

  showDelete(showElement: boolean) {
    this.showDeleteAction = showElement;
  }

  advtDelete(showElement: boolean) {
    this.deleteAdvtAction = showElement;
    this.deleteAdvt(this.advtShow.id!);
  }

  showWriteReview(showElement: boolean) {
    console.log('reeeee')
    showElement == true ? this.writeReview = true : this.writeReview = false;
  }

  showWriteReport(showElement: boolean) {
    showElement == true ? this.writeReport = true : this.writeReport = false;
  }

  showPhotoAdvt(showElement: boolean) {
    showElement == true ? this.showPhoto = true : this.showPhoto = false;
  }

  getPhotoIndexLeft() {
    this.photoIndex$.next(this.photoIndex$.value - 1)
  }

  getPhotoIndexRight() {
    this.photoIndex$.next(this.photoIndex$.value + 1)
  }

  ngOnInit(): void {
    this.advtService.getById(this.id).subscribe(advt => {
        this.advtShow = advt,
        this.advtShow.createDate = DateHelper.castDate(this.advtShow.createDate),

        this.viewingUser = this.userService.getViewUser();

        this.userService.getAllFilter({
          advtFavoriteId: advt.id,
          status: StatusUser.Actual
        }).subscribe(res=> {
          this.userVoters=res;
          this.checkFavoriteAdvt();
        })

      this.userOwnAdvtId = advt.authorId;

      this.photoService.getAdvtPhotosFilter({
        advtId: advt.id
      }).subscribe(res => {

        this.advtShow.photo = [];
        res.forEach((item) => {
          this.advtShow.photo = this.advtShow.photo?.concat(item.base64Str);
        })
        this.isLoadAdvtPhotos$.next(true);
        this.isLoadAdvt$.next(true);
      })
    });
  }

  deleteAdvt(advtId: number) {
    this.advtService.deleteAdvt(advtId).subscribe(res => this.advtShow.status=1);
  }

  addAdvtInFavorite(advtId: number, userId: number) {
    this.advtService.updateFavoriteAdvt(advtId, userId, StatusAdvt.Actual).subscribe(res =>
      this.isFavoriteAdvt$.next(true))
  }

  deleteAdvtFromFavorite(advtId: number, userId: number) {
    this.advtService.updateFavoriteAdvt(advtId, userId, StatusAdvt.Archive)
      .subscribe(res => this.isFavoriteAdvt$.next(false))
  }

  checkFavoriteAdvt(){
    this.userVoters.forEach((user)=>{
      if(user.id==this.viewingUser.id){
        this.isFavoriteAdvt$.next(true);
      }
    })
  }

  getPhotos(){
    this.photoService.getAdvtPhotosFilter({
      advtId: this.advtShow.id
    }).subscribe(res => {
      this.advtShow.photo = [];
      res.forEach((item) => {
        this.advtShow.photo = this.advtShow.photo?.concat(item.base64Str);
      })
      this.isLoadAdvtPhotos$.next(true);
      this.isLoadAdvt$.next(true);
    })
  }

  showEditAdvt(showElement: boolean) {
    this.editAdvt=showElement;
    if(showElement==false) {
      this.photoIndex$.next(0);
      this.isLoadAdvtPhotos$.next(false);
      this.isLoadAdvt$.next(false);

      this.advtService.getById(this.advtShow.id!).subscribe(res => {
        res.createDate=DateHelper.castDate(res.createDate)
        this.advtShow = res
        this.getPhotos();
      });
    }
  }

  sendMessage(advtId:number){
    if(this.authService.userLogin$.value as IUser){
      let usersId:number[]=[];
      this.chatService.createConversation({
        usersId: usersId.concat(this.advtShow.authorId).concat(this.viewingUser.id!)
      }).subscribe(res=> {
        this.chatService.createMessage({
          conversationId: res,
          description: `Здравствуйте! Меня заинтересовало Ваше объявление:</br><a href=${this.router.url}>${this.advtShow.name}</a>`,
          userId: this.authService.userLogin$.value?.id!
        }).subscribe(res=>{
          this.router.navigate(
            ['/chat'],
            {
              queryParams: {
                'id': res == 0 ? null : res,
              }
            }
          )
          }
        )
        ;
      })
    }
    else {
      this.router.navigateByUrl('account/login')
    }
  }
}
