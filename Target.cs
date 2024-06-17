namespace robot1
{
    public enum TargetType
    {
        Animals = 1,
        Humans = 2,
        Superheroes = 3
    }

    public class Target
    {
        public TargetType Type { get; set; }
        public bool IsAlive { get; set; }

        public Target(TargetType type)
        {
            Type = type;
            IsAlive = true;
        }
    }
}