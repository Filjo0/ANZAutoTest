namespace ANZAuto.UnitTest.Model
{
    public class Currency
    {
        public string CodeName { get; set; }

        public float Buy { get; set; }

        public float Sell { get; set; }

        public float Percentage;

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

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}