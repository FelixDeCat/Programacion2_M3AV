using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMamager : MonoBehaviour
{
    public static GameMamager instance;
    public Player player;

    [SerializeField] Enemy[] enemies;
    private void Awake()
    {
        instance = this;
    }

    public void AddEneemy(Enemy e)
    {
        //agrego enemigo 2
    }


}
