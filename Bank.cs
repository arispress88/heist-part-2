// Bank

using System;

namespace Heist
{
    public class Bank
    {
        public int CashOnHand { get; set; }
        public int AlarmScore { get; set; }
        public int VaultScore { get; set; }
        public int SecurityGuardScore { get; set; }

        public bool isSecure
        {
            get
            {
                return AlarmScore > 0 || VaultScore > 0 || SecurityGuardScore > 0;
            }
        }

        public void GenerateBankValues() // Randomizes the values for the heist
        {
            Random random = new Random();

            CashOnHand = random.Next(50000, 1000001);
            AlarmScore = random.Next(0, 101);
            VaultScore = random.Next(0, 101);
            SecurityGuardScore = random.Next(0, 101);
        }

        public string GetMostSecureSystem()
        {
            if (AlarmScore >= VaultScore && AlarmScore >= SecurityGuardScore)
            {
                return "AlarmScore";
            }
            else if (VaultScore >= AlarmScore && VaultScore >= SecurityGuardScore)
            {
                return "VaultScore";
            }
            else
            {
                return "SecurityGuardScore";
            }
        }

        public string GetLeastSecureSystem()
        {
            if (AlarmScore <= VaultScore && AlarmScore <= SecurityGuardScore)
            {
                return "AlarmScore";
            }
            else if (VaultScore <= AlarmScore && VaultScore <= SecurityGuardScore)
            {
                return "VaultScore";
            }
            else
            {
                return "SecurityGuardScore";
            }
        }
    }
}