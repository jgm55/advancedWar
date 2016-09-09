using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour
{
    public float dragSpeed = 2;
    private Vector3 dragOrigin;
    private Vector3 oldPos;

    public GameManager gameManager = new GameManager();

    private TypeSelected selected = TypeSelected.VOID;
    private GameObject selectedObject;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray);
            if (hit.collider != null)
            {
                if(hit.collider.gameObject.tag == Constants.UNIT_TAG)
                {
                    selected = TypeSelected.UNIT;
                }
                selectedObject = hit.collider.gameObject;
                return;
            }
            else
            {
                selected = TypeSelected.CAMERA;
                oldPos = transform.position;
                dragOrigin = Camera.main.ScreenToViewportPoint(Input.mousePosition);
            }
        }

        if (Input.GetMouseButton(0) && TypeSelected.CAMERA == selected)
        {
            Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition) - dragOrigin;    
            transform.position = oldPos + -pos * dragSpeed;
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (selected == TypeSelected.UNIT)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D[] hits = Physics2D.GetRayIntersectionAll(ray);
                foreach (RaycastHit2D hit in hits)
                {
                    Unit selectedUnit = selectedObject.GetComponent<Unit>();
                    if (hit.collider.gameObject.tag == Constants.UNIT_TAG)
                    {
                        if(gameManager.FightUnit(selectedUnit, hit.collider.gameObject.GetComponent<Unit>()))
                        {
                            //Show Animation
                        } else
                        {
                            // Error
                        }
                    } else if (hit.collider.gameObject.tag == Constants.TILE_TAG)
                    {
                        if(gameManager.MoveUnit(selectedUnit, hit.collider.gameObject.GetComponent<Tile>())) {
                            //Show Animation
                        } else
                        {
                            //Error
                        }
                    }//TODO: Buidlings
                }
            } else if (selected == TypeSelected.BUILDING)
            {
                //TODO
            } else if (selected == TypeSelected.TILE)
            {
                //TODO handle case for type
            }
            selectedObject = null;
            selected = TypeSelected.VOID;
        }
    }
}