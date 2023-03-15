﻿namespace AmbiSocial.Domain.Common.Models;

using FluentAssertions;
using Xunit;

public class EnumerationSpecs
{
    [Fact]
    public void EnumerationsWithIdenticalValuesShouldBeEqual()
    {
        // Arrange
        var first = TestEnumeration.FirstTest;
        var second = TestEnumeration.FirstTest;

        // Act
        var result = first == second;

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void EnumerationsWithDifferentValuesShouldNotBeEqual()
    {
        // Arrange
        var first = TestEnumeration.FirstTest;
        var second = TestEnumeration.SecondTest;

        // Act
        var result = first == second;

        // Assert
        result.Should().BeFalse();
    }

    private class TestEnumeration : Enumeration
    {
        internal static readonly TestEnumeration FirstTest = new(1, nameof(FirstTest));
        internal static readonly TestEnumeration SecondTest = new(2, nameof(SecondTest));

        private TestEnumeration(int value, string name)
            : base(value, name)
        {
        }
    }
}