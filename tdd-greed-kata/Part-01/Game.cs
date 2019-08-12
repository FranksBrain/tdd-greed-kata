using System.Collections.Generic;
using System.Linq;

namespace tdd_greed_kata_part_01
{
    public class Game
    {
        private Dictionary<int, int> _dieCounts = new Dictionary<int, int>();

        public int ScoreSingleDie()
        {
            var dieValue = 0;
            dieValue += _dieCounts[1] * 100;
            dieValue += _dieCounts[5] * 50;
            return dieValue;
        }

        public int ScoreTripleOnes()
        {
            if (_dieCounts[1] >= 3)
            {
                _dieCounts[1] -= 3;
                return 1000;
            }
            return 0;
        }

        public int ScoreTripleOthers()
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

        private void PopulateDieCounts(int[] dieValues)
        {
            for (int i = 1; i <= 6; i++)
            {
                _dieCounts.Add(i, dieValues.Count(d => d == i));
            }
        }

        public int CalculateScore(params int[] dieValues)
        {
            var score = 0;
            PopulateDieCounts(dieValues);
            score += ScoreTripleOnes();
            score += ScoreTripleOthers();
            score += ScoreSingleDie();
            return score;
        }
    }
}