import {BehaviorSubject} from "rxjs";
import {Injectable} from "@angular/core";
import {MessageNotification, TypeNotification} from "../models/message-notification";

@Injectable({
  providedIn: 'root'
})

export class MessageNotificationService {
   public newNotification$:BehaviorSubject<MessageNotification[]>=new BehaviorSubject<MessageNotification[]>([])
  constructor(){}
  create(type:TypeNotification, message:string){
     let notification:MessageNotification=new MessageNotification(type,message)
     this.newNotification$.next(this.newNotification$.value?.concat(notification))
  }
}
