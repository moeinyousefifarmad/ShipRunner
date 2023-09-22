using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void onStartGameButton()
    {
        SceneManager.LoadScene("PrototypeLevel");
    }
    public void OnQuitGameButton()
    {
        Application.Quit();
    }

    public void OnMainMenuButton()
    {
        SceneManager.LoadScene("Menu");
    }
    public void OnRestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
