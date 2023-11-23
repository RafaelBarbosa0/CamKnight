using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CamKnight
{
    public class SwordBehavior : MonoBehaviour
    {
        // SwordTracking reference.
        private SwordTracking tracking;

        private enum SwordState
        {
            ATTACKING,
            BLOCKING
        }

        private SwordState state;

        [SerializeField]
        private float stateChangeTreshold;

        private void Start()
        {
            // Get SwordTracking reference.
            tracking = GetComponent<SwordTracking>();
        }

        private void Update()
        {
            if (tracking.Direction.y <= stateChangeTreshold) state = SwordState.BLOCKING;

            else state = SwordState.ATTACKING;

            Debug.Log(state.ToString());
        }
    }
}
