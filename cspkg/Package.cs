using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using System.Net;
using Newtonsoft.Json;

namespace cspkg
{
    public class Package
    {
        [JsonProperty] private string _Name;
        [JsonProperty] private string _Author;
        [JsonProperty] private int _VersionMajor = 0;
        [JsonProperty] private int _VersionMinor = 0;

        private class PackageEntry
        {
            [JsonProperty] private string _InPackage;
            [JsonProperty] private string _OutPackage;

            public string GetPathInPackage()
                => _InPackage;
            public string GetPathInFileSystem()
                => _OutPackage;

            public bool Extract(string packageArchive, string outputPath)
            {
                using (ZipArchive archive = ZipFile.OpenRead(packageArchive))
                {
                    foreach (KeyValuePair<string, string> pair in PathResolve.Resolves)
                        outputPath = outputPath.Replace(pair.Key, pair.Value);
                    if (!Directory.Exists(outputPath))
                        return false;
                    ZipArchiveEntry entryFile = (from pArchive
                            in archive.Entries
                        where pArchive.FullName == GetPathInPackage()
                        select pArchive).Single();
                    entryFile.ExtractToFile(Path.Combine(outputPath, entryFile.FullName), true);
                }

                return true;
            }

            public PackageEntry(string entryPath, string fsPath = "")
            {
                _InPackage = entryPath;
                _OutPackage = fsPath;
            }
        }

        [JsonProperty] private List<PackageEntry> PackageEntries = new List<PackageEntry>();

        public bool ExtractAll(string packageArchive, string outputPath)
        {
            foreach (PackageEntry entry in PackageEntries)
                entry.Extract(packageArchive, entry.GetPathInFileSystem());
            return true;
        }

        public bool AddEntry(string entryPath)
        {
            PackageEntries.Add(new PackageEntry(entryPath));
            return true;
        }

        public string GetPackageId()
            => _Author + "." + _Name;

        public string GetName()
            => _Name;

        public string GetAuthor()
            => _Author;

        public string GetVersion()
            => _VersionMajor + "." + _VersionMinor;

        public int GetVersionMajor() => _VersionMajor;
        public int GetVersionMinor() => _VersionMinor;

        public bool IsNewerThan(Package other)
            => _VersionMajor > other.GetVersionMajor()
               || _VersionMajor == other.GetVersionMajor()
               && _VersionMinor > other.GetVersionMinor();

        public bool IsOlderThan(Package other)
            => !IsNewerThan(other);

        public override bool Equals(object other)
            => (other as Package)?.GetPackageId() == GetPackageId();

        public static bool operator ==(Package pkg1, Package pkg2)
            => (!(pkg1 is null) && !(pkg2 is null)) && pkg1.Equals(pkg2);

        public static bool operator !=(Package pkg1, Package pkg2)
            => !(pkg1 == pkg2);

        public bool SaveJson(string outputPath)
        {
            string jsonEncode = JsonConvert.SerializeObject(this);
            File.WriteAllText(outputPath, jsonEncode);
            return true;
        }

        public static Package LoadJson(string inputPath)
        {
            return JsonConvert.DeserializeObject<Package>(File.ReadAllText(inputPath));
        }

        public bool SaveCspkg(string dataArchive)
        {
            string cspkgName = GetPackageId() + ".cspkg";
            Directory.CreateDirectory(GetPackageId());
            SaveJson(Path.Combine(GetPackageId(), "meta.json"));
            File.Copy(dataArchive, Path.Combine(GetPackageId(), "data.zip"));
            ZipFile.CreateFromDirectory(GetPackageId(), cspkgName, CompressionLevel.Fastest, false);
            Directory.Delete(GetPackageId(), true);
            return true;
        }

        public static Package GetInfoFromCspkg(string cspkgArchive)
        {
            string folderName = Path.GetFileNameWithoutExtension(cspkgArchive);
            Directory.CreateDirectory(folderName);
            ZipFile.ExtractToDirectory(cspkgArchive, folderName);
            Package package = LoadJson(Path.Combine(folderName, "meta.json"));
            Directory.Delete(folderName, true);
            return package;
        }

        public static bool InstallCspkg(string cspkgArchive, string packageName, string outputPath)
        {
            string folderName = packageName + "_temp";
            Directory.CreateDirectory(folderName);
            if (!Directory.Exists(outputPath))
                Directory.CreateDirectory(outputPath);
            ZipFile.ExtractToDirectory(cspkgArchive, folderName);
            Package package = LoadJson(Path.Combine(folderName, "meta.json"));
            package.ExtractAll(Path.Combine(folderName, "data.zip"), outputPath);
            Directory.Delete(folderName, true);
            return true;
        }

        public Package(string author, string name, int versionMajor, int versionMinor)
        {
            _Author = author;
            _Name = name;
            _VersionMajor = versionMajor;
            _VersionMinor = versionMinor;
        }
    }
}
