using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Units;

[RequireComponent(typeof(UnitStateMachine))]
public class CharacterCreation : MonoBehaviour
{

    public Characters.CharacterTypes units;
    public Characters character; 

    public UnitStateMachine machine;
    
    // Start is called before the first frame update
    void Start()
    {
        machine = this.GetComponent<UnitStateMachine>();

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
        if (units == Characters.CharacterTypes.Skeleton)
        {
            character.Skeleton();
        }
        if (units == Characters.CharacterTypes.Warrior)
        {
            character.Warrior();
        }
        if (units == Characters.CharacterTypes.Ranger)
        {
            character.Ranger();
        }
        if (units == Characters.CharacterTypes.Mage)
        {
            character.Mage();
        }
        
        if (character.Level > 1)
        {
            for (int i = 0; i < character.Level; i++)
                machine.LevelUp();
        }
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
