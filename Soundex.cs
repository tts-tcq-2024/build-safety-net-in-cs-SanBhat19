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
        soundex = GetSoundexString(soundex, name, prevCode);        
        // Pad with '0's to ensure the Soundex code is always 4 characters long
        while (soundex.Length < 4)
        {
            soundex.Append('0');
        }
        return soundex.ToString();
    }
    private static StringBuilder GetSoundexString(StringBuilder soundex, string name, char prevCode) 
    {
        for (int i = 1; i < name.Length && soundex.Length < 4; i++)
        {
            char code = GetSoundexCode(name[i]);
            if (code != '0' && code != prevCode)
            {
                soundex.Append(code);
                prevCode = code;
            }
        }
        return soundex;
    }

    private static char GetSoundexCode(char c)
    {
        c = char.ToUpper(c);

        return c switch
        {
            'B' or 'F' or 'P' or 'V' => '1',
            'C' or 'G' or 'J' or 'K' or 'Q' or 'S' or 'X' or 'Z' => '2',
            'D' or 'T' => '3',
            'L' => '4',
            'M' or 'N' => '5',
            'R' => '6',
            _ => '0'
        };
    }
}
