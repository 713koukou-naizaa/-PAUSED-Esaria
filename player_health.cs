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





public class player_health : MonoBehaviour
{

    public int max_health=100;
    public int current_health;

    public health_bar health_bar; // Reference to health bar object in unity


    void Start()
    {

        current_health=max_health; // Sets max value of health to max health set in unity when game started
        health_bar.fct_void_set_max_health(max_health); // Updates health bar object to max health when game started

    }

    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.H))
        {

            fct_void_take_damage(5);

        }

    }

    void fct_void_take_damage(int damage)
    {

        current_health-=damage; // Updates current health after taking damage
        health_bar.fct_void_set_health(current_health); // Updates health bar object to current health after taking damage

    }

}
