using UnityEngine;
using System.Collections;

public class MoveRacket : MonoBehaviour {
    public float speed = 30;
    public string axis = "Vertical";

    void FixedUpdate () {

        float v = Input.GetAxisRaw(axis);
        //Para mover las raquetas, solo en el eje y
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, v) * speed;
    }
}
