
export interface SlidesList{
  slides: Slide[];
  count: number;
}

export interface Slide{
  articleId: string;
  articleImgUrl: string;
  articleTitle: string;
  articleUrl: string;
}

export interface Category{
  categoryId: string;
  categoryNameToDisplay: string;
  categorySlug: string;
}

export interface Keyword{
  keywordId: string;
  keywordNameToDisplay: string;
  keywordSlug: string;
}

export interface ArticleCard{
  articleId: string;
  articleImgUrl: string;
  articleTitle: string;
  articleUrl: string;
  articleDate: string;
  articleCategory: Category[];
}

export interface ArticleDetails{
  articleId: string;
  articleImgUrl: string;
  articleTitle: string;
  articleUrl: string;
  articleKeywords: Keyword[];
}

export interface CybernewsApiResponse{
  data: object[];
  success: boolean;
  msg: string;
}

export enum ArticleCardType {
  Other = 0,
  Category,
  Keyword
}

export interface PaginationOptions {
  limit : number;
  pageNumber: number;
}

export interface Query {
  type: ArticleCardType;
  itemId: number;
}
