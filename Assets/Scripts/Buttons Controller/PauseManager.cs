using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseManager : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject pausePanel;     
    public GameObject settingsPanel;  

    [Header("Disable On Pause")]
    public MonoBehaviour[] disableOnPause; 

    bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!isPaused)            EnterPause();
            else if (settingsPanel.activeSelf) CloseSettings();
            else                      ExitPause();
        }
    }
    public void Resume()
{
    ExitPause();
}

    void EnterPause()
    {
        isPaused = true;
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
        settingsPanel.SetActive(false);

        
        foreach (var comp in disableOnPause)
            if (comp != null) comp.enabled = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible   = true;
    }

    void ExitPause()
    {
        isPaused = false;
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
        settingsPanel.SetActive(false);

        // re-enable them
        foreach (var comp in disableOnPause)
            if (comp != null) comp.enabled = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible   = false;
    }

    // Buttons call these:
    public void OpenSettings()
    {
        if (!isPaused) return;
        pausePanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
        pausePanel.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }
}
