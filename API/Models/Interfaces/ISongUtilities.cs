using System.Collections.Generic;
using mis321tmtromblypa4.Models;


namespace mis321tmtromblypa4.API.Models.Interfaces
{
    public interface ISongUtilities
    {
        public List<Song> playlist { get; set; }
         public void AddSong();
         public void DeleteSong();
         public void EditSong();
         public void PrintPlaylist();
    }
}