using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintSharp.Core.Services.Interfaces
{
    public interface IUpdateService
    {
        Task CheckForUpdates();
    }
}
