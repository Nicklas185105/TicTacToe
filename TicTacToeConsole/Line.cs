namespace TicTacToeAI
{
    public class Line
    {
        public Square[] Squares = new Square[3];
        public int Ocount { get; private set; }
        public int Xcount { get; private set; }
        public int XScore { get; set; }
        public int OScore { get; set; }
        public bool IsLineOBlocked => Xcount > 0;
        public bool IsLineXBlocked => Ocount > 0;
        public bool IsLineBlocked => IsLineOBlocked && IsLineXBlocked;

        public Line(Square c0, Square c1, Square c2)
        {
            Squares[0] = c0;
            Squares[1] = c1;
            Squares[2] = c2;
            foreach (var square in Squares)
            {
                square.SquareContentChangedEvent += SquareChangedEventHandler;
            }
            Update();
        }

        private void SquareChangedEventHandler(object sender, System.EventArgs e)
        {
            Update();
        }

        public void Update()
        {
            Xcount = 0;
            Ocount = 0;
            foreach (var square in Squares)
            {
                if (square.Content == 'X') Xcount++;
                if (square.Content == 'O') Ocount++;
            }
            XScore = IsLineBlocked ? 0 : Xcount;
            OScore = IsLineBlocked ? 0 : Ocount;
        }
    }
}
