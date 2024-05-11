﻿namespace SC4PackMan.Pages.Shared {
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
    }
}