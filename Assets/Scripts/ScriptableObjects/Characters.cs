using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Units
{
    [CreateAssetMenu(fileName = "Characters", menuName = "Character Creation/Unit")]
    public class Characters : ScriptableObject
    {
        public enum CharacterTypes{ Boss, Goblin, Zombie, Skelton, Warrior, Ranger, Mage }

       public int Health;
       public int Attack;
       public int Speed;
       public int Range;
        int Level;


        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
       public void Boss()
        {
            Health = 25;
            Attack = 2;
            Speed = 3;
            Range = 4;
        }
        
        public void Goblin ()
        {
            Health = 5;
            Attack = 2;
            Speed = 3;
            Range = 1;
        }

        public void Zombie ()
        {
            Health = 10;
            Attack = 2;
            Speed = 1;
            Range = 1;
        }
    }
}

