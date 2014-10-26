using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HtmlAgilityPack;
using System.Text;

namespace MPAlbumReviews {
  public class MPAlbumReviews{
   
    public MPAlbumReviews(){}
	  
	  public void Run(){
      WebCrawler.CrawlAllArtistPages();
	     XMLGenerator.Generate();
	  }
  }
}
