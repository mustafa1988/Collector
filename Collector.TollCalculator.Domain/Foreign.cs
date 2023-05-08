using Collector.TollCalculator.Domain.Interfaces;

namespace Collector.TollCalculator.Domain;

public class Foreign : IVehicle
{
    public string GetVehicleType()
    {
        return "Foreign";
    }
}