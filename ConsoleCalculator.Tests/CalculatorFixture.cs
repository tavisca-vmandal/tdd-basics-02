using System;
using Xunit;
using ConsoleCalculator;
namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
        [Fact]
        public void TestMultipleKeyPress()
        {
            var calc = new Calculator();
            var result=calc.SendKeyPress('5');
            Assert.Equal(5,Convert.ToDouble(result));

            result=calc.SendKeyPress('0');
            Assert.Equal(50,Convert.ToDouble(result));

            result=calc.SendKeyPress('.');
            Assert.Equal("50.",result);

            result=calc.SendKeyPress('6');
            Assert.Equal(50.6,Convert.ToDouble(result));

            result=calc.SendKeyPress('7');
            Assert.Equal(50.67,Convert.ToDouble(result));
            
            return;
        }
        [Fact]
        public void TestIgnorePress()
        {
            var calc = new Calculator();
           
            var result=calc.SendKeyPress('5');
            Assert.Equal("5",result);

            result=calc.SendKeyPress('r');
            Assert.Equal("5",result);

            result=calc.SendKeyPress('7');
            Assert.Equal(57,Convert.ToDouble(result));
            
            return;
        }
        [Fact]
        public void TestNormalAddition()
        {
            var calc = new Calculator();
            var result=calc.SendKeyPress('5');
            result=calc.SendKeyPress('0');
            result=calc.SendKeyPress('+');
            result=calc.SendKeyPress('6');
            result=calc.SendKeyPress('=');
            Assert.Equal(56,Convert.ToDouble(result));
            return;
        }

        [Fact]
        public void TestDivideByZero()
        {
            var calc = new Calculator();
            var result=calc.SendKeyPress('1');
            result=calc.SendKeyPress('3');
            result=calc.SendKeyPress('/');
            result=calc.SendKeyPress('0');
            result=calc.SendKeyPress('=');
            Assert.Equal("-E-",result);
            return;
        }
        [Fact]
        public void TestToggleOperation()
        {
            var calc = new Calculator();
            var result=calc.SendKeyPress('1');
            result=calc.SendKeyPress('2');
            Assert.Equal(12,Convert.ToDouble(result));

            result=calc.SendKeyPress('+');
            Assert.Equal(12,Convert.ToDouble(result));

            result=calc.SendKeyPress('2');
            Assert.Equal(2,Convert.ToDouble(result));

            result=calc.SendKeyPress('S');
            Assert.Equal(-2,Convert.ToDouble(result));

            result=calc.SendKeyPress('S');
            Assert.Equal(2,Convert.ToDouble(result));

            result=calc.SendKeyPress('s');
            Assert.Equal(-2,Convert.ToDouble(result));

            result=calc.SendKeyPress('=');
            Assert.Equal(10,Convert.ToDouble(result));
            return;
        }
        [Fact]
        public void TestDecimalNumberOperation()
        {
            var calc = new Calculator();
            var result=calc.SendKeyPress('1');
            result=calc.SendKeyPress('.');
            result=calc.SendKeyPress('3');
            Assert.Equal(1.3,Convert.ToDouble(result));

            result=calc.SendKeyPress('x');
            Assert.Equal(1.3,Convert.ToDouble(result));

            result=calc.SendKeyPress('2');
            result=calc.SendKeyPress('.');
            result=calc.SendKeyPress('5');
            Assert.Equal(2.5,Convert.ToDouble(result));

            result=calc.SendKeyPress('=');
            Assert.Equal(3.25,Convert.ToDouble(result));
            return;
        }


    }
}
