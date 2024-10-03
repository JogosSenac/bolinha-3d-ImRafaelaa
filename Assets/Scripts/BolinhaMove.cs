using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolinhaMove : MonoBehaviour
{
    private float moveH;
    private float moveV;
    private Rigidbody rb;
    [SerializeField] private float velocidade;
    [SerializeField] private float forcaPulo;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        moveH = Input.GetAxis("Horizontal");
        moveV = Input.GetAxis("Vertical");

        transform.position += new Vector3 (moveH *-1 * velocidade * Time.deltaTime, 0, -1 * moveV * velocidade * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.up * forcaPulo, ForceMode.Impulse);
        }
    }
}
