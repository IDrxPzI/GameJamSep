using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_Handler : MonoBehaviour
{
    public AudioSource ad;
    public Animator anim;
    public void StartGame()
    {
        ad.Play();
        anim.SetTrigger("start");
        Invoke("loadWorld", 2);
    }

    public void LoadCredits()
    {
        ad.Play();
        anim.SetTrigger("start");
        Invoke("loadCredits", 2);
    }
    
    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    void loadWorld()
    {
        SceneManager.LoadScene(1);
    }

    void loadCredits()
    {
        SceneManager.LoadScene(2);
    }

    public void BackTOHauptmenues()
    {
        SceneManager.LoadScene(0);
    }
}
