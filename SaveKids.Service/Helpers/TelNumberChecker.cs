namespace SaveKids.Service.Helpers;

public static class TelNumberChecker
{
    public static bool CheckUzbTelNumber(string telNumber) 
    {
        if (telNumber.Length != 13)
            return false;

        if (!telNumber[..4].Equals("+998"))
            return false;

        for(int i=4; i<telNumber.Length; i++)
            if (48>(int)telNumber[i] || 57<(int)telNumber[i])
                return false;
        
        return true;
    }
}
