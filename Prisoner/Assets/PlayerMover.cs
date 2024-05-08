using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    PlayerMovement playerMovement;
    LevelExit levelExit;

    void Update()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        levelExit = FindObjectOfType<LevelExit>();
        
    }

    public void ClimbUp()
    {
        playerMovement.moveInput.y=1;
    }

    public void ClimbDown()
    {
        playerMovement.moveInput.y=-1;
    }

    public void ClimbStop()
    {
        playerMovement.moveInput.y=0;
    }

    

    public void LeftBtn()
    {
        if(levelExit.ended == false)
            playerMovement.moveInput.x = -1;
    }

    public void RightBtn()
    {
        if(levelExit.ended == false)
            playerMovement.moveInput.x = 1;
    }

    public void StopBtn()
    {
        playerMovement.moveInput.x = 0;
    }
    
    public void JumpBtn()
    {
        if (!playerMovement.isAlive ) {return;}

        if (!playerMovement.feetcol.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            return;
        }
        if(levelExit.ended == false){
        SoundMnager.instance.FxPlay(0);
        playerMovement.rigid.velocity += new Vector2(0f,playerMovement.jumpSpeed);
        }
    }
}
