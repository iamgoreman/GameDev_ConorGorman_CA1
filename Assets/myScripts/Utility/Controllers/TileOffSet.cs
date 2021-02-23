using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileOffSet : MonoBehaviour
{
    Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float speed = Time.deltaTime + 2f;
        rend.material.mainTextureOffset = new Vector2(speed, 0);
    }
}
