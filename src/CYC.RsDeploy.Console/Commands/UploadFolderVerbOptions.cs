using System.Collections.Generic;
using CommandLine;

namespace CYC.RsDeploy.Console.Commands
{
    public class UploadFolderVerbOptions : VerbOptionsBase
    {
        [Option('f', "folder", Required = true, HelpText = "The folder containing .rdl and .rds files to be uploaded.")]
        public string SourceFolderPath { get; set; }

        public IEnumerable<string> SourceFiles { get; set; }

        [Option('d', "destination", Required = true, HelpText = "The destination folder on the report server to upload to.")]
        public string DestinationFolderPath { get; set; }

        [Option('s', "server", Required = true, HelpText = "The report server to upload to.")]
        public string Server { get; set; }
    }
}
