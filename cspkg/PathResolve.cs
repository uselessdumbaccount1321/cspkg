using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cspkg
{
    static class PathResolve
    {
        public static Dictionary<string, string> Resolves = new Dictionary<string, string>
        {
            { "%ProgramFiles%", Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) },
            { "%ProgramFilesX86%", Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) },
        };
    }
}
