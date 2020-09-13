namespace TicTacToeHardCodedLogic
{
    public class Player
    {
        string _playerName;
        int _playerNumber;
        int _wins;
        int _loses;

        public Player(string playerName, int playerNumber)
        {
            UpdatePlayerName(playerName);
            UpdatePlayerNumber(playerNumber);
            UpdatePlayerWins(0);
            UpdatePlayerLoses(0);
        }

        public string GetPlayerName()
        {
            return _playerName;
        }

        public void UpdatePlayerName(string playerName)
        {
            this._playerName = playerName;
        }

        public int GetPlayerNumber()
        {
            return _playerNumber;
        }

        public void UpdatePlayerNumber(int playerNumber)
        {
            this._playerNumber = playerNumber;
        }

        public int GetPlayerWins()
        {
            return _wins;
        }

        public void UpdatePlayerWins(int wins)
        {
            this._wins = wins;
        }

        public int GetPlayerLoses()
        {
            return _loses;
        }

        public void UpdatePlayerLoses(int loses)
        {
            this._loses = loses;
        }
    }
}
