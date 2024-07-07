using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class Team_enemy 
{
    private GameManager gameManager;
    public int[,] enemyNum ;
    public Enemy[,,] enemy;
    public Vector3[] position;
    public Structs.EnemyAttribute[,,] enemyAttribute ;
    public int enemyNum_survive ;
    public Team_enemy(GameManager gameManager)
    {
        this.gameManager = gameManager;
        enemyNum = new int[5,5]{{0 , 0 , 0 , 0 , 0},{0 , 0 , 0 , 0 , 0},{0 , 0 , 0 , 0 , 0},{0 , 0 , 0 , 0 , 0},{0 , 0 , 0 , 0 , 0}};
        enemy = new Enemy[5 , 5 , 10];
        position = new Vector3[5];
        enemyAttribute = new Structs.EnemyAttribute[5,5,10];
    }
    public void BegBattle()
    {
        enemyNum_survive = 0;
        for(int k = 0 ; k < 5 ; k++)
        {
            for(int i = 0 ; i < 5 ; i ++)
            {
                for(int j = 0 ; j < enemyNum[k,i] ; j ++)
                {
                    enemyNum_survive ++;
                    if(gameManager.enemyPrefab[i] == null)
                    {
                        Debug.Log("error: enemy prefab not found");
                    }
                    GameObject mid = GameObject.Instantiate(gameManager.enemyPrefab[i]);
                    mid.name = "Enemy_" + i + "_" + j;
                    enemy[k,i,j] = mid.GetComponent<Enemy>();
                    enemyAttribute[k,i,j] = gameManager.enemyAttributeData[i].CreateAttribute() as Structs.EnemyAttribute;
                // Debug.Log("create enemy " + mid.name);
                    enemy[k,i,j].InitAttribute(enemyAttribute[k,i,j] , this);
                    enemy[k,i,j].gameObject.GetComponent<CharacterController>().enabled = false ;
                    enemy[k,i,j].transform.position = position[k] + new Vector3(Random.Range(-4,4) , 0 , Random.Range(-4,4));
                    enemy[k,i,j].gameObject.GetComponent<CharacterController>().enabled = true ;
                    // Debug.Log("enemy position : " + enemy[k,i,j].transform.position);
                }
            }

        }
    }
    
    public void ModifyAttribute()
    {
        for(int k = 0 ; k < 5 ; k++)
        {
            for(int i = 0 ; i < 5 ; i ++)
            {
                for(int j = 0 ; j < enemyNum[k,i] ; j ++)
                {
                    enemyAttribute[k,i,j] = gameManager.enemyAttributeData[i].ModifyAttribute(enemyAttribute[k,i,j]) as Structs.EnemyAttribute;
                }
            }
        }
    }
    public void AddEnemy(int positionId, int id , int num)
    {
        enemyNum[positionId,id] += num;
        if(enemyNum[positionId,id] >=5 )
        {
            Debug.Log("too many enemy");
        }
    }
    public void CleanEnemy()
    {
        for(int i = 0 ; i < 5 ; i ++)
        {
            for(int j = 0 ; j < 5 ;j++)
            {
                enemyNum[i , j] = 0;
            }
        }
    }
    public void SetPosition(int positionId, Vector3 position)
    {
        this.position[positionId] = position;
    }
    public void EnemyDie()
    {
        enemyNum_survive --;
    }
}
