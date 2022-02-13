using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Setting", menuName = "lavaProjectaAddon/CharacterSettings", order = 1)]
public class PlayerState : ScriptableObject
{
    public float CHARACTER_SPEED;
    public float SHOOTING_SPEED;
    public float BULLET_POWER;
}

