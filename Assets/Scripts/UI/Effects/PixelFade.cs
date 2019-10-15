using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class PixelFade : MonoBehaviour {

    private readonly Vector2 defaultResolution = new Vector2(1920, 1080);

    [Range(0.1f, 1)]
    public float _resolutionWeight = 1f;

    private float currentResolutionWeight = 1f;

    private RenderTexture _renderTexture;
    private Camera _camera;
    private Camera _subCamera;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        SetResolution(_resolutionWeight);

    }

    public void SetResolution(float resolutionWeight)
    {
        if (Mathf.Abs(resolutionWeight - currentResolutionWeight) < 0.01f)
            return;
        currentResolutionWeight = _resolutionWeight;

        _renderTexture = new RenderTexture(
            width: (int)(defaultResolution.x * currentResolutionWeight),
            height: (int)(defaultResolution.y * currentResolutionWeight),
            depth: 24);

        _renderTexture.useMipMap = false;
        _renderTexture.filterMode = FilterMode.Point;

        if(_camera == null)
        {
            _camera = GetComponent<Camera>();
        }

        _camera.targetTexture = _renderTexture;

        //if(_subCamera == null)
        //{
        //    GameObject subObject = new GameObject();
        //    _subCamera = subObject.AddComponent<Camera>();
        //    _subCamera.cullingMask = 0;
        //    _subCamera.transform.parent = transform;
        //}
    }
}
