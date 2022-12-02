using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnEye : MonoBehaviour
{
    public GameObject player;
    public void Start()
    {
        player = GameObject.Find("FPSController");
    }
    public void Update()
    {
        if (SceneManager.GetActiveScene().name == "MoonScene")
        {
            
        }
    }
    public void Select()
    {
        gameObject.transform.parent = player.transform.GetChild(0);
        gameObject.transform.localPosition = new Vector3(0.5f, -0.2f, 1);
        gameObject.transform.localRotation = new Quaternion(0, 0, 0, 0);
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
    }
    public void Deselect()
    {
        gameObject.transform.parent = null;
        gameObject.GetComponent<Rigidbody>().isKinematic = false;
    }
}
