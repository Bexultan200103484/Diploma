using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using Cinemachine;

public class PauseMenu : MonoBehaviour
{
    public bool PauseGame;
    public GameObject pauseGameMenu;
    private GameEntryMenu gameEntryMenu;
    public bool IsPlaneDestroyed = false;

    void Start()
    {
        gameEntryMenu = FindObjectOfType<GameEntryMenu>();
        // pauseGameMenu.GetComponentInChildren<Toggle>().isOn = PlayerPrefs.GetInt("MusicEnabled", 1) == 1;
        // pauseGameMenu.GetComponentInChildren<Slider>().value = PlayerPrefs.GetFloat("MasterVolume", 1);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PauseGame)
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
        pauseGameMenu.SetActive(false);
        Time.timeScale = 1f;
        PauseGame = false;
    }

    public void Pause()
    {
        pauseGameMenu.SetActive(true);
        Time.timeScale = 0f;
        PauseGame = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        IsPlaneDestroyed = true;
        foreach (CinemachineVirtualCamera v in gameEntryMenu.gameCameras)
        {
            v.Priority = 0;
        }
        gameEntryMenu.gameCameras[4].Priority = 1;
        gameEntryMenu.DeletePlane();
        // SceneManager.LoadScene("MainMenu");
    }
    // public void ToggleMusic(bool enabled)
    // {
    //     if (enabled)
    //         Mixer.audioMixer.SetFloat("MasterVolume", 0);
    //     else
    //         Mixer.audioMixer.SetFloat("MasterVolume", -80);

    //     PlayerPrefs.SetInt("MusicEnabled", enabled ? 1 : 0);
    // }
    // public void ChangeMasterVolume(float volume)
    // {
    //     Mixer.audioMixer.SetFloat("MusicVolume", Mathf.Lerp(-80, 0, volume));
    //     PlayerPrefs.SetFloat("MasterVolume", volume);
    // }
}
