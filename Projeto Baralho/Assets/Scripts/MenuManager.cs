using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private InventorySO inventory;
    public delegate void OnRestartGameHandler();
    public static event OnRestartGameHandler onRestart;
    public void PlayGame()
    {
        SceneManager.LoadScene("Quarto");
        AudioManager.Instance.PlayBGM("BGM");
    }

    public void QuitGame()
    {
        Debug.Log("Saiu do Jogo");
        Application.Quit();
    }

    public void PlayGameDelayed()
    {
        onRestart?.Invoke();
        DayNightSpriteSwitcher.isDay = false;
        Progression.ClearEvents();
        inventory.Reset();
        Invoke(nameof(PlayGame), .05f);
    }

    public void GoToMenuDelayed()
    {
        onRestart?.Invoke();
        DayNightSpriteSwitcher.isDay = false;
        Progression.ClearEvents();
        Invoke(nameof(GoToMenu), .05f);
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu");
        AudioManager.Instance.PlayBGM("MenuMusic");
    }

    public void ButtonClick()
    {
        AudioManager.Instance.PlaySound("MenuClick", Vector3.zero);
    }

}
