
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using Unity.VisualScripting;
using UnityEditor;

public class Botão : MonoBehaviour
{
[SerializeField] private AudioClip play;
private AudioSource playSource;


    public void PlayGame()
    {
        SceneManager.LoadScene("fase 1");
    }

    public void SairGame()
    {
        Application.Quit();
    }

    public void Replay()
    {
        SceneManager.LoadScene("fase 1");
    }
    public void Replay2()
    {
        SceneManager.LoadScene("fase 2");
    }
    public void Creditos()
    {
        SceneManager.LoadScene("Créditos");
    }
    public void VoltarMenu()
    {
        if(playSource != null)
        {
            playSource.PlayOneShot(play);
        }
        
        SceneManager.LoadScene("Menu");

    }

    


}

