using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using UnityEngine;
using UnityEngine.SceneManagement;
using IllusionPlugin;
namespace LightOut
{
    public class Plugin : IPlugin
    {
        public string Name => "LightSerialOutput";
        public string Version => "1.4.0";

        public void OnApplicationStart()
        {
            SceneManager.activeSceneChanged += SceneManagerOnActiveSceneChanged;
            SceneManager.sceneLoaded += SceneManager_sceneLoaded;

            //Checks if a IPlugin with the name in quotes exists, in case you want to verify a plugin exists before trying to reference it, or change how you do things based on if a plugin is present

        }

        private void SceneManagerOnActiveSceneChanged(Scene oldScene, Scene newScene)
        {

            if (newScene.name == "MenuCore")
            {
                //Code to execute when entering The Menu
                if (oldScene.name == "GameCore")
                {

                }

            }

            if (newScene.name == "GameCore" && Config.enabled)
            {
                new GameObject("EventListener").AddComponent<EventListener>();
            }


        }

        private void SceneManager_sceneLoaded(Scene scene, LoadSceneMode arg1)
        {
            //Create GameplayOptions/SettingsUI if using either
            if (scene.name == "MenuCore")
                UI.BasicUI.CreateSettingsUI();

        }

        public void OnApplicationQuit()
        {
            SceneManager.activeSceneChanged -= SceneManagerOnActiveSceneChanged;
            SceneManager.sceneLoaded -= SceneManager_sceneLoaded;
        }

        public void OnLevelWasLoaded(int level)
        {

        }

        public void OnLevelWasInitialized(int level)
        {
        }

        public void OnUpdate()
        {


        }

        public void OnFixedUpdate()
        {
        }
    }
}