using Shouldly;

namespace ArgDefender.Test;

public class UriTests
{
    [Test]
    public void UriAbsolute_Pass()
    {
        // Arrange
        var arg = new Uri("https://example.com");

        // Act
        var act = () => Guard.Argument(arg).UriAbsolute();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void UriAbsolute_Fail()
    {
        // Arrange
        var arg = new Uri("/relative", UriKind.Relative);

        // Act
        Action act = () => Guard.Argument(arg).UriAbsolute();

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void UriRelative_Pass()
    {
        // Arrange
        var arg = new Uri("/relative", UriKind.Relative);

        // Act
        var act = () => Guard.Argument(arg).UriRelative();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void UriRelative_Fail()
    {
        // Arrange
        var arg = new Uri("https://example.com");

        // Act
        Action act = () => Guard.Argument(arg).UriRelative();

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void UriScheme_Pass()
    {
        // Arrange
        var arg = new Uri("myapp://example");

        // Act
        var act = () => Guard.Argument(arg).UriScheme("myapp");

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void UriScheme_Fail_Different()
    {
        // Arrange
        var arg = new Uri("https://example.com");

        // Act
        Action act = () => Guard.Argument(arg).UriScheme("http");

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void UriScheme_Fail_Relative()
    {
        // Arrange
        var arg = new Uri("/relative", UriKind.Relative);

        // Act
        Action act = () => Guard.Argument(arg).UriScheme("http");

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void UriNotScheme_Pass()
    {
        // Arrange
        var arg = new Uri("https://example.com");

        // Act
        var act = () => Guard.Argument(arg).UriNotScheme("ftp");

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void UriNotScheme_Fail()
    {
        // Arrange
        var arg = new Uri("https://example.com");

        // Act
        Action act = () => Guard.Argument(arg).UriNotScheme("https");

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void UriHttp_Pass()
    {
        // Arrange
        var arg = new Uri("http://example.com");

        // Act
        var act = () => Guard.Argument(arg).UriHttp();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void UriHttp_Fail()
    {
        // Arrange
        var arg = new Uri("https://example.com");

        // Act
        Action act = () => Guard.Argument(arg).UriHttp();

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void UriHttps_Pass()
    {
        // Arrange
        var arg = new Uri("https://example.com");

        // Act
        var act = () => Guard.Argument(arg).UriHttps();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void UriHttps_Fail()
    {
        // Arrange
        var arg = new Uri("http://example.com");

        // Act
        Action act = () => Guard.Argument(arg).UriHttps();

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void UriHttpOrHttps_Pass()
    {
        // Arrange
        var arg = new Uri("http://example.com");

        // Act
        var act = () => Guard.Argument(arg).UriHttpOrHttps();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void UriHttpOrHttps_Fail()
    {
        // Arrange
        var arg = new Uri("ftp://example.com");

        // Act
        Action act = () => Guard.Argument(arg).UriHttpOrHttps();

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void UriHasHost_Pass()
    {
        // Arrange
        var arg = new Uri("https://example.com");

        // Act
        var act = () => Guard.Argument(arg).UriHasHost();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void UriHasHost_Fail()
    {
        // Arrange
        var arg = new Uri("file:///C:/path");

        // Act
        Action act = () => Guard.Argument(arg).UriHasHost();

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void UriPortInRange_Pass()
    {
        // Arrange
        var arg = new Uri("https://example.com:8080");

        // Act
        var act = () => Guard.Argument(arg).UriPortInRange(8000, 9000);

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void UriPortInRange_Fail()
    {
        // Arrange
        var arg = new Uri("https://example.com:8080");

        // Act
        Action act = () => Guard.Argument(arg).UriPortInRange(9000, 9999);

        // Assert
        var exception = act.ShouldThrow<ArgumentException>();
        exception.Message.ShouldContain(nameof(arg));
    }

    [Test]
    public void UriHasHost_Pass_WhenNull()
    {
        // Arrange
        Uri? arg = null;

        // Act
        var act = () => Guard.Argument(arg).UriHasHost();

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void UriPortInRange_Pass_WhenNull()
    {
        // Arrange
        Uri? arg = null;

        // Act
        var act = () => Guard.Argument(arg).UriPortInRange(1, 65535);

        // Assert
        act.ShouldNotThrow();
    }

    [Test]
    public void UriHttpOrHttps_Pass_WhenNull()
    {
        // Arrange
        Uri? arg = null;

        // Act
        var act = () => Guard.Argument(arg).UriHttpOrHttps();

        // Assert
        act.ShouldNotThrow();
    }
}





