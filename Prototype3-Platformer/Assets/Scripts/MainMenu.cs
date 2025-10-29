using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void onPlayButton()
    {
        SceneManager.LoadScene("Level_1");
    }
    public void onQuitButton()
    {
        Application.Quit();
    }
}
