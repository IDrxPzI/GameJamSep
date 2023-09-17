using System;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuHandler : MonoBehaviour
{
    [SerializeField] private InputActionAsset player;

    [SerializeField] private GameObject weapon;

    [SerializeField] private GameObject[] weaponPrefab;

    [SerializeField] private Button upgrade;
    [SerializeField] private Button recycle;

    [SerializeField] private TextMeshProUGUI ReoRecyclePoints;
    [SerializeField] private TextMeshProUGUI trashPoints;

    [Header("Windows")][SerializeField] private GameObject crosshair;
    [SerializeField] private GameObject shopWindow;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject showInfoUI;

    [SerializeField] private GameObject credits;


    private static int weaponUpgradeCount = 0;

    public GameObject audioSource;

    public void playButtonSound()
    {
        if (audioSource != null)
        {
            audioSource.GetComponent<AudioSource>().PlayOneShot(GetComponent<AudioSource>().clip);

        }
    }

    /// <summary>
    /// starts the first level of the game
    /// </summary>
    public void StartGame()
    {
        playButtonSound();
        SceneManager.LoadSceneAsync("Level1");
        Debug.Log("loaded level1 ");
    }

    /// <summary>
    /// opens level selection menu
    /// </summary>
    public void OpenLevelSelection()
    {
        playButtonSound();
        SceneManager.LoadSceneAsync("LevelSelection");
    }

    /// <summary>
    /// closes the game
    /// </summary>
    public void QuitGame()
    {
        playButtonSound();
        Application.Quit();
    }


    public void OpenShopWindow()
    {
        playButtonSound();
        showInfoUI.SetActive(false);
        player.Disable();

        shopWindow.SetActive(true);
        crosshair.SetActive(false);


        Cursor.lockState = CursorLockMode.None;
    }

    public void CloseShopWindow()
    {
        playButtonSound();
        player.Enable();

        shopWindow.SetActive(false);
        showInfoUI.SetActive(true);
        crosshair.SetActive(true);

        Cursor.lockState = CursorLockMode.Locked;
    }

    public void UpgradeWeapon()
    {
        playButtonSound();
        Weapon.currentWeapon++;
        for (int i = 0; i <= weaponUpgradeCount; i++)
        {
            weaponPrefab[i + 1].SetActive(true);
            weaponPrefab[i].SetActive(false);
            //GameEvents.Instance.TargetHitEvent();
        }

        weaponUpgradeCount++;
        EnemyDrops.amountReoRecycle -= 10;
    }

    public void RestartGame()
    {
        playButtonSound();
        SceneManager.LoadSceneAsync("Level_1");
    }

    private void Update()
    {
        if (EnemyDrops.amountTrash < 10)
        {
            recycle.interactable = false;
        }
        else
        {
            recycle.interactable = true;
        }

        if (EnemyDrops.amountReoRecycle < 10)
        {
            upgrade.interactable = false;
        }
        else
        {
            upgrade.interactable = true;
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
        playButtonSound();
        EnemyDrops.amountTrash -= 10;
        EnemyDrops.amountReoRecycle += 1;
    }

    /// <summary>
    /// opens credits window
    /// </summary>
    public void OpenCredits()
    {
        playButtonSound();
        credits.SetActive(true);
    }

    /// <summary>
    /// closes credit window
    /// </summary>
    public void CloseCredits()
    {
        playButtonSound();
        credits.SetActive(false);
    }

    /// <summary>
    /// opens the main menu
    /// </summary>
    public void OpenPauseMenu()
    {
        playButtonSound();
        player.Disable();

        pauseMenu.SetActive(true);

        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
    }

    public void OpenMainMenu()
    {
        playButtonSound();
        SceneManager.LoadSceneAsync("MainMenu");
    }

    public void ClosePauseMenu()
    {
        playButtonSound();
        player.Enable();


        pauseMenu.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1;
    }
}