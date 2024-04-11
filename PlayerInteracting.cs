using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteracting : MonoBehaviour
{
    public float raycastLength;
    RaycastHit hit;

    bool interact = false;
    bool isHeld;

    [Header("Onzigtbaarblok hier")]
    public GameObject holdPos;

    void Start()
    {
        
    }

    void Update()
    {
        keyTrigger();

        if (interact)
        {
            if (isHeld)
            {
                Debug.Log(hit.collider.gameObject.name);
                if (hit.collider.gameObject.CompareTag("Pickup"))
                {
                    //holdPos.transform.position = hit.collider.gameObject.GetComponent<ItemPickup>().go.transform.position;
                    hit.collider.gameObject.GetComponent<ItemPickup>().go.transform.position = holdPos.transform.position;
                    hit.collider.GetComponent<ItemPickup>().go.transform.parent = hit.collider.gameObject.transform;
                    //hit.collider.gameObject.GetComponent<ItemPickup>();

                    hit.collider.gameObject.GetComponent<ItemPickup>().body.velocity = new Vector3(0, -9.8f, 0);
                    isHeld = true;
                }
                else if (hit.collider.gameObject.CompareTag("Interactable"))
                {
                    //hit.collider.gameObject.GetComponent<ItemInteract>();

                    ItemInteract.itemInteraction();
                }
            } else
            {
                if (Physics.Raycast(transform.position, transform.forward, out hit, raycastLength))
                {
                    Debug.Log(hit.collider.gameObject.name);
                    if (hit.collider.gameObject.CompareTag("Pickup"))
                    {
                        //holdPos.transform.position = hit.collider.gameObject.GetComponent<ItemPickup>().go.transform.position;
                        hit.collider.gameObject.GetComponent<ItemPickup>().go.transform.position = holdPos.transform.position;
                        hit.collider.GetComponent<ItemPickup>().go.transform.parent = hit.collider.gameObject.transform;
                        //hit.collider.gameObject.GetComponent<ItemPickup>();

                        hit.collider.gameObject.GetComponent<ItemPickup>().body.velocity = new Vector3(0, -9.8f, 0 );
                        isHeld = true;
                    }
                    else if (hit.collider.gameObject.CompareTag("Interactable"))
                    {
                        //hit.collider.gameObject.GetComponent<ItemInteract>();

                        ItemInteract.itemInteraction();
                    }
                }
            }

        } else
        {
            isHeld = false;
        }
    }

    private void FixedUpdate()
    {
        
    }

    void keyTrigger()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            interact = !interact;
        }
    }

    /*void ItemPlacement()
    {
        rb.transform.position = raycastLength;
    }*/
}
