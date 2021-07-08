using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMenuUI;


    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (gameIsPaused) {
                Resume();
            } else {
                Pause();
            }
        }
    }

    public void Resume() {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }
    

    void Pause() {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void LoadMenu() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MenuScene");
    }

    public void QuitGame() {
        Application.Quit();
    }

    public void TogglePause() {
        if (gameIsPaused) {
            gameIsPaused = false;
            Time.timeScale = 1f;
        } else {
            gameIsPaused = true;
            Time.timeScale = 0f;
        }
    }
}

/*
    Pause menu code received from Brackeys Tutorial
    https://www.youtube.com/watch?v=JivuXdrIHK0
*/