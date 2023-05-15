namespace Exercise_4
{
    // Батьківський клас
    public class ParentClass
    {
        // Оголошення події
        public event Action<string> OnEventHappened;

        // Метод, який викликає подію
        protected virtual void RaiseEvent(string message)
        {
            OnEventHappened?.Invoke(message);
        }
    }
}
