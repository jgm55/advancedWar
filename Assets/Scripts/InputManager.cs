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
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray);
            if (hit.collider != null)
            {
                Debug.Log("hit!");
                Debug.Log(hit.collider.gameObject);
                return;
            }
            else
            {
                cameraDragging = true;
                oldPos = transform.position;
                dragOrigin = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            }
        }

        if (Input.GetMouseButton(0) && cameraDragging)
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