using Ebac.Core.Singleton;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ColorManager : Singleton<ColorManager>
{
    public List<Material> materials;
    public List<ColorSetup> colorSetups;

    public void ChangeColorBy(ArtManager.ArtType type)
    {
        var setup = colorSetups.Where(c => c.artType == type).FirstOrDefault();

        for (int i = 0; i < materials.Count; i++)
        {
            materials[i].SetColor("_Color", setup.colors[i]);
        }
    }

}


[System.Serializable]
public class ColorSetup 
{
    public ArtManager.ArtType artType;
    public List<Color> colors;
}
