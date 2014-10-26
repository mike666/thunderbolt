using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MPAlbumReviews {

  /// <summary>
  /// Class for holding album data
  /// </summary>
  public class Album {
    /// <summary>
    /// Property for Album title
    /// </summary>
    public string Title { get; set; }
    
    /// <summary>
    /// Property for album rating
    /// </summary>
    public int Rating { get; set; }
    
    /// <summary>
    /// Property fot Album review
    /// </summary>
    public string Review { get; set; }

    public Album() { }
  }
}
