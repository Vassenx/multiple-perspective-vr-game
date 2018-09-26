using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class TestPostFx : MonoBehaviour {

    [Range(0.0f,1.0f)]
    public float RedFilter = 1.0f;
    [Range(0.0f, 1.0f)]
    public float GreenFilter = 1.0f;
    [Range(0.0f, 1.0f)]
    public float BlueFilter = 1.0f;

    public Material m_material;
    // Use this for initialization
    void Awake()
    {
        m_material = new Material(Shader.Find("Hidden/Greyscale"));
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        m_material.SetFloat("_redFilter", RedFilter);
        m_material.SetFloat("_greenFilter", GreenFilter);
        m_material.SetFloat("_blueFilter", BlueFilter);

        Graphics.Blit(source, destination, m_material);
    }
}
