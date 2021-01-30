using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetObject : MonoBehaviour
{
    private bool visualizeObject;
    private bool stayObject = false;
    private GameObject currentObject;

    [SerializeField] private float distance;
    [SerializeField] private float speedMove;
    [SerializeField] private Transform target;
    [SerializeField] private GameObject uiView;
    [SerializeField] private GameObject feedbackView;
    [SerializeField] private GameObject keyInHand;
    [SerializeField] private Transform player;

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, distance))
        {
            if (hit.collider.CompareTag("GetObject"))
            {
                visualizeObject = true;

                if (Input.GetMouseButtonDown(0) && !stayObject)
                {
                    stayObject = true;
                    currentObject = hit.collider.gameObject;
                    currentObject.GetComponent<Rigidbody>().useGravity = false;

                    if (currentObject.gameObject.name == "Lanterna")
                    {
                        currentObject.transform.eulerAngles = player.transform.eulerAngles;
                        currentObject.transform.parent = player.transform;                        
                    }
                }
            }
            else if(hit.collider.CompareTag("Door"))
            {
                visualizeObject = true;

                if (Input.GetMouseButtonDown(0))
                {
                    hit.collider.GetComponent<Door>().InteractDoor();

                    if(hit.collider.GetComponent<Door>().GetOpenDoorLocked())
                        keyInHand.SetActive(false);
                }
            }
            else if(hit.collider.CompareTag("Key"))
            {
                visualizeObject = true;

                if (Input.GetMouseButtonDown(0))
                {
                    hit.collider.GetComponent<Key>().GetKey();
                    keyInHand.SetActive(true);
                }
            }
            else if(hit.collider.CompareTag("AlavancaGato"))
            {
                visualizeObject = true;

                if (Input.GetMouseButtonDown(0))
                {
                    hit.collider.GetComponent<AlavancaCat>().InteractAlavancaCat();
                }
            }
            else if(hit.collider.CompareTag("TeclaPiano"))
            {
                visualizeObject = true;

                if (Input.GetMouseButtonDown(0))
                {
                    hit.collider.GetComponent<TeclaPiano>().Click();
                }
            }
            else
            {
                visualizeObject = false;
            }
        }
        else
        {
            visualizeObject = false;
        }

        if(uiView.activeSelf != visualizeObject)
        {
            uiView.SetActive(visualizeObject);
        }

        if (stayObject)
        {
            if(Input.GetMouseButton(0))
            {
                currentObject.transform.position = Vector3.MoveTowards(currentObject.transform.position, target.position, speedMove * Time.deltaTime);
            }
            else
            {
                if (currentObject.gameObject.name == "Lanterna")
                    currentObject.transform.parent = null;

                currentObject.GetComponent<Rigidbody>().useGravity = true;

                currentObject = null;
                stayObject = false;
            }
        }
    }
}
