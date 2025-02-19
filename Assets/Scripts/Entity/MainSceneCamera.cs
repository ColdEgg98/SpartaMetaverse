using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneCamera : MonoBehaviour
{
    public Transform playerTransform;
    public float smoothSpeed = 0.01f;
    public Vector2 cameraOffset;

    // Update is called once per frame
    void LateUpdate()
    {
        Vector2 desiredPos = (Vector2)(playerTransform.transform.position) + cameraOffset;
        Vector2 smoothedPos = Vector2.Lerp(transform.position, desiredPos, smoothSpeed);
        Vector3 newPos = new Vector3(smoothedPos.x, smoothedPos.y, -10);
        transform.position = newPos;
    }
}
