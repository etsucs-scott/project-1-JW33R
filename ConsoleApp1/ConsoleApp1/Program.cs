namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    public interface IAnimal
    {
        public void Eat();
        public void Move();
        public void MakeSound();
    }
    public class Lion : IAnimal 
    {
        public void Eat() 
        {
            //some
        }
        public void Move() 
        { 
            //some
        }
        public void MakeSound() 
        {
            //some
        }
    }
    public class Penguin : IAnimal 
    {
        public void Eat()
        {
            //some
        }
        public void Move()
        {
            //some
        }
        public void MakeSound()
        {
            //some
        }
    }
    public class Eagle : IAnimal 
    {
        public void Eat()
        {
            //some
        }
        public void Move()
        {
            //some
        }
        public void MakeSound()
        {
            //some
        }
    }
    public class Zoo 
    { 
        public List<IAnimal> Animals { get; set; }
    }
}


