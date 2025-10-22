using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GridShooter
{
    public class MyScript : MonoBehaviour, IGlobalSingleton<MyScript>
    {
        public string JakiesDane = "To jest singleton!";

        void Start()
        {
            MyScript singleton = IGlobalSingleton<MyScript>.Instance;
            UnityEngine.Debug.Log(singleton.JakiesDane);
        }

        void Update()
        {

        }
    }
}
