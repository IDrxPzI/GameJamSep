using System;
using System.Linq;
using TMPro;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuHandler : MonoBehaviour
{
    [SerializeField] private InputActionAsset player;

    [SerializeField] private Button upgrade;
    [SerializeField] private Button recycle;

    [SerializeField] private TextMeshProUGUI ReoRecyclePoints;
    [SerializeField] private TextMeshProUGUI trashPoints;

    [Header("Windows")] [SerializeField] private GameObject crosshair;
    [SerializeField] private GameObject shopWindow;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject showInfoUI;

    [SerializeField] private GameObject credits;

    /// <summary>
    /// starts the first level of the game
    /// </summary>
    public void StartGame()
    {
        SceneManager.LoadSceneAsync("Level1");
        Debug.Log("loaded level1 ");
    }

    /// <summary>
    /// opens level selection menu
    /// </summary>
    public void OpenLevelSelection()
    {
        SceneManager.LoadSceneAsync("LevelSelection");
    }

    /// <summary>
    /// closes the game
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }


    public void OpenShopWindow()
    {
        showInfoUI.SetActive(false);
        player.Disable();

        shopWindow.SetActive(true);
        crosshair.SetActive(false);


        Cursor.lockState = CursorLockMode.None;
    }

    public void CloseShopWindow()
    {
        player.Enable();

        shopWindow.SetActive(false);
        showInfoUI.SetActive(true);
        crosshair.SetActive(true);

        Cursor.lockState = CursorLockMode.Locked;
    }

    public void UpgradeWeapon()
    {
    }

    public void ChangeCurrency()
    {
    }


    public void RestartGame()
    {
        SceneManager.LoadSceneAsync("Level_1");
    }

    private void Update()
    {
        if (EnemyDrops.amountReoRecycle < 10)
        {
            //recycle.interactable = false;
        }
        else
        {
           // recycle.interactable = true;
        }

        if (EnemyDrops.amountReoRecycle < 10)
        {
           // upgrade.interactable = false;
        }
        else
        {
            //upgrade.interactable = true;
        }

        if (PlayerMovement.openMenu)
        {
            OpenPauseMenu();
        }

        if (PlayerMovement.openShopMenu)
        {
            OpenShopWindow();
        }
    }

    public void OnRecycleClick()
    {
        EnemyDrops drops = new EnemyDrops();
        //drops.TrashPoints - 10;
    }

    /// <summary>
    /// opens credits window
    /// </summary>
    public void OpenCredits()
    {
        credits.SetActive(true);
    }

    /// <summary>
    /// closes credit window
    /// </summary>
    public void CloseCredits()
    {
        credits.SetActive(false);
    }

    /// <summary>
    /// opens the main menu
    /// </summary>
    public void OpenPauseMenu()
    {
        player.Disable();

        pauseMenu.SetActive(true);

        //SceneManager.LoadSceneAsync("MainMenu");
        //Debug.Log("Back to menu");

        Cursor.lockState = CursorLockMode.None;
    }

    public void ClosePauseMenu()
    {
        player.Enable();

        pauseMenu.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
    }
}