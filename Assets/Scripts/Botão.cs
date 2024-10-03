
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Botão : MonoBehaviour
{
    

    public void PlayGame()
    {
        SceneManager.LoadScene("jogo");
    }

    public void SairGame()
    {
        Application.Quit();
    }


}

