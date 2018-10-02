using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EColor
{
    Magenta = 5, Cyan = 3, Yellow  = 6 , White = 7 , Red = 4, Green = 2, Blue = 1, Black = 0
}

public enum ColorFilter
{
    Red, Green, Blue
}

public static class ColorHelpers
{
    public static Color FromColorEnum(EColor c)
    {
        switch (c)
        {
            case EColor.Cyan:
                return new Color(0, 1.0f, 1.0f);
            case EColor.Magenta:
                return new Color(1.0f, 0, 1.0f);
            case EColor.Yellow:
                return new Color(1.0f, 1.0f, 0);
            default:
                return new Color();
        }
    }
}
public class ColorCheck : MonoBehaviour
{
    public EColor color_choice;
    private RGBFilterPostFX filter;
    private bool hasRigidbody;
    private bool detectCol;

    void Start()
    {
        filter = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<RGBFilterPostFX>();
        detectCol = true;
    }

    void Update()
    {
        if (this.GetComponent<Rigidbody>() == null)
        {
            hasRigidbody = false;
        }
        else hasRigidbody = true;
        
        if(((uint)color_choice & ~(uint)filter.currentFilter) == 0)
        {
            this.GetComponent<Renderer>().enabled = false;
            if (hasRigidbody && detectCol)
            {
                this.GetComponent<Rigidbody>().detectCollisions = false;
                detectCol = false;
            }
        }
        else
        {
            this.GetComponent<Renderer>().enabled = true;
            if (hasRigidbody && !detectCol)
            {
                this.GetComponent<Rigidbody>().detectCollisions = true;
                detectCol = true;
            }
        }
    }
}
