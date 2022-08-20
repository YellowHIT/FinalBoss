using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    public Health Health;
    // Start is called before the first frame update
    void Start()
    {
        
        Health = this.GetComponent<Health>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void useSkill(string skillName, string target)
    {
        if(skillName == "firstSkill")
            firstSkill(target);
        else if(skillName == "secondSkill")
            secondSkill(target);
        else if(skillName == "thirdSkill")
            thirdSkill(target);
    }

    public void firstSkill(string target)
    {
        Debug.Log("First");

    }
    public void secondSkill(string target)
    {
        Debug.Log("Second");


    }
    public void thirdSkill(string target)
    {
        Debug.Log("Third");

    }

    public void takeDamage(int quantity)
    {
        Health.health--;
        Debug.Log("Aiii cuzao");

    }


}
