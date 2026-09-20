using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static GameManager;

public class UiWinTieMenu : MonoBehaviour
{
    [Header("Canvas WinTie")]
    [SerializeField] private GameObject canvasGameOver;

    [Header("Canvas WinTie Text")]
    [SerializeField] private TMP_Text textPlayerPoints;

    [Header("Retry Button")]
    [SerializeField] private Button btnRetry;
    [SerializeField] private Button btnExit;

    private void Awake()
    {
        btnExit.onClick.AddListener(OnExitClicked);
        btnRetry.onClick.AddListener(OnRetryClicked);
    }

    private void Update()
    {
        //// Si la vida del jugador llegó a 0
        //if (GameManager.Instance.GetPlayerHealth() <= 0)
        //{
        //    // Detengo el juego
        //    Time.timeScale = 0;

        //    // Activo el canvas de ganar o empatar
        //    canvasWinTie.SetActive(true);
        //}
    }

    private void OnDestroy()
    {
        btnExit.onClick.RemoveAllListeners();
        btnRetry.onClick.RemoveAllListeners();
    }

    // Eventos de botones
    private void OnRetryClicked()
    {
        // Reseteo el puntaje del jugador
        //GameManager.Instance.ResetPlayersPoints();

        // Reanudo el tiempo del juego
        Time.timeScale = 1;

        // Desactivo el panel de WinTie
        canvasGameOver.SetActive(false);
    }

    private void OnExitClicked()
    {
        // Reseteo el puntaje del jugador
        //GameManager.Instance.ResetPlayersPoints();

        // Reanudo el tiempo del juego
        Time.timeScale = 1;

        // Desactivo el panel de WinTie
        canvasGameOver.SetActive(false);

        // Cargo la escena "MainMenu"
        SceneManager.LoadScene("MainMenu");
    }
}
