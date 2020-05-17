using System.ComponentModel;
using System;
using Cybernews.CybernewsApi.Models.Enums;

namespace Cybernews.CybernewsApi.Dtos
{
    public class QueryDto
    {
        private DateTime? dateCreatedFrom = null;
        private DateTime? dateCreatedTo = null;
        public ArticleCardType Type { get; set; } = ArticleCardType.All;
        public int ItemId { get; set; }
        public DateTime? DateCreatedFrom 
        { 
            get
            {
                if(dateCreatedFrom == null)
                {
                    return DateTime.MinValue;
                }
                else return dateCreatedFrom;
            } 
            set
            {
                dateCreatedFrom = value;
            } 
        }
        public DateTime? DateCreatedTo 
        { 
            get
            {
                if(dateCreatedTo == null)
                {
                    return DateTime.MaxValue;
                }
                else return dateCreatedTo;
            } 
            set
            {
                dateCreatedTo = value;
            } 
        }
    }
}