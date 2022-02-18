import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MoviesComponent } from './movies.component';
import { MovieItemComponent } from './movie-item/movie-item.component';



@NgModule({
  declarations: [
    MoviesComponent,
    MovieItemComponent
  ],
  imports: [
    CommonModule
  ],
  exports: [
    MoviesComponent
  ]
})
export class MoviesModule { }
