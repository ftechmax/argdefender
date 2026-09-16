using System.Net.Mail;
using Shouldly;

namespace ArgDefender.Test;

public class EmailTests
{
    [Test]
    public void EmailHasHost_Pass()
    {
        // Arrange
        var arg = new MailAddress("user@example.com");

        // Act
        var act = () => Guard.Argument(arg).EmailHasHost("example.com");

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void EmailHasHost_Fail()
    {
        // Arrange
        var arg = new MailAddress("user@example.com");

        // Act
        Action act = () => Guard.Argument(arg).EmailHasHost("other.com");

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void EmailHasHost_Null_Pass()
    {
        // Arrange
        MailAddress? arg = null;

        // Act
        var act = () => Guard.Argument(arg).EmailHasHost("example.com");

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void EmailDoesNotHaveHost_Pass()
    {
        // Arrange
        var arg = new MailAddress("user@example.com");

        // Act
        var act = () => Guard.Argument(arg).EmailDoesNotHaveHost("other.com");

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void EmailDoesNotHaveHost_Fail()
    {
        // Arrange
        var arg = new MailAddress("user@example.com");

        // Act
        Action act = () => Guard.Argument(arg).EmailDoesNotHaveHost("example.com");

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void EmailHostIn_Pass()
    {
        // Arrange
        var arg = new MailAddress("user@example.com");
        var hosts = new[] { "other.com", "example.com" };

        // Act
        var act = () => Guard.Argument(arg).EmailHostIn(hosts);

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void EmailHostIn_Fail()
    {
        // Arrange
        var arg = new MailAddress("user@example.com");
        var hosts = new[] { "other.com", "another.com" };

        // Act
        Action act = () => Guard.Argument(arg).EmailHostIn(hosts);

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void EmailHostNotIn_Pass()
    {
        // Arrange
        var arg = new MailAddress("user@example.com");
        var hosts = new[] { "other.com", "another.com" };

        // Act
        var act = () => Guard.Argument(arg).EmailHostNotIn(hosts);

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void EmailHostNotIn_Fail()
    {
        // Arrange
        var arg = new MailAddress("user@example.com");
        var hosts = new[] { "example.com", "another.com" };

        // Act
        Action act = () => Guard.Argument(arg).EmailHostNotIn(hosts);

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void EmailHasDisplayName_Pass()
    {
        // Arrange
        var arg = new MailAddress("user@example.com", "User");

        // Act
        var act = () => Guard.Argument(arg).EmailHasDisplayName();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void EmailHasDisplayName_Fail()
    {
        // Arrange
        var arg = new MailAddress("user@example.com");

        // Act
        Action act = () => Guard.Argument(arg).EmailHasDisplayName();

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void EmailDoesNotHaveDisplayName_Pass()
    {
        // Arrange
        var arg = new MailAddress("user@example.com");

        // Act
        var act = () => Guard.Argument(arg).EmailDoesNotHaveDisplayName();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void EmailDoesNotHaveDisplayName_Fail()
    {
        // Arrange
        var arg = new MailAddress("user@example.com", "User");

        // Act
        Action act = () => Guard.Argument(arg).EmailDoesNotHaveDisplayName();

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void EmailHostIn_Pass_WhenNull()
    {
        // Arrange
        MailAddress? arg = null;

        var hosts = new[] { "example.com" };

        // Act
        var act = () => Guard.Argument(arg).EmailHostIn(hosts);

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void EmailHostNotIn_Pass_WhenNull()
    {
        // Arrange
        MailAddress? arg = null;

        var hosts = new[] { "example.com" };

        // Act
        var act = () => Guard.Argument(arg).EmailHostNotIn(hosts);

        // Assert
        act.ShouldNotThrow();
    }
}





