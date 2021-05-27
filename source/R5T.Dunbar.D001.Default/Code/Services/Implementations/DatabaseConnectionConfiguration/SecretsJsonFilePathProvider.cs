﻿using System;
using System.Threading.Tasks;

using R5T.Lombardy;


namespace R5T.Dunbar.D001.DatabaseConnectionConfiguration
{
    public class SecretsJsonFilePathProvider : ISecretsJsonFilePathProvider
    {
        private ISecretsDirectoryPathProvider SecretsDirectoryPathProvider { get; }
        private ISecretsJsonFileNameProvider SecretsJsonFileNameProvider { get; }
        private IStringlyTypedPathOperator StringlyTypedPathOperator { get; }


        public SecretsJsonFilePathProvider(
            ISecretsDirectoryPathProvider secretsDirectoryPathProvider,
            ISecretsJsonFileNameProvider secretsJsonFileNameProvider,
            IStringlyTypedPathOperator stringlyTypedPathOperator)
        {
            this.SecretsDirectoryPathProvider = secretsDirectoryPathProvider;
            this.SecretsJsonFileNameProvider = secretsJsonFileNameProvider;
            this.StringlyTypedPathOperator = stringlyTypedPathOperator;
        }

        public async Task<string> GetSecretsJsonFilePath()
        {
            var secretsDirectoryPath = await this.SecretsDirectoryPathProvider.GetSecretsDirectoryPath();
            var fileName = await this.SecretsJsonFileNameProvider.GetSecretsJsonFileName();

            var filePath = this.StringlyTypedPathOperator.GetFilePath(secretsDirectoryPath, fileName);
            return filePath;
        }
    }
}
