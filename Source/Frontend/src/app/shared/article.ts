
export interface SlidesList{
  slides: Slide[];
  count: number;
}

export interface Slide{
  articleId: number;
  articleImgUrl: string;
  articleTitle: string;
  articleUrl: string;
}

export interface Category{
  categoryId: number;
  categoryNameToDisplay: string;
  categorySlug: string;
}

export interface Keyword{
  keywordId: number;
  keywordNameToDisplay: string;
  keywordSlug: string;
}

export interface ArticleCard{
  articleId: number;
  articleImgUrl: string;
  articleTitle: string;
  articleUrl: string;
  articleDate: string;
  articleCategories: Category[];
}

export interface ArticleDetails{
  articleId: number;
  articleImgUrl: string;
  articleTitle: string;
  articleUrl: string;
  articleKeywords: Keyword[];
}

export interface CybernewsApiResponse{
  data: object;
  success: boolean;
  msg: string;
}

export enum ArticleCardType {
  Other = 0,
  Category,
  Keyword
}

export interface PaginationOptions {
  limit: number;
  pageNumber: number;
}

export interface Query {
  type: ArticleCardType;
  itemId: number;
}
