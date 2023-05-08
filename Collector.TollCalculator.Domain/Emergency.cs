using Collector.TollCalculator.Domain.Interfaces;

namespace Collector.TollCalculator.Domain;

public class Emergency : IVehicle
{
    public string GetVehicleType()
    {
        return "Emergency";
    }
}