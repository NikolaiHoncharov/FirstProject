using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataBaseLayer
{
   public static class SampleData
    {
        public static void InitData(EFDBContext context)
        {
            if (!context.Directories.Any())
            {


                context.Directories.Add(new Entityes.Directory() { Title = "First Directory", Html = "<br>Some Text!<br>" });
                context.Directories.Add(new Entityes.Directory() { Title = "Second Directory", Html = "<br>Some Text!<br>" });
                context.SaveChanges();

                context.Materials.Add(new Entityes.Material() { Title = "First Material", Html = "<br>Some Text Material 1!<br>", DirectoryId = context.Directories.First().Id });
                context.Materials.Add(new Entityes.Material() { Title = "Second Material", Html = "<br>Some Text Material 2!<br>", DirectoryId = context.Directories.Last().Id });
                context.Materials.Add(new Entityes.Material() { Title = "Trird Material", Html = "<br>Some Text Material 3!<br>", DirectoryId = context.Directories.Last().Id });
                context.SaveChanges();
            }
        }
    }
}
