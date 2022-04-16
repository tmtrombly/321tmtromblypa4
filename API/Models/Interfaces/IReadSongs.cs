using System.Collections.Generic;
using mis321tmtromblypa4.Models;

namespace mis321tmtromblypa4.API.Models.Interfaces
{
    public interface IReadSongs
    {
        public List<Song> GetAll();
        public Song GetOne(int id);
         
    }
}