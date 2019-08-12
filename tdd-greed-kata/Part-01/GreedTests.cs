using Xunit;

namespace tdd_greed_kata_part_01
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
        public void Returns1100WhenOneOneOneOneRolled()
        {
            int[] dieValues = { 1, 1, 1, 1 };
            Assert.Equal(1100, _game.CalculateScore(dieValues));
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
        public void Returns1150GivenOneOneOneFiveOne()
        {
            int[] dieValues = { 1, 1, 1, 5, 1 };
            Assert.Equal(1150, _game.CalculateScore(dieValues));
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

        [Fact]
        public void Returns600GivenAllFives()
        {
            int[] dieValues = { 5, 5, 5, 5, 5 };
            Assert.Equal(600, _game.CalculateScore(dieValues));
        }
    }
}