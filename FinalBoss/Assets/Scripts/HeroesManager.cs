using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroesManager : MonoBehaviour
{
    public GameObject heroes;
    public GameManager gameManager;
    public Hero hero;
    public Hero heroAux;

    public bool isTargetSelected;
    public int heroSelected;
    // Start is called before the first frame update
    void Start()
    {
        isTargetSelected=false;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        setHeroesIndex();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setHeroesIndex()
    {
        int i=0;
        foreach (Transform child in transform)
        {
            hero = child.GetComponent<Hero>();
            hero.position=i;
            i++;
        }
    }
    public int getLowLife()
    {
        int i=0;
        int lowerLife = 100;
        int index=0;
        foreach (Transform child in transform)
        {
            hero = child.GetComponent<Hero>();
            if(hero.health < lowerLife && hero.health > 0)
            {
                lowerLife = hero.health;
                index=i;
            }
            i++;
        }
        //return hero index with lowest health
        return index;
    }

    
    public void healLife(int quantity,int position)
    {
        hero = transform.GetChild(position).GetComponent<Hero>();

        hero.health+=quantity;
        if(hero.health > hero.maxHealth)
            hero.health=hero.maxHealth;
    }

    public IEnumerator takeTurn()
    {
        WaitForSeconds wait = new WaitForSeconds( 1f ) ;

        foreach (Transform child in transform)
        {
            hero = child.GetComponent<Hero>();
            hero.glow(true);
            hero.useSkill();
            yield return wait;
            heroAux = child.GetComponent<Hero>();
            heroAux.glow(false);

        }
        gameManager.passTurn();
        gameManager.buttonFunctionManager();
    }

    public void dealDamage(int quantity,int position)
    {
        transform.GetChild(position).GetComponent<Hero>().takeDamage(quantity);
    }
}
