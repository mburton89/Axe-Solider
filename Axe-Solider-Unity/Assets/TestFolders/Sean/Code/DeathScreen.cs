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
    private GameObject _axeSoldierNoCamera;
    public Button ReloadButton;
    public Button QuitButton;
    private AudioSource _levelMusic;
    [SerializeField] private AudioSource _fail;
    private void Awake()
    {
        Instance = this;
        _axeSoldierNoCamera = FindObjectOfType<AxeSoldier>().gameObject;
    }

    private void Start()
    {
        _levelMusic = SoundManager.Instance.levelMusic;
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
        _axeSoldierNoCamera.SetActive(false);
        DeathScreenContainer.SetActive(true);
        _fail.Play();
        _levelMusic.Stop();
    }
    public void Deactivate()
    {
        HealthBar.SetActive(true);
        _axeSoldierNoCamera .SetActive(true);
        DeathScreenContainer.SetActive(false);
        _levelMusic.Play();
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
