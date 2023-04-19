namespace Exercise_2
{
    internal abstract class Component
    {
        public Component() { }

        public abstract int GetLength();
        public abstract int GetWidth();
        public abstract int GetHeight();

        public virtual void Add(Component component)
        {
            throw new NotImplementedException("The leaf can't have children.");
        }

        public virtual void Remove(Component component)
        {
            throw new NotImplementedException("The leaf can't have children.");
        }

    }
}
