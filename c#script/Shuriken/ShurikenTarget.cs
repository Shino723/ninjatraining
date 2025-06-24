using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShurikenTarget : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Ground")) 
        {
            Destroy(gameObject); 
        }
    }
}
