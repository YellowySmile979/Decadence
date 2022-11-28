using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerPatroller : MonoBehaviour
{

    Rigidbody2D rb;
    Vector2 origin;
    float moveDirection = 1; // Where we are moving towards currently.

    public float patrolDistance = 4f; //sets how far the slime moves from origin point
    public float moveSpeed = 3f; //sets how fast the enemy moves

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //Records the original position of the enemy.
        origin = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(moveSpeed * moveDirection, rb.velocity.y);

        // Make the enemy flip after he exceeds his patrol distance.
        if (moveDirection > 0 && transform.position.x > origin.x + patrolDistance)
        {
            moveDirection *= -1;
        }
        else if (moveDirection < 0 && transform.position.x < origin.x - patrolDistance)
        {
            moveDirection *= -1;
        }
    }

    //responsible for drawing the lines which state how far the enemy moves
    void OnDrawGizmosSelected()
    {
        // Use the colour you want.
        Gizmos.color = Color.cyan;

        // Which should we use as the origin?
        //the ? is a ternary operator
        //Application.isPlaying is to check if the game is being played right now
        //then if it is true, as the game is being played,
        //then the origin is the slime and the lines are set to this origin so that the lines don't move with the slime
        //otherwise, the lines follow the slime when the game is not being played so that the lines follow
        Vector2 o = Application.isPlaying ? origin : (Vector2)transform.position;

        // Draw the left and right lines.
        Vector2 leftPoint = o - new Vector2(patrolDistance, 0);
        Vector2 rightPoint = o + new Vector2(patrolDistance, 0);
        Gizmos.DrawLine(leftPoint, leftPoint + Vector2.up);
        Gizmos.DrawLine(rightPoint, rightPoint + Vector2.up);
    }
}
