using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float dragSpeed = 40;
    private Vector3 oldPosition;


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            oldPosition = Input.mousePosition;
            return;
        }

        if (!Input.GetMouseButton(0)) return;

        if (oldPosition == Input.mousePosition)
            return;
        Vector3 pos = Camera.main.ScreenToViewportPoint(oldPosition - Input.mousePosition);
        Vector3 move = new Vector3(0, 0, pos.y * dragSpeed);

        transform.Translate(move, Space.World);
        oldPosition = Input.mousePosition;

      
    }
}
