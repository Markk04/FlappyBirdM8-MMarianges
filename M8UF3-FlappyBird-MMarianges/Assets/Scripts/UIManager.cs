using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    private float timer = 0f;

    void Start()
    {

    }

    void Update()
    {
        // Actualizar el temporizador
        timer += Time.deltaTime;
        UpdateTimerText();
    }


    private void UpdateTimerText()
    {
        // Calcular los minutos y segundos del temporizador
        int minutes = Mathf.FloorToInt(timer / 60f);
        int seconds = Mathf.FloorToInt(timer % 60f);

        // Actualizar el texto del temporizador
        timerText.text = "Time: " + minutes.ToString("00") + ":" + seconds.ToString("00");
    }
}
