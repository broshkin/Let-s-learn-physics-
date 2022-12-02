using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeightChanger : MonoBehaviour
{
    public TextMeshProUGUI textOfWeight;
    public GameObject player;
    public bool somethingOnScales = false;
    public float currentMass;
    private void OnCollisionEnter(Collision collision)
    {
        textOfWeight.text = collision.gameObject.GetComponent<Rigidbody>().mass.ToString() + " Í„";
        currentMass = collision.gameObject.GetComponent<Rigidbody>().mass;
        somethingOnScales = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        textOfWeight.text = null;
        somethingOnScales = false;
    }
    private void Update()
    {
        if (player.transform.position.x - gameObject.GetComponentInParent<Transform>().position.x > -0.5 && player.transform.position.x - gameObject.GetComponentInParent<Transform>().position.x < 0.5)
        {
            if (player.transform.position.y - gameObject.GetComponentInParent<Transform>().position.y > -2 && player.transform.position.y - gameObject.GetComponentInParent<Transform>().position.y < 2)
            {
                if (player.transform.position.z - gameObject.GetComponentInParent<Transform>().position.z > -0.5 && player.transform.position.z - gameObject.GetComponentInParent<Transform>().position.z < 0.5)
                {
                    if (somethingOnScales)
                    {
                        textOfWeight.text = (player.gameObject.GetComponent<Rigidbody>().mass + currentMass).ToString() + " Í„";
                    }
                    else if(player.GetComponent<InteractionManager>().CurrentSelectable)
                    {
                        textOfWeight.text = (player.gameObject.GetComponent<Rigidbody>().mass + player.GetComponent<InteractionManager>().CurrentSelectable.GetComponent<Rigidbody>().mass).ToString() + " Í„";
                    }
                    else
                    {
                        textOfWeight.text = player.gameObject.GetComponent<Rigidbody>().mass.ToString() + " Í„";
                    }
                }
                else if (!somethingOnScales)
                {
                    textOfWeight.text = null;
                }
            }
            else if(!somethingOnScales)
            {
                textOfWeight.text = null;
            }
        }
        else if(!somethingOnScales)
        {
            textOfWeight.text = null;
        }
    }
}