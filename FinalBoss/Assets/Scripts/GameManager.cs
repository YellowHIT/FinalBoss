using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject backgroundSky;

    public float skyRotationSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RotateBackgroundSky();
    }

    public void RotateBackgroundSky()
    {
        backgroundSky.transform.Rotate(new Vector3(0, 0, 50) * skyRotationSpeed * Time.deltaTime);

    }
}
