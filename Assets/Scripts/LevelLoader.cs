using UnityEngine;
using System.Collections;

public class LevelLoader : MonoBehaviour {

    public string levelToLoad;

    public void LoadLevel()
    {
        if (levelToLoad != null)
        {
            Application.LoadLevel(levelToLoad);
        }
    }
}
