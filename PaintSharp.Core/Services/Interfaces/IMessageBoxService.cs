using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintSharp.Core.Services.Interfaces
{
    public interface IMessageBoxService
    {
        void ShowError(string title, string message);
        string GetSavingPath(string startDirectory);
        string GetSavingPath();
        string GetFilePath();
    }
}
