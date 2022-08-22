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
    public bool dead;
    public bool concentration;
    public int confusion;
    public bool isHealing;
    public GameManager gameManager;
    
    public HeroesManager heroesManager;
    // Start is called before the first frame update
    void Start()
    {
        isHealing = false;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        heroesManager = GameObject.Find("Heroes").GetComponent<HeroesManager>();
        confusion = 0;
        concentration=false;
        dead=false;
        //randomic hero generation

    }

    // Update is called once per frame
    void Update()
    {
        if(confusion>0)
            transform.GetChild(3).gameObject.SetActive(true);
        else
            transform.GetChild(3).gameObject.SetActive(false);

    }
    private void FixedUpdate() {
        int i = Random.Range(0, 100);
        if(i==20)
        {
            transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = !(transform.GetChild(0).GetComponent<SpriteRenderer>().flipX); 
        }
    }
    
    public void setHealth()
    {
        if(heroClass=="warrior")
        {
            maxHealth=4;
            health = maxHealth;
        }
        else
        {
            health = maxHealth;
        }
    }

    public void setClass(int index)
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
        // Debug.Log("Mouse is over "+heroClass);
    }
    void OnMouseDown()
    {
        //If your mouse hovers over the GameObject with the script attached, output this message
        
        // Debug.Log("Selected "+heroClass+" At "+position);
        heroesManager.isTargetSelected = true;
        heroesManager.heroSelected = position;
    }
    
    void OnMouseExit()
    {
        //The mouse is no longer hovering over the GameObject so output this message each frame
        transform.GetChild(1).gameObject.SetActive(false);

        // Debug.Log("Mouse is no longer on GameObject.");
    }


    public void takeDamage(int quantity)
    {
        health-=quantity;
        if(health <= 0)
            die();
    }

    public void useSkill()
    {
        gameManager.slash(false);
        Debug.Log(heroClass);
        //IF HERO CONFUSED
        if(confusion > 0)
        {
            Debug.Log("IM CONFUSED LUL");
            confusion--;
            concentration=false;
        }
        else if(dead == false)
        {
            
            if(heroClass == "warrior")
            {
                charge();
            }
            else if(heroClass == "archer")
            {

                doubleStrike();   
            }
            else if(heroClass == "healer")
            {
                heal();
            }
            else if(heroClass == "mage")
            {

                fireBall();
            }
        }

    }
    public void die()
    {
        dead=true;
        // transform.GetChild(0).GetComponent<SpriteRenderer>().flipY = true;
        heroIcon(false);
        deadIcon(true);

    }
    //skills

    public void charge()
    {
        Debug.Log("Charge");
        gameManager.slash(true);
        gameManager.takeDamage("player",1,-1);
    }
    public void doubleStrike()
    {
        Debug.Log("DoubleStrike");
        gameManager.indexTarget=-1;
        gameManager.indexSource=position;
        gameManager.skillNumber=2;
        gameManager.takeDamage("player",1,-1);
        var rand = Random.Range(0, 100);
        if(rand <= 25)
        {
            Debug.Log("DoubleStrike");
            gameManager.indexTarget=-1;
            gameManager.indexSource=position;
            gameManager.skillNumber=2;
            gameManager.takeDamage("player",1,-1);
        }

    }
    public void heal()
    {
        Debug.Log("Healing Position " +heroesManager.getLowLife());
        heroesManager.healLife(1,heroesManager.getLowLife());
    }
    public void fireBall()
    {
        if(concentration == false)
        {
            Debug.Log("Concentrationnnn");
            concentration = true;

        }
        else
        {
            Debug.Log("EXISPROSION");
            gameManager.indexTarget=-1;
            gameManager.indexSource=position;
            gameManager.skillNumber=5;
            concentration = false;
            gameManager.takeDamage("player",3,-1);
        }
    }

    public void glow(bool state)
    {
        transform.GetChild(2).gameObject.SetActive(state);
    }

    public void healIcon(bool state)
    {
        transform.GetChild(5).gameObject.SetActive(state);
    }

    public void fearIcon(bool state)
    {
        transform.GetChild(3).gameObject.SetActive(state);
    }
    public void deadIcon(bool state)
    {
        transform.GetChild(6).gameObject.SetActive(state);
    }
    public void heroIcon(bool state)
    {
        transform.GetChild(0).gameObject.SetActive(state);
    }
}
