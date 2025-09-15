using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMamager : MonoBehaviour
{
    public static GameMamager instance;
    public Player player;
    private void Awake()
    {
        instance = this;
    }


}
