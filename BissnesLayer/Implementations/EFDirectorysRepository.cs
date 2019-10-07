using BissnesLayer.Interfaces;
using DataBaseLayer;
using DataBaseLayer.Entityes;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BuissnesLayer.Implementations
{
    public class EFDirectorysRepository : IDirectorysRepository
    {
        private EFDBContext context;
        public EFDirectorysRepository(EFDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<Directory> GetAllDirectorys(bool includeMaterials = false)
        {
            if (includeMaterials)
                return context.Set<Directory>().Include(x => x.Materials).AsNoTracking().ToList();
            else
                return context.Directories.ToList();
        }

        public Directory GetDirectoryById(int directoryId, bool includeMaterials = false)
        {
            if (includeMaterials)
                return context.Set<Directory>().Include(x => x.Materials).AsNoTracking().FirstOrDefault(x => x.Id == directoryId);
            else
                return context.Directories.FirstOrDefault(x => x.Id == directoryId);
        }

        public void SaveDirectory(Directory directory)
        {
            if (directory.Id == 0)
                context.Directories.Add(directory);
            else
                context.Entry(directory).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteDirectory(Directory directory)
        {
            context.Directories.Remove(directory);
            context.SaveChanges();
        }
    }
}