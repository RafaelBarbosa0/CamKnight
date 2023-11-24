using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace CamKnight
{
    public class Attacking : IEnemyState
    {
        private int[] attackSequence;

        private int attackIndex;
        private float timer = 0;

        private bool attackStarted;

        public void OnEnter(EnemyController enemy)
        {
            // Create attack sequence array with number of attacks enemy can perform.
            attackSequence = new int[enemy.attackAmount];

            // Randomize enemy attack sequence.
            for(int i = 0; i < attackSequence.Length; i++)
            {
                attackSequence[i] = Random.Range(0, enemy.attackZones.Length - 1);
            }
        }

        public void UpdateState(EnemyController enemy)
        {
            // If enemy health drops to 0 change to dead state.
            if (enemy.health <= 0) enemy.ChangeState(new Dead());

            // If enemy stun reaches max change to stunned state.
            if (enemy.stun >= enemy.stunMax) enemy.ChangeState(new Stunned());

            // Attack start behavior.
            if(!attackStarted)
            {
                // Display attack indicator.
                enemy.attackIcons[attackSequence[attackIndex]].gameObject.SetActive(true);

                // Play animation here.

                attackStarted = true;
            }

            // Increment timer.
            timer++;

            if(timer >= enemy.attackInterval)
            {
                // Attack code here.

                // If last attack in sequence.
                if (attackIndex == attackSequence.Length - 1)
                {
                    // Set attack indicator off.
                    enemy.attackIcons[attackSequence[attackIndex]].gameObject.SetActive(false);

                    // Change to idle state.
                    enemy.ChangeState(new Idle());
                }

                // Setup next attack.
                else
                {
                    // Set attack indicator off.
                    enemy.attackIcons[attackSequence[attackIndex]].gameObject.SetActive(false);

                    // Increment attack index.
                    attackIndex++;

                    // Reset timer.
                    timer = 0;

                    // Reset attack start behavior check.
                    attackStarted = false;
                }
            }
        }
    }
}
