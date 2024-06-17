namespace robot1
{
    public enum Intensity
    {
        Stun = 1,
        Kill = 2,
        Destroy = 3
    }

    public class GiantKillerRobot
    {
        public Intensity EyeLaserIntensity { get; set; }
        public List<Target> Targets { get; set; }
        public Target CurrentTarget { get; set; }
        public bool Active { get; set; }

        public GiantKillerRobot()
        {
            Targets = new List<Target>();
            Active = true;
        }

        public void Initialize()
        {
            Console.WriteLine("Robot initialized.");
        }

        public void FireLaserAt(Target target)
        {
            if (target.IsAlive)
            {
                Console.WriteLine($"Firing laser at {target.Type} with intensity {EyeLaserIntensity}.");
                target.IsAlive = false; // Ținta este omorâtă
            }
        }

        public void AcquireNextTarget()
        {
            foreach (var target in Targets)
            {
                if (target.IsAlive)
                {
                    CurrentTarget = target;
                    return;
                }
            }
            // Dacă nu există alte ținte, robotul se oprește
            Active = false;
        }
    }
}