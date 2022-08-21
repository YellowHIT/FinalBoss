using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject buttons;

    public GameObject backgroundSky;

    public Player player;

    public HeroesManager heroesManager;

    public float skyRotationSpeed;
    
    public bool isPlayerTurn;

    public bool isEnemyTurn; 
    // Start is called before the first frame update
    void Start()
    {
        isPlayerTurn=true;
        isEnemyTurn=false;

        buttons = GameObject.Find("Panel");
        player = GameObject.Find("Player").GetComponent<Player>();
        heroesManager = GameObject.Find("Heroes").GetComponent<HeroesManager>();
        buttonFunctionManager();

    }

    // Update is called once per frame
    void Update()
    {
        RotateBackgroundSky();
        if(isEnemyTurn)
            enemyTurn();
    }

    public void RotateBackgroundSky()
    {
        //rotate stars ✰✰✰✰✰
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
        if(isEnemyTurn)
        {
            isEnemyTurn=false;
            isPlayerTurn=true;
        }
        else if(isPlayerTurn)
        {
            isEnemyTurn=true;
            isPlayerTurn=false;
        }
    }

    public void useEnmemySkill(int enemyIndex)
    {
        
    }


    public void buttonFunctionManager()
    {
        int i=0;

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
                // text.text = playerskills[i];
                // Debug.Log(player.GetComponent<Player>().skills);
                i++;

            }
        }
        
 

    }

    public void takeDamage(string target, int quantity, int index)
    {
        if(target=="player")
        {
            player.takeDamage(quantity);
        }
        else if(target=="hero")
        {
            
        }
    }

    public void enemyTurn()
    {
        heroesManager.takeTurn();
        isEnemyTurn = false;
        isPlayerTurn = true;
    }
    

}
