using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameoversciprt : MonoBehaviour
{
   public void mainmenuButtonAction()
    {
        SceneManager.LoadScene("MainMenu");
    }
    

    
    public void restartbuttonaction()
    {
        SceneManager.LoadScene("SnakeGame");
    }


    public void quitbuttonaction()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

}
