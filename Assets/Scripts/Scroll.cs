using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    [Range(0f, 1f)]
    public float scrollSpeed;
    private Material mat;

	void Start ()
    {
        mat = GetComponent<Renderer>().material;
	}
	
	void Update ()
    {
        mat.mainTextureOffset = new Vector3(Time.realtimeSinceStartup * scrollSpeed, 0);
	}
}
