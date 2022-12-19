import {Injectable} from "@angular/core";
import {HttpClient, HttpParams} from "@angular/common/http";
import {environment} from "../../environments/environment";
import {IAddress} from "../models/address";
import {Observable} from "rxjs";

@Injectable({
  providedIn: 'root'
})

export class DadataSuggestService {

  constructor(private http: HttpClient) {
  }
  getSuggest(cityName:string): Observable<IAddress[]>{
    let params = new HttpParams();
    if (cityName != null)
      params = params.set("cityName", cityName);
    return this.http.get<IAddress[]>(`${environment.apiUrl}/v1/address/getSuggestions`, {params});
  }
}
