using System;
using System.IO;
using System.Linq;
using CYC.RsDeploy.Console.Commands;
using CYC.RsDeploy.Console.Exceptions;
using NLog;

namespace CYC.RsDeploy.Console.Verbs
{
    public class UploadFolderVerb : UploadVerbBase
    {
        private readonly UploadFolderVerbOptions options;

        public UploadFolderVerb(UploadFolderVerbOptions options, ILogger logger) : base (logger, options.Server)
        {
            this.options = options;
        }

        public void Process()
        {
            ValidateOptions();

            options.SourceFiles.ToList().ForEach(file => UploadFile(file, options.DestinationFolderPath, options.Server));
        }

        private void ValidateOptions()
        {
            if (!Directory.Exists(options.SourceFolderPath))
            {
                throw new InvalidParameterException(new DirectoryNotFoundException($"The source folder '{options.SourceFolderPath}' does not exist."));
            }

            options.SourceFiles = Directory.EnumerateFiles(options.SourceFolderPath, "*.rdl").ToList();

            if (!options.SourceFiles.Any())
            {
                throw new InvalidParameterException(new Exception($"No .rdl files found in source folder '{options.SourceFolderPath}'."));
            }
        }
    }
}
