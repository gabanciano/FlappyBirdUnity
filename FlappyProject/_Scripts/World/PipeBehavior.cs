using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeBehavior : MonoBehaviour {

    public float pipeSpeed; //Speed declaration

    // Update is called once per frame
    void Update()
    {
        if (!GameData.gameOver)
        {
            transform.Translate(new Vector2(-pipeSpeed * Time.deltaTime, 0)); //Moves the pipe to the left with the speed of 'pipeSpeed' and normalized with Time.deltaTime
        }
    }
}
