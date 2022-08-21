using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public Health Health;
    public Mana Mana;
    // Start is called before the first frame update
    public string[] skills = {"Paws of The Undying","Fire Meow","Nyafe Drain", "Fearline"};
    public float speed;
    float y0;
    public float amplitude;

    public HeroesManager heroesManager;
    void Start()
    {
        heroesManager = GameObject.Find("Heroes").GetComponent<HeroesManager>();

        Health = this.GetComponent<Health>();
        Mana = this.GetComponent<Mana>();


        Debug.Log(skills);
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
        heroesManager.dealDamage(damage,target);
        spendMana(manaCost);
    }
    public void fireSkill(int target)
    {
        Debug.Log("Fire at"+ target);
        int damage = 2;
        int manaCost = 2;
        heroesManager.dealDamage(damage,target);
        spendMana(manaCost);
         
    }
    public void lifeSkill(int target)
    {
        Debug.Log("Life at"+ target);
        int damage = 2;
        int manaCost = 3;
        //TODO heal for 3
        heroesManager.dealDamage(damage,target);
        spendMana(manaCost);

    }
    public void fearSkill(int target)
    {
        Debug.Log("Fear at"+ target);
        int damage = 0;
        int manaCost = 1;
        //TODO interrupt a enemy
        heroesManager.dealDamage(damage,target);
        spendMana(manaCost);

    }


    public void takeDamage(int quantity)
    {
        Health.health -= quantity ;
        // Debug.Log("Aiii cuzao");
    }
    void spendMana(int quantity)
    {
        Mana.mana -= quantity ;
    }

    public void glow(bool state)
    {
        transform.GetChild(1).gameObject.SetActive(state);
    }


 


}
