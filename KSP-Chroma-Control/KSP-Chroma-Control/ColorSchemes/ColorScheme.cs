﻿using Corale.Colore.Razer.Keyboard;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace KspChromaControl.ColorSchemes
{
    /// <summary>
    /// Represents a base color scheme, saving all the colors per key.
    /// </summary>
    [Serializable]
    internal class ColorScheme : Dictionary<KeyCode, Color>
    {
        public Color baseColor { get; }

        /// <summary>
        /// Creates a new ColorScheme rendering all keys black;
        /// </summary>
        public ColorScheme() : this(Color.black) {
        }

        /// <summary>
        /// Creates a new ColorScheme rendering all keys in the defined color.
        /// </summary>
        /// <param name="color">The color to use</param>
        public ColorScheme(Color color)
        {
            this.baseColor = color;
        }

        public new Color this[KeyCode key]
        {
            get {
                Color myReturn;
                if (this.ContainsKey(key))
                    myReturn = base[key];
                else
                    myReturn = this.baseColor;

                return myReturn;
            }
            set { base[key] = value; }
        }

        public void SetKeyToColor(KeyCode key, Color color)
        {
            if(color.r == baseColor.r && color.g == baseColor.g && color.b == baseColor.b && this.ContainsKey(key))
                    this.Remove(key);
            else
            {
                if (this.ContainsKey(key))
                    this[key] = color;
                else
                    this.Add(key, color);
            }
        }

        public void SetKeyToColor(int x, int y, Color color)
        {
            SetKeyToColor(Config.Instance.KeyByPosition[y,x], color);
        }

        /// <summary>
        /// Sets a number of keys to the defined color
        /// </summary>
        /// <param name="keys">An array of keys to light up</param>
        /// <param name="color">The color to use</param>
        public void SetKeysToColor(KeyCode[] keys, Color color)
        {
            foreach (KeyCode key in keys)
            {
                SetKeyToColor(key, color);
            }
        }
    }
}
