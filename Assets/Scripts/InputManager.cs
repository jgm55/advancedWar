using UnityEngine;
using System.Collections;
using System;
using Assets.Scripts;

public class InputManager : MonoBehaviour
{
    public float dragSpeed = 2;
    private Vector3 dragOrigin;
    private Vector3 oldPos;

    public GameManager gameManager;

    private TypeSelected selected = TypeSelected.VOID;
    private GameObject selectedObject;
    private MoveDisplayController moveDisplayController;

    void Start()
    {
        moveDisplayController = GameObject.FindObjectOfType<MoveDisplayController>();
        if (moveDisplayController == null)
        {
            throw new Exception("OMG! MoveDisplayController CANNOT BE FOUND!!");
        }

        gameManager = GameObject.FindObjectOfType<GameManager>();
        if (gameManager == null)
        {
            throw new Exception("OMG! GameManager CANNOT BE FOUND!!");
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray);
            //Check is hit and is not a tile.
            if (hit.collider != null && hit.collider.gameObject.GetComponent<Tile>() == null)
            {
                if(hit.collider.gameObject.tag == Constants.UNIT_TAG)
                {
                    selected = TypeSelected.UNIT;
                    gameManager.setSelected(hit.collider.gameObject);
                    GameObject tile = InputHelper.getObjectInLayerAtPoint(MapLayer.TILE, Input.mousePosition);
                    if (tile == null)
                    {
                        Debug.Log("TERRIBLE NO TILE BENEATH UNIT");
                    } else {
                        Debug.Log(hit.collider.gameObject.GetComponent<Unit>());
                        moveDisplayController.displayMovesFor(hit.collider.gameObject.GetComponent<Unit>(), tile.GetComponent<Tile>());
                    }
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
                GameObject topLayer = InputHelper.getObjectInLayerAtPoint(MapLayer.ANY, Input.mousePosition);
                if (topLayer != null)
                {
                    if (topLayer.GetComponent<Unit>() != null)
                    {
                        Unit selectedUnit = selectedObject.GetComponent<Unit>();
                        if (gameManager.FightUnit(selectedUnit, topLayer.GetComponent<Unit>()))
                        {
                            //display fight Anim
                        }
                        else
                        {
                            //Error state handle
                            Debug.Log("Undoing select unit");
                            moveDisplayController.hideMovesFor(selectedUnit,
                                InputHelper.getObjectInLayerAtPoint(MapLayer.TILE, selectedUnit.transform.position).GetComponent<Tile>());
                        }
                    }
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