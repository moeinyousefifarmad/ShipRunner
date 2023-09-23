
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isPlayerDead { get; set; }
    public Vector2 lastCheckPointPosition;
    public float LastGravityScale;
    private int sCount;
    public bool haveCheckPoint;
    private void Awake()
    {
        sCount = SceneManager.sceneCount;
        
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else if(instance != null)
            Destroy(gameObject);

        isPlayerDead = false;
    }
    private void Update()
    {

        if (isPlayerDead)
        {
            OnRestartButton();
            isPlayerDead = false;
        }
    }
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

    public void GoNextLevel()
    {
        sCount++;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
