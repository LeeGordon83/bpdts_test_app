using bpdts_test_app.Models;

namespace bpdts_test_app.Services.Utilities
{
    public interface IDistanceCalculationService
    {
        double DistanceCalculator(LatLng pos1, LatLng pos2);
    }
}