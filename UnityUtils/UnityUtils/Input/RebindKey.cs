using UnityEngine;

namespace ToothlessUtils.Input
{
    public static class RebindKey
    {
        /// <summary>
        /// How long will the function wait for the players input?
        /// </summary>
        public static int rebindTimeout = 2000;

        /// <summary>
        /// Rebinds a pre-existing binding. <para />
        /// If no key is pressed <see cref="bind"/> is set to <see cref="KeyCode.None"/> if the <see cref="bind"/> exists.
        /// </summary>
        /// <param name="bind">Binding to change</param>
        /// <returns>true if binding was chnaged sucessfuly</returns>
        public static bool SetRebindKey(string bind)
        {
            KeyCode key = KeyCode.None;

            int iterations = 0;

            while(key == KeyCode.None)
            {
                iterations++;

                if (iterations >= rebindTimeout) break;

                key = NewKeyInput.CheckForInput();
            }

            return BoundKeys.EditBind(bind, key);
        }
    }
}
