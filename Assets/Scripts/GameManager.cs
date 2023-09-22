
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isPlayerDead { get; set; }

    private void Awake()
    {
        isPlayerDead = false;
    }
    private void Update()
    {
        if (isPlayerDead)
            OnRestartButton();
    }
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
