using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

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

    public UnityEvent heroClick;

    public int target;
    // Start is called before the first frame update
    void Start()
    {
        target=-1;
        isPlayerTurn=true;
        isEnemyTurn=false;
        if (heroClick == null)
            heroClick = new UnityEvent();
        buttons = GameObject.Find("Panel");
        player = GameObject.Find("Player").GetComponent<Player>();
        heroesManager = GameObject.Find("Heroes").GetComponent<HeroesManager>();
        buttonFunctionManager();

        player.glow(true);


        
    }

    // Update is called once per frame
    void Update()
    {
        RotateBackgroundSky();

        //invoke click
        if(heroesManager.isTargetSelected)
        {
            heroesManager.isTargetSelected = false;
            heroClick.Invoke();

        }
    }

    public void RotateBackgroundSky()
    {
        //rotate stars ✰✰✰✰✰
        backgroundSky.transform.Rotate(new Vector3(0, 0, 50) * skyRotationSpeed * Time.deltaTime);
    }

    public void usePlayerSkill(string skillName)
    {
        //call player
        // Debug.Log("MIAU PORRA");
    }

    public void passTurn()
    {
        Debug.Log("Vc Passou o turno Nya Nya!~✰");
        if(isEnemyTurn)
        {
            player.glow(true);
            isEnemyTurn=false;
            isPlayerTurn=true;
        }
        else if(isPlayerTurn)
        {
            player.glow(false);
            isEnemyTurn=true;
            isPlayerTurn=false;
            enemyTurn();
        }
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
                button.onClick.AddListener(PassOnClick);
                text.text = "End turn";
            }
            // child.gameObject.GetComponent<Button>().onClick.AddListener(()=>{takeDamage("player",1);});
            else
            {
                switch (i)
                {
                    case 0:
                        button.onClick.AddListener(() => { SkillOnClick(0);});
                        break;
                    case 1:
                        button.onClick.AddListener(() => { SkillOnClick(1);});
                        break;
                    case 2:
                        button.onClick.AddListener(() =>{ SkillOnClick(2);});
                        break;
                    case 3:
                        button.onClick.AddListener(() => { SkillOnClick(3);});
                        break;
                }
                // text.text = child.name;
                // button.onClick.AddListener(delegate{SkillOnClick(i);});
                // text.text = playerskills[i];
                // Debug.Log(player.GetComponent<Player>().skills);

                i++;

            }
        }
        
 

    }
    public void buttonEnemyTurn()
    {
        int i=0;
        foreach (Transform child in buttons.transform)
        {

            Button button = child.gameObject.GetComponent<Button>();
            TMP_Text text = button.transform.GetChild(0).gameObject.GetComponent<TMP_Text>();
            if(child.name == "EndTurnButton")
            {
                button.onClick.RemoveListener(PassOnClick);
                text.text = "Heroes' turn";
            }
            else
            {

                button.onClick.RemoveAllListeners();
                i++;

            }
        }
    }
    void PassOnClick()
    {
        passTurn();
    }
    void SkillOnClick(int index)
    {


        heroClick.AddListener(heroSelected);

        //now prompts to player select the enemy
        StartCoroutine(waitTarget(index));


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
        buttonEnemyTurn();
        StartCoroutine(heroesManager.takeTurn());
    }

    
    void heroSelected()
    {
        // Debug.Log("hero Selected "+heroesManager.heroSelected);
        target = heroesManager.heroSelected;
    }
    // private IEnumerator WaitUntilEvent(UnityEvent unityEvent) {
    //     int heroSelected = -1;
    //     Action action = () => heroSelected >= 0;
    //     unityEvent.AddListener(action.Invoke);
    //     yield return new WaitUntil(()=>heroSelected >= 0);
    //     unityEvent.RemoveListener(action.Invoke);
    // }
    private IEnumerator waitTarget(int index)
    {
        yield return new WaitUntil(() => (target >= 0));
        switch (index)
        {
            case 0:
                player.useSkill("Paw",target);
                break;
            case 1:
                player.useSkill("Fire",target);
                break;
            case 2:
                player.useSkill("Life",target);
                break;
            case 3:
                player.useSkill("Fear",target);
                break;
        }
        target = -1;
        heroClick.RemoveAllListeners();

    }
    
}
