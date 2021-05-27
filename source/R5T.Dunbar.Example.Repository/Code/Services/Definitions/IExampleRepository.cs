using System;
using System.Threading.Tasks;


namespace R5T.Dunbar.Example.Repository
{
    public interface IExampleRepository
    {
        Task<Guid> Add(string value);
    }
}
