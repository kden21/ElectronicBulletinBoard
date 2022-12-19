import {Injectable} from "@angular/core";
import {HttpClient, HttpParams} from "@angular/common/http";
import {Observable} from "rxjs";
import {environment} from "../../environments/environment";
import {CreateConversationRequest} from "../models/chat/create-conversation-request";
import {ConversationModel} from "../models/chat/conversation-model";
import {MessageModel} from "../models/chat/message-model";

@Injectable({
  providedIn: 'root'
})
export class ChatService {

  constructor(private http: HttpClient) {
  }

  createConversation(request: CreateConversationRequest){
    return this.http.post<number>(`${environment.apiUrl}/v1/chat`, request)
  }

  createMessage(message: MessageModel){
    return this.http.post(`${environment.apiUrl}/v1/chat/create_message`, message)
  }

  getConversations(userId:number):Observable<ConversationModel[]>{
    let params = new HttpParams();
    if(userId!=null)
      params=params.set("userId", userId);
    return this.http.get<ConversationModel[]>(`${environment.apiUrl}/v1/chat`, {params})
  }

}
