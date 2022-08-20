using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Building
{
    [CreateAssetMenu(fileName = "Rooms", menuName = "Building/Rooms")]
    public class Rooms : ScriptableObject
    {
        public enum RoomType {Boss, Zombie, Skeleton, Goblin, Gold, Gems, ArrowTrap, SpikeTrap};

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
