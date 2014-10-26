using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MPAlbumReviews {

  /// <summary>
  /// Class for logging
  /// </summary>
  public class Logger {
    private static Logger _Instance = null;
    
    public static Logger Instance{
      get {
        if(_Instance == null){
          _Instance = new Logger();
        }
        
        return _Instance;
      }
    }
    
    private Logger() { }
    
    /// <summary>
    /// Write to log
    /// </summary>
    /// <param name="msg"></param>
    public void Write(string msg){
    }
  }
}
