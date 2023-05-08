namespace Collector.TollCalculator.Domain;

public class Fee
{
    public int StartHour { get; set; }
    public int StartMinute { get; set; }
    public int EndMinute { get; set; }
    public int TollFee { get; set; }
}