using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public TextMeshProUGUI scoreText;
    public AudioClip pointSound;
    private AudioSource audioSource;
    public int score = 0;
    private UIManager uiManager;


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
        audioSource = GetComponent<AudioSource>();
        UpdateScoreText();

        uiManager = FindObjectOfType<UIManager>();
        if (uiManager == null)
        {
            Debug.LogError("No se encontró el UIManager en la escena.");
            return;
        }
    }

    public void AddScore(int value)
    {
        score += value;
        UpdateScoreText();
        audioSource.PlayOneShot(pointSound);
    }

    void UpdateScoreText()
    {
        scoreText.text = score.ToString();
    }
}