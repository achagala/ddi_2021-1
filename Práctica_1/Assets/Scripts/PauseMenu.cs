using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{   
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject controlPanel;
    public GameObject statsPanel;
    public GameObject inventoryUI;


    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        statsPanel.SetActive(true);
        controlPanel.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused =  false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        statsPanel.SetActive(false);
        controlPanel.SetActive(false);
        inventoryUI.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Quit()
    {
        Debug.Log("Quitting game...");
    }

    public void Inventory()
    {
        inventoryUI.SetActive(!inventoryUI.activeSelf);
    }
}
