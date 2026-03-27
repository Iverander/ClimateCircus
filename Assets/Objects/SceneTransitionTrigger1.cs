using UnityEngine;
using UnityEngine.SceneManagement;

public class VRPortalTrigger : MonoBehaviour
{
    [SerializeField] private string sceneName = "RingmasterScene";
    private bool isLoading = false;

    // Este comando deteta qualquer coisa que encoste no Plane
    private void OnTriggerEnter(Collider other)
    {
        // 1. Mensagem básica de contacto
        Debug.Log("CONTACT DETECTED! Object: " + other.name + " | Tag: " + other.tag);

        // 2. Verifica se a TAG coincide
        if (other.CompareTag("Player"))
        {
            if (!isLoading)
            {
                isLoading = true;
                Debug.Log("SUCCESS! Loading scene: " + sceneName);
                SceneManager.LoadScene(sceneName);
            }
        }
        else
        {
            Debug.LogWarning("Object touched, but Tag is NOT 'Player'. It is: " + other.tag);
        }
    }
}
