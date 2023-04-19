namespace Exercise_2
{
    internal class Department : Component
    {
        protected List<Component> _children = new List<Component>();
        public string Name { get; set; }
        public Department(string name = "No name")
        {
            Name = name;
        }
        public override void Add(Component component)
        {
            _children.Add(component);
        }

        public override void Remove(Component component)
        {
            _children.Remove(component);
        }

        public List<Component> GetChildren()
        {
            return _children;
        }

        public override int GetLength()
        {
            int maxLength = 0;
            foreach (Component component in _children)
            {
                if (component.GetLength() > maxLength)
                {
                    maxLength = component.GetLength();
                }
            }

            return maxLength;
        }

        public override int GetWidth()
        {
            int maxWidth = 0;
            foreach (Component component in _children)
            {
                if (component.GetWidth() > maxWidth)
                {
                    maxWidth = component.GetWidth();
                }
            }
            return maxWidth;
        }

        public override int GetHeight()
        {
            int sumLength = 0;
            foreach (Component component in _children)
            {
                sumLength += component.GetHeight();
            }

            return sumLength;
        }
    }
}
