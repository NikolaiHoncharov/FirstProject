﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DataBaseLayer.Entityes
{
    public class Material : Page
    {
        public int DirectoryId { get; set; }
        public Directory Directory { get; set; }
    }
}
