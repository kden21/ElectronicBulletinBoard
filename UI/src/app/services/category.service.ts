import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {Observable} from "rxjs";
import {ICategory} from "../models/category";
import {environment} from "../../environments/environment";

@Injectable({
  providedIn: 'root'
})

export class CategoryService {

  constructor(private http: HttpClient) {
  }

  getAll(): Observable<ICategory[]> {
    return this.http.get<ICategory[]>(`${environment.apiUrl}/v1/categories`)
  }

  getById(id:number){
    return this.http.get<ICategory>(`${environment.apiUrl}/v1/categories/`+id)
  }
}
