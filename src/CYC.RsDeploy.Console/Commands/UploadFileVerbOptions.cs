using CommandLine;

namespace CYC.RsDeploy.Console.Commands
{
    public class UploadFileVerbOptions : VerbOptionsBase
    {
        [Option('f', "file", Required = true, HelpText = "The file to be upload.")]
        public string FilePath { get; set; }

        [Option('d', "destination", Required = true, HelpText = "The destination folder on the report server to upload to.")]
        public string DestinationFolderPath { get; set; }

        [Option('s', "server", Required = true, HelpText = "The report server to upload to.")]
        public string Server { get; set; }
    }
}
