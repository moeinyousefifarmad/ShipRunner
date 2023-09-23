
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isPlayerDead { get; set; }
    public Vector2 lastCheckPointPosition;
    public float LastGravityScale;
    private PlayerController playerController;
    public bool haveCheckPoint;
    private void Awake()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
           //
        }
        else if(instance != null)
            Destroy(gameObject);

        isPlayerDead = false;
    }
    private void Update()
    {

        if (isPlayerDead)
        {
            //ResetPlayerPos();
            OnRestartButton();
            isPlayerDead = false;
        }
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

    private void ResetPlayerPos()
    {
        playerController.transform.position = lastCheckPointPosition;
        playerController.rb2d.gravityScale = LastGravityScale;
    }
}
