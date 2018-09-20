using UnityEngine;

public partial class playerController
{
    private void OnTriggerStay(Collider other) 
    {
        
        //TODO: Currently aim area also picks up items, don't do that
        if (Input.GetButtonDown("Action") && other.CompareTag("item"))
        {
            switch (other.gameObject.name)
            {
                case "ammoClip":
                    Bullets += 10;
                    Debug.Log("Ammo Clip Added");
                    other.gameObject.SetActive(false);
                    break;
                default:
                    Debug.Log("no item found");
                    break;
            }
        }
    }
}