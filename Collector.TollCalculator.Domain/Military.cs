using Collector.TollCalculator.Domain.Interfaces;

namespace Collector.TollCalculator.Domain;

public class Military : IVehicle
{
    public string GetVehicleType()
    {
        return "Military";
    }
}