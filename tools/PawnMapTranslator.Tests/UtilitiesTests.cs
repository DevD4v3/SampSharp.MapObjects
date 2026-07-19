namespace PawnMapTranslator.Tests;

public class UtilitiesTests
{
    [Test]
    public void ToFloat_WhenValueDoesNotEndWithSuffix_ShouldAppendSuffix()
    {
        // Arrange
        const string value = "1.25";

        // Act
        string actual = Utilities.ToFloat(value);

        // Assert
        actual.Should().Be("1.25f");
    }

    [Test]
    public void ToFloat_WhenValueAlreadyEndsWithSuffix_ShouldReturnOriginalValue()
    {
        // Arrange
        const string value = "1.25f";

        // Act
        string actual = Utilities.ToFloat(value);

        // Assert
        actual.Should().Be("1.25f");
    }

    [Test]
    public void ToFloat_WhenValueContainsWhitespace_ShouldTrimBeforeAppendingSuffix()
    {
        // Arrange
        const string value = "  1.25  ";

        // Act
        string actual = Utilities.ToFloat(value);

        // Assert
        actual.Should().Be("1.25f");
    }
}
