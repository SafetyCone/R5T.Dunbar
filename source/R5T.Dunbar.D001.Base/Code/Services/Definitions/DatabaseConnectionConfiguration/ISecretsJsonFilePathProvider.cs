using System;
using System.Threading.Tasks;


namespace R5T.Dunbar.D001.DatabaseConnectionConfiguration
{
    public interface ISecretsJsonFilePathProvider
    {
        Task<string> GetSecretsJsonFilePath();
    }
}
