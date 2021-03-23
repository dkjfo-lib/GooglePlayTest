using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct DistrictStyle
{
    public TerrainType terrainType;
    public DistrictType districtType;
}

public enum TerrainType
{
    flat,
    hill,
    mountain,
    water,
}
public enum LandStyleType
{
    meadow,
    forest,
    river,
}
public enum WaterStyleType
{
    lake,
    sea,
    swamp,
}
public enum DistrictType
{
    empty,
    city,
    farm,
    mine,
    port,
}
