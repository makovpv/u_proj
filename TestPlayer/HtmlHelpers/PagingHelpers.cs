using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
//using System.Web.WebPages.Html;
using System.Web.Mvc;

namespace TestPlayer.HtmlHelpers
{
    public static class PagingHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html, int currentPage, int totalPages, Func<int, string> pageUrl)
        {
            
            
            
            StringBuilder result = new StringBuilder();
            for (int i = 1; i <= totalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(i));

                tag.InnerHtml = i.ToString();
                if (i == currentPage)
                    tag.AddCssClass("selected");
                result.AppendLine(tag.ToString());

                //result.AppendLine (string.Format(@"<a href=""{0}"">{1}</a>", pageUrl(i), i));

            }
            return MvcHtmlString.Create(result.ToString());
        }
    }
}