using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameoversciprt : MonoBehaviour
{
    /*Attribut servant a recuperer le Text du score dans l'UI
     * 
     */
    public Text TextScore;


    /*Methode servant a fair le lien entre le score de la scene précedente et celle de la scene 
     * de GameOver
     * 
     */

    private void Start()
    {
        TextScore = GameObject.Find("Canvas/TextScore").GetComponent<Text>();
        TextScore.text = "Score : "+ SnakeGameScript.score.ToString();
    }

    /*
     * Methode qui gere l'action d'appuyer sur le boutton main
     * Elle relance la scene du menu principal
     */
   public void mainmenuButtonAction()
    {
        SceneManager.LoadScene("MainMenu");
    }


    /*
     * Methode qui gere l'action d'appuyer sur le boutton restart
     * Elle relance la scene de jeux
     */

    public void restartbuttonaction()
    {
        Debug.Log("PETIT ETETSF");
        SceneManager.LoadScene("SnakeGame");
    }

    /*
     * Methode qui gere l'action d'appuyer sur le boutton quit
     * Elle quitte l'application
     */

    public void quitbuttonaction()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

}
