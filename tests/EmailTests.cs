using System.Net.Mail;
using Shouldly;

namespace ArgDefender.Test;

public class EmailTests
{
    [Test]
    public void EmailHasHost_Pass()
    {
        var arg = new MailAddress("user@example.com");

        var act = () => Guard.Argument(arg).EmailHasHost("example.com");

        act.ShouldNotThrow();
    }

    [Test]
    public void EmailHasHost_Fail()
    {
        var arg = new MailAddress("user@example.com");

        Action act = () => Guard.Argument(arg).EmailHasHost("other.com");

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void EmailHasHost_Null_Pass()
    {
        MailAddress? arg = null;

        var act = () => Guard.Argument(arg).EmailHasHost("example.com");

        act.ShouldNotThrow();
    }

    [Test]
    public void EmailDoesNotHaveHost_Pass()
    {
        var arg = new MailAddress("user@example.com");

        var act = () => Guard.Argument(arg).EmailDoesNotHaveHost("other.com");

        act.ShouldNotThrow();
    }

    [Test]
    public void EmailDoesNotHaveHost_Fail()
    {
        var arg = new MailAddress("user@example.com");

        Action act = () => Guard.Argument(arg).EmailDoesNotHaveHost("example.com");

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void EmailHostIn_Pass()
    {
        var arg = new MailAddress("user@example.com");
        var hosts = new[] { "other.com", "example.com" };

        var act = () => Guard.Argument(arg).EmailHostIn(hosts);

        act.ShouldNotThrow();
    }

    [Test]
    public void EmailHostIn_Fail()
    {
        var arg = new MailAddress("user@example.com");
        var hosts = new[] { "other.com", "another.com" };

        Action act = () => Guard.Argument(arg).EmailHostIn(hosts);

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void EmailHostNotIn_Pass()
    {
        var arg = new MailAddress("user@example.com");
        var hosts = new[] { "other.com", "another.com" };

        var act = () => Guard.Argument(arg).EmailHostNotIn(hosts);

        act.ShouldNotThrow();
    }

    [Test]
    public void EmailHostNotIn_Fail()
    {
        var arg = new MailAddress("user@example.com");
        var hosts = new[] { "example.com", "another.com" };

        Action act = () => Guard.Argument(arg).EmailHostNotIn(hosts);

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void EmailHasDisplayName_Pass()
    {
        var arg = new MailAddress("user@example.com", "User");

        var act = () => Guard.Argument(arg).EmailHasDisplayName();

        act.ShouldNotThrow();
    }

    [Test]
    public void EmailHasDisplayName_Fail()
    {
        var arg = new MailAddress("user@example.com");

        Action act = () => Guard.Argument(arg).EmailHasDisplayName();

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void EmailDoesNotHaveDisplayName_Pass()
    {
        var arg = new MailAddress("user@example.com");

        var act = () => Guard.Argument(arg).EmailDoesNotHaveDisplayName();

        act.ShouldNotThrow();
    }

    [Test]
    public void EmailDoesNotHaveDisplayName_Fail()
    {
        var arg = new MailAddress("user@example.com", "User");

        Action act = () => Guard.Argument(arg).EmailDoesNotHaveDisplayName();

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }
}





