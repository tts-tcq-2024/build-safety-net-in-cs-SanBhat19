using System;
using System.Text;

public class Soundex
{
    public static string GenerateSoundex(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return string.Empty;
        }
        StringBuilder soundex = new StringBuilder();
        soundex.Append(char.ToUpper(name[0]));
        char prevCode = GetSoundexCode(name[0]);
        for (int i = 1; i < name.Length && soundex.Length < 4; i++)
        {
            char code = GetSoundexCode(name[i]);
            if (code != '0' && code != prevCode)
            {
                soundex.Append(code);
                prevCode = code;
            }
            if (i < name.Length)
                soundex.Append('0');
        }            
        return soundex.ToString();
    }
    private static char GetSoundexCode(char c)
    {
        c = char.ToUpper(c);
        if ("BFPV".IndexOf(c) >= 0) return '1';
        if ("CGJKQSXZ".IndexOf(c) >= 0) return '2';
        if ("DT".IndexOf(c) >= 0) return '3';
        if ("L".IndexOf(c) >= 0) return '4';
        if ("MN".IndexOf(c) >= 0) return '5';
        if ("R".IndexOf(c) >= 0) return '6';
        return 0; //For A,E,I,O,U,H,W,Y
    }
}
