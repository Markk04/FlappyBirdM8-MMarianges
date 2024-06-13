using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;

    public GameObject startMenu;
    public GameObject inGameMenu;
    public GameObject gameOverMenu;
    public TextMeshProUGUI scoreText;
    public AudioClip gameOverSound;
    private AudioSource audioSource;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Obtener el componente AudioSource
        ShowStartMenu();
    }

    public void ShowStartMenu()
    {
        startMenu.SetActive(true);
        inGameMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        Time.timeScale = 0f;
    }

    public void HideStartMenu()
    {
        startMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void StartGame()
    {
        inGameMenu.SetActive(true);
    }

    public void ShowGameOverMenu()
    {
        inGameMenu.SetActive(false);
        gameOverMenu.SetActive(true);
        scoreText.text = "Final Score: " + GameManager.Instance.score.ToString(); 
        Time.timeScale = 0f;
        
        // Reproducir el sonido de Game Over
        audioSource.PlayOneShot(gameOverSound);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void HideGameOverMenu()
    {
        gameOverMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (startMenu.activeSelf && (Input.GetKeyDown(KeyCode.X) || Input.GetMouseButtonDown(0)))
        {
            HideStartMenu();
            StartGame();
        }
        else if (gameOverMenu.activeSelf && (Input.GetKeyDown(KeyCode.X) || Input.GetMouseButtonDown(0)))
        {
            RestartGame();
        }
    }
}
