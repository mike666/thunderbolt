using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using HtmlAgilityPack;
using System.Xml;

namespace MPAlbumReviews{

  /// <summary>
  /// Class for generating xml file and saving to disk
  /// </summary>
  public class XMLGenerator{
    
    /// <summary>
    /// Generate a single xml file from the html files that where saved to disk. This file holds Artist, albums, and rating.
    /// </summary>
    public static void  Generate(){
      string sourceFolder = Config.WebCrawlerDestinationFolder;
      string destinationFile = Config.XMLDestinationPath;

      string[] filePaths = Directory.GetFiles(sourceFolder, "*.htm");
      
      List<Artist> artists = new List<Artist>();
      
      foreach(string filePath in filePaths){
        string contents = File.ReadAllText(filePath);
        
        DataFactory factory = new DataFactory();
        
        Artist artist = factory.GetArtist(contents);
        artist.Link = filePath.Substring(filePath.LastIndexOf("\\") + 1);

        artists.Add(artist);
      }

      using (XmlWriter writer = XmlWriter.Create(destinationFile)) {
        writer.WriteStartDocument();
        writer.WriteStartElement("Artists");

        foreach (Artist artist in artists) {
          writer.WriteStartElement("Artists");

          writer.WriteElementString("Title", artist.Title);
          writer.WriteElementString("Link", artist.Link);

          writer.WriteStartElement("Albums");
          
          foreach(Album album in artist.Albums){
            writer.WriteStartElement("Album");
            writer.WriteElementString("Title", album.Title);
            writer.WriteElementString("Rating", album.Rating.ToString());
            writer.WriteElementString("Review", album.Review);
            writer.WriteEndElement();
          }
          
          writer.WriteEndElement();
          
          writer.WriteEndElement();
        }

        writer.WriteEndElement();
        writer.WriteEndDocument();
      }
    }
  }
}
