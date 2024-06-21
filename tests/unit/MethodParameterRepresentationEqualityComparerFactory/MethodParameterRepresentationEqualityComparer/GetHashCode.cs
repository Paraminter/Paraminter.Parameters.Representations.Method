﻿namespace Paraminter.Parameters.Representations.MethodParameterRepresentationEqualityComparer;

using Moq;

using System;

using Xunit;

public sealed class GetHashCode
{
    private readonly IFixture Fixture = FixtureFactory.Create();

    [Fact]
    public void Null_ThrowsArgumentNullException()
    {
        var result = Record.Exception(() => Target(null!));

        Assert.IsType<ArgumentNullException>(result);
    }

    [Fact]
    public void PropagatesHashCode()
    {
        var hashCode = 42;
        var name = "Name";

        Mock<IMethodParameterRepresentation> objMock = new();

        objMock.Setup(static (representation) => representation.Name).Returns(name);

        Fixture.NameComparerMock.Setup((comparer) => comparer.GetHashCode(name)).Returns(hashCode);

        var result = Target(objMock.Object);

        Assert.Equal(hashCode, result);
    }

    private int Target(
        IMethodParameterRepresentation obj)
    {
        return Fixture.Sut.GetHashCode(obj);
    }
}