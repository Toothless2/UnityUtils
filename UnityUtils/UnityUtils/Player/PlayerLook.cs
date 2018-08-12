using UnityEngine;
using ToothlessUtils.Types;

namespace ToothlessUtils.Player
{
    public class PlayerLook : MonoBehaviour
    {
        public float maxUpLook = 5.2f;
        public float maxLookDown = 1;

        public bool invertYAxis;
        public bool invertXAxis;

        public float lookAngle;
        public float axis;

        public Transform playerCamera;

        public THVector3 vecTotalRotation { get; private set; }
        public THQuaternion quartTotalRotation { get { return THQuaternion.CreateAndSetFromVec(vecTotalRotation); } }

        void Awake()
        {
            if (playerCamera == null)
            {
                playerCamera = GameObject.FindGameObjectWithTag("MainCamera").transform;
            }
        }

        void Update()
        {
            RotateSide();
            LookUpDown();
        }

        public virtual void RotateSide()
        {
            var axis = UnityEngine.Input.GetAxis("Mouse X") * (invertXAxis ? -1 : 1);
            transform.Rotate(new Vector3(0, axis, 0));

            vecTotalRotation = transform.localEulerAngles + playerCamera.transform.localEulerAngles;
        }

        public virtual void LookUpDown()
        {
            axis += UnityEngine.Input.GetAxis("Mouse Y") * (invertYAxis ? 1 : -1);

            axis = Mathf.Clamp(axis, -90, 60);

            playerCamera.transform.localEulerAngles = new THVector3(axis, 0, 0);

            vecTotalRotation = transform.localEulerAngles + playerCamera.transform.localEulerAngles;
        }
    }
}
