using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void LoadLevel1(){
        this.gameObject.SetActive(false);
        Singleton.instance.levelCounter++;
        Singleton.instance.textPanel.SetActive(true);
        SceneManager.LoadScene("Level1");
    }

    public void LoadMainMenu(){
        this.gameObject.SetActive(false);
        Singleton.instance.textPanel.SetActive(false);
        SceneManager.LoadScene("MainMenu");
    }
}
