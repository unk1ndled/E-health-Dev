using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Pen : MonoBehaviour
{
    [SerializeField] private Transform _tip;
    [SerializeField] private int _penSize = 5;

    private Renderer _renderer;
    private Color[] _colors;
    private float _tipHeight;

    private RaycastHit _touch;
    private DrawingBoard _drawingBoard;
    private Vector2 _touchPos;
    private Vector2 _lastTouchPos;
    private bool _touchLastFrame;
    private Quaternion _lastTouchRot;

    void Start()
    {
        _renderer = _tip.GetComponent<Renderer>();
        // Create a fully opaque color array
        Color penColor = new Color(_renderer.material.color.r, _renderer.material.color.g, _renderer.material.color.b, 1f);
        _colors = Enumerable.Repeat(penColor, _penSize * _penSize).ToArray();
        _tipHeight = _tip.localScale.y;
    }

    void Update()
    {
        Draw();
    }

    private void Draw()
    {
        if (Physics.Raycast(_tip.position, _tip.transform.up, out _touch, _tipHeight * 2))
        {
            if (_touch.transform.CompareTag("DrawingBoard"))
            {
                if (_drawingBoard == null)
                {
                    _drawingBoard = _touch.transform.GetComponent<DrawingBoard>();
                }

                _touchPos = new Vector2(_touch.textureCoord.x, _touch.textureCoord.y);
                var x = (int)(_touchPos.x * _drawingBoard.textureSize.x - (_penSize / 2));
                var y = (int)(_touchPos.y * _drawingBoard.textureSize.y - (_penSize / 2));

                if (y < 0 || y > _drawingBoard.textureSize.y || x < 0 || x > _drawingBoard.textureSize.x)
                {
                    return;
                }

                if (_touchLastFrame)
                {
                    // Ensure the drawn pixels are fully opaque
                    _drawingBoard.texture.SetPixels(x, y, _penSize, _penSize, _colors);

                    for (float f = 0.01f; f < 1.00f; f += 0.05f)
                    {
                        var LerpX = (int)Mathf.Lerp(_lastTouchPos.x, x, f);
                        var LerpY = (int)Mathf.Lerp(_lastTouchPos.y, y, f);
                        _drawingBoard.texture.SetPixels(LerpX, LerpY, _penSize, _penSize, _colors);
                    }
                    transform.rotation = _lastTouchRot;
                    _drawingBoard.texture.Apply();
                }
                _lastTouchPos = new Vector2(x, y);
                _lastTouchRot = transform.rotation;
                _touchLastFrame = true;
                return;
            }
        }
        _drawingBoard = null;
        _touchLastFrame = false;
    }
}
