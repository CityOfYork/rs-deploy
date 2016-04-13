using System.IO;
using System.Linq;
using CYC.RsDeploy.Console.Commands;
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
            options.SourceFiles.ToList().ForEach(file => UploadFile(file, options.DestinationFolderPath, options.Server));
        }
    }
}
