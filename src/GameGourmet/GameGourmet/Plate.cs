namespace GameGourmet
{
    public class Plate
    {
        public Plate(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }

        public override string ToString()
        {
            return Name;
        }
    }
}