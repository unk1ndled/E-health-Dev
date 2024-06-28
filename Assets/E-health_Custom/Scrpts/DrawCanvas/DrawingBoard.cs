using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class DrawingBoard : MonoBehaviour
{
    public Texture2D texture;
    public Vector2 textureSize = new Vector2(2048, 2048);
    [SerializeField] private Color fillColor = new Color(0, 0, 0, 0); // Transparent


    private void Start()
    {
        var r = GetComponent<Renderer>();
        // Initialize the texture with RGBA format to support alpha
        texture = new Texture2D((int)textureSize.x, (int)textureSize.y, TextureFormat.RGBA32, false);
        // Set the texture to be transparent initially
        Color[] fillPixels = Enumerable.Repeat(fillColor, (int)textureSize.x * (int)textureSize.y).ToArray();
        texture.SetPixels(fillPixels);
        texture.Apply();

        r.material.mainTexture = texture;
    }
}
