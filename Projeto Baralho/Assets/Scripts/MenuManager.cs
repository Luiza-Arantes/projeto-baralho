using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Quarto");
    }

    public void QuitGame()
    {
        Debug.Log("Saiu do Jogo");
        Application.Quit();
    }

    public void ButtonClick()
    {
        AudioManager.Instance.PlaySound("MenuClick", Vector3.zero);
    }

}
