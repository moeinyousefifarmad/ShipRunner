using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelButtons : MonoBehaviour
{
    public void onStartGameButton()
    {
        SceneManager.LoadScene("Pt_level_01");
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
