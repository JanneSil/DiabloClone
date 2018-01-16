using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    [Header("Target")]
    public Transform Target;

    [Header("Distances")]
    [Range(2f, 7f)]public float Distance = 5f;
    public float MinDistance;
    public float MaxDistance;
    public Vector3 Offset;

    [Header("Speeds")]
    public float SmoothSpeed = 5f;
    public float ScrollSensivity = 1f;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void LateUpdate ()
    {
        if (!Target)
        {
            Debug.Log("NO TARGET SET FOR CAMERA");
            return;
        }

        float num = Input.GetAxis("Mouse ScrollWheel");
        Distance -= num * ScrollSensivity;
        Distance = Mathf.Clamp(Distance, MinDistance, MaxDistance);

        Vector3 pos = Target.position + Offset;
        pos -= transform.forward * Distance;

        transform.position = Vector3.Lerp(transform.position, pos, SmoothSpeed * Time.deltaTime);
	}
}
