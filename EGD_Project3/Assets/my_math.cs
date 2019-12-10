using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class my_math
{
    public static Vector2 bounds;

    public static Vector2 Wrap (Vector2 pos, Vector2 tBounds)
    {
        bounds = tBounds;

        return Wrap(pos);
    }

    public static Vector2 Wrap(Vector2 pos)
    {
        if (Mathf.Abs(pos.x) > bounds.x)
        {
            pos.x *= -1f;
            pos.x *= 0.95f;
        }
        if (Mathf.Abs(pos.y) > bounds.y)
        {
            pos.y *= -1f;
            pos.y *= 0.95f;
        }
        return pos;
    }
}
