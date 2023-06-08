using System;

namespace Heist
{
    public class Hacker : IRobber
    {
        public string? Name { get; set; }
        public int SkillLevel { get; set; }
        public int PercentageCut { get; set; }
        public void PerformSkill(Bank bank)
        {
            bank.AlarmScore -= SkillLevel;
            Console.WriteLine($"{Name} is hacking the alarm system. Decreasing security {SkillLevel} points.");
            
            if (bank.AlarmScore <= 0)
            {
                Console.WriteLine($"The alarm system has been disarmed by {Name}!");
            }
        }


    }
}