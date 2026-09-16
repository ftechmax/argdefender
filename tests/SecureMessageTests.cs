using System.Net.Mail;
using Shouldly;

namespace ArgDefender.Test;

public class SecureMessageTests
{
    [Test]
    public void Secure_Equal_Redacts_Validation_Values()
    {
        // Arrange
        var arg = "value";
        var argument = Guard.Argument(arg, secure: true);

        // Act
        Action act = () => argument.Equal("other");

        // Assert
        ShouldUseGenericMessage(act);
    }

    [Test]
    public void Secure_NotEqual_Redacts_Validation_Values()
    {
        // Arrange
        var arg = "value";
        var argument = Guard.Argument(arg, secure: true);

        // Act
        Action act = () => argument.NotEqual("value");

        // Assert
        ShouldUseGenericMessage(act);
    }

    [Test]
    public void Secure_EqualDelta_Redacts_Validation_Values()
    {
        // Arrange
        var arg = 1d;
        var argument = Guard.Argument(arg, secure: true);

        // Act
        Action act = () => argument.Equal(2d, 0.1d);

        // Assert
        ShouldUseGenericMessage(act);
    }

    [Test]
    public void Secure_NotEqualDelta_Redacts_Validation_Values()
    {
        // Arrange
        var arg = 1d;
        var argument = Guard.Argument(arg, secure: true);

        // Act
        Action act = () => argument.NotEqual(1d, 0.1d);

        // Assert
        ShouldUseGenericMessage(act);
    }

    [Test]
    public void Secure_Same_Redacts_Validation_Values()
    {
        // Arrange
        var arg = "value";
        var argument = Guard.Argument(arg, secure: true);

        // Act
        Action act = () => argument.Same(new object());

        // Assert
        ShouldUseGenericMessage(act);
    }

    [Test]
    public void Secure_NotSame_Redacts_Validation_Values()
    {
        // Arrange
        var arg = "value";
        var argument = Guard.Argument(arg, secure: true);

        // Act
        Action act = () => argument.NotSame("value");

        // Assert
        ShouldUseGenericMessage(act);
    }

    [Test]
    public void Secure_StartsWith_Redacts_Validation_Values()
    {
        // Arrange
        var arg = "value";
        var argument = Guard.Argument(arg, secure: true);

        // Act
        Action act = () => argument.StartsWith("other");

        // Assert
        ShouldUseGenericMessage(act);
    }

    [Test]
    public void Secure_DoesNotStartWith_Redacts_Validation_Values()
    {
        // Arrange
        var arg = "value";
        var argument = Guard.Argument(arg, secure: true);

        // Act
        Action act = () => argument.DoesNotStartWith("val");

        // Assert
        ShouldUseGenericMessage(act);
    }

    [Test]
    public void Secure_EndsWith_Redacts_Validation_Values()
    {
        // Arrange
        var arg = "value";
        var argument = Guard.Argument(arg, secure: true);

        // Act
        Action act = () => argument.EndsWith("other");

        // Assert
        ShouldUseGenericMessage(act);
    }

    [Test]
    public void Secure_DoesNotEndWith_Redacts_Validation_Values()
    {
        // Arrange
        var arg = "value";
        var argument = Guard.Argument(arg, secure: true);

        // Act
        Action act = () => argument.DoesNotEndWith("ue");

        // Assert
        ShouldUseGenericMessage(act);
    }

    [Test]
    public void Secure_Contains_Redacts_Validation_Values()
    {
        // Arrange
        var arg = "value";
        var argument = Guard.Argument(arg, secure: true);

        // Act
        Action act = () => argument.Contains("other");

        // Assert
        ShouldUseGenericMessage(act);
    }

    [Test]
    public void Secure_DoesNotContain_Redacts_Validation_Values()
    {
        // Arrange
        var arg = "value";
        var argument = Guard.Argument(arg, secure: true);

        // Act
        Action act = () => argument.DoesNotContain("alu");

        // Assert
        ShouldUseGenericMessage(act);
    }

    [Test]
    public void Secure_Matches_Redacts_Validation_Values()
    {
        // Arrange
        var arg = "value";
        var argument = Guard.Argument(arg, secure: true);

        // Act
        Action act = () => argument.Matches("other");

        // Assert
        ShouldUseGenericMessage(act);
    }

    [Test]
    public void Secure_DoesNotMatch_Redacts_Validation_Values()
    {
        // Arrange
        var arg = "value";
        var argument = Guard.Argument(arg, secure: true);

        // Act
        Action act = () => argument.DoesNotMatch("value");

        // Assert
        ShouldUseGenericMessage(act);
    }

    [Test]
    public void Secure_MatchesTimeout_Redacts_Validation_Values()
    {
        // Arrange
        var arg = "value";
        var argument = Guard.Argument(arg, secure: true);

        // Act
        Action act = () => argument.MatchesTimeout("other", TimeSpan.FromSeconds(1));

        // Assert
        ShouldUseGenericMessage(act);
    }

    [Test]
    public void Secure_DoesNotMatchTimeout_Redacts_Validation_Values()
    {
        // Arrange
        var arg = "value";
        var argument = Guard.Argument(arg, secure: true);

        // Act
        Action act = () => argument.DoesNotMatchTimeout("value", TimeSpan.FromSeconds(1));

        // Assert
        ShouldUseGenericMessage(act);
    }

    [Test]
    public void Secure_EnumHasFlag_Redacts_Validation_Values()
    {
        // Arrange
        var arg = FileAccess.Read;
        var argument = Guard.Argument(arg, secure: true);

        // Act
        Action act = () => argument.EnumHasFlag(FileAccess.Write);

        // Assert
        ShouldUseGenericMessage(act);
    }

    [Test]
    public void Secure_EnumDoesNotHaveFlag_Redacts_Validation_Values()
    {
        // Arrange
        var arg = FileAccess.Read;
        var argument = Guard.Argument(arg, secure: true);

        // Act
        Action act = () => argument.EnumDoesNotHaveFlag(FileAccess.Read);

        // Assert
        ShouldUseGenericMessage(act);
    }

    [Test]
    public void Secure_CollectionContains_Redacts_Validation_Values()
    {
        // Arrange
        var arg = new[] { "value" };
        var argument = Guard.Argument(arg, secure: true);

        // Act
        Action act = () => argument.Contains("other");

        // Assert
        ShouldUseGenericMessage(act);
    }

    [Test]
    public void Secure_CollectionDoesNotContain_Redacts_Validation_Values()
    {
        // Arrange
        var arg = new[] { "value" };
        var argument = Guard.Argument(arg, secure: true);

        // Act
        Action act = () => argument.DoesNotContain("value");

        // Assert
        ShouldUseGenericMessage(act);
    }

    [Test]
    public void Secure_In_Redacts_Validation_Values()
    {
        // Arrange
        var arg = "value";
        var argument = Guard.Argument(arg, secure: true);

        // Act
        Action act = () => argument.In(new[] { "other" });

        // Assert
        ShouldUseGenericMessage(act);
    }

    [Test]
    public void Secure_NotIn_Redacts_Validation_Values()
    {
        // Arrange
        var arg = "value";
        var argument = Guard.Argument(arg, secure: true);

        // Act
        Action act = () => argument.NotIn(new[] { "value" });

        // Assert
        ShouldUseGenericMessage(act);
    }

    [Test]
    public void Secure_EmailHasHost_Redacts_Validation_Values()
    {
        // Arrange
        var arg = new MailAddress("user@example.com");
        var argument = Guard.Argument(arg, secure: true);

        // Act
        Action act = () => argument.EmailHasHost("other.example");

        // Assert
        ShouldUseGenericMessage(act);
    }

    [Test]
    public void Secure_EmailDoesNotHaveHost_Redacts_Validation_Values()
    {
        // Arrange
        var arg = new MailAddress("user@example.com");
        var argument = Guard.Argument(arg, secure: true);

        // Act
        Action act = () => argument.EmailDoesNotHaveHost("example.com");

        // Assert
        ShouldUseGenericMessage(act);
    }

    [Test]
    public void Secure_EmailHostIn_Redacts_Validation_Values()
    {
        // Arrange
        var arg = new MailAddress("user@example.com");
        var argument = Guard.Argument(arg, secure: true);

        // Act
        Action act = () => argument.EmailHostIn(["other.example"]);

        // Assert
        ShouldUseGenericMessage(act);
    }

    [Test]
    public void Secure_EmailHostNotIn_Redacts_Validation_Values()
    {
        // Arrange
        var arg = new MailAddress("user@example.com");
        var argument = Guard.Argument(arg, secure: true);

        // Act
        Action act = () => argument.EmailHostNotIn(["example.com"]);

        // Assert
        ShouldUseGenericMessage(act);
    }

    private static void ShouldUseGenericMessage(Action validate)
    {
        var exception = validate.ShouldThrow<ArgumentException>();

        exception.ParamName.ShouldBe("arg");
        exception.Message.ShouldBe("arg is invalid. (Parameter 'arg')");
    }
}
