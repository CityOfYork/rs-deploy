using System;
using CommandLine;
using CYC.RsDeploy.Console.Commands;
using CYC.RsDeploy.Console.Verbs;
using NLog;

namespace CYC.RsDeploy.Console
{
    class Program
    {
        private static ILogger logger = LogManager.GetLogger("rsdeploy");

        static void Main(string[] args)
        {
            var options = new Options();
            if (!Parser.Default.ParseArguments(args, options, OnVerb))
            {
                Environment.Exit(Parser.DefaultExitCodeFail);
            }
        }

        static void OnVerb(string verb, object options)
        {
            if (options == null)
            {
                Environment.Exit(Parser.DefaultExitCodeFail);
            }

            try
            {
                switch (verb)
                {
                    case VerbNames.UploadFile:
                        UploadFile(options);
                        break;

                    case VerbNames.UploadFolder:
                        UploadFolder(options);
                        break;

                    case VerbNames.CreateDatasources:
                        CreateDatasources(options);
                        break;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                Environment.Exit(Parser.DefaultExitCodeFail);
            }
        }

        private static void UploadFile(object options)
        {
            var verbOptions = (UploadFileVerbOptions)options;
            new UploadFileVerb(verbOptions, logger).Process();
        }

        private static void UploadFolder(object options)
        {
            var verbOptions = (UploadFolderVerbOptions)options;
            new UploadFolderVerb(verbOptions, logger).Process();
        }

        private static void CreateDatasources(object options)
        {
            var verbOptions = (CreateDatasourcesVerbOptions)options;
            new CreateDatasourcesVerb(verbOptions, logger).Process();
        }
    }
}
