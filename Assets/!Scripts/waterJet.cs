using UnityEngine;

public class waterJet : Grabable
{

 [SerializeField] public  GameObject objectToToggle;
    
     public override void OnAction()
    {
        Debug.Log("Action triggered!");
        if (objectToToggle != null)
        {
            objectToToggle.SetActive(true);
        }

    }

    public override void OnEndAction()
    {
        Debug.Log("Action released!");
        if (objectToToggle != null)
        {
            objectToToggle.SetActive(false);
        }
    }
}
