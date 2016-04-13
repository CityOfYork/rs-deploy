using System;
using System.IO;
using CYC.RsDeploy.Console.Commands;
using NLog;

namespace CYC.RsDeploy.Console.Verbs
{
    public class UploadFileVerb : UploadVerbBase
    {
        private readonly UploadFileVerbOptions options;
        
        public UploadFileVerb(UploadFileVerbOptions options, ILogger logger) : base(logger, options.Server)
        {
            this.options = options;
        }

        public void Process()
        {
            UploadFile(options.FilePath, options.DestinationFolderPath, options.Server);
        }
    }
}
