namespace Exercise_2
{
    internal class Product : Component
    {
        private string _name;
        private int _height;
        private int _width;
        private int _length;

        public Product(string name, int height, int width, int length)
        {
            _name = name;
            _height = height;
            _width = width;
            _length = length;
        }
        public string Name { get { return _name; } }

        public override int GetHeight()
        {
            return _height;
        }

        public override int GetLength()
        {
            return _length;
        }

        public override int GetWidth()
        {
            return _width;
        }
    }
}
