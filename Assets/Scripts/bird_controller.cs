using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class bird_controller : MonoBehaviour
{

    [SerializeField] private Rigidbody rb;
    [SerializeField] private float jump_force = 50;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Jump") > 0)
        {
            rb.AddForce(new Vector3(0, jump_force, 0));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "lava")
        {
            SceneManager.LoadScene("main_menu");
        }
    }
}
