using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using TestPlayer.HtmlHelpers;
using System.Web.Mvc;

namespace TestPlayer.Tests
{
    
    [TestFixture]
    class PageHelperTests
    {
        [Test]
        public void PageLinks_Method_Extends_HtmlHelper()
        {
            HtmlHelper html = null;
            html.PageLinks( 0, 0, null);
            //html.PageLinks(html, 0, 0, null);
        }

        [Test]
        public void PageLinks_Produces_Anchor_Tags()
        {
            string links = ((HtmlHelper)null).PageLinks(2, 3, i => "Page" + i).ToString();
            //string links = ((HtmlHelper)null).PageLinks(null, 2, 3, i => "Page" + i);
            Assert.AreEqual(@"<a href=""Page1"">1</a>"+"\r\n"+@"<a class=""selected"" href=""Page2"">2</a>"+"\r\n"+@"<a href=""Page3"">3</a>"+"\r\n", links);
        }


    }
}

