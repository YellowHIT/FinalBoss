using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuWin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadMainScene());
    }

   IEnumerator LoadMainScene()
   {
        yield return new WaitForSeconds(5.0f);

        SceneManager.LoadScene(1);
   }
}
