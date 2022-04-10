using System.Collections.Generic;
using UnityEngine;

public static class MyUtilities
{
    public static bool TossACoin(float probability) =>
        Random.Range(0f, 1f) < probability;
}
