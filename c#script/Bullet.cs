using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    public float BulletSpeed;

    public GameObject bulletPrefab;
    public Transform firepoints;
    

    // Start is called before the first frame update
    void Start()
    {
      
     }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
           
            GameObject bullet = Instantiate(bulletPrefab, firepoints.position, firepoints.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.velocity = firepoints.forward * BulletSpeed;
        }

       

       
    }
}
