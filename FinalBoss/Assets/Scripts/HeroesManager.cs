using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroesManager : MonoBehaviour
{
    public GameObject heroes;
    public GameManager gameManager;
    public Hero hero;
    public Hero heroAux;
    public GameObject BaseHeroes;
    public bool isTargetSelected;
    public int heroSelected;

    public List<GameObject> prefab;

    // Start is called before the first frame update
    void Start()
    {
        isTargetSelected=false;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        BaseHeroes = GameObject.Find("BaseHeroes");
        foreach(Transform child in BaseHeroes.transform)
        {
            prefab.Add(child.gameObject);
            Debug.Log("Nya");
        }
        instantiateHeroes();
        setHeroesIndex();

        Debug.Log(BaseHeroes.transform.GetChild(0));

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void instantiateHeroes()
    {
        for(var i=0; i<4; i++)
        {
            var heroClass = Random.Range(0, 4);
            Debug.Log(prefab[heroClass]);
            Instantiate(prefab[heroClass], new Vector3(i*0.8f,0,0),Quaternion.identity);
            // setClass();
            // setHealth();
            Debug.Log(heroClass);
        }
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
