using UnityEngine;

public class Torches : MonoBehaviour
{
    private int torchesCount = 5; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void DecreaseLight()
    {
        torchesCount--; 
        Debug.Log("Torch put out! Remaining: " + torchesCount);
        if(torchesCount <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    
}
