using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    //Til at vide om spillet er paused
    public static bool gameIsPaused = false;

    public GameObject pauseMenuUI;


    void Update()
    {
        //Hvis der er trykket escape første gang pauser den eller starter den igen.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        //Slukker objectet
        pauseMenuUI.SetActive(false);
        //Starter tiden igen
        Time.timeScale = 1f;
        //Sætter den til at spillet ikke er pauset mere.
        gameIsPaused = false;
    }

    void Pause()
    {
        //Tænder objectet
        pauseMenuUI.SetActive(true);
        //Stopper alt undtagen PauseUI
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void LoadMenu()
    {
        //Starter tiden igen
        Time.timeScale = 1f;
        //Sender brugeren tilbage til den tidligere scene som er menu
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    //Stopper spillet.
    public void QuitGame()
    {
        Application.Quit();
    }
}
