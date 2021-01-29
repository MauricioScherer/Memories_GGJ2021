using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetObject : MonoBehaviour
{
    private bool visualizeObject;
    private bool stayObject = false;
    private GameObject currentObject;

    [SerializeField] private float distance;
    [SerializeField] private Transform target;

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

        if(stayObject)
        {
            if(Input.GetMouseButton(0))
            {
                currentObject.transform.position = Vector3.MoveTowards(currentObject.transform.position, target.position, 2.0f * Time.deltaTime);
            }
            else
            {
                currentObject.GetComponent<Rigidbody>().useGravity = true;
                currentObject = null;
                stayObject = false;
            }
        }

        //Debug.DrawRay(transform.position, transform.forward, visualizeObject ? Color.green : Color.yellow, distance);
    }
}
