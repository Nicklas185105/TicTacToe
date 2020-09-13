using System.Collections.Generic;
using TicTacToeAI.Interfaces;

namespace TicTacToeAI
{
    public class GameScorer : IGameScorer
    {
        public Line BestLineO { get; private set; }

        public Line BestLineX { get; private set; }

        public int BestScoreO { get; private set; }

        public int BestScoreX { get; private set; }

        private IEnumerable<Line> lines;
        private int[] ImpactScores = new int[9];

        public int GetBestImpactSquare()
        {
            int bestImpact = -1;
            int bestSquare = -1;
            UpdateImpactScores();
            for (int i = 0; i < ImpactScores.Length; i++)
            {
                if (ImpactScores[i] > bestImpact)
                {
                    bestImpact = ImpactScores[i];
                    bestSquare = i;
                }
            }

            return bestSquare;
        }

        public void Reset(IBoard board)
        {
            lines = board.Lines;
            BestScoreX = BestScoreO = -1;
            BestLineX = BestLineO = null;
            UpdateBestLineScores();
        }

        private void UpdateBestScoreXAndBestLineX(Line line)
        {
            if (line.XScore > BestScoreX)
            {
                BestScoreX = line.XScore;
                BestLineX = line;
            }
        }
        private void UpdateBestScoreOAndBestLineO(Line line)
        {
            if (line.OScore > BestScoreO)
            {
                BestScoreO = line.OScore;
                BestLineO = line;
            }
        }

        private void UpdateBestLineScores()
        {
            foreach (var line in lines)
            {
                UpdateBestScoreXAndBestLineX(line);
                UpdateBestScoreOAndBestLineO(line);
            }
        }
        private void ResetImpactScores()
        {
            for (int i = 0; i < ImpactScores.Length; i++)
            {
                ImpactScores[i] = -1;
            }
        }
        private void UpdateImpactScores()
        {
            ResetImpactScores();
            foreach (var line in lines)
            {
                if (!line.IsLineBlocked)
                {
                    UpdateImpactScoresForLine(line);
                }
            }
        }
        private void UpdateImpactScoresForLine(Line line)
        {
            for (int i = 0; i < 3; i++)
            {
                if (line.Squares[i].IsEmpty)
                {
                    ImpactScores[line.Squares[i].BoardIndex] += 1;
                }
            }
        }
    }
}
