using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ColorMaterial
{
    Magenta, Cyan, Yellow, White
}

public enum ColorFilter
{
    Red, Green, Blue
}
public static class ColorHelpers
{
    public static Color FromColorEnum(ColorMaterial c)
    {
        switch (c)
        {
            case ColorMaterial.Cyan:
                return new Color(0, 1.0f, 1.0f);
            case ColorMaterial.Magenta:
                return new Color(1.0f, 0, 1.0f);
            case ColorMaterial.Yellow:
                return new Color(1.0f, 1.0f, 0);
            default:
                return new Color();
        }
    }
}
public class ColorCheck : MonoBehaviour
{
    public enum Color { Magenta, Cyan, Yellow };
    public Color color_choice;
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

        switch (color_choice)
        {
            case Color.Magenta:
                if (filter.BlueFilter == 0.0f && filter.RedFilter == 0.0f)
                {
                    this.GetComponent<Renderer>().enabled = false;
                    if(hasRigidbody && detectCol)
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
                break;
            case Color.Cyan:
                if (filter.BlueFilter == 0.0f && filter.GreenFilter == 0.0f)
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
                break;
            case Color.Yellow:
                if (filter.GreenFilter == 0.0f && filter.RedFilter == 0.0f)
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
                break;
            default:
                Debug.Log("No Color for game object:" + this.gameObject);
                break;
        }
    }
}
