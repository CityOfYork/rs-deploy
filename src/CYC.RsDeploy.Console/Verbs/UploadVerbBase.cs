using System;
using System.Linq;
using System.ServiceModel;
using CYC.RsDeploy.Console.Constants;
using CYC.RsDeploy.Console.Exceptions;
using CYC.RsDeploy.Console.ReportService2010;
using CYC.RsDeploy.Console.Services;
using NLog;

namespace CYC.RsDeploy.Console.Verbs
{
    public abstract class UploadVerbBase
    {
        protected IFileService fileService;
        protected IReportingServiceChannelFactory channelFactory;
        protected ILogger logger;
        protected IReportingService2010 channel;

        protected UploadVerbBase(ILogger logger, string server)
        {
            this.fileService = new FileService();
            this.channelFactory = new ReportingServiceChannelFactory();
            this.logger = logger;

            var url = String.Format("http://{0}/reportserver/ReportService2010.asmx", server);
            channel = channelFactory.Create(url);
        }

        protected void UploadFile(string file, string destinationFolder, string server)
        {
            var path = fileService.ExpandFileNamePath(file);
            var parent = path == null ? destinationFolder : String.Format("{0}/{1}", destinationFolder, path);
            var name = fileService.GetFileName(file);

            logger.Info("Uploading file '{0}' to '{1}/{2}' on report server '{3}'", file, parent, name, server);

            try
            {
                channel.CreateCatalogItem(new CreateCatalogItemRequest
                {
                    Definition = fileService.GetBytes(file),
                    Name = name,
                    Parent = parent,
                    ItemType = ItemType.Report,
                    Overwrite = true
                });
            }
            catch(EndpointNotFoundException ex)
            {
                throw new InvalidParameterException(ex, $"There was no response from '{server}'");
            }

            var itemPath = String.Format("{0}/{1}", parent, name);

            UpdateDatasources(itemPath, destinationFolder);
        }

        private void UpdateDatasources(string itemPath, string parent)
        {
            logger.Info("Updating datasources in report {0}", itemPath);

            var response = GetItemDataSources(itemPath);

            var dataSources = response.DataSources.Select(datasource => new DataSource
            {
                Name = datasource.Name,
                Item = new DataSourceReference
                {
                    Reference = String.Format("{0}/{1}", parent, datasource.Name)
                }
            }).ToArray();

            SetItemDataSources(itemPath, dataSources);
        }

        private GetItemDataSourcesResponse GetItemDataSources(string itemPath)
        {
            var request = new GetItemDataSourcesRequest
            {
                ItemPath = itemPath
            };

            return channel.GetItemDataSources(request);
        }

        private void SetItemDataSources(string itemPath, DataSource[] dataSources)
        {
            var request = new SetItemDataSourcesRequest
            {
                ItemPath = itemPath,
                DataSources = dataSources
            };

            channel.SetItemDataSources(request);
        }
    }
}
