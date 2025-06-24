using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMover : MonoBehaviour
{
    public float movespeed = 2f;
    public float changeDirectionTime = 2f;
    private Vector3 moveDirection;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveDirection * movespeed *  Time.deltaTime,Space.World);

        timer += Time.deltaTime;
        if (timer >= changeDirectionTime )
        {
            SetRandomDirection();
            timer = 0;
        }
    }

    void SetRandomDirection()
    {

    }
}
