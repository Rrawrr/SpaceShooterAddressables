using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;
using UnityEngine.Serialization;

public class SceneLoader : MonoBehaviour
{
    public string nextSceneAddress;
    AsyncOperationHandle preloadOp;
    
    // Start is called before the first frame update
    void Start()
    {
        Addressables.DownloadDependenciesAsync("preload").Completed += OnContentDownloaded;
    }

    void OnContentDownloaded(AsyncOperationHandle op)
    {
        Debug.Log("CONTENT DOWNLOADED");
        Addressables.LoadSceneAsync(nextSceneAddress).Completed += OnSceneLoaded;
    }

    void OnSceneLoaded(AsyncOperationHandle<SceneInstance> op)
    {
        Debug.Log("SCENE LOADED");
    }


}
