using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeigthedDirection
{

    public readonly Vector2 direction;
    public readonly float weight;

    public WeigthedDirection(Vector2 dir, float wgt)
    {
        direction = dir.normalized;
        weight = wgt;
    }


}
