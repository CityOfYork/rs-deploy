using System;
using System.IO;
using CommandLine;
using CYC.RsDeploy.Console.Exceptions;

namespace CYC.RsDeploy.Console.Commands
{
    public class CreateDatasourcesVerbOptions : VerbOptionsBase
    {
        [Option('f', "config", Required = true, HelpText = "The config file containing connection strings to create as data sources")]
        public string ConfigFilePath { get; set; }

        [Option('d', "destination", Required = true, HelpText = "The destination folder on the report server to upload to.")]
        public string DestinationFolderPath { get; set; }

        [Option('s', "server", Required = true, HelpText = "The report server to upload to.")]
        public string Server { get; set; }

        public override void Validate()
        {
            if (Path.GetExtension(ConfigFilePath) != ".config")
            {
                throw new InvalidParameterException(new ArgumentException("Only a .config file can be uploaded"));
            }

            if (!File.Exists(ConfigFilePath))
            {
                throw new InvalidParameterException(new FileNotFoundException($"The file \"{ConfigFilePath}\" does not exist."));
            }
        }
    }
}
