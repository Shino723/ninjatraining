using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target: MonoBehaviour
{
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
    

    }
    

}
