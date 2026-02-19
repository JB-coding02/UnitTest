using Microsoft.VisualStudio.TestTools.UnitTesting;
using CPW211_UnitTestStarterCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPW211_UnitTestStarterCode.Tests;

[TestClass()]
public class SimpleMathTests
{
    [TestMethod()]
    [DataRow(5, 10)]
    [DataRow(0, 100)]
    [DataRow(-1, -10)]
    [DataRow(0, -0)]
    public void Add_TwoNumbers_ReturnsSum(double num1, double num2)
    {
        // Use the DataRow values to test the Add method
        // Arrange
        double expected = num1 + num2;
        const double delta = 1e-12;

        // Act
        double actual = SimpleMath.Add(num1, num2);

        // Assert
        Assert.AreEqual(expected, actual, delta, "Add should return the arithmetic sum of the two operands.");
    }

    [TestMethod]
    public void Multiply_TwoNumbers_ReturnsProduct()
    {
        // Use a few pairs of values to test the Multiply method
        const double delta = 1e-12;

        Assert.AreEqual(12.0, SimpleMath.Multiply(3.0, 4.0), delta, "3 * 4 should be 12");
        Assert.AreEqual(0.0, SimpleMath.Multiply(0.0, 5.0), delta, "0 * 5 should be 0");
        Assert.AreEqual(6.0, SimpleMath.Multiply(-2.0, -3.0), delta, "-2 * -3 should be 6");
        Assert.AreEqual(-6.0, SimpleMath.Multiply(-2.0, 3.0), delta, "-2 * 3 should be -6");
    }

    [TestMethod]
    public void Divide_DenominatorZero_ProducesInfinityOrNaN()
    {
        // IEEE-754 double division: non-zero / 0 -> +/-Infinity; 0 / 0 -> NaN
        Assert.IsTrue(double.IsPositiveInfinity(SimpleMath.Divide(1.0, 0.0)), "1.0 / 0.0 should be +Infinity.");
        Assert.IsTrue(double.IsNegativeInfinity(SimpleMath.Divide(-1.0, 0.0)), "-1.0 / 0.0 should be -Infinity.");
        Assert.IsTrue(double.IsNaN(SimpleMath.Divide(0.0, 0.0)), "0.0 / 0.0 should be NaN.");
    }

    // TODO: Add a new test to test the Divide method with two valid numbers
    [TestMethod]
    public void Divide_TwoValidNumbers_ReturnsQuotient()
    {
        // Arrange
        const double delta = 1e-12;

        // Act & Assert
        Assert.AreEqual(2.0, SimpleMath.Divide(10.0, 5.0), delta, "10 / 5 should be 2");
        Assert.AreEqual(-2.5, SimpleMath.Divide(-5.0, 2.0), delta, "-5 / 2 should be -2.5");
        Assert.AreEqual(0.0, SimpleMath.Divide(0.0, 3.0), delta, "0 / 3 should be 0");
        Assert.AreEqual(0.5, SimpleMath.Divide(1.0, 2.0), delta, "1 / 2 should be 0.5");
    }

    // TODO: Add a new test to test the subtract method with two valid numbers
    [TestMethod]
    public void Subtract_TwoNumbers_ReturnsDifference()
    {
        // Arrange
        const double delta = 1e-12;

        // Act & Assert
        Assert.AreEqual(5.0, SimpleMath.Subtract(10.0, 5.0), delta, "10 - 5 should be 5");
        Assert.AreEqual(-7.0, SimpleMath.Subtract(3.0, 10.0), delta, "3 - 10 should be -7");
        Assert.AreEqual(0.0, SimpleMath.Subtract(2.5, 2.5), delta, "2.5 - 2.5 should be 0");
    }
}