namespace client_draw
{
    enum PlatformType
    {
        Normal,
        Spike,
    }
    internal class Platform
    {
        public Rect rect;
        public PlatformType type;
        public string name;

        public Platform(Rect rect, int type, string name)
        {
            this.rect = rect;
            this.name = name;
            if (type == 1) this.type = PlatformType.Normal;
            else this.type = PlatformType.Spike;
        }
    }
}
