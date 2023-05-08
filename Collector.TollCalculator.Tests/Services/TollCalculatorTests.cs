using Collector.TollCalculator.Domain;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Collector.TollCalculator.Tests.Services;

[TestClass]
public class TollCalculatorTests
{
    private readonly Service.TollCalculator _tollCalculatorService;
    
    public TollCalculatorTests()
    {
        _tollCalculatorService = new Service.TollCalculator();
    }
    
    [TestMethod]
    public void Should_Throw_Exception_When_No_Date_Provided()
    {
        // Act
        Action act = () => _tollCalculatorService.GetTollFee(new Car(), new List<DateTime>());
        
        // Assert
        act.Should().Throw<Exception>().WithMessage("Bad user request");
    }

    [TestMethod]
    public void Should_Be_Toll_Free()
    {
        var dates = new List<DateTime>
        {
            new(2013, 12, 31, 19, 12, 22)
        };
        
        // Act
        var tollFee = _tollCalculatorService.GetTollFee(new Car(), dates);
        
        // Assert
        tollFee.Should().Be(0);
    }
    
    [TestMethod]
    public void Should_Be_Toll_Free_Month()
    {
        var dates = new List<DateTime>
        {
            new(2013, 07, 05, 06, 12, 22)
        };
        
        // Act
        var freeMonth = _tollCalculatorService.GetTollFee(new Car(), dates);
        
        // Assert
        freeMonth.Should().Be(0);
    }
    
    [TestMethod]
    public void Should_Be_Minimum_Fee()
    {
        var dates = new List<DateTime>()
        {
            new(2013, 10, 1, 6, 12, 22)
        };
        
        // Act
        var minimumFee = _tollCalculatorService.GetTollFee(new Car(), dates);
        
        // Assert
        minimumFee.Should().Be(8);
    }
    
    [TestMethod]
    public void Should_Be_Maximum_Fee_In_Same_Hour()
    {
        var dates = new List<DateTime>
        {
            new(2013, 10, 08, 6, 12, 22),
            new(2013, 10, 08, 7, 11, 22)
        };
        
        // Act
        var maximumFee = _tollCalculatorService.GetTollFee(new Car(), dates);
        
        // Assert
        maximumFee.Should().Be(18);
    }
    
    [TestMethod]
    public void Should_Be_Maximum_Fee_In_Day()
    {
        var dates = new List<DateTime>
        {
            new(2013, 10, 08, 6, 01, 22),
            new(2013, 10, 08, 7, 11, 22),
            new(2013, 10, 08, 8, 28, 22),
            new(2013, 10, 08, 9, 40, 22),
            new(2013, 10, 08, 10, 50, 22),
            new(2013, 10, 08, 11, 55, 22),
            new(2013, 10, 08, 12, 58, 22),
            new(2013, 10, 08, 14, 58, 22)
        };
        
        // Act
        var maximumDayFee = _tollCalculatorService.GetTollFee(new Car(), dates);
        
        // Assert
        maximumDayFee.Should().Be(60);
    }
    
    [TestMethod]
    public void Should_Be_Free_Fee_Time()
    {
        var dates = new List<DateTime>
        {
            new(2013, 10, 01, 19, 01, 22),
        };
        
        // Act
        var freeTimeFee = _tollCalculatorService.GetTollFee(new Car(), dates);
        
        // Assert
        freeTimeFee.Should().Be(0);
    }
    
    [TestMethod]
    public void Should_Be_Free_For_vehicle()
    {
        var dates = new List<DateTime>
        {
            new(2013, 10, 1, 6, 12, 22)
        };
        
        // Act
        var freeVehicleFee = _tollCalculatorService.GetTollFee(new Motorbike(), dates);
        
        // Assert
        freeVehicleFee.Should().Be(0);
    }
}