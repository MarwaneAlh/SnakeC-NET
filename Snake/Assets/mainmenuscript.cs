using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class mainmenuscript : MonoBehaviour
{
    /*
     * Methode qui sert a gerer l'action du bouton quit
     * Elle quitte l'application
     */

    public void ExitButton()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
       
    }

    /*
     * Methode qui sert a gerer l'action du bouton start
     * Elle lance la scene de jeux
     */

    public void StartGame()
    {
        SceneManager.LoadScene("SnakeGame");
    }
}
