using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public void ChangeLayer(LayerMask a_layer)
    {
        gameObject.layer = GetLayerNumber(a_layer,31);
    }
    public int GetLayerNumber(LayerMask a_mask, int result)
    {
        if (1 << result == a_mask.value)
        {
            return result;
        }
        else if (result <= 0)
        {
            return 0;
        }
        else
        {
            return GetLayerNumber(a_mask, result - 1);
        }
    }
}
