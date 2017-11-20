using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

    public SFXManager sfx; //Game's sfx manager 

    public float jumpForce; //Player's jumping force
    Rigidbody2D PlayerRigid; //Player's RigidBody2D

	// Use this for initialization
	void Start () {
        PlayerRigid = GetComponent<Rigidbody2D>(); //Accessing Player's Rigidbody2D and putting it inside PlayerRigid
	}

    public void RemoveConstraints() //Removes all RigidBody2D Constraints
    {
        PlayerRigid.constraints = RigidbodyConstraints2D.None; //Freezes the player in all RigidBody2D constraint Axes
    }

    public void PlayerJump() //Player jumps by altering the Player's Y-axis velocity
    {
        sfx.birdJump.Play(); // Plays the Jump sound from the SFXManager
        PlayerRigid.velocity = new Vector2(PlayerRigid.velocity.x, jumpForce); // Increases the players velocity to the value of 'jumpForce'
    }

    void OnCollisionEnter2D(Collision2D obj) //Collisions
    {
        if (obj.gameObject.tag == "Pipe" || obj.gameObject.tag == "Ground")  // if the player collided with an object tagged "Pipe" or "Ground"
        {
            sfx.birdHit.Play(); // Plays the bird hit sound effect
            GameData.gameOver = true; // Game Over ; Player dies
            PlayerJump(); // A jump to exit the screen
            GetComponent<PolygonCollider2D>().enabled = false; //Disables Player's Collider2D
        }
    }

    void OnTriggerEnter2D(Collider2D obj) //Triggers
    {
        if(obj.gameObject.tag == "ScoreTrigger") // if the player entered trigger has the tag "ScoreTrigger"
        {
            sfx.birdScore.Play(); // Plays the score sound effect
            GameData.gameScore++; // Game score increases by 1;
        }
    }
}
