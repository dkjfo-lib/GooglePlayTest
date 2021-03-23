using myEx;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistrictStylizer : MonoBehaviour
{
    public Transform styleHolder;

    IDistrictDesigner[] designers = new IDistrictDesigner[]
    {
        new DesignCleaner(),
        new CityDesigner(),
    };

    public void Redesign(DistrictStyle style)
    {
        RedesignDistrict(style.districtType);
    }

    void RedesignDistrict(DistrictType districtType)
    {
        int designerId = (int)districtType;
        if (designerId > designers.Length)
        {
            Debug.LogError("No style found!", gameObject);
            return;
        }
        designers[designerId].Design(styleHolder);
    }
}

interface IDistrictDesigner
{
    void Design(Transform styleHolder);
}

public class DesignCleaner : IDistrictDesigner
{
    public void Design(Transform styleHolder)
    {
        styleHolder.DestroyChildren();
        Debug.Log("Empty now!", styleHolder.parent);
    }
}

public class CityDesigner : IDistrictDesigner
{
    public static Vector2Int buildingsRange = new Vector2Int(5, 30);
    public static Vector2[] buildingsScaleRange = new[]
    {
        new Vector2(.1f, .3f),
        new Vector2(.1f, .3f),
        new Vector2(.1f, .3f),
    };
    public static Vector2 localPosition = new Vector2(-.5f, .5f);

    public void Design(Transform styleHolder)
    {
        var house = GameHolder.PrefabsManager.prefabs.GetObject("House");

        int houseCount = MyRandom.Range(buildingsRange);

        for (int i = 0; i < houseCount; i++)
        {
            var localScale = MyRandom.Range(buildingsScaleRange);
            Vector3 localPoint = new Vector3(
                MyRandom.Range(localPosition), .1f,
                MyRandom.Range(localPosition));

            var newHouse = GameObject.Instantiate(house);
            newHouse.transform.parent = styleHolder;
            newHouse.transform.localPosition = localPoint;
            newHouse.transform.localScale = new Vector3(localScale[0], localScale[1], localScale[2]);
        }
        Debug.Log("City now!", styleHolder.parent);
    }
}