using UnityEngine;
using UnityEngine.UI;


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


public class health_bar : MonoBehaviour
{
    public Slider slider; // Reference to slider component of health bar in unity

    public Gradient gradient;

    public Image fill;

    public void fct_void_set_max_health(int health) // Sets max health value of slider component
    {

        slider.maxValue=health; // Sets max value of slider component of health bar in unity to health set in unity
        slider.value=health; // Sets value of slider component of health bar in unity to health set in unity

        fill.color=gradient.Evaluate(1f); // Sets color of health bar to color corresponding to max value of gradient in unity

    }

    public void fct_void_set_health(int health) // Sets health value of slider when damages taken or heals
    {

        slider.value=health; // Sets value of slider component of health bar in unity to health set in unity

        fill.color=gradient.Evaluate(slider.normalizedValue); // Sets color of health bar to color corresponding to value of gradient in unity (normalized: if value is 20: returns 0.2 because gradient value: 0-1)

    }

}
