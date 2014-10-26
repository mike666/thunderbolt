using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HtmlAgilityPack;

namespace MPAlbumReviews {

  /// <summary>
  /// Build artist data object from html source
  /// </summary>
  public class DataFactory
  {
    public DataFactory(){ }
  	
  	/// <summary>
  	/// Build and get artist object by parsing the input html
  	/// </summary>
  	/// <param name="html">input html</param>
  	/// <returns>A populated artist object</returns>
  	public Artist GetArtist(string html){
      Artist artist = new Artist();
      
      HtmlDocument htmlDocument = LoadHtmlDocument(html);
  	  
  	  if(htmlDocument == null){
  	    throw new Exception("Html document is null.");
  	  }

      artist.Title = htmlDocument.DocumentNode.SelectSingleNode(".//head/title").InnerText;
      
      HtmlNodeCollection nodeCollection = htmlDocument.DocumentNode.SelectNodes(".//center/a");

      artist.Albums = new List<Album>();

      foreach (HtmlNode node in nodeCollection) {
        string albumTitle = node.FirstChild.InnerText;
        int rating = 0;

        albumTitle = albumTitle.Trim();

        HtmlNode ratingNode = node.ParentNode.SelectSingleNode(".//img");

        if (ratingNode != null) {

          if (ratingNode.Attributes["src"] != null) {
            string ratingRaw = ratingNode.Attributes["src"].Value;
            if (!String.IsNullOrEmpty(ratingRaw)) {

              rating = ConvertToDigit(ratingRaw.Replace(".jpg", ""));
            }
          }
        }

        if (!String.IsNullOrEmpty(albumTitle)) {
          artist.Albums.Add(new Album() { Title = albumTitle, Rating = rating });
        }
      }
  	  
  	  return artist;
  	}

    private HtmlDocument LoadHtmlDocument(string html) {
      HtmlNode.ElementsFlags.Remove("form");

      HtmlDocument document = new HtmlDocument();
      document.LoadHtml(html);

      return document;
    }
    
    private int ConvertToDigit(string s){
      switch(s){
        case "one" :
          return 1;
        case "two":
          return 2;
        case "three":
          return 3;
        case "four":
          return 4;
        case "five":
          return 5;
        case "six":
          return 6;
        case "seven":
          return 7;
        case "eight":
          return 8;
        case "nine":
          return 9;
        case "ten":
          return 10;
        default :
          return 0;
      }
    }
  }
}