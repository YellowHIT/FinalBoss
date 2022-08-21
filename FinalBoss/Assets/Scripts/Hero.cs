using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    public string heroClass;
    public int health;
    public int colorVariant;
    public int maxHealth = 3;
    public int position;

    // Start is called before the first frame update
    void Start()
    {
        //randomic hero generation
        setClass(Random.Range(0, 4));
        setHealth();
        Debug.Log(heroClass);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate() {
        int i = Random.Range(0, 100);
        if(i==20)
        {
            transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = !(transform.GetChild(0).GetComponent<SpriteRenderer>().flipX); 
        }
    }
    
    void setHealth()
    {
        health = maxHealth;
    }

    void setClass(int index)
    {
        switch (index)
        {
            case 0:
                heroClass="warrior";
                break;
            case 1:
                heroClass="mage";
                break;
            case 2:
                heroClass="healer";
                break;
            case 3:
                heroClass="archer";
                break;
        }

    }
    void OnMouseOver()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        transform.GetChild(1).gameObject.SetActive(true);
        Debug.Log("Mouse is over "+heroClass);
    }
    
    void OnMouseExit()
    {
        //The mouse is no longer hovering over the GameObject so output this message each frame
        transform.GetChild(1).gameObject.SetActive(false);

        // Debug.Log("Mouse is no longer on GameObject.");
    }
}
