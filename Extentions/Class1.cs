namespace Extentions
{
    public class Class1
    {
        public bool IsNumber(string number)
        {
            if (int.TryParse(number, out var num1))
            {
                return true;
            }

            return false;
        }

        public bool IsDate(string date)
        {
            if (DateTime.TryParse(date, out var date1))
            {
                return true;
            }

            return false;
        }

        public string[] ToWords(string sentence)
        {
            return sentence.Split(" ");
        }

        public void SaveToFile(string filePath, string text)
        {
            File.WriteAllText(filePath, text);
        }

        
        
            public double ToPercent(double number)
            {
                return number * 100;
            }

            public int RoundDown(double number)
            {
                var splitNumber = number.ToString().Split(".");
                var roundedNumber = Convert.ToInt32(splitNumber[0]);
                return roundedNumber;
            }

            public decimal ToDecimal(double number)
            {
                return (decimal)number;
            }

            public bool IsGreater(double comparingNumber, double compareToNumber)
            {
                if (comparingNumber > compareToNumber)
                {
                    return true;
                }

                return false;
            }

            public bool IsLess(double comparingNumber, double compareToNumber)
            {
                if (comparingNumber < compareToNumber)
                {
                    return true;
                }

                return false;
            }
        public DateTime Min(DateTime firstDate, DateTime secondDate)
        {
            var comparision = DateTime.Compare(firstDate, secondDate);
            if (comparision == 1)
            {
                return secondDate;
            }
            return firstDate;
        }

        public DateTime Max(DateTime firstDate, DateTime secondDate)
        {
            var comparision = DateTime.Compare(firstDate, secondDate);
            if (comparision == 1)
            {
                return firstDate;
            }

            return secondDate;
        }
    }
}