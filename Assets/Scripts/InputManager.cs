using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour
{

    public float dragSpeed = 2;
    private Vector3 dragOrigin;
    private Vector3 oldPos;

    public bool cameraDragging = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            cameraDragging = true;
            oldPos = transform.position;
            dragOrigin = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition) - dragOrigin;    
            transform.position = oldPos + -pos * dragSpeed;
        }

        if (Input.GetMouseButtonUp(0))
        {
            cameraDragging = false;
        }
    }
}