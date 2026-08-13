namespace TabSplit.Classes
{
    public class VerifyInput
    {
        public bool CheckIfParseToNumber(string textBoxContent)
        {
            float number = 0;
            bool success = float.TryParse(textBoxContent, out number);

            if (success && number < float.MaxValue && number > 0)
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
