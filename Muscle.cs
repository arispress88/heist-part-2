using System;

namespace Heist
{
    public class Muscle : IRobber
    {
        public string? Name { get; set;}
        public int SkillLevel { get; set;}
        public int PercentageCut { get; set;}
        public void PerformSkill(Bank bank)
        {
            bank.AlarmScore -= SkillLevel;
            Console.WriteLine($"{Name} is using their brawn to disable the alarm system. Security decreased by {SkillLevel} points.");
            if (bank.AlarmScore <= 0)
            {
                Console.WriteLine($"{Name} overpowered the alarm system!");
            }
        }
    }
}