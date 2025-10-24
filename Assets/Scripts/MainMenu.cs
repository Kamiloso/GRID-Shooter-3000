using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject levelPrefab;

    public void StartGame()
    {
        LevelInitializer.LoadLevel(new LevelInitializer.InitializeData
        {
            LevelPrefab = levelPrefab,
        });
    }
}
