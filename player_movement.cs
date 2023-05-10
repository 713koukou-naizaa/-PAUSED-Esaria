using UnityEngine;


/*NAMING SYNTAX:

constructor xxx of class xxx:       cls_xxx
struct xxx:                         stc_xxx
class xxx:                          cls_xxx
object xxx:                         obj_xxx
int fct xxx:                        fct_int_xxx
set int xxx:                        set_int_xxx
get int xxx:                        get_int_xxx
int pointer xxx:                    ptr_int_xxx

string var xxx:                     str_xxx
int var xxx:                        int_xxx
unsigned int var xxx:               uint_xxx
const str xxx:                      STR_xxx
const int xxx:                      INT_xxx
const uint xxx:                     UINT_xxx

fct int arg xxx:                    int_aXxx
*/


public class player_movement : MonoBehaviour
{
    public float float_move_speed; // player speed var
    public float float_jump_force; // player jump var

    private bool fct_is_jumping; // player jump state fct 
    private bool fct_is_grounded; // player grounded state fct

    public Transform ground_check_left;
    public Transform ground_check_right;

    public Rigidbody2D rb; // adds physics system to player and forces for movements
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    private Vector3 velocity=Vector3.zero; // obligatory red value to velocity


    void FixedUpdate()
    {

        fct_is_grounded=Physics2D.OverlapArea(ground_check_left.position,ground_check_right.position); // creates box detecting collisions between obj ground_check_left and ground_check_right

        float float_horizontal_movement=Input.GetAxis("Horizontal") * float_move_speed * Time.deltaTime; // sets horizontal movements to move speed set in Unity as "Horizontal": R/L arrows

        if (Input.GetButtonDown("Jump") && fct_is_grounded) // if "Jump": space bar is pressed and collision is detected at feet
        {
            fct_is_jumping=true; // sets player jump state to true
        }

        fct_move_player(float_horizontal_movement); // sends movement to rb

        fct_flip_player(rb.velocity.x);

        float float_character_velocity=Mathf.Abs(rb.velocity.x); // makes character speed always positive for movements to left (=1 and not -1)
        animator.SetFloat("speed",float_character_velocity); // sends speed movement to animator
    }

    void fct_move_player(float float_aHorizontal_movement) // fct to apply horizontal movement
    {
        Vector3 target_velocity=new Vector2(float_aHorizontal_movement,rb.velocity.y); // calculates velocity of target
        rb.velocity=Vector3.SmoothDamp(rb.velocity,target_velocity,ref velocity,.05f); // applies horizontal movement to rb

        if(fct_is_jumping==true) // if space bar pressed
        {
            rb.AddForce(new Vector2(0f,float_jump_force)); // sets jump force set in Unity
            fct_is_jumping=false; // sets player jump state to false
        }
    }

    void fct_flip_player(float float_aCharacter_velocity)
    {
        if(float_aCharacter_velocity>0.1f)
        {
            spriteRenderer.flipX=false;
        }else if(float_aCharacter_velocity<-0.1f){
            spriteRenderer.flipX=true;
        }
    }
}
