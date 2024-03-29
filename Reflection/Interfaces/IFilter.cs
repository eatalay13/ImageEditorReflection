﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.Interfaces
{
    public interface IFilter
    {
        string Name { get; }
        Image RunPlugin(Image src);
        Task<Image> RunPluginAsync(Image src);
    }
}
