using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState_levelOn : GameState
{
    public GameState_levelOn(GameStateMachine gameStateMachine, Enums.EGameState eGameState) : base(gameStateMachine, eGameState)
    {
        Structs.PlayerAttribute playerAttribute = new Structs.PlayerAttribute
        {
            ID = 0,

            hp = 100,
            hp_max = 100,
            poise = 100,
            poise_max = 100,

            minAngleCos = -0.1f,

            direction = Vector3.forward,

            isInvisible = false,

            invisibleTime_dash = 0.5f,
            isInvisible_dash = -1,
            prepareTime_dash = 0,

            invisibleTime_parry = 0.5f,
            isInvisible_parry = -1,
            prepareTime_parry = 0 ,
            damage_poise_parry = 10,
            isInvisible_defend = false
        };
        GameObject player = GameObject.Find("Doll");
        if(player == null)
        {
            Debug.LogError("error to find doll");
            return;
        }
        Doll doll =player.GetComponent<Doll>();
        doll.InitPlayerAttribute(playerAttribute);
    }
    public override void Update()
    {

    }
}
