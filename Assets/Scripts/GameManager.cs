
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isPlayerDead { get; set; }
    public Vector2 lastCheckPointPosition;
    public float LastGravityScale;
    public bool haveCheckPoint;
    private void Awake()
    {
        
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
 
    public void OnRestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void GoNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
