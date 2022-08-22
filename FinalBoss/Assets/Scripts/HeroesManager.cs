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
    float[] initialPosition = {-0.85f,0.84f,2.61f,4.49f};   
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
            var clone = Instantiate(prefab[heroClass], new Vector3(initialPosition[i],0,0),Quaternion.identity);
            clone.transform.SetParent(this.transform);
            clone.SetActive(true);

            clone.GetComponent<Hero>().setClass(heroClass);
            clone.GetComponent<Hero>().setHealth();
            Debug.Log(heroClass);
        }
    }
    public void setHeroesIndex()
    {
        int i=0;
        foreach (Transform child in transform)
        {
            Debug.Log(child);

            hero = child.GetComponent<Hero>();
            hero.position=i;
            i++;
        }
        if(i==0)
            gameManager.playerWon();

    }
    public Transform getHeroByIndex(int index)
    {
        int i=0;
        foreach (Transform child in transform)
        {
            // Debug.Log(child);

            hero = child.GetComponent<Hero>();
            if(hero.position == index)
                return child;
            i++;
        }
        return null;
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
                index=hero.position;
            }
            i++;
        }
        //return hero index with lowest health
        return index;
    }

    public bool checkIfPartyIsDead()
    {
        bool partyIsDead = true;
        foreach (Transform child in transform)
        {
            hero = child.GetComponent<Hero>();
            if(hero.dead == false)
                partyIsDead=false;
            }
        return partyIsDead;
    }

    
    public void healLife(int quantity,int position)
    {
        // hero = transform.GetChild(position).GetComponent<Hero>();
        GameObject hero = null;   
        foreach(Transform child in transform)
        {
            if(child.GetComponent<Hero>().position == position)
            {
                hero = child.gameObject;
            }
        }
        var heroAux =hero.GetComponent<Hero>();
        heroAux.transform.GetChild(5).gameObject.SetActive(true);
        heroAux.health+=quantity;
        if(heroAux.health > heroAux.maxHealth)
            heroAux.health=heroAux.maxHealth;

    }

    public IEnumerator takeTurn()
    {
        WaitForSeconds wait = new WaitForSeconds( 1f ) ;
        foreach (Transform child in transform)
        {
            hero = child.GetComponent<Hero>();
            hero.isAttacking=true;
            hero.transform.GetChild(5).gameObject.SetActive(false);

            hero.glow(true);
            hero.useSkill();
            yield return wait;
            heroAux = child.GetComponent<Hero>();
            heroAux.glow(false);
            heroAux.transform.GetChild(5).gameObject.SetActive(false);
            heroAux.isAttacking=false;

            

        }
        gameManager.slash(false);
        
        gameManager.passTurn();
        gameManager.buttonFunctionManager();
    }

    public void dealDamage(int quantity,int position)
    {
        GameObject heroDamaged = null;   
        foreach(Transform child in transform)
        {
            if(child.GetComponent<Hero>().position == position)
            {
                heroDamaged = child.gameObject;
            }
        }
        heroDamaged.GetComponent<Hero>().takeDamage(quantity);

    }
    public void confuseTarget(int position)
    {
        GameObject heroDamaged = null;   
        foreach(Transform child in transform)
        {
            if(child.GetComponent<Hero>().position == position)
            {
                heroDamaged = child.gameObject;
                
            }
        }
        heroDamaged.GetComponent<Hero>().confusion = 1;
    }

    public void changeHeroPosition(int fromPosition, int toPosition)
    {
        
        GameObject heroPosition = null;
        GameObject heroInPosition = null;
        foreach (Transform child in transform)
        {
            if(child.GetComponent<Hero>().position == fromPosition)
            {
                heroPosition = child.gameObject;
            }
            else if(child.GetComponent<Hero>().position == toPosition)
            {
                heroInPosition = child.gameObject;
            }

        }
        
        //change position
        var xPosAux = heroPosition.transform.position.x;
        heroPosition.transform.position = new Vector3(heroInPosition.transform.position.x,heroPosition.transform.position.y,heroPosition.transform.position.z);
        heroInPosition.transform.position = new Vector3(xPosAux,heroPosition.transform.position.y,heroPosition.transform.position.z);
        heroPosition.GetComponent<Hero>().position = toPosition;
        heroInPosition.GetComponent<Hero>().position = fromPosition;
    }

    
}
