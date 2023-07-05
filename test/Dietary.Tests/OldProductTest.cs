using System;
using AutoFixture;
using AutoFixture.AutoMoq;
using FluentAssertions;
using LegacyFighter.Dietary.Models.NewProducts;
using NSubstitute.ExceptionExtensions;
using Xunit;

namespace LegacyFighter.Dietary.Tests
{
    public class OldProductTest
    {
        [Fact]
        public void IncrementCounter_PositivePriceAndCounter_IncrementsCounter()
        {
            //ASSIGN
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var sut = fixture.Create<OldProduct>();
            var counter = sut.Counter;
            //ACT
            sut.IncrementCounter();
            
            //ASSERT
            sut.Counter.Should().Be(counter + 1);
        }

        [Fact]
        public void IncrementCounter_NullPrice_ThrowsInvalidOperationException()
        {
            //ASSIGN
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var product = fixture.Create<OldProduct>();
            var sut = new OldProduct(null, product.Desc, product.LongDesc, product.Counter);

            //ASSERT
            sut.Invoking(p => p.IncrementCounter())
                .Should().Throw<InvalidOperationException>();
        }
        
        [Fact]
        public void IncrementCounter_NullCounter_ThrowsInvalidOperationException()
        {
            //ASSIGN
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var product = fixture.Create<OldProduct>();
            var sut = new OldProduct(product.Price, product.Desc, product.LongDesc, null);

            //ASSERT
            sut.Invoking(p => p.IncrementCounter())
                .Should().Throw<InvalidOperationException>();
        }
        
        [Fact]
        public void IncrementCounter_NegativeCounter_ThrowsInvalidOperationException()
        {
            //ASSIGN
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var product = fixture.Create<OldProduct>();
            var sut = new OldProduct(product.Price, product.Desc, product.LongDesc, -2);

            //ASSERT
            sut.Invoking(p => p.IncrementCounter())
                .Should().Throw<InvalidOperationException>();
        }
        
        [Fact]
        public void DecrementCounter_PositivePriceAndCounter_DecrementsCounter()
        {
            //ASSIGN
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var sut = fixture.Create<OldProduct>();
            var counter = sut.Counter;
            //ACT
            sut.DecrementCounter();
            
            //ASSERT
            sut.Counter.Should().Be(counter - 1);
        }

        [Fact]
        public void DecrementCounter_NullPrice_ThrowsInvalidOperationException()
        {
            //ASSIGN
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var product = fixture.Create<OldProduct>();
            var sut = new OldProduct(null, product.Desc, product.LongDesc, product.Counter);

            //ASSERT
            sut.Invoking(p => p.DecrementCounter())
                .Should().Throw<InvalidOperationException>();
        }
        
        [Fact]
        public void DecrementCounter_NullCounter_ThrowsInvalidOperationException()
        {
            //ASSIGN
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var product = fixture.Create<OldProduct>();
            var sut = new OldProduct(product.Price, product.Desc, product.LongDesc, null);

            //ASSERT
            sut.Invoking(p => p.DecrementCounter())
                .Should().Throw<InvalidOperationException>();
        }
        
        [Fact]
        public void DecrementCounter_NegativeCounter_ThrowsInvalidOperationException()
        {
            //ASSIGN
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var product = fixture.Create<OldProduct>();
            var sut = new OldProduct(product.Price, product.Desc, product.LongDesc, -1);

            //ASSERT
            sut.Invoking(p => p.DecrementCounter())
                .Should().Throw<InvalidOperationException>();
        }
        
        [Fact]
        public void ChangePrice_PositivePrice_ChangesPrice()
        {
            //ASSIGN
            var newPrice = new decimal(10.50);
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var sut = fixture.Create<OldProduct>();

            //ACT
            sut.ChangePriceTo(newPrice);
            
            //ASSERT
            sut.Price.Should().Be(newPrice);
        }
        
        [Fact]
        public void ChangePrice_ZeroOrNegativeCounter_ThrowsInvalidOperationException()
        {
            //ASSIGN
            var oldPrice = new decimal(1.00);
            var newPrice = new decimal(10.50);
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var product = fixture.Create<OldProduct>();
            var sut = new OldProduct(oldPrice, product.Desc, product.LongDesc, 0);
            var sut2 = new OldProduct(oldPrice, product.Desc, product.LongDesc, -1);

            //ACT
            sut.ChangePriceTo(newPrice);
            sut2.ChangePriceTo(newPrice);
            
            //ASSERT
            sut.Price.Should().Be(oldPrice);
            sut.Price.Should().Be(oldPrice);
        }
        
        [Fact]
        public void ChangePrice_NullCounter_ThrowsInvalidOperationException()
        {
            //ASSIGN
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var product = fixture.Create<OldProduct>();
            var sut = new OldProduct(product.Price, product.Desc, product.LongDesc, null);

            //ASSERT
            sut.Invoking(p => p.ChangePriceTo(1))
                .Should().Throw<InvalidOperationException>();
        }
        
        [Fact]
        public void ChangePrice_NullPrice_ThrowsInvalidOperationException()
        {
            //ASSIGN
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var sut = fixture.Create<OldProduct>();

            //ASSERT
            sut.Invoking(p => p.ChangePriceTo(null))
                .Should().Throw<InvalidOperationException>();
        }
        
        [Fact]
        public void ReplaceCharFromDesc_AnyDescNull_ThrowsInvalidOperationException()
        {
            //ASSIGN
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var product = fixture.Create<OldProduct>();
            var sut = new OldProduct(product.Price, product.Desc, null, product.Counter);
            var sut2 = new OldProduct(product.Price, null, product.LongDesc, product.Counter);
            
            
            //ASSERT
            sut.Invoking(p => p.ReplaceCharFromDesc("", ""))
                .Should().Throw<InvalidOperationException>();
            sut2.Invoking(p => p.ReplaceCharFromDesc("", ""))
                .Should().Throw<InvalidOperationException>();
        }
        
        [Fact]
        public void ReplaceCharFromDesc_DescNotNull_DoesNotThrow()
        {
            //ASSIGN
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var sut = fixture.Create<OldProduct>();
            
            //ASSERT
            sut.Invoking(p => p.ReplaceCharFromDesc(sut.Desc.Substring(0, sut.Desc.Length / 2), ""))
                .Should().NotThrow();
        }
        
        [Fact]
        public void FormatDesc_AnyDescNull_()
        {
            //ASSIGN
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var product = fixture.Create<OldProduct>();
            var sut = new OldProduct(product.Price, product.Desc, null, product.Counter);
            var sut2 = new OldProduct(product.Price, null, product.LongDesc, product.Counter);
            
            
            //ASSERT
            sut.FormatDesc().Should().Be("");
            sut2.FormatDesc().Should().Be("");
        }
        
        [Fact]
        public void FormatDesc_NotNullDescAndLongDesc_ReturnsFormattedDesc()
        {
            //ASSIGN
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var sut = fixture.Create<OldProduct>();

            //ASSERT
            sut.FormatDesc().Should().Be($"{sut.Desc} *** {sut.LongDesc}");
        }
    }
}