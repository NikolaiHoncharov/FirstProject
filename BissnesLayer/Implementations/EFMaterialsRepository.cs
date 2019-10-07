using BissnesLayer.Interfaces;
using DataBaseLayer;
using DataBaseLayer.Entityes;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BissnesLayer.Implementations
{
    public class EFMaterialsRepository : IMaterialsRepository
    {
        private EFDBContext context;
        public EFMaterialsRepository(EFDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<Material> GetAllMaterials(bool includeDirectory = false)
        {
            if (includeDirectory)
                return context.Set<Material>().Include(x => x.Directory).AsNoTracking().ToList();
            else
                return context.Materials.ToList();
        }

        public Material GetMaterialById(int materialId, bool includeDirectory = false)
        {
            if (includeDirectory)
                return context.Set<Material>().Include(x => x.Directory).AsNoTracking().FirstOrDefault(x => x.Id == materialId);
            else
                return context.Materials.FirstOrDefault(x => x.Id == materialId);
        }

        public void SaveMaterial(Material material)
        {
            if (material.Id == 0)
                context.Materials.Add(material);
            else
                context.Entry(material).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteMaterial(Material material)
        {
            context.Materials.Remove(material);
            context.SaveChanges();
        }
    }
}
