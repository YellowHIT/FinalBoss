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

    public void healLife()
    {

    }

    public void takeDamage()
    {

    }

    public void useSkill()
    {

    }

    public void instantiateHeroes()
    {

    }

    public void killHero()
    {

    }
}
