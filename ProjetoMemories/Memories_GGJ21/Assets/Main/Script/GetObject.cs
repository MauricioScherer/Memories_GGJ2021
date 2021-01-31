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
    [SerializeField] private GameObject fita1InHand;
    [SerializeField] private GameObject fita2InHand;
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
            else if(hit.collider.CompareTag("Fita1"))
            {
                visualizeObject = true;

                if (Input.GetMouseButtonDown(0) && !fita2InHand.activeSelf && !fita1InHand.activeSelf)
                {
                    Destroy(hit.collider.gameObject);
                    fita1InHand.SetActive(true);
                }
            }
            else if (hit.collider.CompareTag("Fita2"))
            {
                visualizeObject = true;

                if (Input.GetMouseButtonDown(0) && !fita1InHand.activeSelf && !fita2InHand.activeSelf)
                {
                    Destroy(hit.collider.gameObject);
                    fita2InHand.SetActive(true);
                }
            }
            else if(hit.collider.CompareTag("Radio1"))
            {
                visualizeObject = true;

                if (Input.GetMouseButtonDown(0))
                {
                    if(!fita2InHand.activeSelf)
                    {
                        if (!hit.collider.GetComponent<Radio>().GetRadioComFita())
                        {
                            if (fita1InHand.activeSelf)
                            {
                                fita1InHand.SetActive(false);
                                hit.collider.GetComponent<Radio>().ColocaFita();
                            }
                            else
                            {
                                hit.collider.GetComponent<Radio>().PlayRadioSemFita();
                            }
                        }
                        else
                        {
                            hit.collider.GetComponent<Radio>().PlayRadio();
                        }
                    }
                    else if(!hit.collider.GetComponent<Radio>().GetRadioComFita())
                    {
                        hit.collider.GetComponent<Radio>().PlayRadioSemFita();
                    }
                    else
                    {
                        hit.collider.GetComponent<Radio>().PlayRadio();
                    }
                }
            }
            else if (hit.collider.CompareTag("Radio2"))
            {
                visualizeObject = true;

                if (Input.GetMouseButtonDown(0))
                {
                    if (!fita1InHand.activeSelf)
                    {
                        if (!hit.collider.GetComponent<Radio>().GetRadioComFita())
                        {
                            if (fita2InHand.activeSelf)
                            {
                                fita2InHand.SetActive(false);
                                hit.collider.GetComponent<Radio>().ColocaFita();
                            }
                            else
                            {
                                hit.collider.GetComponent<Radio>().PlayRadioSemFita();
                            }
                        }
                        else
                        {
                            hit.collider.GetComponent<Radio>().PlayRadio();
                        }
                    }
                    else if (!hit.collider.GetComponent<Radio>().GetRadioComFita())
                    {
                        hit.collider.GetComponent<Radio>().PlayRadioSemFita();
                    }
                    else
                    {
                        hit.collider.GetComponent<Radio>().PlayRadio();
                    }
                }
            }
            else if(hit.collider.CompareTag("Botao"))
            {
                visualizeObject = true;

                if (Input.GetMouseButtonDown(0))
                {
                    hit.collider.GetComponent<Botao>().Click();
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
