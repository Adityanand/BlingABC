using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManagerScript : MonoBehaviour {

    // Use this for initialization
    public void startGame()
    {
        SceneManager.LoadScene("main");
    }
    public void NewGame()
    {
        SceneManager.LoadScene("Level 2-1");
    }
    public void Restart()
    {
        SceneManager.LoadScene("main");
    }
    public void Restart1()
    {
        SceneManager.LoadScene("Level 2-1");
    }
    public void NewGame1()
    {
        SceneManager.LoadScene("Level 2-1");
    }
    public void Restart2()
    {
        SceneManager.LoadScene("Level 2-2");
    }
    public void NewGame2_2()
        {
        SceneManager.LoadScene("Level 2-2");
        }

    public void NewGame2()
    {
        SceneManager.LoadScene("Level 4-1");
    }
    public void NewGame3()
    {
        SceneManager.LoadScene("Level 4-2");
    }
    public void NewGame4()
    {
        SceneManager.LoadScene("Level 4-3");
    }
    public void Restart3()
    {
        SceneManager.LoadScene("Level 4-1");
    }
    public void Restart4()
    {
        SceneManager.LoadScene("Level 4-2");
    }
    public void Restart5()
    {
        SceneManager.LoadScene("Level 4-3");
    }
    public void Quit()
    {
        Application.Quit();
    }
}

