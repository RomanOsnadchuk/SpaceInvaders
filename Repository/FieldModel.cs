namespace Repository
{
    public class FieldModel
    {
        public FieldModel()
        {
        }

        public FieldModel(int width, int height, char backGround)
        {
            Height = height;
            Width = width;
            BackGround = backGround;
        }

        public int Height { get; set; }
        public int Width { get; set; }
        public char BackGround { get; set; }
    }
}