using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public void StartGameMrsRunner()
    {
        SceneManager.LoadScene("Scene1");
    }
    public void StartGameMrRunner()
    {
        SceneManager.LoadScene("Scene2");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
