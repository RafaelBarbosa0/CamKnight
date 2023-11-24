using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CamKnight
{
    public class EnemyController : MonoBehaviour
    {
        IEnemyState currentState;

        [Header("Stats")]
        [SerializeField]
        internal float health;
        [SerializeField]
        internal float stun;
        [SerializeField]
        internal float stunMax;

        [Header("Animator reference")]
        [SerializeField]
        internal Animator animator;

        [Header("Spawn time")]
        [SerializeField]
        internal float spawnTime;

        [Header("Wait time range to change from idle to attack")]
        [SerializeField]
        internal float minSwitchAttack;
        [SerializeField]
        internal float maxSwitchAttack;

        [Header("Attack sequence settings")]
        [SerializeField]
        internal int attackAmount;
        [SerializeField]
        internal float attackInterval;

        [Header("Attack zones")]
        [SerializeField]
        internal GameObject[] attackZones;
        [SerializeField]
        internal GameObject[] attackIcons;

        [Header("Attack strings for animator")]
        [SerializeField]
        internal string[] attackStrings;

        // Start is called before the first frame update
        void Start()
        {
            currentState = new Spawning();

            currentState.OnEnter(this);
        }

        // Update is called once per frame
        void Update()
        {
            currentState.UpdateState(this);
        }

        public void ChangeState(IEnemyState newState)
        {
            currentState = newState;

            currentState.OnEnter(this);
        }
    }

    public interface IEnemyState
    {
        public void OnEnter(EnemyController enemy);
        public void UpdateState(EnemyController enemy);
    }
}
