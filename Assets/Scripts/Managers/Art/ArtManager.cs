using Ebac.Core.Singleton;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ArtManager : Singleton<ArtManager>
{
    public enum ArtType
    {
        Type_01,
        Type_02,
        Type_03
    }

    public List<ArtSetup> artSetups;

    public ArtSetup GetSetupByType(ArtType type) 
    {
        return artSetups.Where(s => s.artType ==  type).FirstOrDefault();
    }
}

[System.Serializable]
public class ArtSetup
{
    public ArtManager.ArtType artType;
    public GameObject gameObject;

}