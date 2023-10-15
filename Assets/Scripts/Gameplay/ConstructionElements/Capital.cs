
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Gameplay.ConstructionElements
{
    public class Capital : MonoBehaviour
    {
        [SerializeField] public Tile Tile { get; private set; }
        [SerializeField] public int Lvl { get; private set; } = 1;
        
        [SerializeField] public float UnitsPerSecond { get; private set; } = 1f;
        
        // [Space]
        [SerializeField] public int GoldPerSecond { get; private set; } = 1;
        
        // [Space]
        [SerializeField] public float UnitRecruitmentRate { get; private set; } = 1.1f;

        public float UnitsCapital { get; private set; } = 10f;

        private int _gold = 10;
    }
}