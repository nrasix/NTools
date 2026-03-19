using System.IO;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;

namespace NTools.Extension
{
    public class AutoKeystoreSetter : IPreprocessBuildWithReport
    {
        // TODO: move to config
        private const string NAME_KEY_STORE = "user.keystore";
        private const string NAME_AND_PASSWORD_KEY_STORE = "dancegame";

        public int callbackOrder => 0;

        public void OnPreprocessBuild(BuildReport report)
        {
            if (report.summary.platform != BuildTarget.Android)
                return;

            if (!PlayerSettings.Android.useCustomKeystore)
            {
                var projectPath = Directory.GetParent(Application.dataPath).ToString();
                string keystorePath = Path.Combine(projectPath, NAME_KEY_STORE);
                PlayerSettings.Android.useCustomKeystore = true;
                PlayerSettings.Android.keystoreName = keystorePath;
            }

            string keystorePass = NAME_AND_PASSWORD_KEY_STORE;
            string keyAlias = NAME_AND_PASSWORD_KEY_STORE;
            string keyPass = NAME_AND_PASSWORD_KEY_STORE;

            PlayerSettings.Android.keystorePass = keystorePass;
            PlayerSettings.Android.keyaliasName = keyAlias;
            PlayerSettings.Android.keyaliasPass = keyPass;
        }
    }
}