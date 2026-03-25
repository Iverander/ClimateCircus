using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class VRPortalTrigger : MonoBehaviour
{
    [SerializeField] private string sceneName;
    
    private bool isLoading = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isLoading)
        {
            StartCoroutine(LoadSceneAsync());
        }
    }

    IEnumerator LoadSceneAsync()
    {
        isLoading = true;

        // Optional: Trigger a Fade Out here if you have a Fade system
        // FadeScreen.Instance.FadeOut(); 

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        
        // This prevents the scene from switching until it's 100% ready
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            // When loading reaches 90%, it's actually ready to switch
            if (operation.progress >= 0.9f)
            {
                operation.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}

