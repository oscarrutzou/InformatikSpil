using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//For at kunne loade den n�ste i r�kken
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Start spil
    public void PlayGame()
    {
        //Loader den n�ste i build index
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    //Stopper spilet 
    public void QuitGame()
    {
        Application.Quit();
    }
}
