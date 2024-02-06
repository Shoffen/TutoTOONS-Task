using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineLogic : MonoBehaviour
{
    public Sprite spriteToAssign;
    private LineRenderer line;

    public Transform pos1;
    public Transform pos2;

    void Start()
    {
        line = GetComponent<LineRenderer>();
        //line.material.mainTexture = spriteToAssign.texture;

        line.positionCount = 2;


        line.sortingOrder = 1;
        line.material = new Material(Shader.Find("Sprites/Default"));
        line.material.color = Color.red;

    }
    private void Update()
    {
        line.SetPosition(0, pos1.position);
        line.SetPosition(1, pos2.position);
    }
}
