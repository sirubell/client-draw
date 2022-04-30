namespace client_draw
{
    internal class Player
    {
        public Rect rect;
        public string name;
        public int heart;
        public bool isMe;

        public Player(Rect rect, string name, int heart, bool isMe)
        {
            this.rect = rect;
            this.name = name;
            this.heart = heart;
            this.isMe = isMe;
        }
    }
}
