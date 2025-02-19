using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnAvatarName : MonoBehaviour
{
    string clickedObject;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                clickedObject = hit.collider.gameObject.name;

            }
        }
    }

    public void GetAvatarName()
    {
        string str = clickedObject.Replace("Image", null);
    }
}
