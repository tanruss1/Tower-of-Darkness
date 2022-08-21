using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Units;


public class CharacterCreation : MonoBehaviour
{

    public Characters.CharacterTypes units;
    public Characters character;

    
    // Start is called before the first frame update
    void Start()
    {
        if(units == Characters.CharacterTypes.Boss)
        {
            character.Boss();
        }
        if(units == Characters.CharacterTypes.Goblin)
        {
            character.Goblin();
        }
        if(units == Characters.CharacterTypes.Zombie)
        {
            character.Zombie();
        }
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
