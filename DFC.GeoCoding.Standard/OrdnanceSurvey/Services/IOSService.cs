using System.Threading.Tasks;
using DFC.GeoCoding.Standard.OrdnanceSurvey.Models;

namespace DFC.GeoCoding.Standard.OrdnanceSurvey.Services
{
    public interface IOSService
    {
        Task<Position> GetPositionForPostcodeAsync(string postcode);
    }
}
