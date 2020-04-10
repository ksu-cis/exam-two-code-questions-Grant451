//Modified by Grant Clothier
//4.10.2020
using System;
using System.ComponentModel;
using ExamTwoCodeQuestions.Data;
using Xunit;

namespace ExamTwoCodeQuestions.DataTests
{
    public class CobblerUnitTests
    {
        [Theory]
        [InlineData(FruitFilling.Cherry)]
        [InlineData(FruitFilling.Blueberry)]
        [InlineData(FruitFilling.Peach)]
        public void ShouldBeAbleToSetFruit(FruitFilling fruit)
        {
            var cobbler = new Cobbler();
            cobbler.Fruit = fruit;
            Assert.Equal(fruit, cobbler.Fruit);
        }

        [Fact]
        public void ShouldBeServedWithIceCreamByDefault()
        {
            var cobbler = new Cobbler();
            Assert.True(cobbler.WithIceCream);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void ShouldBeAbleToSetWithIceCream(bool serveWithIceCream)
        {
            var cobbler = new Cobbler();
            cobbler.WithIceCream = serveWithIceCream;
            Assert.Equal(serveWithIceCream, cobbler.WithIceCream);
        }

        [Theory]
        [InlineData(true, 5.32)]
        [InlineData(false, 4.25)]
        public void PriceShouldReflectIceCream(bool serveWithIceCream, double price)
        {
            var cobbler = new Cobbler()
            {
                WithIceCream = serveWithIceCream
            };
            Assert.Equal(price, cobbler.Price);
        }

        [Fact]
        public void DefaultSpecialInstructionsShouldBeEmpty()
        {
            var cobbler = new Cobbler();
            Assert.Empty(cobbler.SpecialInstructions);
        }

        [Fact]
        public void SpecialIstructionsShouldSpecifyHoldIceCream()
        {
            var cobbler = new Cobbler()
            {
                WithIceCream = false
            };
            Assert.Collection<string>(cobbler.SpecialInstructions, instruction =>
            {
                Assert.Equal("Hold Ice Cream", instruction);
            });
        }

        [Fact]
        public void ShouldImplementIOrderItemInterface()
        {
            var cobbler = new Cobbler();
            Assert.IsAssignableFrom<IOrderItem>(cobbler);
        }

        //#########################(new tests:)
        [Fact]
        public void CobblerShouldImplementInotifyPropertyChanged()
        {
            var cob = new Cobbler();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(cob);
        }

        [Fact]
        public void ChangingWithIceCreamShouldInvokePropertyChangedForWithIceCream()
        {
            var cob = new Cobbler();
            Assert.PropertyChanged(cob, "WithIceCream", () =>
            {
                cob.WithIceCream = false;
            });

        }

        [Fact]
        public void ChangingPeachShouldInvokePropertyChangedForPeach()
        {
            var cob = new Cobbler();
            Assert.PropertyChanged(cob, "Fruit", () => { cob.Fruit = FruitFilling.Peach; });
        }

        [Fact]
        public void ChangingCherryShouldInvokePropertyChangedForCherry()
        {
            var cob = new Cobbler();
            Assert.PropertyChanged(cob, "Fruit", () => { cob.Fruit = FruitFilling.Cherry; });
        }

        [Fact]
        public void ChangingBlueberryShouldInvokePropertyChangedForBlueberry()
        {
            var cob = new Cobbler();
            Assert.PropertyChanged(cob, "Fruit", () => { cob.Fruit = FruitFilling.Blueberry; });
        }

        [Fact]
        public void ChangingWithIceCreamShouldInvokePropertyChangedForPriceTrueToFalse()
        {
            var cob = new Cobbler();
            Assert.PropertyChanged(cob, "WithIceCream", () =>
            {
                cob.WithIceCream = false;
            });
            Assert.Equal(4.25, cob.Price);

        }

        [Fact]
        public void ChangingWithIceCreamShouldInvokePropertyChangedForPriceFalseToTrue()
        {
            var cob = new Cobbler();
            cob.WithIceCream = false;
            Assert.PropertyChanged(cob, "WithIceCream", () =>
            {
                cob.WithIceCream = true;
                Assert.Equal(5.32, cob.Price);
            });
        }

        [Fact]
        public void ChangingWithIceCreamShouldInvokePropertyChangedForSpecialInstructions()
        {
            var soda = new Cobbler();
            Assert.PropertyChanged(soda, "SpecialInstructions", () =>
            {
                soda.WithIceCream = false;
            });
        }

    }
}
