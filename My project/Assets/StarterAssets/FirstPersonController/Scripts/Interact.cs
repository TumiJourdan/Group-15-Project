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

        [Header("Physics Parameters")]
        [SerializeField] public float pickupRange = 5.0f;
        [SerializeField] public float pickupForce = 150.0f;

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
        }

        public void interact()
        {
            if (_input.pickup == true)
            {
                Debug.Log("asdf");
            }

            if (_input.pickup == true)
            {
                if (heldObj == null)
                {
                    RaycastHit hit;
                    if (Physics.Raycast(transform.position,transform.TransformDirection(Vector3.forward), out hit, pickupRange))
                    {
                        //pickup obj
                        PickupObject(hit.transform.gameObject);
                    }
                    else
                    {
                        //drop object
                        DropObject();
                    }

                    
                }

            }
            if (heldObj != null)
            {
                //moveobject
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
            
            }
        }

        void DropObject()
        {
            
            
                heldObjRB.useGravity = true;
                heldObjRB.drag = 1;
                heldObjRB.constraints = RigidbodyConstraints.None;

                heldObjRB.transform.parent = null;
                heldObj = null;

           
        }
        void MoveObject()
        {
            if (Vector3.Distance)
        }
    }
}

