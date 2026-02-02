using System;

namespace hazard
{
    // Custom exception class
    public class RobotSafetyException : Exception
    {
        public RobotSafetyException(string message) : base(message)
        {
        }
    }

    // Auditor class
    public class RobotHazardAuditor
    {
        public double CalculateHazardRisk(double armPrecision, int workerDensity, string machineryState)
        {
            if (armPrecision < 0.0 || armPrecision > 1.0)
                throw new RobotSafetyException("Error: Arm precision must be between 0.0 and 1.0");

            if (workerDensity < 1 || workerDensity > 20)
                throw new RobotSafetyException("Error: Worker density must be between 1 and 20");

            double machineRiskFactor;

            if (machineryState == "Worn")
                machineRiskFactor = 1.3;
            else if (machineryState == "Faulty")
                machineRiskFactor = 2.0;
            else if (machineryState == "Critical")
                machineRiskFactor = 3.0;
            else
                throw new RobotSafetyException("Error: Unsupported machinery state");

            return ((1.0 - armPrecision) * 15.0) + (workerDensity * machineRiskFactor);
        }
    }

    // Program class (entry point)
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter arm precision (0.0 - 1.0):");
                double armPrecision = double.Parse(Console.ReadLine());

                Console.WriteLine("Enter worker density (1 - 20):");
                int workerDensity = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter machinery state (Worn / Faulty / Critical):");
                string machineryState = Console.ReadLine();

                RobotHazardAuditor auditor = new RobotHazardAuditor();
                double result = auditor.CalculateHazardRisk(
                    armPrecision,
                    workerDensity,
                    machineryState
                );

                Console.WriteLine($"Robot Hazard Risk Score: {result}");
            }
            catch (RobotSafetyException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Invalid input: " + ex.Message);
            }
        }
    }
}