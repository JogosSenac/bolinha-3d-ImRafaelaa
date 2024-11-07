using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;
using System.Xml.Serialization;


public class BolinhaMove : MonoBehaviour
{
    private float moveH;
    private float moveV;
    private Rigidbody rb;
    [SerializeField] private float velocidade;
    [SerializeField] private float forcaPulo;
    [SerializeField] private bool estaVivo = true, estaPulando = false, fases = false; 
    [SerializeField] private AudioSource sfx;
    [SerializeField] private AudioSource morte;
    private TextMeshProUGUI textoPontos;
    private TextMeshProUGUI pontoTotal;
    private GameObject telaGameOver, telaFinal;
    private GameObject outraFase;

    [Header("Emojis")]
    [SerializeField] private List<Sprite> emojis = new List<Sprite>();
  
    private float pontos = 0;
    void Start()
    {
        List<int> emojis = new List<int>(3);
        rb = GetComponent<Rigidbody>();
        sfx = GetComponent<AudioSource>();
        morte = GetComponent<AudioSource>();
        textoPontos = GameObject.Find("Pontos").GetComponent<TextMeshProUGUI>();
        pontoTotal = GameObject.Find("pontoTotal").GetComponent<TextMeshProUGUI>();
        pontoTotal.text = GameObject.FindGameObjectsWithTag("Moeda").Length.ToString();
        telaFinal = GameObject.Find("Final");
        telaFinal.SetActive(false);
        telaGameOver = GameObject.Find("Morte");
        telaGameOver.SetActive(false);
        outraFase = GameObject.Find("OutraFase");
    }
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
            VerificaObjetivos();

            

    }
        void OnCollisionEnter(Collision other)
        {
            if(other.gameObject.CompareTag("chão"))
            {
                estaVivo = false;
                gameObject.SetActive(false);
                telaGameOver.SetActive(true);
                morte.Play();
            

            }
            if(other.gameObject.CompareTag("solo"))
            {
                estaPulando = false;
                
            }
            if(other.gameObject.CompareTag("Moeda"))
            {
                other.gameObject.SetActive(false);
                sfx.Play();
                pontos++;
                textoPontos.text = pontos.ToString();
            }
                else
                {
                    sfx.Stop();
                }

            if(other.gameObject.CompareTag("fase"))
            {
                int TotalPontos = Int32.Parse(pontoTotal.text);
                if(pontos == TotalPontos)
                {
                    SceneManager.LoadScene("Fase 2");
                }
                
            }
            if(other.gameObject.CompareTag("fase1"))
            {
                int TotalPontos = Int32.Parse(pontoTotal.text);
                if(pontos == TotalPontos)
                {
                    telaFinal.SetActive(true);
                }
                
            }
        
            
        }
    public bool VerificaSePlayerEstaVivo()
    {
        return estaVivo;
    }

    private void VerificaObjetivos()
    {
        int TotalPontos = Int32.Parse(pontoTotal.text);
        TextMeshProUGUI objetivo = GameObject.Find("Objetivo").GetComponent<TextMeshProUGUI>();
        Image emoji = GameObject.Find("Emoji").GetComponent<Image>();
        
        Debug.LogFormat($"Pontos: {pontos}, Total Cubos: {TotalPontos}");
        if(pontos < TotalPontos)
        {
            emoji.sprite = emojis[0];
            objetivo.text = "Pegue todos as moedas!";
        }
        if (pontos >=  TotalPontos/2)
        {
            emoji.sprite = emojis[1];
            objetivo.text = "Quase lá!";
        }
        if(pontos == TotalPontos)
        {
            emoji.sprite = emojis[2];
            objetivo.text = "Todas as moedas foram coletas. passagem livre!";

        }
    }
}

