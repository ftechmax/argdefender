using AutoFixture;
using Shouldly;

namespace ArgDefender.Test;

public class StringTests
{
    private IFixture _fixture = null!;

    [SetUp]
    public void Setup()
    {
        _fixture = new Fixture();////.Customize(new AutoFakeItEasyCustomization());
    }

    [Test]
    public void Empty_Pass()
    {
        // Arrange
        var arg = string.Empty;

        // Act
        var act = () => Guard.Argument(arg).Empty();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void Empty_Fail()
    {
        // Arrange
        var arg = _fixture.Create<string>();

        // Act
        Action act = () => Guard.Argument(arg).Empty();

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void NotEmpty_Pass()
    {
        // Arrange
        var arg = _fixture.Create<string>();

        // Act
        var act = () => Guard.Argument(arg).NotEmpty();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void NotEmpty_Fail()
    {
        // Arrange
        var arg = string.Empty;

        // Act
        Action act = () => Guard.Argument(arg).NotEmpty();

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    [TestCase(" ")]
    [TestCase("\t")]
    [TestCase(" \t")]
    public void WhiteSpace_Pass(string testCase)
    {
        // Act
        var act = () => Guard.Argument(testCase).WhiteSpace();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void WhiteSpace_Fail()
    {
        // Arrange
        var arg = _fixture.Create<string>();

        // Act
        Action act = () => Guard.Argument(arg).WhiteSpace();

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void NotWhiteSpace_Pass()
    {
        // Arrange
        var arg = _fixture.Create<string>();

        // Act
        var act = () => Guard.Argument(arg).NotWhiteSpace();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void NotWhiteSpace_Fail()
    {
        // Arrange
        var arg = string.Empty;

        // Act
        Action act = () => Guard.Argument(arg).NotWhiteSpace();

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void Length_Pass()
    {
        // Arrange
        var arg = _fixture.Create<string>();

        // Act
        var act = () => Guard.Argument(arg).Length(arg.Length);

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    [TestCase(1)]
    [TestCase(-1)]
    public void Length_Fail(int testCase)
    {
        // Arrange
        var arg = _fixture.Create<string>();

        // Act
        Action act = () => Guard.Argument(arg).Length(arg.Length + testCase);

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void MinLength_Pass()
    {
        // Arrange
        var arg = "abcd";

        // Act
        var act = () => Guard.Argument(arg).MinLength(2);

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void MinLength_Fail()
    {
        // Arrange
        var arg = "a";

        // Act
        Action act = () => Guard.Argument(arg).MinLength(2);

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void MaxLength_Pass()
    {
        // Arrange
        var arg = "abcd";

        // Act
        var act = () => Guard.Argument(arg).MaxLength(5);

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void MaxLength_Fail()
    {
        // Arrange
        var arg = "abcdef";

        // Act
        Action act = () => Guard.Argument(arg).MaxLength(5);

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void LengthInRange_Pass()
    {
        // Arrange
        var arg = "abcd";

        // Act
        var act = () => Guard.Argument(arg).LengthInRange(2, 5);

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void LengthInRange_Fail_Below()
    {
        // Arrange
        var arg = "a";

        // Act
        Action act = () => Guard.Argument(arg).LengthInRange(2, 5);

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void LengthInRange_Fail_Above()
    {
        // Arrange
        var arg = "abcdef";

        // Act
        Action act = () => Guard.Argument(arg).LengthInRange(2, 5);

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void StartsWith_Pass()
    {
        // Arrange
        var arg = "hello";

        // Act
        var act = () => Guard.Argument(arg).StartsWith("he");

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void StartsWith_Fail()
    {
        // Arrange
        var arg = "hello";

        // Act
        Action act = () => Guard.Argument(arg).StartsWith("xy");

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void DoesNotStartWith_Pass()
    {
        // Arrange
        var arg = "hello";

        // Act
        var act = () => Guard.Argument(arg).DoesNotStartWith("xy");

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void DoesNotStartWith_Fail()
    {
        // Arrange
        var arg = "hello";

        // Act
        Action act = () => Guard.Argument(arg).DoesNotStartWith("he");

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void EndsWith_Pass()
    {
        // Arrange
        var arg = "hello";

        // Act
        var act = () => Guard.Argument(arg).EndsWith("lo");

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void EndsWith_Fail()
    {
        // Arrange
        var arg = "hello";

        // Act
        Action act = () => Guard.Argument(arg).EndsWith("zz");

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void DoesNotEndWith_Pass()
    {
        // Arrange
        var arg = "hello";

        // Act
        var act = () => Guard.Argument(arg).DoesNotEndWith("zz");

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void DoesNotEndWith_Fail()
    {
        // Arrange
        var arg = "hello";

        // Act
        Action act = () => Guard.Argument(arg).DoesNotEndWith("lo");

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void Matches_Pass()
    {
        // Arrange
        var arg = "hello";

        // Act
        var act = () => Guard.Argument(arg).Matches("^h.*o$");

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void Matches_Fail()
    {
        // Arrange
        var arg = "hello";

        // Act
        Action act = () => Guard.Argument(arg).Matches("^x");

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void MatchesTimeout_Pass()
    {
        // Arrange
        var arg = "hello";

        // Act
        var act = () => Guard.Argument(arg).MatchesTimeout("^h.*o$", TimeSpan.FromSeconds(1));

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void MatchesTimeout_Fail()
    {
        // Arrange
        var arg = "hello";

        // Act
        Action act = () => Guard.Argument(arg).MatchesTimeout("^x", TimeSpan.FromSeconds(1));

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void DoesNotMatch_Pass()
    {
        // Arrange
        var arg = "hello";

        // Act
        var act = () => Guard.Argument(arg).DoesNotMatch("^x");

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void DoesNotMatch_Fail()
    {
        // Arrange
        var arg = "hello";

        // Act
        Action act = () => Guard.Argument(arg).DoesNotMatch("^h");

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void DoesNotMatchTimeout_Pass()
    {
        // Arrange
        var arg = "hello";

        // Act
        var act = () => Guard.Argument(arg).DoesNotMatchTimeout("^x", TimeSpan.FromSeconds(1));

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void DoesNotMatchTimeout_Fail()
    {
        // Arrange
        var arg = "hello";

        // Act
        Action act = () => Guard.Argument(arg).DoesNotMatchTimeout("^h", TimeSpan.FromSeconds(1));

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }
}




