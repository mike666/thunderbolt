using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;

namespace MPAlbumReviews {

  /// <summary>
  /// Class to retrieve configuration settings
  /// </summary>
  public class Config{
   
   public static string WebsiteUrl{
    get { return @"http://markprindle.com"; }
   }
   
   public static string WebCrawlerDestinationFolder {
    get { return @"C:\tmp\markprindle"; }
   }
   
   public static string XMLDestinationPath {
    get { return @"C:\tmp\markprindle\data.xml"; }
   }
   
   private string GetStringSetting(string key){
    return ConfigurationManager.AppSettings[key] + "";
   }   
  }
}
