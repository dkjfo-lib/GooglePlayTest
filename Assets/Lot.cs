using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DistrictStylizer))]
public class Lot : MonoBehaviour
{
    public Vector2Int gridPosition;
    public DistrictStyle style;

    public DistrictStyle previousStyle;
    private DistrictStylizer stylizer;

    void Start()
    {
        stylizer = GetComponent<DistrictStylizer>();
        StartCoroutine(OnDistrictChange());
    }

    IEnumerator OnDistrictChange()
    {
        while (true)
        {
            yield return new WaitWhile(() => style.Equals(previousStyle));
            ChangeDistrict();
        }
    }

    void ChangeDistrict()
    {
        Debug.Log("type changed!");
        stylizer.Redesign(style);
        previousStyle = style;
    }
}
