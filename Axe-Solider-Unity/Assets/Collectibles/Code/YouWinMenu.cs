using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using TMPro;

public class YouWinMenu : MonoBehaviour
{
    public static YouWinMenu Instance;
    public GameObject container;
    public Button restartButton;
    public Button dismissButton;
    public TextMeshProUGUI winMessage;
    public AudioSource audioSource;

    private float _animationSpeed = .25f;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Show("Hey, you cheated!");
        }
    }

    private void OnEnable()
    {
        restartButton.onClick.AddListener(HandleRestartPressed);
        dismissButton.onClick.AddListener(Hide);
    }

    private void OnDisable()
    {
        restartButton.onClick.RemoveListener(HandleRestartPressed);
        dismissButton.onClick.RemoveListener(Hide);
    }

    void HandleRestartPressed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Show(string message)
    {
        container.SetActive(true);
        transform.localScale = Vector3.zero;
        transform.DOScale(1, _animationSpeed).SetEase(Ease.OutBack);
        StartCoroutine(ShowNextButton());
        winMessage.SetText(message);
        audioSource.Play();
    }

    public void Hide()
    {
        container.SetActive(false);
    }

    private IEnumerator ShowNextButton()
    {
        restartButton.gameObject.SetActive(false);
        dismissButton.gameObject.SetActive(false);
        yield return new WaitForSeconds(2);
        restartButton.gameObject.SetActive(true);
        dismissButton.gameObject.SetActive(true);
        restartButton.transform.DOShakeScale(_animationSpeed, 1, 10, 90, true);
        dismissButton.transform.DOShakeScale(_animationSpeed, 1, 10, 90, true);
    }
}