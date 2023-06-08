using System;
using System.Collections.Generic;

namespace Heist
{
    class Program
    {
        public static void Main (string[] args)
        {
            Console.WriteLine("Plan your heist!");
            Console.WriteLine("--------------------");

            Bank bank = new Bank();
            bank.GenerateBankValues();

            Console.WriteLine("Recon Report:");
            Console.WriteLine($"Most Secure: {GetSystemName(bank.GetMostSecureSystem())}");
            Console.WriteLine($"Least Secure: {GetSystemName(bank.GetLeastSecureSystem())}");

            Console.WriteLine("--------------------");


            List<IRobber> rolodex = new List<IRobber>();
            rolodex.Add(new Hacker()
            {
                Name = "Jesse Hackerman",
                SkillLevel = 50,
                PercentageCut = 10
            });

            rolodex.Add(new Muscle()
            {
                Name = "Jorgen von Strangle",
                SkillLevel = 60,
                PercentageCut = 10
            });

            rolodex.Add(new LockSpecialist()
            {
                Name = "Jack",
                SkillLevel = 50,
                PercentageCut = 10
            });

            rolodex.Add(new Hacker()
            {
                Name = "Anonymouse",
                SkillLevel = 50,
                PercentageCut = 10
            });

            rolodex.Add(new Muscle()
            {
                Name = "Ahnold",
                SkillLevel = 60,
                PercentageCut = 10
            });

            while (true)
            {
                Console.WriteLine($"There are currently {rolodex.Count} operatives in the rolodex.");
                Console.WriteLine($"Enter a new operative's name (or leave it blank to finish):");
                string newOperativeName = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(newOperativeName))
                {
                    break; // Exits the loop if the name is blank
                }

                Console.WriteLine($"Choose from the following specialties:");
                Console.WriteLine($"1. Hacker (disables alarms)");
                Console.WriteLine($"2. Muscle (disarms guards)");
                Console.WriteLine($"3. Lock Specialist (cracks vault)");
                Console.WriteLine($"Enter a new operative's specialty:");
                string newOperativeSpecialty = Console.ReadLine();

                Console.WriteLine("Enter a new operative's skill level (1-100):");
                int newOperativeSkillLevel;

                while (true)
                {
                    string newOperativeSkillLevelString = Console.ReadLine();
                    if (!int.TryParse(newOperativeSkillLevelString, out newOperativeSkillLevel))
                    {
                        Console.WriteLine("Invalid skill level. Please enter a number between 1 and 100.");
                        continue;
                    }
                    if (newOperativeSkillLevel < 1 || newOperativeSkillLevel > 100)
                    {
                        Console.WriteLine("Invalid skill level. Please enter a number between 1 and 100.");
                        continue;
                    }

                    break;
                }

                Console.WriteLine($"Enter a new operative's cut from the heist (1-100):");
                int newOperativePercentageCut;

                while (true)
                {
                    string newOperativePercentageCutString = Console.ReadLine();
                    if (!int.TryParse(newOperativePercentageCutString, out newOperativePercentageCut))
                    {
                        Console.WriteLine("Invalid percentage. Please enter a number between 1 and 100.");
                        continue;
                    }
                    if (newOperativePercentageCut < 1 || newOperativePercentageCut > 100)
                    {
                        Console.WriteLine("Invalid percentage. Please enter a number between 1 and 100.");
                        continue;
                    }

                    break;
                }

                IRobber newOperative;
                string specialtyName;

                if (newOperativeSpecialty == "1")
                {
                    specialtyName = "Hacker";
                    newOperative = new Hacker()
                    {
                        Name = newOperativeName,
                        SkillLevel = newOperativeSkillLevel,
                        PercentageCut = newOperativePercentageCut
                    };
                }
                else if (newOperativeSpecialty == "2")
                {
                    specialtyName = "Muscle";
                    newOperative = new Muscle()
                    {
                        Name = newOperativeName,
                        SkillLevel = newOperativeSkillLevel,
                        PercentageCut = newOperativePercentageCut
                    };
                }
                else
                {
                    specialtyName = "Lock Specialist";
                    newOperative = new LockSpecialist()
                    {
                        Name = newOperativeName,
                        SkillLevel = newOperativeSkillLevel,
                        PercentageCut = newOperativePercentageCut
                    };
                }

                rolodex.Add(newOperative);
                Console.WriteLine($"The new operative is {newOperative.Name}. They're a {specialtyName} with a skill level of {newOperativeSkillLevel} and are getting {newOperativePercentageCut}% of the loot.");
                Console.WriteLine();
            }

            Console.WriteLine($"Total number of operatives in the rolodex: {rolodex.Count}");
        }

        private static string GetSystemName (string system)
        {
            switch (system)
            {
                case "AlarmScore":
                    return "Alarm";
                case "VaultScore":
                    return "Vault";
                case "SecurityGuardScore":
                    return "Security Guard";
                default:
                    return "Unknown";
                
            }
        }
    }
}


