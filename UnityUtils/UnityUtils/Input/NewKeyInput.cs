using UnityEngine;

namespace ToothlessUtils.Input
{
    static class NewKeyInput
    {
        /// <summary>
        /// Checks for input on most Keys
        /// </summary>
        /// <returns>The key pressd</returns>
        public static KeyCode CheckForInput()
        {
            KeyCode input;
            string inputString;
            char character;

            #region NumpadKeys
            if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha0))
            {
                input = KeyCode.Alpha0;
            }
            else if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha1))
            {
                input = KeyCode.Alpha1;
            }
            else if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha2))
            {
                input = KeyCode.Alpha2;
            }
            else if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha3))
            {
                input = KeyCode.Alpha3;
            }
            else if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha4))
            {
                input = KeyCode.Alpha4;
            }
            else if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha5))
            {
                input = KeyCode.Alpha5;
            }
            else if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha6))
            {
                input = KeyCode.Alpha6;
            }
            else if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha7))
            {
                input = KeyCode.Alpha7;
            }
            else if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha8))
            {
                input = KeyCode.Alpha8;
            }
            else if (UnityEngine.Input.GetKeyDown(KeyCode.Alpha9))
            {
                input = KeyCode.Alpha9;
            }
            else if (UnityEngine.Input.GetKeyDown(KeyCode.KeypadDivide))
            {
                input = KeyCode.KeypadDivide;
            }
            else if (UnityEngine.Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                input = KeyCode.KeypadEnter;
            }
            else if (UnityEngine.Input.GetKeyDown(KeyCode.KeypadMinus))
            {
                input = KeyCode.KeypadMinus;
            }
            else if (UnityEngine.Input.GetKeyDown(KeyCode.KeypadMultiply))
            {
                input = KeyCode.KeypadMultiply;
            }
            else if (UnityEngine.Input.GetKeyDown(KeyCode.KeypadPeriod))
            {
                input = KeyCode.KeypadPeriod;
            }
            else if (UnityEngine.Input.GetKeyDown(KeyCode.KeypadPlus))
            {
                input = KeyCode.KeypadPlus;
            }
            #endregion NumpadKeys
            #region NormalCharacterInput (A-Z + 0-9 + Special characters)
            else if (UnityEngine.Input.inputString != "")
            {
                inputString = UnityEngine.Input.inputString;

                character = inputString[0];
                input = (KeyCode)character;
            }
            #endregion NormalCharcterInput
            #region ShiftKeys
            else if (UnityEngine.Input.GetKeyDown(KeyCode.LeftShift))
            {
                input = KeyCode.LeftShift;
            }
            else if (UnityEngine.Input.GetKeyDown(KeyCode.RightShift))
            {
                input = KeyCode.RightShift;
            }
            #endregion ShiftKeys
            #region ControlKeys
            else if (UnityEngine.Input.GetKeyDown(KeyCode.LeftControl))
            {
                input = KeyCode.LeftControl;
            }
            else if (UnityEngine.Input.GetKeyDown(KeyCode.RightControl))
            {
                input = KeyCode.RightControl;
            }
            #endregion ControlKeys
            #region MouseButtons
            else if (UnityEngine.Input.GetMouseButtonDown(0))
            {
                input = KeyCode.Mouse0;
            }
            else if (UnityEngine.Input.GetMouseButtonDown(1))
            {
                input = KeyCode.Mouse1;
            }
            else if (UnityEngine.Input.GetMouseButtonDown(2))
            {
                input = KeyCode.Mouse2;
            }
            else if (UnityEngine.Input.GetMouseButtonDown(3))
            {
                input = KeyCode.Mouse3;
            }
            else if (UnityEngine.Input.GetMouseButtonDown(4))
            {
                input = KeyCode.Mouse4;
            }
            else if (UnityEngine.Input.GetMouseButtonDown(5))
            {
                input = KeyCode.Mouse5;
            }
            else if (UnityEngine.Input.GetMouseButtonDown(6))
            {
                input = KeyCode.Mouse6;
            }
            #endregion MouseButtons
            #region ArrowKeys
            else if (UnityEngine.Input.GetKeyDown(KeyCode.UpArrow))
            {
                input = KeyCode.UpArrow;
            }
            else if (UnityEngine.Input.GetKeyDown(KeyCode.DownArrow))
            {
                input = KeyCode.DownArrow;
            }
            else if (UnityEngine.Input.GetKeyDown(KeyCode.RightArrow))
            {
                input = KeyCode.RightArrow;
            }
            else if (UnityEngine.Input.GetKeyDown(KeyCode.LeftArrow))
            {
                input = KeyCode.LeftArrow;
            }
            #endregion ArrowKeys
            #region AltKeys
            else if (UnityEngine.Input.GetKeyDown(KeyCode.LeftAlt))
            {
                input = KeyCode.LeftAlt;
            }
            else if (UnityEngine.Input.GetKeyDown(KeyCode.RightAlt))
            {
                input = KeyCode.LeftAlt;
            }
            #endregion AltKeys
            #region MiscKeys
            else if (UnityEngine.Input.GetKeyDown(KeyCode.AltGr))
            {
                input = KeyCode.AltGr;
            }
            else if (UnityEngine.Input.GetKeyDown(KeyCode.Insert))
            {
                input = KeyCode.Insert;
            }
            else if (UnityEngine.Input.GetKeyDown(KeyCode.Home))
            {
                input = KeyCode.Home;
            }
            else if (UnityEngine.Input.GetKeyDown(KeyCode.Delete))
            {
                input = KeyCode.Delete;
            }
            else if (UnityEngine.Input.GetKeyDown(KeyCode.End))
            {
                input = KeyCode.End;
            }
            else if (UnityEngine.Input.GetKeyDown(KeyCode.PageUp))
            {
                input = KeyCode.PageUp;
            }
            else if (UnityEngine.Input.GetKeyDown(KeyCode.PageDown))
            {
                input = KeyCode.PageDown;
            }
            else if(UnityEngine.Input.GetKeyDown(KeyCode.Print))
            {
                input = KeyCode.Print;
            }
            else if (UnityEngine.Input.GetKeyDown(KeyCode.ScrollLock))
            {
                input = KeyCode.ScrollLock;
            }
            else if(UnityEngine.Input.GetKeyDown(KeyCode.Pause))
            {
                input = KeyCode.Pause;
            }
            #region F Keys
            else if (UnityEngine.Input.GetKeyDown(KeyCode.F1))
            {
                input = KeyCode.F1;
            }
            else if (UnityEngine.Input.GetKeyDown(KeyCode.F2))
            {
                input = KeyCode.F2;
            }
            else if (UnityEngine.Input.GetKeyDown(KeyCode.F3))
            {
                input = KeyCode.F3;
            }
            else if (UnityEngine.Input.GetKeyDown(KeyCode.F4))
            {
                input = KeyCode.F4;
            }
            else if (UnityEngine.Input.GetKeyDown(KeyCode.F5))
            {
                input = KeyCode.F5;
            }
            else if (UnityEngine.Input.GetKeyDown(KeyCode.F6))
            {
                input = KeyCode.F6;
            }
            else if (UnityEngine.Input.GetKeyDown(KeyCode.F7))
            {
                input = KeyCode.F7;
            }
            else if (UnityEngine.Input.GetKeyDown(KeyCode.F8))
            {
                input = KeyCode.F8;
            }
            else if (UnityEngine.Input.GetKeyDown(KeyCode.F9))
            {
                input = KeyCode.F9;
            }
            else if (UnityEngine.Input.GetKeyDown(KeyCode.F10))
            {
                input = KeyCode.F10;
            }
            else if (UnityEngine.Input.GetKeyDown(KeyCode.F11))
            {
                input = KeyCode.F11;
            }
            else if (UnityEngine.Input.GetKeyDown(KeyCode.F12))
            {
                input = KeyCode.F12;
            }
            #endregion
            #region PlatformSpecific
            else if (UnityEngine.Input.GetKeyDown(KeyCode.LeftWindows))
            {
                input = KeyCode.LeftWindows;
            }
            else if (UnityEngine.Input.GetKeyDown(KeyCode.RightWindows))
            {
                input = KeyCode.RightWindows;
            }
            else if (UnityEngine.Input.GetKeyDown(KeyCode.LeftApple))
            {
                input = KeyCode.LeftApple;
            }
            else if (UnityEngine.Input.GetKeyDown(KeyCode.RightApple))
            {
                input = KeyCode.RightApple;
            }
            #endregion PlatformSpecific
            #endregion MiscKeys
            #region NoInput
            else
            {
                input = KeyCode.None;
            }
            #endregion NoInput

            return input;
        }

        /// <summary>
        /// Checks for input on most keys
        /// </summary>
        /// <param name="key">The Key pressed</param>
        /// <returns>True if a key is pressed</returns>
        public static bool CheckForInput(out KeyCode key)
        {
            key = CheckForInput();

            if (key == KeyCode.None) return false;
            return true;
        }
    }
}
