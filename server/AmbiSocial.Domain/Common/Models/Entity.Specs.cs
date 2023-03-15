namespace AmbiSocial.Domain.Common.Models;

using FluentAssertions;
using Xunit;

public class EntitySpecs
{
    private class TestEntity : Entity<int>
    {
    }

    [Fact]
    public void EntitiesWithIdenticalIdsShouldBeEqual()
    {
        // Arrange
        var first = new TestEntity().SetId(1);
        var second = new TestEntity().SetId(1);

        // Act
        var result = first == second;

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void EntitiesWithDifferentIdsShouldNotBeEqual()
    {
        // Arrange
        var first = new TestEntity().SetId(1);
        var second = new TestEntity().SetId(2);

        // Act
        var result = first == second;

        // Assert
        result.Should().BeFalse();
    }
}

internal static class EntityExtensions
{
    public static TEntity SetId<TEntity>(this TEntity entity, int id)
        where TEntity : Entity<int>
        => (entity.SetId<int>(id) as TEntity)!;

    private static Entity<T> SetId<T>(this Entity<T> entity, int id)
        where T : struct
    {
        entity
            .GetType()
            .BaseType!
            .GetProperty(nameof(Entity<T>.Id))!
            .GetSetMethod(true)!
            .Invoke(entity, new object[] { id });

        return entity;
    }
}