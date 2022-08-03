using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace StarterAssets
{
    public class Interact : MonoBehaviour
    {
        [Header("Pickup settings")]
        [SerializeField] Transform holdArea;
        private GameObject heldObj;
        private Rigidbody heldObjRB;
        public Camera cam;

        [Header("Physics Parameters")]
        [SerializeField] public float pickupRange = 5.0f;
        [SerializeField] public float pickupForce = 150.0f;

        [SerializeField] public float pickupBufferTime = 0.5f;
        [SerializeField] private float pickupTimeOutDelta;

        private StarterAssetsInputs _input;
        // Start is called before the first frame update
        void Start()
        {
            _input = GetComponent<StarterAssetsInputs>();
        }

        // Update is called once per frame
        void Update()
        {
            interact();
            cam = Camera.main;
        }

        public void interact()
        {
            if (_input.pickup == true)
            {
                Debug.Log("asdf");
            }

            if (_input.pickup == true && (pickupTimeOutDelta <= 0))
            {

                if (heldObj == null)
                {
                    RaycastHit hit;
                    if (Physics.Raycast(cam.transform.position,cam.transform.TransformDirection(Vector3.forward), out hit, pickupRange))
                    {
                        //pickup obj
                        PickupObject(hit.transform.gameObject);
                        
                    }
                   

                  
                }
                else
                {
                    //drop object
                    DropObject();
                    
                }
             

            }
            else
            {
                pickupTimeOutDelta -= Time.deltaTime;
            }
            if (heldObj != null)
            {
                //moveobject
                MoveObject();
            }
        }

        void PickupObject(GameObject pickObj)
        {
            if (pickObj.GetComponent<Rigidbody>())
            {
                heldObjRB = pickObj.GetComponent<Rigidbody>();
                heldObjRB.useGravity = false;
                heldObjRB.drag = 10;
                heldObjRB.constraints = RigidbodyConstraints.FreezeRotation;

                heldObjRB.transform.parent = holdArea;
                heldObj = pickObj;
                pickupTimeOutDelta = pickupBufferTime;
            }

        }

        void DropObject()
        {
            
            
                heldObjRB.useGravity = true;
                heldObjRB.drag = 1;
                heldObjRB.constraints = RigidbodyConstraints.None;

                heldObjRB.transform.parent = null;
                heldObj = null;

                pickupTimeOutDelta = pickupBufferTime;

        }
        void MoveObject()
        {
            if (Vector3.Distance(heldObj.transform.position, holdArea.position) > 0.1f)
            {
                Vector3 moveDirection = (holdArea.position - heldObj.transform.position);
                heldObjRB.AddForce(moveDirection * pickupForce);
            }


        }
    }
}

