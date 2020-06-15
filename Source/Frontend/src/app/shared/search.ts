import { Slide, Keyword, Category } from './article';

export interface SearchResultDto {
  articles: Slide[];
  keywords: Keyword[];
  categories: Category[];
}
