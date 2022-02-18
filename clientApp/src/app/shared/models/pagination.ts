import {IMovie} from './movie'

export interface IPagination {
  pageIndex: number;
  pageSize: number;
  count: number;
  data: IMovie[];
}