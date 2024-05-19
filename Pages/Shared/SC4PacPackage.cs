﻿using YamlDotNet.Serialization;
using static SC4PackMan.Pages.IndexModel;

namespace SC4PackMan.Pages.Shared {
    public class SC4PacPackage {
        /// <summary>
        /// Package owner, modding group or similar. Required.
        /// </summary>
        public string? Group { get; set; }
        /// <summary>
        /// The name of the package, unique within the group. Required.
        /// </summary> 
        public string? Name { get; set; }
        /// <summary>
        /// The version string should be chosen in line with the version of the main asset. It should be incremented whenever changes are made that make it necessary to reinstall the package. Required.
        /// </summary>
        public string? Version { get; set; }
        /// <summary>
        /// The folder inside the Plugins folder into which the package is installed. 3-digit numbers are used to control load order. Required.
        /// </summary>
        public string? Subfolder { get; set; }
        /// <summary>
        /// Optional list of package identifiers (zero or more) that are required for this package.
        /// </summary>
        public List<string>? Dependencies { get; set; }
        /// <summary>
        /// Optional list of assets from which to extract files (zero or more).
        /// </summary>
        public List<AssetDetails>? Assets { get; set; }
        /// <summary>
        /// Additional descriptive information.
        /// </summary>
        public PackageInfo Info { get; set; }

        //public Package(string group, string name, string version, int subfolder, string summary, string website, List<string>? dependencies = null, List<string>? assets = null, List<string>? include = null, List<string>? exclude = null, string warning = "", string conflicts = "", string description = "", string author = "", List<string>? images = null) {
        //    Group = group;
        //    Name = name;
        //    Version = new Version(version);
        //    Subfolder = subfolder;
        //    Dependencies = dependencies ?? new List<string>();
        //    Assets = assets ?? new List<string>();
        //    Include = include ?? new List<string>();
        //    Exclude = exclude ?? new List<string>();
        //    PackageInfo = new PackageInfo(summary, website, warning, conflicts, description, author, images);
        //}

        public override string ToString() {
            return $"{Group}:{Name} (v{Version}), {Subfolder}";
        }




        /// <summary>
        /// Details about an asset included in this package.
        /// </summary>
        public class AssetDetails {
            public string AssetId { get; set; }
            /// <summary>
            /// Optional list of files to include if not all of the files of an asset are needed.
            /// </summary>
            public List<string>? Include { get; set; }
            /// <summary>
            /// Optional list of files to exclude if not all of the files of an asset are needed.
            /// </summary>
            public List<string>? Exclude { get; set; }

            public override string ToString() {
                return $"{AssetId}, Include:{(Include is null ? 0 : Include.Count)}, Exclude:{(Exclude is null ? 0 : Exclude.Count)}";
            }
        }

        /// <summary>
        /// Additional descriptive information. It is mostly optional, but each package should include a one-line summary and a link to a website, usually the original download page.
        /// </summary>
        public class PackageInfo {
            /// <summary>
            /// Single line summary.
            /// </summary>
            public string Summary { get; set; }

            /// <summary>
            /// A link to a website, usually the original download page.
            /// </summary>
            public string Website { get; set; }

            /// <summary>
            /// An informational message that displayed during the installation process.
            /// </summary>
            /// <remarks>
            /// This should be used sparingly, for example in case a user has to take action before installing the package.
            /// </remarks>
            public string? Warning { get; set; }
            /// <summary>
            /// Description of any possible conflicts with this package.
            /// </summary>
            public string? Conflicts { get; set; }
            /// <summary>
            /// Several paragraphs of contextual information (it should not repeat the summary).
            /// </summary>
            public string? Description { get; set; }
            /// <summary>
            /// The original authors of the content by the names they are known to the community
            /// </summary>
            public string? Author { get; set; }
            /// <summary>
            /// A list of image URLs.
            /// </summary>
            public List<string>? Images { get; set; }

            //public PackageInfo(string summary, string website, string warning = "", string conflicts = "", string description = "", string author = "", List<string>? images = null) {
            //    Summary = summary;
            //    Website = website;
            //    Warning = warning;
            //    Conflicts = conflicts;
            //    Description = description;
            //    Author = author;
            //    Images = images ?? new List<string>();
            //}

            public override string ToString() {
                return Summary;
            }

            public string ToYAMLString() {
                string output = "\r\ninfo:\r\n";
                output = output + "summary: " + Summary + "\r\n";
                if (Warning != string.Empty) {
                    output = output + "  warning: " + Warning + "\r\n";
                }
                if (Conflicts != string.Empty) {
                    output = output + "  conflicts: " + Conflicts + "\r\n";
                }
                if (Description != string.Empty) {
                    output = output + "  description: >\r\n" + Description + "\r\n";
                }
                if (Author != string.Empty) {
                    output = output + "  author:" + Author + "\r\n";
                }
                if (Images is not null && Images.Count > 0) {
                    output = output + "  images:" + Images.ToYAMLString() + "\r\n";
                }
                output = output + "website: " + Website + "\r\n";

                return output;
            }
        }
    }
}
