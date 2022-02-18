import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ICategory } from '../shared/models/category';
import { IPagination } from '../shared/models/pagination';
import { map } from 'rxjs/operators'

@Injectable({
  providedIn: 'root'
})
export class MoviesService {
  baseUrl = "https://localhost:7220/api/"

  constructor(private http: HttpClient) { }

  getMovies(categoriesId?: number[], sort?: string) {
    let params = new HttpParams();

    if (categoriesId) {
      for (let id of categoriesId) {
        params = params.append('categoriesId', id.toString())
      }
    }

    if (sort) {
      params = params.append('sort', sort);
    }

    return this.http.get<IPagination>(this.baseUrl + 'movies?pageSize=6', {observe: 'response', params})
    .pipe(
      map(response => {
        return response.body;
      })
    );
  }

  getCategories() {
    return this.http.get<ICategory[]>(this.baseUrl + 'movies/categories');
  }

}
