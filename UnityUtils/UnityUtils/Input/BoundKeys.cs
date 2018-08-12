using System.Collections.Generic;
using UnityEngine;

namespace ToothlessUtils.Input
{
    public static class BoundKeys
    {
        /// <summary>
        /// Keybindings
        /// </summary>
        public static Dictionary<string, KeyCode> binds { get; private set; } = new Dictionary<string, KeyCode>()
        {
            {"Forward", KeyCode.W },
            {"Backwards", KeyCode.S },
            {"Right", KeyCode.D },
            {"Left", KeyCode.A },
            {"Jump", KeyCode.Space },
            {"LeftMouse", KeyCode.Mouse0 },
            {"RightMouse", KeyCode.Mouse1 }
        };
        
        /// <summary>
        /// Adds a binding to the <see cref="binds"/> Dictionary
        /// </summary>
        /// <param name="bindName">Name of new Binding.</param>
        /// <param name="additionInfo">Extra Information about an Addition</param>
        /// <param name="key">Key to add</param>
        /// <returns>true if key is added</returns>
        /// <example>AddBind("Forward", out string info, KeyCode.W)</example>
        public static bool AddBind(string bindName, out string additionInfo, KeyCode key = KeyCode.None)
        {
            if(binds.ContainsKey(bindName))
            {
                additionInfo = $"ERROR: {bindName} is already in the dictionary";
                return false;
            }

            if (binds.ContainsValue(key) && key != KeyCode.None) additionInfo = $"WARNING: {key} is already bound, keybinding overlapps can cause unexpected results!";
            else additionInfo = null;

            binds.Add(bindName, key);

            return true;
        }
        /// <summary>
        /// Adds a binding to the <see cref="binds"/> Dictionary
        /// </summary>
        /// <param name="bindName">Name of new Binding.</param>
        /// <param name="additionInfo">Extra Information about an Addition</param>
        /// <returns>true if key is added</returns>
        public static bool AddBind(string bindName, KeyCode key = KeyCode.None)
        {
            string b;

            return AddBind(bindName, out b, key);
        }

        /// <summary>
        /// Edits a pre-existing keybinding in the <see cref="binds"/> Dictionary
        /// </summary>
        /// <param name="bindName">Binding to Change</param>
        /// <param name="key">Key to Change Binding to</param>
        /// <returns>true if change is succesful</returns>
        public static bool EditBind(string bindName, KeyCode key = KeyCode.None)
        {
            if (!binds.ContainsKey(bindName)) return false;

            binds[bindName] = key;

            return true;
        }

        /// <summary>
        /// View the <see cref="KeyCode"/> for a specific binding
        /// </summary>
        /// <param name="bind">Binding to look for</param>
        /// <returns><see cref="KeyCode"/> associated with binding. If binding is not found then <see cref="KeyCode.None"/> is returned</returns>
        public static KeyCode ViewBinding(string bind)
        {
            if (binds.ContainsKey(bind)) return binds[bind];
            else return KeyCode.None;
        }

        /// <summary>
        /// Is a <see cref="KeyCode"/> used in the <see cref="binds"/> dictionary?
        /// </summary>
        /// <param name="key"><see cref="KeyCode"/> to look for</param>
        /// <returns>true if binding is used</returns>
        public static bool IsBindingUsed(KeyCode key)
        {
            return binds.ContainsValue(key);
        }
    }
}
