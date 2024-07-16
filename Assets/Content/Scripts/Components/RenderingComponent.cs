using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderingComponent : AComponent
{
    private Renderer objectRenderer;
    private Material objectMaterial;
    private bool isInitializeSuccesful = false;
    private MeshFilter meshFilter;

    [Range(0f, 1f)] [SerializeField] private float opacity = 1f;
    public override void Initialize()
    {
        if (gameObject)
        {
            objectRenderer = GetComponent<Renderer>();
            objectMaterial = objectRenderer.material;
            meshFilter = GetComponent<MeshFilter>();
            if (objectRenderer == null)
            {
                gameObject.AddComponent<Renderer>();
                objectRenderer = GetComponent<Renderer>();
            }
        }


    }

    public float GetOpacity()
    {
        return opacity;
    }

    public void SetOpacity(float value)
    {
        opacity = Mathf.Clamp01(value);
        Color color = objectMaterial.color;
        color.a = opacity;
        objectMaterial.color = color;
    }

    //Setting Up Fresnel and Outline Effects later on 

    public Mesh GetMesh()
    {
        if (meshFilter != null)
        {
            return meshFilter.mesh;
        }
        else
        {
            Debug.LogWarning("MeshFilter is not assigned on " + gameObject.name);
            return null;
        }
    }
}
