using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

}
