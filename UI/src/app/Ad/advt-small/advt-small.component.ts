import {Component, Input, OnInit} from '@angular/core';
import {IAdvt} from "../../models/advt";
import {BehaviorSubject} from 'rxjs';
import {PhotoService} from "../../services/photo.service";

@Component({
  selector: 'app-advt-small',
  templateUrl: './advt-small.component.html',
  styleUrls: ['./advt-small.component.css']
})
export class AdvtSmallComponent implements OnInit {

  isAdvtLoading: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false)

  @Input() advt: IAdvt

  constructor(
    private photoService: PhotoService
    ) {
  }

  ngOnInit(): void {
    this.advt.photo = []

    this.photoService.getAdvtPhotosFilter({
      advtId: this.advt.id
    }).subscribe(res => {
      if (res.length != 0) {
        res.forEach((item) => {
            this.advt.photo = this.advt.photo!.concat(item.base64Str);
          }
        )
      }
      this.isAdvtLoading.next(true);
    })
  }
}
