using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public Health Health;
    // Start is called before the first frame update
    public string[] skills = {"Paws of The Undying","Fire Meow","Nyafe Drain", "Fearline"};

    void Start()
    {
        Health = this.GetComponent<Health>();
        Debug.Log(skills);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void useSkill(string skillName, string target)
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

    public void pawSkill(string target)
    {
        Debug.Log("Paw");
        int damage = 1;
        int manaCost = 2;
        //TODO pull 1 position if position > 1

    }
    public void fireSkill(string target)
    {
        Debug.Log("Fire");
        int damage = 2;
        int manaCost = 2;
         
    }
    public void lifeSkill(string target)
    {
        Debug.Log("Life");
        int damage = 2;
        int manaCost = 3;
        //TODO heal for 3
        
    }
    public void fearSkill(string target)
    {
        Debug.Log("Fear");
        int damage = 0;
        int manaCost = 1;
        //TODO interrupt a enemy
        
    }


    public void takeDamage(int quantity)
    {
        Health.health -= quantity ;
        Debug.Log("Aiii cuzao");

    }


}
