import { Component, OnInit } from '@angular/core';
import { ICategory } from '../shared/models/category';
import { IMovie } from '../shared/models/movie';
import { MoviesService } from './movies.service';

@Component({
  selector: 'app-movies',
  templateUrl: './movies.component.html',
  styleUrls: ['./movies.component.scss']
})

export class MoviesComponent implements OnInit {
  movies: IMovie[] = [];
  categories: ICategory[] = [];
  selectedCategories: number[] = [];
  selectedSorting = 'byTitle';
  sortingOptions = [
    {name: 'By Title', value: 'byTitle'},
    {name: 'Year: Ascending', value: 'yearAsc'},
    {name: 'Year: Descending', value: 'yearDesc'},
    {name: 'Rating: Ascending', value: 'ratingAsc'},
    {name: 'Rating: Descending', value: 'ratingDesc'}
  ]

  constructor(private moviesService: MoviesService) { }

  ngOnInit(): void {
    this.getMovies();
    this.getCategories();
  }

  getMovies() {
    this.moviesService.getMovies(this.selectedCategories, this.selectedSorting).subscribe(response => {
      if (response) {
        this.movies = response.data;
      }
    }, err => {
      console.log(err);
    });
  }

  getCategories() {
    this.moviesService.getCategories().subscribe((response: ICategory[]) => {
      this.categories = response;
    }, err => {
      console.log(err);
    });
  }

  onCategorySelected(categoryId: number) {

    let index = this.selectedCategories.indexOf(categoryId);
    if (index !== -1) {
      this.selectedCategories.splice(index, 1);
      this.getMovies();
    } else {
      this.selectedCategories.push(categoryId);
      this.getMovies();
    }
  }

  onSortSelected(event: any) {
    this.selectedSorting = event.target.value;
    this.getMovies(); 
  }

}
