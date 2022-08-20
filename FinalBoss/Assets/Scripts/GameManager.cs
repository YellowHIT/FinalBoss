using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject buttons;

    public GameObject backgroundSky;

    public GameObject player;

    public float skyRotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        buttons = GameObject.Find("Panel");
        player = GameObject.Find("Player");
        buttonFunctionManager();

    }

    // Update is called once per frame
    void Update()
    {
        RotateBackgroundSky();
    }

    public void RotateBackgroundSky()
    {
        backgroundSky.transform.Rotate(new Vector3(0, 0, 50) * skyRotationSpeed * Time.deltaTime);
    }

    public void usePlayerSkill(string skillName)
    {
        //call player
        Debug.Log("MIAU PORRA");
    }

    public void passTurn()
    {
        Debug.Log("Vc Passou o turno Nya Nya!~✰");
    }

    public void useEnmemySkill(int enemyIndex)
    {
        
    }


    public void buttonFunctionManager()
    {
        

        //For each button in a panel
        foreach (Transform child in buttons.transform)
        {
            //get the button and add a Lister
            //Note: Change the function after '=>' to change the onClick function
            Button button = child.gameObject.GetComponent<Button>();
            TMP_Text text = button.transform.GetChild(0).gameObject.GetComponent<TMP_Text>();
            if(child.name == "EndTurnButton")
            {
                button.onClick.AddListener(()=>{passTurn();});
            }
                // child.gameObject.GetComponent<Button>().onClick.AddListener(()=>{takeDamage("player",1);});
            else
            {
                // text.text = child.name;
                button.onClick.AddListener(()=>{usePlayerSkill("Miau");});

            }

        }
        
 

    }

    public void takeDamage(string target, int quantity)
    {
        if(target=="player")
        {
            player.GetComponent<Player>().takeDamage(quantity);
        }
    }

}
