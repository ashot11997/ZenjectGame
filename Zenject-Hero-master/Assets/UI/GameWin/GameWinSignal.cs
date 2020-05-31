using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI.GameWin
{
    public class GameWinSignal
    {

        public GameWinSignal(bool value)
        {
            Value = value;
        }

        public bool Value { get; }
    }
}