using DataBaseLayer.Entityes;
using System;
using System.Collections.Generic;
using System.Text;

namespace BissnesLayer.Interfaces
{
   public interface IDirectorysRepository
    {
        IEnumerable<Directory> GetAllDirectorys(bool includeMaterials = false);
        Directory GetDirectoryById(int directoryId, bool includeMaterials = false);
        void SaveDirectory(Directory achieve);
        void DeleteDirectory(Directory achieve);
    }
}
