using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class RGBFilterPostFX : MonoBehaviour {

    [Range(0.0f, 1.0f)]
    public float RedFilter = 1.0f;
    [Range(0.0f, 1.0f)]
    public float GreenFilter = 1.0f;
    [Range(0.0f, 1.0f)]
    public float BlueFilter = 1.0f;
    public EColor currentFilter = EColor.Black;

    private Material m_material;
	// Use this for initialization
	void Awake () {
        m_material = new Material(Shader.Find("Hidden/RGBFilter"));
	}

	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
        m_material.SetFloat("_redFilter", RedFilter);
        m_material.SetFloat("_greenFilter", GreenFilter);
        m_material.SetFloat("_blueFilter", BlueFilter);

        Graphics.Blit(source, destination, m_material);
	}

    public void AddFilter(ColorFilter filterColor)
    {
        switch (filterColor)
        {
            case ColorFilter.Red:
                RedFilter = 0.0f;
                currentFilter += (int)EColor.Red;
                break;
            case ColorFilter.Green:
                GreenFilter = 0.0f;
                currentFilter += (int)EColor.Green;
                break;
            case ColorFilter.Blue:
                BlueFilter = 0.0f;
                currentFilter += (int)EColor.Blue;
                break;
        }
    }

    public void ClearFilter()
    {
        currentFilter = EColor.Black;
        GreenFilter = RedFilter = BlueFilter = 1.0f;
    }
}
