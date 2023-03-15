namespace AmbiSocial.Domain.Common.Models;

using FluentAssertions;
using Xunit;

public class ValueObjectSpecs
{
    [Fact]
    public void ValueObjectsWithIdenticalPropertiesShouldBeEqual()
    {
        // Arrange
        var first = new TestValueObject();
        var second = new TestValueObject();

        // Act
        var result = first == second;

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void ValueObjectsWithDifferentPropertiesShouldNotBeEqual()
    {
        // Arrange
        var first = new TestValueObject();
        var second = new TestValueObject2();

        // Act
        var result = first == second;

        // Assert
        result.Should().BeFalse();
    }

    private class TestValueObject : ValueObject
    {
    }

    private class TestValueObject2 : ValueObject
    {
        public string Test { get; } = default!;
    }
}