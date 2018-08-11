namespace ToothlessUtils.Input
{
    public static class THInput
    {
        /// <summary>
        /// Checks if a key has been relesed this frame
        /// </summary>
        /// <param name="bind">Binding to check from <see cref="BoundKeys.binds"/></param>
        /// <returns>true if button has been released this frame, false if not or bind does not exist</returns>
        public static bool GetButtonDown(string bind)
        {
            if (!BoundKeys.binds.ContainsKey(bind)) return false;
            return UnityEngine.Input.GetKeyDown(BoundKeys.binds[bind]);
        }

        /// <summary>
        /// Checks if a key is being held
        /// </summary>
        /// <param name="bind">Binding to check from <see cref="BoundKeys.binds"/></param>
        /// <returns>true if button a button is being held, false if not or bind does not exist</returns>
        public static bool GetButton(string bind)
        {
            if (!BoundKeys.binds.ContainsKey(bind)) return false;
            return UnityEngine.Input.GetKey(BoundKeys.binds[bind]);
        }

        /// <summary>
        /// Checks if a key has been pressed this frame
        /// </summary>
        /// <param name="bind">Binding to check from <see cref="BoundKeys.binds"/></param>
        /// <returns>true if button has been pressed this frame, false if not or bind does not exist</returns>
        public static bool GetButtonUp(string bind)
        {
            if (!BoundKeys.binds.ContainsKey(bind)) return false;
            return UnityEngine.Input.GetKeyUp(BoundKeys.binds[bind]);
        }
    }
}
