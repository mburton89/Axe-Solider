using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public static DeathScreen Instance;
    public GameObject DeathScreenContainer;
    public GameObject HealthBar;
    public GameObject AxeSoldierNoCamera;
    public Button ReloadButton;
    public Button QuitButton;
    public AudioSource LevelMusic;
    [SerializeField] private AudioSource _fail;

    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        ReloadButton.onClick.AddListener(Reload);
        QuitButton.onClick.AddListener(QuitGame);
    }

    private void OnDisable()
    {
        ReloadButton.onClick.RemoveListener(Reload);
        QuitButton.onClick.RemoveListener(QuitGame);
    }

    public void Activate()
    {
        HealthBar.SetActive(false);
        AxeSoldierNoCamera.SetActive(false);
        DeathScreenContainer.SetActive(true);
        _fail.Play();
        LevelMusic.Stop();
    }

    public void Deactivate()
    {
        HealthBar.SetActive(true);
        AxeSoldierNoCamera.SetActive(true);
        DeathScreenContainer.SetActive(false);
        LevelMusic.Play();
    }

    void Reload()
    {
        AxeSoldier.Instance.RespawnPlayer();
        Deactivate();
    }

    void QuitGame()
    {
        SceneManager.LoadScene(0);
    }
}
