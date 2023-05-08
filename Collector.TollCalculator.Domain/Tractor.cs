using Collector.TollCalculator.Domain.Interfaces;

namespace Collector.TollCalculator.Domain;

public class Tractor : IVehicle
{
    public string GetVehicleType()
    {
        return "Tractor";
    }
}