import{Injectable} from "@angular/core";
import {HttpClient, HttpParams} from "@angular/common/http";
import {Observable} from "rxjs";
import {IAdvtReview} from "../../models/review/advtReview";
import {environment} from "../../../environments/environment";
import { ReviewFilter} from "../../models/filters/review-filter";

@Injectable({
  providedIn: 'root'
})

export class AdvtReviewService {

  constructor(private http: HttpClient) {
  }

  getAll(advtReviewFilter:ReviewFilter): Observable<IAdvtReview[]>{
    let params = new HttpParams();
    if(advtReviewFilter.advtId!=null) {
      console.log(advtReviewFilter.advtId+' idddd')
      params = params.set("AdvtId", advtReviewFilter.advtId);
    }
    return this.http.get<IAdvtReview[]>(`${environment.apiUrl}/v1/advtReviews/advtReviewFilter` , {params})
  }

  createAdvtReview(model:IAdvtReview){
    return this.http.post(`${environment.apiUrl}/v1/advtReviews/`, model)
  }

}
