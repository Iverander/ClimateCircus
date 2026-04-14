
using UnityEngine;

public class ExtinguishTorch : MonoBehaviour
{
    public Torches mainTorchesSystem; 
    private bool isExtinguished = false; 
    public void Extinguish()
    {
        if (isExtinguished) return; 

        isExtinguished = true; // Lock it so it can't run again
        
        if (mainTorchesSystem != null)
        {
            mainTorchesSystem.DecreaseLight();
        }
        Destroy(this.gameObject);
    }
}
