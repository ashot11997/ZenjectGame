using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI.GameOver
{
    public class GameOver : MonoBehaviour
    {
        public GameObject Text;

        private bool _toggleValue = false;

        public void Toggle(bool value)
        {
            _toggleValue = value;
            Text.SetActive(value);
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


        private void Start()
        {
            Toggle(false);
        }
    }
}