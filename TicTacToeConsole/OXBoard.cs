using System.Collections.Generic;
using System.Linq;
using TicTacToeAI.Interfaces;

namespace TicTacToeAI
{
    public class OXBoard : IBoard
    {
        public Square this[int index]
        {
            get { return Squares[index]; }
            set { Squares[index] = value; }
        }
        private Square[] Squares;
        public List<Line> Lines { get; protected set; }
        public int[,] CornerLines { get; protected set; }

        public OXBoard()
        {
            Squares = new Square[9]
            {
                new Square('1',0),
                new Square('2',1),
                new Square('3',2),
                new Square('4',3),
                new Square('5',4),
                new Square('6',5),
                new Square('7',6),
                new Square('8',7),
                new Square('9',8),
            };

            Lines = new List<Line>
            {
                { new Line(Squares[0], Squares[1], Squares[2]) },//0
                { new Line(Squares[3], Squares[4], Squares[5]) },//1
                { new Line(Squares[6], Squares[7], Squares[8]) },//2
                { new Line(Squares[0], Squares[3], Squares[6]) },//3
                { new Line(Squares[1], Squares[4], Squares[7]) },//4
                { new Line(Squares[2], Squares[5], Squares[8]) },//5
                { new Line(Squares[0], Squares[4], Squares[8]) },//6
                { new Line(Squares[6], Squares[4], Squares[2]) } //7
            };

            CornerLines = new int[,]
            {
                { 0, 3, 0 }, // Line 0 and line 3 share corner square 0
                { 0, 5, 2 },
                { 2, 3, 6 },
                { 2, 5, 8 }
            };
        }

        #region Debugging
        public IBoard Clone()
        {
            OXBoard newBoard = new OXBoard();
            for (int i = 0; i < 9; i++)
            {
                newBoard[i].Content = Squares[i].Content;
            }
            return newBoard;
        }

        public bool Compare(IBoard test)
        {
            for (int i = 0; i < Squares.Length; i++)
            {
                if (Squares[i].Content != test[i].Content)
                    return false;
            }
            return true;
        }

        public void Initialize(char[] squareContents)
        {
            for (int i = 0; i < 9; i++)
            {
                Squares[i].Content = squareContents[i];
                Squares[i].BoardIndex = i;
            }
        }
        #endregion

        public int GetOccupiedSquaresCount()
        {
            return Squares.Count(s => !s.IsEmpty);
        }

        public IEnumerable<int> GetUnOccupiedSquaresIndexes()
        {
            return Squares.Where(s => s.IsEmpty).Select(s => s.BoardIndex);
        }

        public void Reset()
        {
            for (int i = 0; i < Squares.Length; i++)
            {
                Squares[i].Content = (i + 1).ToString()[0];
            }
        }
    }
}
