using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace CamKnight
{
    public class Dead : IEnemyState
    {
        private float timer;

        public void OnEnter(EnemyController enemy)
        {
            enemy.animator.Play("Death");
        }

        public void UpdateState(EnemyController enemy)
        {
            timer += Time.deltaTime;

            if(timer >= enemy.respawnTimer)
            {
                enemy.gameManager.SpawnKnight();
            }
        }

        public void OnExit(EnemyController enemy)
        {

        }
    }
}
