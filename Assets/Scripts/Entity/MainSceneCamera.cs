using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneCamera : MonoBehaviour
{
    public float smoothSpeed = 0.01f;
    public Vector2 cameraOffset;

    private void Start()
    {

    }

    void LateUpdate()
    {
        if (MainPlayer.instance != null)
        {
            Vector2 desiredPos = (Vector2)(MainPlayer.instance.transform.position) + cameraOffset;
            Vector2 smoothedPos = Vector2.Lerp(transform.position, desiredPos, smoothSpeed);
            Vector3 newPos = new Vector3(smoothedPos.x, smoothedPos.y, -10);
            transform.position = newPos;
        }
        else
            Debug.LogError("Error : MainPlayer instance is Missing");
    }
}
