namespace TabSplit.Classes
{
    public class VerifyInput
    {
        public float number = 0;
        public bool CheckIfParseToNumber(string textBoxContent)
        {
            bool success = float.TryParse(textBoxContent, out number);

            if (success && number < float.MaxValue && number >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckIfParseToInt(string textBoxContent)
        {
            int number = 0;
            bool success = int.TryParse(textBoxContent, out number);

            if (success && number < float.MaxValue && number > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckInputStringLength(string textBoxContent)
        {
            if (textBoxContent.Length > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckIfNumber(object value)
        {
            if (value is float || value is int)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
