using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PGGE
{
    // The base class for all third-person camera controllers
    public abstract class TPCBase
    {
        protected Transform mCameraTransform;
        protected Transform mPlayerTransform;

        public Transform CameraTransform
        {
            get
            {
                return mCameraTransform;
            }
        }
        public Transform PlayerTransform
        {
            get
            {
                return mPlayerTransform;
            }
        }

        public TPCBase(Transform cameraTransform, Transform playerTransform)
        {
            mCameraTransform = cameraTransform;
            mPlayerTransform = playerTransform;
        }

        public void RepositionCamera()
        {
            //-------------------------------------------------------------------
            // Implement here.
            //-------------------------------------------------------------------
            //-------------------------------------------------------------------
            // Hints:
            //-------------------------------------------------------------------
            // check collision between camera and the player.
            // find the nearest collision point to the player
            // shift the camera position to the nearest intersected point
            //-------------------------------------------------------------------


            //a line from the player to the camera that is straight in the y axis for the raycast to fire.
            Vector3 vec = new Vector3(mCameraTransform.position.x - mPlayerTransform.position.x , 0 , mCameraTransform.position.z - mPlayerTransform.position.z); 
            //the position the raycast should be fired at, maintaining the existing y position of camera
            Vector3 playerHead = new Vector3(mPlayerTransform.position.x, mCameraTransform.position.y, mPlayerTransform.position.z);
            //limits the distance the raycast should fire so it does not stick the camera to the wall when the player is too far
            float dist = Vector3.Distance(playerHead, mCameraTransform.position);
            Debug.DrawRay(playerHead, vec, Color.red);

            RaycastHit hitData;
            //fires the raycast from the top of the player toward the camera
            if(Physics.Raycast(playerHead, vec, out hitData, dist))
            {
                //checks if there is an object between the player and the camera
                if (hitData.collider.gameObject.CompareTag("Obstacle"))
                {
                    //sticks the camera to the object so it does not get blocked
                    mCameraTransform.position = hitData.point;

                    
                }

            }


        }

        public abstract void Update();
    }
}
