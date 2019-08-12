using Xunit;

namespace tdd_greed_kata_part_02
{
    public class CalculateScore
    {
        Game _game = new Game();

        [Fact]
        public void Returns100WhenSingleOneIsRolled()
        {
            int[] dieValues = { 1 };
            Assert.Equal(100, _game.CalculateScore(dieValues));
        }

        [Fact]
        public void Returns50WhenSingleFiveIsRolled()
        {
            int[] dieValues = { 5 };
            Assert.Equal(50, _game.CalculateScore(dieValues));
        }

        [Fact]
        public void Returns1000WhenTripleOnesRolled()
        {
            int[] dieValues = { 1, 1, 1 };
            Assert.Equal(1000, _game.CalculateScore(dieValues));
        }

        [Fact]
        public void Returns2000WhenOneOneOneOneRolled()
        {
            int[] dieValues = { 1, 1, 1, 1 };
            Assert.Equal(2000, _game.CalculateScore(dieValues));
        }

        [Theory]
        [InlineData(2, 200)]
        [InlineData(3, 300)]
        [InlineData(4, 400)]
        [InlineData(5, 500)]
        [InlineData(6, 600)]
        public void ReturnsExpectedValueWhenTripleIsRolled(int dieValue, int expectedScore)
        {
            Assert.Equal(expectedScore, _game.CalculateScore(dieValue, dieValue, dieValue));
        }

        [Fact]
        public void Returns2050GivenOneOneOneFiveOne()
        {
            int[] dieValues = { 1, 1, 1, 5, 1 };
            Assert.Equal(2050, _game.CalculateScore(dieValues));
        }

        [Fact]
        public void Returns0GivenGarbage()
        {
            int[] dieValues = { 2, 3, 4, 6, 2 };
            Assert.Equal(0, _game.CalculateScore(dieValues));
        }

        [Fact]
        public void Returns350GivenThreeFourFiveThreeThree()
        {
            int[] dieValues = { 3, 4, 5, 3, 3 };
            Assert.Equal(350, _game.CalculateScore(dieValues));
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false, 1)]
        [InlineData(false, 1, 2)]
        [InlineData(false, 1, 2, 3)]
        [InlineData(false, 1, 2, 3, 4)]
        [InlineData(false, 1, 2, 3, 4, 5)]
        [InlineData(false, 1, 2, 3, 4, 5, 6)]
        [InlineData(true, 1, 2, 3, 4, 5, 6, 6)]
        public void ThrowsExceptionIfLessThanOneOrMoreThanSixDiceRolled(bool exceptionThrown, params int[] diceRolled)
        {
            var exception = Record.Exception(() => _game.CalculateScore(diceRolled));
            Assert.Equal(exceptionThrown, exception != null);
        }

        [Theory]
        [InlineData(1, 2000)]
        [InlineData(2, 400)]
        [InlineData(3, 600)]
        [InlineData(4, 800)]
        [InlineData(5, 1000)]
        [InlineData(6, 1200)]
        public void ReturnsExpectedValueWhenFourOfAKindIsRolled(int dieValue, int expectedScore)
        {
            Assert.Equal(expectedScore, _game.CalculateScore(dieValue, dieValue, dieValue, dieValue));
        }

        [Theory]
        [InlineData(1, 4000)]
        [InlineData(2, 800)]
        [InlineData(3, 1200)]
        [InlineData(4, 1600)]
        [InlineData(5, 2000)]
        [InlineData(6, 2400)]
        public void ReturnsExpectedValueWhenFiveOfAKindIsRolled(int dieValue, int expectedScore)
        {
            Assert.Equal(expectedScore, _game.CalculateScore(dieValue, dieValue, dieValue, dieValue, dieValue));
        }

        [Theory]
        [InlineData(1, 8000)]
        [InlineData(2, 1600)]
        [InlineData(3, 2400)]
        [InlineData(4, 3200)]
        [InlineData(5, 4000)]
        [InlineData(6, 4800)]
        public void ReturnsExpectedValueWhenSixOfAKindIsRolled(int dieValue, int expectedScore)
        {
            Assert.Equal(expectedScore, _game.CalculateScore(dieValue, dieValue, dieValue, dieValue, dieValue, dieValue));
        }

        [Theory]
        [InlineData(1800, 1, 1, 2, 2, 3, 3)]
        [InlineData(1800, 2, 2, 3, 3, 4, 4)]
        [InlineData(1800, 1, 1, 3, 3, 5, 5)]
        [InlineData(1800, 2, 2, 4, 4, 6, 6)]
        [InlineData(1800, 2, 2, 5, 5, 6, 6)]
        public void Returns1800WhenTriplePairsRolled(int expectedValue, params int[] dieValues)
        {
            Assert.Equal(expectedValue, _game.CalculateScore(dieValues));
        }

        [Fact]
        public void Returns1200WhenStraightIsRolled()
        {
            int[] dieValues = { 1, 2, 3, 4, 5, 6 };
            Assert.Equal(1200, _game.CalculateScore(dieValues));
        }
    }
}