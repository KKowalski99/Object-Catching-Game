using UnityEngine;
using UnityEngine.SceneManagement;

public sealed class BootView : MonoBehaviour
{
    public static BootView Instance { get; private set; }

    private Scene scene;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else
        {
            Debug.LogWarning($"SceneManager duplicated, game object has been destroyed", this);
            Destroy(gameObject);
        }
        scene = SceneManager.GetActiveScene();
    }

    private void Start()
    {
        if (scene.name == SceneNames.bootSceneName)
        {
            if (SceneManager.GetSceneByName(SceneNames.coreSceneName).isLoaded == false)
            {
                SceneManager.LoadSceneAsync(SceneNames.coreSceneName, mode: LoadSceneMode.Additive);
            }


            if (SceneManager.GetSceneByName(SceneNames.uiSceneName).isLoaded == false)
            {
                SceneManager.LoadSceneAsync(SceneNames.uiSceneName, mode: LoadSceneMode.Additive);
            }
          
        }
    }
}

/// <summary>
/// In case of project expansion, move to a separate dll file (notice that strings access modifiers should be public then)
/// </summary>
public sealed record SceneNames
{
    internal const string bootSceneName = "BootScene";
    internal const string coreSceneName = "CoreScene";
    internal const string uiSceneName = "UIScene";
}
