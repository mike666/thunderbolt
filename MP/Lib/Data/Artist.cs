using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MPAlbumReviews {

  /// <summary>
  /// Class to hold Artist data
  /// </summary>
  public class Artist {

    /// <summary>
    /// Property for artist name
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Link path to artist web page
    /// </summary>
    public string Link { get; set; }

    /// <summary>
    /// List of albums by the artists
    /// </summary>
    public List<Album> Albums { get; set; }

    /// <summary>
    /// Full url to artists web page
    /// </summary>

    public string FullUrl {
      get { return String.Format("http://markprindle.com/{0}", Link); }
    }

    public Artist() { }
  }
}
