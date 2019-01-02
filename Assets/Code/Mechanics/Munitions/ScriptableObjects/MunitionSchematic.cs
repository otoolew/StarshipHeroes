using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "newMunition", menuName = "Munition")]
public class MunitionSchematic : ScriptableObject
{
    public Munition munitionPrefab;
    public int range;
    public int speed;
    public int damage;
}
