using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // TODO: MAKE IT SUCH THAT LEVEL LIST SCENE LOADS
    public void PlayGame() 
    {
        // TODO: WRITE THAT SCENE NAME  
        SceneManager.LoadScene("");
    }

    public void QuitGame() 
    {
        Application.Quit();
    }
}
