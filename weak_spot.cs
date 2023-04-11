using UnityEngine;

public class weak_spot : MonoBehaviour
{

    public GameObject object_to_destroy;

    private void OnTriggerEnter2D(Collider2D collision) {
        
        if(collision.CompareTag("Player")) // compares tag of object colliding with weak_spot box collider with Player tag
        {

            Destroy(object_to_destroy);  // destroys snake (set as object_to_destroy in unity)

        }

    }

}
