namespace ANZAutomation.Model
{
    public class Currency
    {
        private string CodeName { get; set; }

        private float Buy { get; set; }

        private float Sell { get; set; }

        public readonly float Percentage;

        public Currency(string codeName, float buy, float sell, float percentage)
        {
            CodeName = codeName;
            Buy = buy;
            Sell = sell;
            Percentage = percentage;
        }

        public static float GetPercentage(float buy, float sell)
        {
            var percentage = (buy - sell) / buy * 100;
            return percentage;
        }

        public override string ToString()
        {
            return "Code of currency: " + CodeName + " | Buy Rate: " + Buy + " | Sell Rate: " + Sell +
                   " | Rate difference: " + Percentage;
        }
    }
}