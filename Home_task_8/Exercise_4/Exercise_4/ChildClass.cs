namespace Exercise_4
{
    // Дочірній клас
    public class ChildClass : ParentClass
    {
        // Метод, який генерує подію
        public void GenerateEvent(string message)
        {
            RaiseEvent(message);
        }
    }
}
