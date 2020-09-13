using System;

namespace TicTacToeAI
{
    public class Square
    {
        private char content;
        public char Content
        {
            get { return content; }
            set
            {
                content = value;
                OnSquareContentChanged(new EventArgs());
            }
        }

        // Its position on the board
        public int BoardIndex { get; set; }

        public Square(char content, int boardIndex)
        {
            this.content = content;
            BoardIndex = boardIndex;
        }

        public bool IsEmpty => Content != 'X' && Content != 'O';

        public event EventHandler SquareContentChangedEvent;

        protected virtual void OnSquareContentChanged(EventArgs e)
        {
            SquareContentChangedEvent?.Invoke(this, e);
        }
    }
}
