using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;

public class ChangeScene : MonoBehaviour
{
    public Transform exteriorLoc;

    [YarnCommand("change_scene")]
    public static void SceneChange(string sceneName)
    {
        if (!string.IsNullOrEmpty(sceneName))
        { 
            SceneManager.LoadScene(sceneName);
        }
    }
}
