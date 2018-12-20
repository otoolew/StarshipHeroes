using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "newResourceFieldConfig", menuName = "Resource Field/Resource Field Configuration")]
public class ResourceFieldConfig : ScriptableObject
{
    public ResourcePack resourcePackPrefab;
    [Range(1,10)]
    public int maxResourcePacks;

}
