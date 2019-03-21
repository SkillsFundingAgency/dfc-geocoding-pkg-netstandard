using System.Threading.Tasks;
using DFC.GeoCoding.Standard.AzureMaps.Model;

namespace DFC.GeoCoding.Standard.AzureMaps.Service
{
    public interface IAzureMapService
    {
        Task<Position> GetPositionForAddress(string address);
    }
}