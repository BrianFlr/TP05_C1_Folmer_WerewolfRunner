using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiMainMenu : MonoBehaviour
{
    [Header("Canvas")]
    [SerializeField] private GameObject mainMenuCanvas;
    [SerializeField] private GameObject settingsCanvas;
    [SerializeField] private GameObject creditsCanvas;

    [Header("Buttons")]
    [SerializeField] private Button btnStart;
    [SerializeField] private Button btnSettings;
    [SerializeField] private Button btnCredits;
    [SerializeField] private Button btnExit;

    private void Awake()
    {
        btnStart.onClick.AddListener(OnStartClicked);
        btnSettings.onClick.AddListener(OnSettingsClicked);
        btnCredits.onClick.AddListener(OnCreditsClicked);
        btnExit.onClick.AddListener(OnExitClicked);
    }

    private void Start()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        btnExit.gameObject.SetActive(false);
#endif
    }

    private void OnDestroy()
    {
        btnStart.onClick.RemoveAllListeners();
        btnSettings.onClick.RemoveAllListeners();
        btnCredits.onClick.RemoveAllListeners();
        btnExit.onClick.RemoveAllListeners();
    }

    // Eventos de botones
    private void OnStartClicked()
    {
        AudioManagerUi.Instance.PlayButtonSound();

        //// Vuelvo a correr el contador de tiempo del limite para anotar
        //if (GameManager.Instance != null)
        //{
        //    GameManager.Instance.ResetTimerOffState();
        //}

        // Cargo la escena de juego
        SceneManager.LoadScene("Gameplay");
    }

    private void OnSettingsClicked()
    {
        AudioManagerUi.Instance.PlayButtonSound();

        // Activo el canvas settings
        settingsCanvas.SetActive(true);
    }

    private void OnCreditsClicked()
    {
        AudioManagerUi.Instance.PlayButtonSound();

        // Activo el canvas credits
        creditsCanvas.SetActive(true);
    }

    private void OnExitClicked()
    {
        AudioManagerUi.Instance.PlayButtonSound();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
