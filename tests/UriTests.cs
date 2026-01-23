using Shouldly;

namespace ArgDefender.Test;

public class UriTests
{
    [Test]
    public void UriAbsolute_Pass()
    {
        var arg = new Uri("https://example.com");

        var act = () => Guard.Argument(arg).UriAbsolute();

        act.ShouldNotThrow();
    }

    [Test]
    public void UriAbsolute_Fail()
    {
        var arg = new Uri("/relative", UriKind.Relative);

        Action act = () => Guard.Argument(arg).UriAbsolute();

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void UriRelative_Pass()
    {
        var arg = new Uri("/relative", UriKind.Relative);

        var act = () => Guard.Argument(arg).UriRelative();

        act.ShouldNotThrow();
    }

    [Test]
    public void UriRelative_Fail()
    {
        var arg = new Uri("https://example.com");

        Action act = () => Guard.Argument(arg).UriRelative();

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void UriScheme_Pass()
    {
        var arg = new Uri("myapp://example");

        var act = () => Guard.Argument(arg).UriScheme("myapp");

        act.ShouldNotThrow();
    }

    [Test]
    public void UriScheme_Fail_Different()
    {
        var arg = new Uri("https://example.com");

        Action act = () => Guard.Argument(arg).UriScheme("http");

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void UriScheme_Fail_Relative()
    {
        var arg = new Uri("/relative", UriKind.Relative);

        Action act = () => Guard.Argument(arg).UriScheme("http");

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void UriNotScheme_Pass()
    {
        var arg = new Uri("https://example.com");

        var act = () => Guard.Argument(arg).UriNotScheme("ftp");

        act.ShouldNotThrow();
    }

    [Test]
    public void UriNotScheme_Fail()
    {
        var arg = new Uri("https://example.com");

        Action act = () => Guard.Argument(arg).UriNotScheme("https");

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void UriHttp_Pass()
    {
        var arg = new Uri("http://example.com");

        var act = () => Guard.Argument(arg).UriHttp();

        act.ShouldNotThrow();
    }

    [Test]
    public void UriHttp_Fail()
    {
        var arg = new Uri("https://example.com");

        Action act = () => Guard.Argument(arg).UriHttp();

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void UriHttps_Pass()
    {
        var arg = new Uri("https://example.com");

        var act = () => Guard.Argument(arg).UriHttps();

        act.ShouldNotThrow();
    }

    [Test]
    public void UriHttps_Fail()
    {
        var arg = new Uri("http://example.com");

        Action act = () => Guard.Argument(arg).UriHttps();

        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }
}





