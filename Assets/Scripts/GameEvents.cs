﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    #region Singleton
    public static GameEvents instance;
    private void Awake()
    {
        instance = this;
        //DontDestroyOnLoad(this.gameObject);
    }
    #endregion



    //Move a singular unit
    public event Action<Unit, Vector3> moveUnit;
    public void MoveUnit(Unit unit, Vector3 point) => moveUnit?.Invoke(unit, point);

    //Scan for player in aggro range
    public event Action scanForPlayerInAggroRange;
    public void ScanForPlayerInAggroRange() => scanForPlayerInAggroRange?.Invoke();

    //Scan for player in attack range
    public event Action scanForPlayerInAttackRange;
    public void ScanForPlayerInAttackRange() => scanForPlayerInAttackRange?.Invoke();

    //Do damage
    public event Action<Unit, Unit, int> doDamage;
    public void DoDamage(Unit givesDamage, Unit takesDamage, int amount) => doDamage?.Invoke(givesDamage, takesDamage, amount);

    //Turn pass
    public event Action turnPass;
    public void TurnPass() => turnPass?.Invoke();

    //Add an item to the inventory
    public event Action<Item, int> addItem;
    public void AddItem(Item toAdd, int amount) => addItem?.Invoke(toAdd, amount);

    //Remove an item from the inventory

    public event Action<Item, int> removeItem;
    public void RemoveItem(Item toAdd, int amount) => removeItem?.Invoke(toAdd, amount);

    //Remove an item from the inventory

    public event Action<Item> useItem;
    public void UseItem(Item toAdd) => useItem?.Invoke(toAdd);

    //Enemy destruction event
    public event Action<EnemyUnit> enemyDestruction;
    public void EnemyDestruction(EnemyUnit unit) => enemyDestruction?.Invoke(unit);

    //Dungeon data event
    public event Action<DungeonData> pushDungeonData;
    public void PushDungeonData(DungeonData dungeonData) => pushDungeonData?.Invoke(dungeonData);

}