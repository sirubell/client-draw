
namespace client_draw
{
    public class Dir
    {
        public int code;

        public Dir()
        {
            code = 0;
        }

        override public string ToString()
        {
            bool left = ((code & 0x01) != 0);
            bool right = ((code & 0x10) != 0);

            if (left ^ right)
            {
                if (left) return "2";
                if (right) return "3";
                return "?";
            }
            else
            {
                return "1";
            }
        }
    }
}
