using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NTools.Utility
{
    [InitializeOnLoad]
    public static class AutoLoadFirstScene
    {
        private const string PREVIOUS_SCENE_KEY = "PREVIOUS SCENE";

        static AutoLoadFirstScene()
        {
            EditorApplication.playModeStateChanged += OnPlayModeStateChanged;
        }

        private static void OnPlayModeStateChanged(PlayModeStateChange state)
        {
            if (EditorApplication.isPlaying)
                return;

            if (EditorApplication.isPlayingOrWillChangePlaymode)
                InitializeFirstScene();
            else
                LoadPreviousScene();
        }

        private static void InitializeFirstScene()
        {
            var currentScene = SceneManager.GetActiveScene();
            var pathPreviousScene = currentScene.path;
            EditorPrefs.SetString(PREVIOUS_SCENE_KEY, pathPreviousScene);

            if (currentScene.buildIndex == 0)
                return;

            if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
            {
                var path = EditorBuildSettings.scenes[0].path;
                LoadSceneFromPath(path);
            }
            else
            {
                EditorApplication.isPlaying = false;
            }
        }

        private static void LoadPreviousScene()
        {
            var path = EditorPrefs.GetString(PREVIOUS_SCENE_KEY);
            LoadSceneFromPath(path);
        }

        private static void LoadSceneFromPath(string path)
        {
            try
            {
                EditorSceneManager.OpenScene(path);
            }
            catch
            {
                Debug.LogError($"Cannot load scene from - {path}!");
                EditorApplication.isPlaying = false;
            }
        }
    }
}