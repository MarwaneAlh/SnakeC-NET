using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class mainmenuscript : MonoBehaviour
{public void ExitButton()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
       
    }

    public void StartGame()
    {
        SceneManager.LoadScene("SnakeGame");
    }
}
