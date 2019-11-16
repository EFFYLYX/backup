using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Vector3Extension 
{
  public static Vector2 Round(this Vector3 v)
    {
        
        int x = Mathf.RoundToInt(v.x);
        int y = Mathf.RoundToInt(v.y);
        //int x = (float)Math.Truncate(p.y);
        //int y = Mathf.RoundToInt(v.y);
        return new Vector2(x, y);
    }

    public static string toString(this Vector3 v)
    {
        return Mathf.RoundToInt(v.x).ToString() + "," + Mathf.RoundToInt(v.y);
    }
}
