using System;
using CYC.RsDeploy.Console.Commands;
using CYC.RsDeploy.Console.Exceptions;
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
            if (!CommandLine.Parser.Default.ParseArguments(args, options, OnVerb))
            {
                Environment.Exit(CommandLine.Parser.DefaultExitCodeFail);
            }
        }

        static void OnVerb(string verb, object options)
        {
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
            catch (InvalidParameterException ex)
            {
                logger.Info(ex.InnerException, ex.Message);
                Environment.Exit(CommandLine.Parser.DefaultExitCodeFail);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                Environment.Exit(CommandLine.Parser.DefaultExitCodeFail);
            }
        }

        private static void UploadFile(object options)
        {
            var verbOptions = (UploadFileVerbOptions)options;
            verbOptions.Validate();
            new UploadFileVerb(verbOptions, logger).Process();
        }

        private static void UploadFolder(object options)
        {
            var verbOptions = (UploadFolderVerbOptions)options;
            verbOptions.Validate();
            new UploadFolderVerb(verbOptions, logger).Process();
        }

        private static void CreateDatasources(object options)
        {
            var verbOptions = (CreateDatasourcesVerbOptions)options;
            verbOptions.Validate();
            new CreateDatasourcesVerb(verbOptions, logger).Process();
        }
    }
}
