using System.Threading.Tasks;

namespace LightRays.Core.Services
{
    public interface IRequestService
    {
        Task<bool> GetRequest(string uri, string code);
    }
}
