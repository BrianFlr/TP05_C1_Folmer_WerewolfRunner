using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiGameOverMenu : MonoBehaviour
{
    [Header("Canvas GameOver")]
    [SerializeField] private GameObject canvasGameOver;

    [Header("Canvas GameOver Text")]
    [SerializeField] private TMP_Text textPlayerPoints;

    [Header("Buttons")]
    [SerializeField] private Button btnRetry;
    [SerializeField] private Button btnExit;

    private void Awake()
    {
        btnExit.onClick.AddListener(OnExitClicked);
        btnRetry.onClick.AddListener(OnRetryClicked);
    }

    private void Start()
    {
        // Muestro los puntos del player
        textPlayerPoints.text = GameManager.Instance.GetPlayerPoints().ToString("0");
    }

    private void Update()
    {
        // Si la vida del jugador llegó a 0
        if (GameManager.Instance.GetPlayerHealth() <= 0)
        {
            // Detengo el juego
            Time.timeScale = 0;

            // Activo el canvas de ganar o empatar
            canvasGameOver.SetActive(true);
        }
    }

    private void OnDestroy()
    {
        btnExit.onClick.RemoveAllListeners();
        btnRetry.onClick.RemoveAllListeners();
    }

    // Eventos de botones
    private void OnRetryClicked()
    {
        // Reseteo la escena Gameplay
        SceneManager.LoadScene("Gameplay");

        // Reanudo el tiempo del juego
        Time.timeScale = 1;

        // Desactivo el panel de WinTie
        canvasGameOver.SetActive(false);
    }

    private void OnExitClicked()
    {
        // Reanudo el tiempo del juego
        Time.timeScale = 1;

        // Desactivo el panel de WinTie
        canvasGameOver.SetActive(false);

        // Cargo la escena "MainMenu"
        SceneManager.LoadScene("MainMenu");
    }
}
