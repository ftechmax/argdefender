using AutoFixture;
using FluentAssertions;

namespace ArgDefender.Tests
{
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
            act.Should().NotThrow<ArgumentException>();
        }

        [Test]
        public void Empty_Fail()
        {
            // Arrange
            var arg = _fixture.Create<string>();

            // Act
            var act = () => Guard.Argument(arg).Empty();

            // Assert
            act.Should().Throw<ArgumentException>().WithMessage($"{nameof(arg)}*");
        }

        [Test]
        public void NotEmpty_Pass()
        {
            // Arrange
            var arg = _fixture.Create<string>();

            // Act
            var act = () => Guard.Argument(arg).NotEmpty();

            // Assert
            act.Should().NotThrow<ArgumentException>();
        }

        [Test]
        public void NotEmpty_Fail()
        {
            // Arrange
            var arg = string.Empty;

            // Act
            var act = () => Guard.Argument(arg).NotEmpty();

            // Assert
            act.Should().Throw<ArgumentException>().WithMessage($"{nameof(arg)}*");
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
            act.Should().NotThrow<ArgumentException>();
        }

        [Test]
        public void WhiteSpace_Fail()
        {
            // Arrange
            var arg = _fixture.Create<string>();

            // Act
            var act = () => Guard.Argument(arg).WhiteSpace();

            // Assert
            act.Should().Throw<ArgumentException>().WithMessage($"{nameof(arg)}*");
        }

        [Test]
        public void NotWhiteSpace_Pass()
        {
            // Arrange
            var arg = _fixture.Create<string>();

            // Act
            var act = () => Guard.Argument(arg).NotWhiteSpace();

            // Assert
            act.Should().NotThrow<ArgumentException>();
        }

        [Test]
        public void NotWhiteSpace_Fail()
        {
            // Arrange
            var arg = string.Empty;

            // Act
            var act = () => Guard.Argument(arg).NotWhiteSpace();

            // Assert
            act.Should().Throw<ArgumentException>().WithMessage($"{nameof(arg)}*");
        }

        [Test]
        public void Length_Pass()
        {
            // Arrange
            var arg = _fixture.Create<string>();

            // Act
            var act = () => Guard.Argument(arg).Length(arg.Length);

            // Assert
            act.Should().NotThrow<ArgumentException>();
        }

        [Test]
        [TestCase(1)]
        [TestCase(-1)]
        public void Length_Fail(int testCase)
        {
            // Arrange
            var arg = _fixture.Create<string>();

            // Act
            var act = () => Guard.Argument(arg).Length(arg.Length + testCase);

            // Assert
            act.Should().Throw<ArgumentException>().WithMessage($"{nameof(arg)}*");
        }
    }
}
