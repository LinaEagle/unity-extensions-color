using UnityEngine;

public static class ColorExtensions
{
    public static int HexToDec(this string value)
    {
        return System.Convert.ToInt32(value, 16);
    }

    public static string DecToHex(this int value)
    {
        return value.ToString("X2");
    }

    public static string FloatNormalizedToHex(this float value)
    {
        return DecToHex(Mathf.RoundToInt(value * 255f));
    }

    public static float HexToFloatNormalized(this string value)
    {
        return HexToDec(value) / 255f;
    }
    
    public static Color HexToColorRGBA(this string hex)
    {
        if (hex.StartsWith('#'))
        {
            hex = hex.Remove(0, 1);
        }
        var r = HexToFloatNormalized(hex.Substring(0, 2));
        var g = HexToFloatNormalized(hex.Substring(2, 2));
        var b = HexToFloatNormalized(hex.Substring(4, 2));
        var a = 1f;
        if (hex.Length > 6)
        {
            a = HexToFloatNormalized(hex.Substring(6, 2));
        }

        return new Color(r,g,b,a);
    }
}