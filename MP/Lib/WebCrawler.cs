using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using HtmlAgilityPack;

namespace MPAlbumReviews {

  /// <summary>
  /// Class for requesting and saving each artist page to local disk.
  /// </summary>
  public class WebCrawler{
        
    /// <summary>
    /// Download all artist pages that link from the homepage and save to disk.
    /// </summary>
    public static void CrawlAllArtistPages(){
      string websiteUrl = Config.WebsiteUrl;
      
      Logger.Instance.Write(String.Format("HTTP request page {0}...", websiteUrl));
                   
      string homepage = WebRequestUtil.GetRquest(websiteUrl);
      HtmlDocument htmlDocument = LoadHtmlDocument(homepage);

      HtmlNodeCollection nodes = htmlDocument.DocumentNode.SelectNodes("//center");

      HtmlNode reviewsNode = nodes[4];

      HtmlNodeCollection linkNodes = reviewsNode.SelectNodes(".//a");

      foreach (HtmlNode node in linkNodes) {
        string path = node.Attributes["href"].Value;
        
        if(String.IsNullOrEmpty(path)){
          continue;
        }
        
        string fullpath = String.Format("{0}/{1}", websiteUrl, path);

        Logger.Instance.Write(String.Format("HTTP request page {0}...", websiteUrl));
        
        string html = WebRequestUtil.GetRquest(fullpath);
        
        string destinationPath = String.Format("{0}\\{1}", Config.WebCrawlerDestinationFolder, path);
        
        Logger.Instance.Write(String.Format("Writing response to destination {0}...", destinationPath));
        
        File.WriteAllText(destinationPath, html);
      }
    }
    
    /// <summary>
    /// Load and html document object
    /// </summary>
    /// <param name="html">Html string</param>
    /// <returns>An Html document object</returns>
    private static HtmlDocument LoadHtmlDocument(string html) {
      HtmlNode.ElementsFlags.Remove("form");

      HtmlDocument document = new HtmlDocument();
      document.LoadHtml(html);

      return document;
    }
  }
}
