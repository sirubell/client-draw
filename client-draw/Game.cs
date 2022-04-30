namespace client_draw
{
    internal class Game
    {
        public bool doneDrawing;
        public string myName ;
        public List<Player> players;
        public List<Platform> platforms;
        public int time;
        public bool gaming;
        public string winner;

        public Game()
        {
            doneDrawing = true;
            myName = String.Empty;
            players = new List<Player>();
            platforms = new List<Platform>();
            time = 0;
            gaming = false;
        }
    }
}
