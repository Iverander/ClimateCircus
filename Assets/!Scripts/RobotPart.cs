using NaughtyAttributes;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RobotPart : Grabable 
{
    [SerializeField, Scene] string _sceneName;
    public override void OnPickup(Hand hand)
    {
       WinGame(); 
    }
    
    [Button]
    void WinGame()
    {
        SceneManager.LoadScene(_sceneName);
    }
}
