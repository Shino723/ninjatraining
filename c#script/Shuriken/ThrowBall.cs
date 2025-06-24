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
        //Velocity�̌v�Z
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
        Debug.Log("�藠���𗣂���");
        StartCoroutine(ReleaseAfterFrame());

    }

    private IEnumerator ReleaseAfterFrame()
    {
        yield return new WaitForFixedUpdate();

        rb.isKinematic = false;
        rb.useGravity = false; // �d�͂�OFF�ɂ��Ē��i��s��

        // �������Ƃ��� forward �����ɒ��i
        rb.velocity = currentvelosity * 5f;

        // ��]�� Z�������ɃX�s��������
        //rb.angularVelocity = transform.forward * spinSpeed;

        // ��]�̈��艻
        rb.drag = 0f;
        rb.angularDrag = 0f;
        rb.inertiaTensor = Vector3.one;
        rb.inertiaTensorRotation = Quaternion.identity;

        
    }

    private void OnCollisionEnter(Collision collision)
    {
        // �I�ɓ��������ꍇ
        if (collision.gameObject.CompareTag("Target"))
        {
            GameManager.Instance.AddScore(10);
        }
        // �I�ȊO�ɓ��������ꍇ
        else if (collision.gameObject.CompareTag("NonTarget"))
        {
            GameManager.Instance.AddScore(-5);
        }


        Destroy(gameObject); 
    }

}