using UnityEngine;

namespace ToothlessUtils.Misc
{
    public class HideLockCursor : MonoBehaviour
    {
        public static bool isCursorHidden { get; private set; }
        public static bool isCursorLocked { get; private set; }

        private void Awake()
        {
            ToggleCursorHide();
            ToggleCursorLock();
        }

        public static void ToggleCursorHideAndLock()
        {
            ToggleCursorHide();
            ToggleCursorLock();
        }

        #region Cursor Hide
        public static void ToggleCursorHide()
        {
            Cursor.visible = !Cursor.visible;
            isCursorHidden = !isCursorHidden;
        }

        public static void HideCursor()
        {
            if (!isCursorHidden)
            {
                isCursorHidden = true;
                Cursor.visible = false;
            }
        }

        public static void ShowCursor()
        {
            if (isCursorHidden)
            {
                isCursorHidden = false;
                Cursor.visible = true;
            }
        }
        #endregion

        #region Cursor Lock
        public static void ToggleCursorLock()
        {
            if (Cursor.lockState != CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.Locked;
                isCursorLocked = true;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                isCursorLocked = false;
            }

        }

        public static void LockCursor()
        {
            if (Cursor.lockState != CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.Locked;
                isCursorLocked = true;
            }
        }

        public static void UnlockCursor()
        {
            if (Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.lockState = CursorLockMode.None;
                isCursorLocked = false;
            }
        }
        #endregion
    }
}
