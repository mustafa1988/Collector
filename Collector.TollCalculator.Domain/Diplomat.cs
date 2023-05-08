using Collector.TollCalculator.Domain.Interfaces;

namespace Collector.TollCalculator.Domain;

public class Diplomat : IVehicle
{
    public string GetVehicleType()
    {
        return "Diplomat";
    }
}