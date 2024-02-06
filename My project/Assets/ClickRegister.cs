using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickRegister : MonoBehaviour
{
    public List<int> clicks;
    public int maxSize;

    public void Start()
    {
        clicks = new List<int>();
    }
    public void SetPointsCount(int size)
    {
        maxSize = size;
    }
}
