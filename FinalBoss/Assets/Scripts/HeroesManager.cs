using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroesManager : MonoBehaviour
{
    public GameObject heroes;
    public Hero hero;
    // Start is called before the first frame update
    void Start()
    {
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

    public void instantiateHeroes()
    {

    }

    public void killHero()
    {

    }

    public void takeTurn()
    {

        foreach (Transform child in transform)
        {
            hero = child.GetComponent<Hero>();
            hero.useSkill();
        }
    }
}
