using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowBall : MonoBehaviour
{
    [SerializeField]
    private GameObject targetObject; 
    private Rigidbody rb;


    private Vector3 lastposition;
    private Vector3 currentvelosity;

    
    [SerializeField] private float spinSpeed = 30f; 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        lastposition = targetObject.transform.position;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Velocityの計算
        Vector3 currentposition = targetObject.transform.position;
        currentvelosity = (currentposition - lastposition) / Time.fixedDeltaTime;
        lastposition = currentposition;


    }
    public void OnSelect()
    {
        rb.isKinematic = true;
    }
    public void OnUnselect()
    {
        Debug.Log("手裏剣を離した");
        StartCoroutine(ReleaseAfterFrame());

    }

    private IEnumerator ReleaseAfterFrame()
    {
        yield return new WaitForFixedUpdate();

        rb.isKinematic = false;
        rb.useGravity = false; // 重力をOFFにして直進飛行に

        // 離したときの forward 方向に直進
        rb.velocity = currentvelosity * 5f;

        // 回転を Z軸方向にスピンさせる
        //rb.angularVelocity = transform.forward * spinSpeed;

        // 回転の安定化
        rb.drag = 0f;
        rb.angularDrag = 0f;
        rb.inertiaTensor = Vector3.one;
        rb.inertiaTensorRotation = Quaternion.identity;

        
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 的に当たった場合
        if (collision.gameObject.CompareTag("Target"))
        {
            GameManager.Instance.AddScore(10);
        }
        // 的以外に当たった場合
        else if (collision.gameObject.CompareTag("NonTarget"))
        {
            GameManager.Instance.AddScore(-5);
        }


        Destroy(gameObject); 
    }

}