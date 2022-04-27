using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle_manager_script : MonoBehaviour
{

    private List<(GameObject, GameObject)> obstacles = new List<(GameObject, GameObject)>();
    private Material lava_mat;
    [SerializeField] private float obstacle_move_speed = 0.5f;

    (GameObject, GameObject) make_pair()
    {
        float top = Random.Range(0f, 4.5f);
        float height = Random.Range(1.5f, 4f);

        GameObject cube1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube1.transform.position = new Vector3(10, 9 - top, -4);
        cube1.transform.localScale = new Vector3(1, 10, 1);
        cube1.GetComponent<Renderer>().material = lava_mat;
        cube1.AddComponent<BoxCollider>();
        cube1.tag = "lava";

        GameObject cube2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube2.transform.position = new Vector3(10, -1 - top - height, -4);
        cube2.transform.localScale = new Vector3(1, 10, 1);
        cube2.GetComponent<Renderer>().material = lava_mat;
        cube1.AddComponent<BoxCollider>();
        cube2.tag = "lava";

        return (cube1, cube2);
    }

    // Start is called before the first frame update
    void Start()
    {
        lava_mat = new Material(Resources.Load<Material>("Stylized Lava Materials/Lava03/M_Lava03"));
        lava_mat.mainTextureScale = new Vector2(1, 10);

        obstacles.Add(make_pair());
    }

    // Update is called once per frame
    void Update()
    {
        List<(GameObject, GameObject)> to_be_removed = new List<(GameObject, GameObject)>();
        foreach ((GameObject, GameObject) obstacle in obstacles)
        {
            if(obstacle.Item1.transform.position.x <= -10)
            {
                to_be_removed.Add(obstacle);
            }
            else
            {
                obstacle.Item1.transform.position += new Vector3(-1 * Time.deltaTime * obstacle_move_speed, 0, 0);
                obstacle.Item2.transform.position += new Vector3(-1 * Time.deltaTime * obstacle_move_speed, 0, 0);
            }
        }
        foreach ((GameObject, GameObject) obstacle in to_be_removed)
        {
            obstacles.Remove(obstacle);
            Destroy(obstacle.Item1);
            Destroy(obstacle.Item2);
        }
        if(obstacles[obstacles.Count-1].Item1.transform.position.x <= 7)
        {
            (GameObject, GameObject) obstacle = make_pair();
            obstacles.Add(obstacle);
        }
    }
}
