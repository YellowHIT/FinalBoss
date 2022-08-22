using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsMenuHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public void LoadStartMenu()
    {
        SceneManager.LoadScene(0);
    }
}
