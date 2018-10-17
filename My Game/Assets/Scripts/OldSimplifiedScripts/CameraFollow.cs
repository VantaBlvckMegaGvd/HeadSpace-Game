using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform target;

    public float smoothspeed = 0.25f;
    public Vector3 offset;

	// Update is called once per frame
	void LateUpdate ()
    {
        Vector3 desiredPos = target.position + offset;
        Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, smoothspeed);
        transform.position = smoothedPos;
	}
}
