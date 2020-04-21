using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sceneLoader : MonoBehaviour
{
    public void GoToLevel(int level)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(level);
    }
}
