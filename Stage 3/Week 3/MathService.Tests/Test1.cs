using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

[TestClass]
public class MathServiceTests
{
    private readonly MathService _mathService;

    public MathServiceTests()
    {
        _mathService = new MathService();
    }

    [TestMethod]
    public void Add_TwoPositiveNumbers_ReturnsCorrectSum()
    {
        // Arrange
        int a = 5;
        int b = 7;

        // Act
        var result = _mathService.Add(a, b);

        // Assert
        Assert.AreEqual(12, result);



    }

    [TestMethod]
    public void Subtract_TwoPositiveNumbers_ReturnsCorrectDifference()
    {
        // Arrange
        int a = 15;
        int b = 5;

        // Act
        var result = _mathService.Subtract(a, b);

        // Assert
        Assert.AreEqual(10, result);
    }

    [TestMethod]
    public void Multiply_TwoPositiveNumbers_ReturnsCorrectProduct()
    {
        // Arrange
        int a = 6;
        int b = 7;

        // Act
        var result = _mathService.Multiply(a, b);

        // Assert
        Assert.AreEqual(42, result);
    }

    [TestMethod]
    public void Divide_TwoPositiveNumbers_ReturnsCorrectResult()
    {
        // Arrange
        int a = 20;
        int b = 5;

        // Act
        var result = _mathService.Divide(a, b);

        // Assert
        Assert.AreEqual(4, result);
    }

    [TestMethod]
    public void Divide_ThrowsException_WhenDividingByZero()
    {
        // Arrange
        double a = 10;
        double b = 0;

        // Act & Assert
        Assert.ThrowsException<DivideByZeroException>(() => _mathService.Divide(a, b));
    }

    [TestMethod]
    public void IsEven_ReturnsTrue_ForEvenNumbers()
    {
        Assert.IsTrue(_mathService.IsEven(4));
        Assert.IsTrue(_mathService.IsEven(0));
    }

    [TestMethod]
    public void IsEven_ReturnsFalse_ForOddNumbers()
    {
        Assert.IsFalse(_mathService.IsEven(5));
        Assert.IsFalse(_mathService.IsEven(1));
    }

    [TestMethod]
    public void GetMax_ReturnsLargerNumber()
    {
        Assert.AreEqual(10, _mathService.GetMax(10, 7));
        Assert.AreEqual(25, _mathService.GetMax(3, 25));
        Assert.AreEqual(100, _mathService.GetMax(100, 100));
    }
}