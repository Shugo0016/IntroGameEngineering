using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Levels : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    public void Level1() {
        SceneManager.LoadScene("Level 1");
    }

    // Update is called once per frame
    public void Level2() {
       if (PublicVars.level2) {
            SceneManager.LoadScene("Level 2");
        }
    }

    public void Level3()
    {
        if (PublicVars.level3) {
            SceneManager.LoadScene("Level 3");
        }
    }
}
