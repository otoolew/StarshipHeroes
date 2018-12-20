using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarshipFactory : MonoBehaviour
{

    public FactionAlignment factionAlignment;
    public StarshipSchematic playerSchematic;
    public StarshipSchematic fighterSchematic;
    public StarshipSchematic workerSchematic;
    public StarshipSchematic defenderSchematic;

    public void SpawnFighter(StarshipSchematic schematic, FactionAlignment factionAlignment)
    {
        Starship starship = Resources.Load<Starship>("Starship");

        for (int i = 0; i < schematic.weaponSchematics.Length; i++)
        {
            WeaponComponent weaponComponent = Resources.Load<WeaponComponent>("WeaponComponent");
            weaponComponent.WeaponSchematic = schematic.weaponSchematics[i];
            weaponComponent.transform.parent = starship.transform;
            weaponComponent.FactionAlignment = factionAlignment;
            weaponComponent.name = weaponComponent.name.Replace("(Clone)", "");
        }
        for (int i = 0; i < schematic.engineSchematics.Length; i++)
        {
            EngineComponent engineComponent = Resources.Load<EngineComponent>("EngineComponent");
            engineComponent.EngineSchematic = schematic.engineSchematics[i];
            engineComponent.transform.parent = starship.transform;
            engineComponent.name = engineComponent.name.Replace("(Clone)", "");
        }
        //starshipPrefab.transform.parent = controller.transform;
        //if (starshipPrefab == null)
        //{
        //    Debug.LogError("No Prefab for name: " + schematic.starshipRole.ToString());
        //    return new GameObject(schematic.starshipRole.ToString());
        //}
        //GameObject instance = GameObject.Instantiate(starshipPrefab);
        //instance.name = instance.name.Replace("(Clone)", "");
        //return instance;
    }

    //public static Starship InstantiatePrefab(StarshipSchematic schematic)
    //{
    //    NPCController controller = Resources.Load<NPCController>("NPC_Starship");
    //    GameObject starshipPrefab = Resources.Load<GameObject>(schematic.starshipRole.ToString());

    //    if (starshipPrefab == null)
    //    {
    //        Debug.LogError("No Prefab for name: " + schematic.starshipRole.ToString());
    //        return null;
    //    }

    //    starshipPrefab.transform.parent = controller.transform;

    //    NPCController instance = NPCController.Instantiate(controller);
    //    instance.name = instance.name.Replace("(Clone)", "");
    //    return instance;
    //}

    ////static void AddStats(GameObject obj)
    ////{
    ////    Stats s = obj.AddComponent<Stats>();
    ////    s.SetValue(StatTypes.LVL, 1, false);
    ////}

    //static void AddJob(GameObject obj, string name)
    //{
    //    GameObject instance = InstantiatePrefab("Jobs/" + name);
    //    instance.transform.SetParent(obj.transform);
    //    Job job = instance.GetComponent<Job>();
    //    job.Employ();
    //    job.LoadDefaultStats();
    //}

}
