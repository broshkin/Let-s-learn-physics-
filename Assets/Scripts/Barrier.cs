using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Barrier : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Hub")
        {
            if (gameObject.transform.position.y < -100)
            {
                gameObject.GetComponent<Rigidbody>().position += new Vector3(-gameObject.transform.position.x, 200, -gameObject.transform.position.z);
                gameObject.transform.position += new Vector3(-gameObject.transform.position.x, 200, -gameObject.transform.position.z);
            }
        }
        if (SceneManager.GetActiveScene().name == "earthScene")
        { 
            if (gameObject.transform.position.x >= -95)
            {
                gameObject.transform.position = new Vector3(-95, gameObject.transform.position.y, gameObject.transform.position.z);
            }
            if (gameObject.transform.position.x <= -230)
            {
                gameObject.transform.position = new Vector3(-230, gameObject.transform.position.y, gameObject.transform.position.z);
            }
            if (gameObject.transform.position.z >= 600)
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 600);
            }
            if (gameObject.transform.position.z <= 500)
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 500);
            }
        }
        if (SceneManager.GetActiveScene().name == "MoonScene")
        {
            if (gameObject.transform.position.x <= -60)
            {
                gameObject.transform.position = new Vector3(-60, gameObject.transform.position.y, gameObject.transform.position.z);
            }
            if (gameObject.transform.position.x >= 80)
            {
                gameObject.transform.position = new Vector3(80, gameObject.transform.position.y, gameObject.transform.position.z);
            }
            if (gameObject.transform.position.z >= 60)
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 60);
            }
            if (gameObject.transform.position.z <= -60)
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -60);
            }
        }
  
    }
}
