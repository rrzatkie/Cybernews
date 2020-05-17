
export interface SlidesList{
  slides: Slide[];
  queryItemId: number;
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

export interface CategorySummary{
  category: Category;
  count: number;
}

export interface Keyword{
  keywordId: number;
  keywordNameToDisplay: string;
  keywordSlug: string;
  keywordValue: number;
}

export interface KeywordSummary{
  keyword: Keyword;
  count: number;
}

export interface ArticleCard{
  articleId: number;
  articleImgUrl: string;
  articleTitle: string;
  articleUrl: string;
  articleDateCreated: string;
  articleAuthor: string;
  likesCount: string;
  commentsCount: string;
  articleCategories: Category[];
  articleKeywords: Keyword[];
}

export interface SimilarArticle{
  article: ArticleCard;
  similarity: number;
}

export interface ArticleCardsList{
  articleCards: ArticleCard[];
  count: number;
  queryItemId: number;
  queryItemNameToDisplay: string;
}

export interface ArticlesArchive{
  year: string;
  month: string;
  count: number;
}

export interface ArticleDetails{
  article: ArticleCard;
  similarArticles: SimilarArticle[];
}

export interface CybernewsApiResponse{
  data: object;
  success: boolean;
  msg: string;
}

export enum ArticleCardType {
  All = 0,
  Category,
  Keyword
}

export interface PaginationOptions {
  limit: number;
  pageNumber: number;
}

export interface Query {
  type?: ArticleCardType;
  itemId?: number;
  dateCreatedFrom?: string;
  dateCreatedTo?: string;
}
