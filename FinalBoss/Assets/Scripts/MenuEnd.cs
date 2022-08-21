using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuEnd : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadStartScene());
    }

   IEnumerator LoadStartScene()
   {
        yield return new WaitForSeconds(5.0f);

        SceneManager.LoadScene(0);
   }
}
