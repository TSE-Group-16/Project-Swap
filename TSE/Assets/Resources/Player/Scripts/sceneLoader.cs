using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sceneLoader : MonoBehaviour
{
    public void GoToLevel(int level)
    {
        //Load the scene index from the given int
        UnityEngine.SceneManagement.SceneManager.LoadScene(level);
    }
}
