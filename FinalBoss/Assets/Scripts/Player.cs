using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public Health Health;
    public Mana Mana;
    // Start is called before the first frame update
    public string[] skills;
    public float speed;
    float y0;
    public float amplitude;

    public HeroesManager heroesManager;
    public GameManager gameManager;
    public bool dead;
    void Start()
    {
        heroesManager = GameObject.Find("Heroes").GetComponent<HeroesManager>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        Health = this.GetComponent<Health>();
        Mana = this.GetComponent<Mana>();
        dead = false;

        skills = new string[4]{"Paw of Doom","Fire Meow","Nyafe Drain", "Fearline"};
        //save initial y position
        speed = 1.0f;
        y0 = transform.position.y;
        amplitude=0.1f;
        
    }

    // Update is called once per frame
    void Update()
    {
        //makes the player float
        transform.position = new Vector3(transform.position.x, (y0+amplitude*Mathf.Sin(speed*Time.time)), transform.position.z);
    }

    public void useSkill(string skillName, int target)
    {
        if(skillName == "Paw")
            pawSkill(target);
        else if(skillName == "Fire")
            fireSkill(target);
        else if(skillName == "Life")
            lifeSkill(target);
        else if(skillName == "Fear")
            fearSkill(target);

    }

    public void pawSkill(int target)
    {
        Debug.Log("Paw at "+ target);
        int damage = 1;
        int manaCost = 2;
        //TODO pull 1 position if position > 1
        if(Mana.mana - manaCost < 0)
        {
            spellFail();
        }
        else
        {
            gameManager.indexTarget=target;
            gameManager.indexSource=-1;
            gameManager.skillNumber=0;
            heroesManager.dealDamage(damage,target);
            if(target>0)
                heroesManager.changeHeroPosition(target,target-1);
            spendMana(manaCost);
        }

    }
    public void fireSkill(int target)
    {

        int damage = 2;
        int manaCost = 2;
        if(Mana.mana - manaCost < 0 || target !=0)
        {
            spellFail();
        }
        else
        {
            gameManager.indexTarget=target;
            gameManager.indexSource=-1;
            gameManager.skillNumber=4;
            Debug.Log("Fire at"+ target);
            heroesManager.dealDamage(damage,target);
            spendMana(manaCost);
        }
     
    }
    public void lifeSkill(int target)
    {
        int damage = 2;
        int manaCost = 3;
        //TODO heal for 3
        if(Mana.mana - manaCost < 0)
        {
            
            spellFail();
        }
        else
        {
            gameManager.indexTarget=-1;
            gameManager.indexSource=target;
            gameManager.skillNumber=3;
            Debug.Log("Life at"+ target);
            heroesManager.dealDamage(damage,target);
            recoverLife(3);
            spendMana(manaCost);
        }


    }
    public void fearSkill(int target)
    {
        int manaCost = 1;
        //TODO interrupt a enemy
        // heroesManager.dealDamage(damage,target);c

        if(Mana.mana - manaCost < 0)
        {
            spellFail();
        }
        else
        {       
            Debug.Log("Fear at"+ target);

            heroesManager.confuseTarget(target);
            spendMana(manaCost);

        }

    }


    public void takeDamage(int quantity)
    {
        Health.health -= quantity ;
        // Debug.Log("Aiii cuzao");
        if(Health.health <= 0)
            die();
    }
    void spendMana(int quantity)
    {
        Mana.mana -= quantity ;
    }

    public void recoverMana(int quantity)
    {
        Mana.mana += quantity ;
    }
    public void recoverLife(int quantity)
    {
        Health.health += quantity ;
    }

    public void glow(bool state)
    {
        transform.GetChild(1).gameObject.SetActive(state);
    }


    void spellFail()
    {
        Debug.Log("Spell Fail");
    }
    
    public void die()
    {
        dead=true;
        transform.GetChild(0).GetComponent<SpriteRenderer>().flipY = true;
        gameManager.GameOver();



    }

    public void slash(bool state)
    {
        transform.GetChild(2).gameObject.SetActive(state);
    }
}
