using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private float speedY;
    [SerializeField] private float speedX;
    private MeshRenderer rend;
    private Rigidbody rb;
    private TextMeshProUGUI textoPontos;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<MeshRenderer>();
        rb = GetComponent<Rigidbody>();
        //textoPontos = GameObject.FindGameObjectsWithTag("Pontos").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        rend.material.mainTextureOffset = new Vector2(speedX * Time.timeSinceLevelLoad, speedY * Time.timeSinceLevelLoad);
    }
}

   
