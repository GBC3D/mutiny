using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultPlayerScript : MonoBehaviour
{
    public CharacterController controller;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            controller.Move(new Vector3(0, 0, 10 * Time.deltaTime));
        }
    }
}
