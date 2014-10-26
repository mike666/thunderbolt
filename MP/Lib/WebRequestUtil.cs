using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;
using System.Text;

namespace MPAlbumReviews {
  
  /// <summary>
  /// Utility class for making web requests
  /// </summary>
  public class WebRequestUtil {
    
    /// <summary>
    /// Make an http web request using GET method
    /// </summary>
    /// <param name="url">The url to request</param>
    /// <returns>The response string</returns>
    public static string GetRquest(string url){
      return Request(url, "GET");
    }
    
    /// <summary>
    /// make an http web request
    /// </summary>
    /// <param name="url">The url to request</param>
    /// <param name="method">HTTP request method</param>
    /// <returns>The response string</returns>
    private static string Request(string url, string method) {
      string returnVal = String.Empty;
      
      HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
      request.KeepAlive = false;
      request.Method = method;
       
      HttpWebResponse response = (HttpWebResponse)request.GetResponse();
      StreamReader sr = new StreamReader(response.GetResponseStream());
                  
      returnVal = sr.ReadToEnd();
      
      sr.Close();
      sr.Dispose();
      
      response.Close();
      request.Abort();
                  
      return returnVal;
    }
  }
}
