using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LastTeleportPlayer : MonoBehaviour
{
    public GameObject VideoPlayer;
    public float setTime;
    //public GameObject HUD;

    private void Start()
    {
        VideoPlayer.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //HUD.SetActive(false);
            VideoPlayer.SetActive(true);
            Destroy(VideoPlayer, setTime);

            StartCoroutine(LateCall());
        }
    }

    IEnumerator LateCall()
    {
        yield return new WaitForSeconds(setTime);
        //HUD.SetActive(true);

        SceneManager.LoadScene(1);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}