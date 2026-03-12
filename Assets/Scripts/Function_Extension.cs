using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Function_Extension
{
    static float hue = Random.value; //Starts with a random color value
    public static bool Rndmz_BlockMovement()
    {
        return Random.value > 0.5f;
    }

    public static Color GetNextStackColor(float step = 0.02f)
    {
        hue += step;
        if (hue > 1f)
            hue = 0f;
        return Color.HSVToRGB(hue, 0.8f, 0.9f);
    }
}
