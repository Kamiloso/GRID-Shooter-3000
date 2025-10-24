using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelInitializer : MonoBehaviour
{
    private static bool _initializing = false;
    private static InitializeData? _initializeData = null;

    public struct InitializeData
    {
        public GameObject LevelPrefab;
    }

    public static void LoadLevel(InitializeData initData)
    {
        if (!_initializing)
        {
            _initializing = true;
            _initializeData = initData;

            SceneManager.LoadScene(GridShooter.Core.GameSceneName);
        }
        else
        {
            UnityEngine.Debug.LogWarning(
                "Multiple LevelInitializer.LoadLevel() methods have been called!" +
                "Ignoring the last one.");
        }
    }

    private void Awake()
    {
        if (_initializing)
        {
            InitializeData init = _initializeData.Value;
            GameObject gobj = Instantiate(init.LevelPrefab, new Vector3(0f, 0f, 0f), Quaternion.identity);
            gobj.name = "Level";

            _initializing = false;
            _initializeData = null;
        }
        else
        {
            UnityEngine.Debug.LogWarning(
                "Couldn't load level! LevelInitializer must be a singleton in a game scene and scene " +
                "changing must be done by the LevelInitializer.LoadScene() method.");

            SceneManager.LoadScene(GridShooter.Core.MenuSceneName);
            UnityEngine.Debug.Log("Returning to main menu...");
        }
    }
}
