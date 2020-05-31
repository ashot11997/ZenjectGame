using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI.GameWin
{
    public class GameWin : MonoBehaviour
    {
        public GameObject UI;

        private bool _toggleValue = false; 

        void Start()
        {
            Toggle(false);
        }

        public void Toggle(bool value)
        {
            _toggleValue = value;
            UI.SetActive(value);
        }

        private void Update()
        {
            if (_toggleValue == true)
            {
                if (Input.GetKey(KeyCode.Escape))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
            }
        }

    }
}