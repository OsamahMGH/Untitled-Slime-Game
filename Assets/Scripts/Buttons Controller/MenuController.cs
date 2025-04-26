using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject settingsPanel;
    public Slider volumeSlider;
    public Slider brightnessSlider;
    public Image brightnessOverlay;

    private void Start()
    {
        
        if (PlayerPrefs.HasKey("Volume"))
        {
            float savedVolume = PlayerPrefs.GetFloat("Volume");
            volumeSlider.value = savedVolume;
            AudioListener.volume = savedVolume;
        }
        else
        {
            volumeSlider.value = 1f;
            AudioListener.volume = 1f;
        }

        
        if (PlayerPrefs.HasKey("Brightness"))
        {
            float savedBrightness = PlayerPrefs.GetFloat("Brightness");
            brightnessSlider.value = savedBrightness;
            SetBrightness(savedBrightness);
        }
        else
        {
            brightnessSlider.value = 1f;
            SetBrightness(1f);
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void OpenSettings()
    {
        mainMenuPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    public void ChangeVolume(float value)
{
    AudioListener.volume = value;
    PlayerPrefs.SetFloat("Volume", value);
    Debug.Log($"Volume now: {value}");
}

  public void SetBrightness(float value)
{
    value = Mathf.Clamp(value, 0.5f, 1f);
    Color c = brightnessOverlay.color;
    c.a = 1f - value;
    brightnessOverlay.color = c;
    PlayerPrefs.SetFloat("Brightness", value);
    Debug.Log($"Brightness now: {value}, alpha: {c.a}");
}

public void SetFullscreen(bool isFullscreen)
{
    Screen.fullScreen = isFullscreen;
    
}
}
