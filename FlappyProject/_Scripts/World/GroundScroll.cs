using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScroll : MonoBehaviour {

    public float scrollingSpeed; //Material scrolling speed
    Vector2 offset; //Material Offset value

    void Update()
    {
        if (!GameData.gameOver)
        {
            offset = new Vector2(Time.time * scrollingSpeed, 0); //Time.time means to normalize time instead of 60 frames
            GetComponent<Renderer>().material.mainTextureOffset = offset; //Applies the value of the offset
        }
    }
}
