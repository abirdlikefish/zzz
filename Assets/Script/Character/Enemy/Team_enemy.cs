using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Team_enemy 
{
    private GameManager gameManager;
    public int[] enemyNum ;
    public Enemy[,] enemy;
    public Structs.EnemyAttribute[,] enemyAttribute ;
    public Team_enemy(GameManager gameManager)
    {
        this.gameManager = gameManager;
        enemyNum = new int[5]{0 , 0 , 0 , 0 , 0};
        enemy = new Enemy[5 , 10];
        enemyAttribute = new Structs.EnemyAttribute[5,10];
    }
    public void BegBattle()
    {
        for(int i = 0 ; i < 5 ; i ++)
        {
            for(int j = 0 ; j < enemyNum[i] ; j ++)
            {
                if(gameManager.enemyPrefab[i] == null)
                {
                    Debug.Log("error: enemy prefab not found");
                }
                GameObject mid = GameObject.Instantiate(gameManager.enemyPrefab[i]);
                mid.name = "Enemy_" + i + "_" + j;
                enemy[i,j] = mid.GetComponent<Enemy>();
                enemyAttribute[i,j] = gameManager.enemyAttributeData[i].CreateAttribute() as Structs.EnemyAttribute;
            // Debug.Log("create enemy " + mid.name);
                enemy[i,j].InitAttribute(enemyAttribute[i,j]);
            }
        }
    }
    
    public void ModifyAttribute()
    {
        for(int i = 0 ; i < 5 ; i ++)
        {
            for(int j = 0 ; j < enemyNum[i] ; j ++)
            {
                enemyAttribute[i,j] = gameManager.enemyAttributeData[i].ModifyAttribute(enemyAttribute[i,j]) as Structs.EnemyAttribute;
            }
        }
    }
    public void AddEnemy(int id , int num)
    {
        enemyNum[id] += num;
        if(enemyNum[id] >=5 )
        {
            Debug.Log("too many enemy");
        }
    }
}
