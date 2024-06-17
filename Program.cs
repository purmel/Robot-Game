using System.Numerics;

namespace robot1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GiantKillerRobot robot = new GiantKillerRobot();
            robot.Initialize();

            Console.WriteLine("Select the Eye Laser Intensity:");
            Console.WriteLine("1. Stun");
            Console.WriteLine("2. Kill");
            Console.WriteLine("3. Destroy");
            int intensityChoice = int.Parse(Console.ReadLine());
            robot.EyeLaserIntensity = (Intensity)intensityChoice;

            bool addingTargets = true;
            int targetCnt = 0;
            while (addingTargets && targetCnt < 3)
            {
                Console.WriteLine("Add a target:");
                Console.WriteLine("1. Animals");
                Console.WriteLine("2. Humans");
                Console.WriteLine("3. Superheroes");
                int targetChoice = int.Parse(Console.ReadLine());
                robot.Targets.Add(new Target((TargetType)targetChoice));
                targetCnt++;
                if(targetCnt < 3) 
                {
                    Console.WriteLine("Do you want to add another target? (y/n)");
                    string addAnother = Console.ReadLine();
                    if (addAnother.ToLower() != "y")
                    {
                        addingTargets = false;
                    }
                }
            }

            Planet earth = new Planet();

            robot.AcquireNextTarget();

            while (robot.Active && earth.ContainsLife)
            {
                if (robot.CurrentTarget.IsAlive)
                {
                    robot.FireLaserAt(robot.CurrentTarget);
                }
                else
                {
                    robot.AcquireNextTarget();
                }

                earth.ContainsLife = robot.Targets.Exists(t => t.IsAlive);
            }

            Console.WriteLine("Robot operation completed.");
        }
    }
}
