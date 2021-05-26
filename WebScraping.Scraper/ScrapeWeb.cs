using AngleSharp.Dom;
using AngleSharp.Html.Parser;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace WebScraping.Scraper
{
    public static class ScrapeWeb
    {
        public static List<Post> ScrapeLakewoodScoop()
        {
            var results = new List<Post>();
            var html = GetScoopHtml();
            var parser = new HtmlParser();
            var document = parser.ParseDocument(html);
            IHtmlCollection<IElement> postResultElements = document.QuerySelectorAll(".post");
            foreach(IElement result in postResultElements)
            {
                var post = new Post();
                var titleh2 = result.QuerySelector("h2");                                   
                var anchorTag = titleh2.QuerySelector("a");
                if (anchorTag != null)
                {
                    post.LinkToArticle = anchorTag.Attributes["href"].Value;
                    post.Title = anchorTag.TextContent;
                }
                var date=result.QuerySelector("div.postmetadata-top");
                if( date != null)
                {
                    date = date.QuerySelector("small");
                    post.Date = date.TextContent;
                }
                var imageElement = result.QuerySelector("img");
                if (imageElement != null)
                {
                    var imageSrc = imageElement.Attributes["src"].Value;
                    post.ImageUrl = imageSrc;
                }
                var commentsElement = result.QuerySelector(".backtotop");
                if (commentsElement != null)
                {
                    post.CommentAmount = commentsElement.TextContent;
                }
                var textElements = result.QuerySelectorAll("p");
                if (textElements != null)
                {
                    foreach(IElement text in textElements)
                    {
                        post.Text += text.TextContent.Replace("Read more ›", String.Empty);                        
                    }                   
                }
                results.Add(post);
            }
            return results;
        }
      
        private static string GetScoopHtml()
        {
            HttpClientHandler handler = new HttpClientHandler()
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            };
            string url = "https://www.thelakewoodscoop.com/";
            var client = new HttpClient(handler);
            var html = client.GetStringAsync(url).Result;
            return html;

           
        }
    }
}

   
   
   



