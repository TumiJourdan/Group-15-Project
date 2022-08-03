using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StarterAssets
{
    public class DShiftScr : MonoBehaviour
    {
        [SerializeField] public float jumpAmount = 20;
        [SerializeField] private float dshiftDelta;
        [SerializeField] private float dshiftTime = 0.5f;
        private StarterAssetsInputs _inputs;

        // Start is called before the first frame update
        void Start()
        {
            _inputs = GetComponent<StarterAssetsInputs>();
        }

        // Update is called once per frame
        void Update()
        {
            jump();
        }
        public void jump()
        {
            
            if (_inputs.dshift && dshiftDelta <= 0)
            {
                Debug.Log("JUMP");
                dshiftDelta = dshiftTime;
                Vector3 tempPos;
                tempPos = transform.position;
                tempPos.x += jumpAmount;
                transform.position = tempPos;
            }
            else
            {
                dshiftDelta -= Time.deltaTime;
            }


        }
    }
}

