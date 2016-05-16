using System;
using System.IO;
using CYC.RsDeploy.Console.Commands;
using CYC.RsDeploy.Console.Exceptions;
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
            ValidateOptions();

            UploadFile(options.FilePath, options.DestinationFolderPath, options.Server);
        }

        private void ValidateOptions()
        {
            if (Path.GetExtension(options.FilePath) != ".rdl")
            {
                throw new InvalidParameterException(new ArgumentException("Only .rdl files can be uploaded"));
            }

            if (!File.Exists(options.FilePath))
            {
                throw new InvalidParameterException(new FileNotFoundException($"The file '{options.FilePath}' does not exist."));
            }
        }
    }
}
