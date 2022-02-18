import { ICategory } from "./category";
import { IUserReview } from "./userReview";

export interface IMovie {
    id: number;
    title: string;
    description: string;
    director: string;
    pictureUrl: string;
    rating: number;
    releaseYear: number;
    categories: ICategory[];
    userReviews: IUserReview[];
}