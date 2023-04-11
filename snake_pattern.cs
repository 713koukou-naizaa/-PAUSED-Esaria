using UnityEngine;

public class snake_pattern : MonoBehaviour
{

    public float float_move_speed; // snake speed var
    public Transform[] waypoints; // list of waypoints for snake pattern
    public SpriteRenderer graphics;
    private Transform target; // target towards the which snake will move = waypoints
    private int int_destination=0; // destination point in waypoints list

    void Start()
    {
        target=waypoints[0]; // when game starts: snake goes to first point of list waypoints
    }

    void Update()
    {
        Vector3 dir=target.position - transform.position; // gives direction towards the which snake has to move
        transform.Translate(dir.normalized * float_move_speed * Time.deltaTime, Space.World); // applies movement to constant direction: dir.normalized: vector magnitude=1

        if(Vector3.Distance(transform.position,target.position)<0.3f) // if snake almost to destination
        {
            int_destination=(int_destination+1) % waypoints.Length; // sets destination to next point in list waypoints (%: modulo waypoints.Length=0 so snake goes back to first point)
            target=waypoints[int_destination]; // sets target to value of destination in waypoints list
            graphics.flipX=!graphics.flipX;
        }
    }
}
