using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mana : MonoBehaviour
{
    public int mana;
    public int numOfCrystals;

    public Image[] manaCrystals;
    public Sprite fullCrystal;
    public Sprite emptyCrystal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMana();
    }

    public void PlayerMana()
    {
        if(mana > numOfCrystals)
        {
            mana = numOfCrystals;
        }

        for(int i=0; i < manaCrystals.Length; i++)
        {
            if(i < mana)
            {
                manaCrystals[i].sprite = fullCrystal;
            }
            else
            {
                manaCrystals[i].sprite = emptyCrystal;
            }

            if(i < numOfCrystals)
            {
                manaCrystals[i].enabled = true;
            }
            else
            {
                manaCrystals[i].enabled = false;
            }
        }
    }
}