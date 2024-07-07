using System.Collections;
using System.Collections.Generic;
// using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameStateMachine gameStateMachine ;
    public Team team;
    public Team_enemy team_enemy;
    public GameObject[] playerPrefab;
    public AttributeData[] playerAttributeData;
    public GameObject[] enemyPrefab;
    public AttributeData[] enemyAttributeData;

#region init
    void InitSO()
    {
        playerAttributeData = new AttributeData[5];
        playerAttributeData[0] = Resources.Load<DollAttributeData>("SO/DollAttributeData");
        playerAttributeData[1] = Resources.Load<BigAttributeData>("SO/BigAttributeData");
        if(playerAttributeData[1] == null)
        {
            Debug.Log("AttributeData load failed");
        }
        enemyAttributeData = new AttributeData[5];
        enemyAttributeData[0] = Resources.Load<PiggyMan_daggerAttributeData>("SO/PiggyMan_daggerAttributeData");
        enemyAttributeData[1] = Resources.Load<PiggyMan_bowAttributeData>("SO/PiggyMan_bowAttributeData");
        if(enemyAttributeData[1] == null)
        {
            Debug.Log("AttributeData load failed");
        }
    }
    void InitPrefab()
    {
        playerPrefab = new GameObject[5];
        playerPrefab[0] = Resources.Load<GameObject>("Prefab/Doll");
        playerPrefab[1] = Resources.Load<GameObject>("Prefab/Big");
        if(playerPrefab[1] == null)
        {
            Debug.Log("Prefab load failed");
        }
        enemyPrefab = new GameObject[5];
        enemyPrefab[0] = Resources.Load<GameObject>("Prefab/PiggyMan_dagger");
        enemyPrefab[1] = Resources.Load<GameObject>("Prefab/PiggyMan_bow");
        if(enemyPrefab[1] == null)
        {
            Debug.Log("Prefab load failed");
        }
    }
    void InitGameStateMachine()
    {
        gameStateMachine = new GameStateMachine(this , Enums.EGameState.StartMenu);
        // gameStateMachine = new GameStateMachine(this , Enums.EGameState.LevelOn);
    }
    void InitTeam()
    {
        team = new Team();
        Structs.CreatureAttribute playerAttribute1 = playerAttributeData[0].CreateAttribute();
        Structs.CreatureAttribute playerAttribute2 = playerAttributeData[1].CreateAttribute();
        Structs.CreatureAttribute playerAttribute3 = playerAttributeData[1].CreateAttribute();
        team.AddPlayer(playerPrefab[0] , playerAttribute1 as Structs.PlayerAttribute , 0);
        team.AddPlayer(playerPrefab[1] , playerAttribute2 as Structs.PlayerAttribute , 1);
        team.AddPlayer(playerPrefab[1] , playerAttribute3 as Structs.PlayerAttribute , 2);
        #region test
            team.AddPlayerSO(playerAttributeData[0] , 0);
            team.AddPlayerSO(playerAttributeData[1] , 1);
            team.AddPlayerSO(playerAttributeData[1] , 2);
        #endregion

        team_enemy = new Team_enemy(this);
        team_enemy.SetPosition(0,new Vector3(53 , 5 , 63));
        team_enemy.SetPosition(1,new Vector3(76 , 5 , 65));
        team_enemy.SetPosition(2,new Vector3(59 , 5 , 84));
        team_enemy.SetPosition(3,new Vector3(63 , 5 , 42));
        // team_enemy.AddEnemy(0 ,0 , 1);
        // team_enemy.AddEnemy(0 ,1 , 1);
    }
#endregion

#region game state
    private void Update() 
    {
        gameStateMachine.Update();
    }
#endregion

#region archive
    public void SaveArchive()
    {

    }
    public void LoadArchive()
    {

    }
#endregion
    void Awake()
    {
        // Debug.Log("game manager awake");
        InitSO();
        InitPrefab();
        InitTeam();
    }
    void Start()
    {
        // Debug.Log("game manager start");
        InitGameStateMachine();
    }
}
