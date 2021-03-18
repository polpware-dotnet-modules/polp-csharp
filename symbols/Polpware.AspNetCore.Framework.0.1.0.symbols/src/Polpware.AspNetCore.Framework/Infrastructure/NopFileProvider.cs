using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using Polpware.NetStd.Framework.IO;

namespace Polpware.AspNetCore.Framework.Infrastructure
{
    /// <summary>
    /// IO functions using the on-disk file system
    /// </summary>
    public class NopFileProvider : NopFileProviderBase
    {
        /// <summary>
        /// Initializes a new instance of a NopFileProvider
        /// </summary>
        /// <param name="hostingEnvironment">Hosting environment</param>
        public NopFileProvider(IWebHostEnvironment hostingEnvironment)
            : base(File.Exists(hostingEnvironment.WebRootPath) ? Path.GetDirectoryName(hostingEnvironment.WebRootPath) : hostingEnvironment.WebRootPath)
        {
            var path = hostingEnvironment.ContentRootPath ?? string.Empty;
            if (File.Exists(path))
                path = Path.GetDirectoryName(path);

            BaseDirectory = path;
        }
    }

}
