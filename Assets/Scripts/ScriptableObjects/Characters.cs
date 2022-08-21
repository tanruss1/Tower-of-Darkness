using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Units
{
    [CreateAssetMenu(fileName = "Characters", menuName = "Character Creation/Unit")]
    public class Characters : ScriptableObject
    {
        public enum CharacterTypes{ Boss, Goblin, Zombie, Skeleton, Warrior, Ranger, Mage }

        public int Health;
        public int MaxHealth;
        public int Attack;
        public int Speed;
        public int Range;
        public int Exp;
        public int ExpToNext;
        public int Level;


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
            MaxHealth = 25;
            Attack = 2;
            Speed = 3;
            Range = 4;
        }
        
        public void Goblin()
        {
            Health = 5;
            MaxHealth = 5;
            Attack = 2;
            Speed = 3;
            Range = 1;
            Exp = 1;
        }

        public void Zombie()
        {
            Health = 10;
            MaxHealth =10;
            Attack = 2;
            Speed = 1;
            Range = 1;
            Exp = 3;
        }

        public void Skeleton()
        {
            Health = 4;
            MaxHealth = 4;
            Attack = 3;
            Speed = 2;
            Range = 3;
            Exp = 2;
        }

        public void Warrior()
        {
            Health = 7;
            MaxHealth = 7;
            Attack = 2;
            Speed = 1;
            Range = 1;
            Exp = 0;
            ExpToNext = 10;
        }

        public void Ranger()
        {
            Health = 5;
            MaxHealth = 5;
            Attack = 1;
            Speed = 3;
            Range = 2;
            Exp = 0;
            ExpToNext = 10;
        }

        public void Mage()
        {
            Health = 3;
            MaxHealth = 3;
            Attack = 3;
            Speed = 2;
            Range = 2;
            Exp = 0;
            ExpToNext = 10;
        }

    }
}

