using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI.GameOver
{
    public class GameOverSignal
    {
        public GameOverSignal(bool value)
        {
            Value = value;
        }

        public bool Value { get; }
    }
}