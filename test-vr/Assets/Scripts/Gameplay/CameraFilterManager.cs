using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity;

[RequireComponent(typeof(RGBFilterPostFX))]
public class CameraFilterManager : Singleton<CameraFilterManager> {

    //Filters are RGB matching first three bits in the same order
    private bool m_redFilterActive = false;
    private bool m_greenFilterActive = false;
    private bool m_blueFilterActive = false;

    private RGBFilterPostFX m_postFX;

    public void OnEnable()
    {
        m_postFX = this.GetComponent<RGBFilterPostFX>();
    }
    
    public bool FilterRemovesColor(EColor color)
    {
        Color match = ColorHelpers.FromColorEnum(color);
        return (match.r * (m_redFilterActive ? 0 : 1) + match.g * (m_greenFilterActive ? 0 : 1) + match.b * (m_blueFilterActive ? 0 : 1)) <= 0;
    }

    public void AddFilter(ColorFilter color)
    {
        switch(color)
        {
            case ColorFilter.Red:
                m_redFilterActive = true;
                break;
            case ColorFilter.Green:
                m_greenFilterActive = true;
                break;
            case ColorFilter.Blue:
                m_blueFilterActive = true;
                break;
        }
        m_postFX.AddFilter(color);
    }

    public void ClearFilter()
    {
        m_redFilterActive = m_greenFilterActive = m_blueFilterActive = false;
        m_postFX.ClearFilter();
    }
}
