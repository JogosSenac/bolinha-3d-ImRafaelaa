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
    [SerializeField] private bool estaVivo = true;
    [SerializeField] private bool estaPulando = false;
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

        if(Input.GetKeyDown(KeyCode.Space) && !estaPulando)
        {
            rb.AddForce(transform.up * forcaPulo, ForceMode.Impulse);
            estaPulando = true;
        }
    }
        private void OnCollisionEnter(Collision other)
        {
            if(other.gameObject.CompareTag("chão"))
            {
                estaVivo = false;
            }
            if(other.gameObject.CompareTag("solo"));
            {
                estaPulando = false;
            }
        }

        

    public bool VerificaSePlayerEstaVivo()
    {
        return estaVivo;
    }
}
