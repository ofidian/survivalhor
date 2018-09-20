using UnityEngine;

public partial class playerController
{
    private void PlayerAimAttack()
    {
        //Create aiming object (Aim Weapon) when button held down
        aimArea.SetActive(Input.GetButton("Aim"));

        //When you stop aiming change the tag of all enemies in the aim area to just enemy
        if (Input.GetButtonUp("Aim"))
        {
            GameObject[] enemyArray = GameObject.FindGameObjectsWithTag("enemyActive");

            foreach (var t in enemyArray)
            {
                t.tag = "enemy";
            }
        }

        //Track ammo in clip and reload when empty and trying to fire
        if (aimArea.activeSelf)
        {
            if (Input.GetButtonDown("Action"))
            {
                if (clipSize >= 1)
                {
                    --clipSize;
                }
                else if (clipSize <= 0)
                {
                    Reload();
                }
            }
           
            if (Input.GetKeyDown("r"))//TODO: connect to action input
            {
                Reload();
            }
        }

        
    }

    private void Reload()
    {
        int clipChecker = maxClipSize - clipSize;

        if (Bullets >= clipChecker)
        {
            clipSize += clipChecker;
            Bullets -= clipChecker;
        }
        else if (Bullets < clipChecker)
        {
            clipSize += Bullets;
            Bullets = 0;
        }
    }
}

