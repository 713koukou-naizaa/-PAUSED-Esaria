using UnityEngine;

public class camera_follow : MonoBehaviour
{
    public float float_time_off_set; // adds time off set parameter for the camera follow to be delayed compared to player movements
    public GameObject player; // introduces player to follow
    public Vector3 pos_off_set; // gives backstep to camera for it to follow player (z=-10 in Unity)

    private Vector3 velocity; // obligatory red value to velocity


    void Update()
    {
        transform.position=Vector3.SmoothDamp(transform.position,player.transform.position + pos_off_set,ref velocity,float_time_off_set); // makes camera follow player with smoothdamp movement
    }
}
