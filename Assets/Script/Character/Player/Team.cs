using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Team 
{
    public CameraController cameraController ;
    Player[] players ;
    GameObject[] playerPrefabs;
    Structs.PlayerAttribute[] playerAttributes;
    AttributeData[] attributeDatas ;
    private int currentPlayerID ;
    // public Enemy targetEnemy ;
    public Team()
    {
        players = new Player[3];
        playerPrefabs = new GameObject[3];
        playerAttributes = new Structs.PlayerAttribute[3];
        attributeDatas = new AttributeData[3];
    }
    public void AddPlayer(GameObject player , Structs.PlayerAttribute attribute, int order)
    {
        playerPrefabs[order] = player;
        playerAttributes[order] = attribute;
    }
    
    public void AddPlayerSO(AttributeData data , int order)
    {
        attributeDatas[order] = data;
    }

    public void ModifyAttribute()
    {
        playerAttributes[0] = attributeDatas[0].ModifyAttribute(playerAttributes[0]) as Structs.PlayerAttribute;
        playerAttributes[1] = attributeDatas[1].ModifyAttribute(playerAttributes[1]) as Structs.PlayerAttribute;
        // playerAttributes[2] = attributeDatas[2].ModifyAttribute(playerAttributes[2]) as Structs.PlayerAttribute;
    }
    
    public void BegBattle(CameraController cameraController)
    {
        // Debug.Log("team begin battle");
        this.cameraController = cameraController;
        currentPlayerID = 1;
        for(int i = 0 ; i < 2 ; i ++)
        {
            GameObject mid = GameObject.Instantiate(playerPrefabs[i]);
            mid.name = "Player_" + i;
            players[i] = mid.GetComponent<Player>();
            players[i].InitPlayerStateMachine(Enums.EPlayerState.BackEnd);
            players[i].InitPlayerAttribute(playerAttributes[i]);
            players[i].InitTeam(this);
        }
        players[0].transform.position = new Vector3(60 , 0 , 60);
        // FindEnemy();
        ChangeCharacter(Enums.EPlayerState.Idle , players[0].transform);
    }

    public void ChangeCharacter(Enums.EPlayerState eState , Transform midTransform)
    {
        currentPlayerID ++;
        if(currentPlayerID == 2)    currentPlayerID = 0;
        // if(IsParry())
        // {
        //     Debug.Log("parrying");
        //     players[currentPlayerID].Appear(Enums.EPlayerState.Parry , midTransform);
        // }
        // else
        // {
            players[currentPlayerID].Appear(eState , midTransform);
        // }
        cameraController.SetTarget(players[currentPlayerID].transform);
    }
    public void ChangeCharacter_Parry(Vector3 position , Vector3 direction)
    {
        // Debug.Log("parrying");
        currentPlayerID ++;
        if(currentPlayerID == 2)    currentPlayerID = 0;
        players[currentPlayerID].Appear(position , direction);
        cameraController.SetTarget(players[currentPlayerID].transform);
    }

    public bool CanChangeCharacter()
    {
        int nextId = currentPlayerID + 1;
        if(nextId == 2) nextId = 0;
        if(players[nextId].playerStateMachine.playerStateNow.ePlayerState == Enums.EPlayerState.BackEnd)
            return true ;
        else
            return false ;
    }

}