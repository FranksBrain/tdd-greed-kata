using System.Collections.Generic;
using System.Linq;

namespace tdd_greed_kata_part_02
{
    public class Game
    {
        private Dictionary<int, int> _dieCounts = new Dictionary<int, int>();

        private int ScoreSingleDie()
        {
            var dieValue = 0;
            dieValue += _dieCounts[1] * 100;
            dieValue += _dieCounts[5] * 50;
            return dieValue;
        }

        private int ScoreTripleOnes()
        {
            if (_dieCounts[1] >= 3)
            {
                _dieCounts[1] -= 3;
                return 1000;
            }
            return 0;
        }

        private int ScoreTripleOthers()
        {
            for (int i = 2; i <= 6; i++)
            {
                if (_dieCounts[i] >= 3)
                {
                    _dieCounts[i] -= 3;
                    return i * 100;
                }
            }
            return 0;
        }

        private int ScoreMoreThanThreeOfAKind(int multiplier = 2, int reductionCounter = 1, int dieCountValue = 4)
        {
            int score = 0;
            if (_dieCounts[1] == dieCountValue)
            {
                score += ScoreTripleOnes();
                _dieCounts[1] -= reductionCounter;
                return score * multiplier;
            }

            for (int i = 2; i <= 6; i++)
            {
                if (_dieCounts[i] == dieCountValue)
                {
                    score = ScoreTripleOthers();
                    _dieCounts[i] -= reductionCounter;
                    return score * multiplier;
                }
            }

            if (dieCountValue < 6)
            {
                score = ScoreMoreThanThreeOfAKind(multiplier * 2, ++reductionCounter, ++dieCountValue);
            }

            return score;
        }

        private int ScoreTriplePairs()
        {
            int numberOfPairs = 0;
            for (int i = 1; i <= 6; i++)
            {
                if (_dieCounts[i] == 2)
                {
                    numberOfPairs++;
                    _dieCounts[i] -= 2;
                }
            }
            if (numberOfPairs == 3)
            {
                return 1800;
            }

            return 0;
        }

        private int ScoreStraight()
        {
            if (_dieCounts.All(x => x.Value == 1))
            {
                foreach (var dieValue in _dieCounts.Keys.ToList())
                {
                    _dieCounts[dieValue] = 0;
                }
                return 1200;
            }
            return 0;
        }

        private void PopulateDieCounts(int[] dieValues)
        {
            for (int i = 1; i <= 6; i++)
            {
                _dieCounts.Add(i, dieValues.Count(d => d == i));
            }
        }

        public int CalculateScore(params int[] dieValues)
        {
            if (dieValues.Length > 6 || dieValues.Length < 1)
                throw new System.Exception("You may only throw between 1 and 6 dice.");
            var score = 0;
            PopulateDieCounts(dieValues);
            score += ScoreMoreThanThreeOfAKind();
            score += ScoreTriplePairs();
            score += ScoreStraight();
            score += ScoreTripleOnes();
            score += ScoreTripleOthers();
            score += ScoreSingleDie();
            return score;
        }
    }
}