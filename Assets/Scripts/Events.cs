using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Events : MonoBehaviour
{
    public void ReplayGameMrsRunner()
    {
        SceneManager.LoadScene("Scene1");
    }
    public void ReplayGameMrRunner()
    {
        SceneManager.LoadScene("Scene2");
    }
}
