using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
using cspkg;

namespace cspkgBuild
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("* cspkgBuild - build .cspkg packages"
                              + Environment.NewLine
                              + "* get latest version at https://github.com/LoukaMB/cspkg");

            if (args.Length != 3)
            {
                Console.WriteLine(
                    "* usage: cspkgBuild [author.PackageName] [versionMajor.versionMinor] [zipIn]");
                return;
            }

            string[] authorPackage = args[0].Split('.');
            string packageId = args[0];
            string[] packageVersion = args[1].Split('.');
            string packageZip = args[2];

            Package newPackage = new Package(
                authorPackage[0],
                authorPackage[1],
                int.Parse(packageVersion[0]),
                int.Parse(packageVersion[1]));

            using (var archive = ZipFile.OpenRead(packageZip))
                foreach (var zipArchiveEntry in archive.Entries)
                    newPackage.AddEntry(zipArchiveEntry.FullName);

            newPackage.SaveCspkg(packageZip);
            Console.WriteLine("* successfully built package \"{0}\"", newPackage.GetPackageId() + ".cspkg");
        }
    }
}
