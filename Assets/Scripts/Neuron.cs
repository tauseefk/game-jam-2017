using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neuron : MonoBehaviour {

    // Reference to renderer
    MeshRenderer mRender;

    // Material to apply at start
    [SerializeField]
    Material material;

    // Initial texture size
    [SerializeField]
    Vector2 initTextureSize;

	// Use this for initialization
	void Start () {

        // Setup
        mRender = GetComponentInChildren<MeshRenderer>();
        mRender.material = new Material(material);

        // Scale texture on MK Shader
        mRender.material.mainTextureScale = initTextureSize;
        mRender.material.SetTextureScale(Constants.MK_GLOW_TEX, initTextureSize);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetMKGlowTexture(Texture texture)
    {
        mRender.material.SetTexture(Constants.MK_GLOW_TEX, texture);
    }

    public void SetMKGlowColor(Color color)
    {
        mRender.material.SetColor(Constants.MK_GLOW_COL, color);
    }

    public void SetMKGlowTextureColor(Color color)
    {
        mRender.material.SetColor(Constants.MK_GLOW_TEX_COL, color);
    }

    public void SetMKGlowPower(float power)
    {
        mRender.material.SetFloat(Constants.MK_GLOW_POW, power);
    }

    public void SetMKGlowTextureStrength(float glowTexStr)
    {
        mRender.material.SetFloat(Constants.MK_GLOW_TEX_STR, glowTexStr);
    }
}
