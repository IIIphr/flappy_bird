using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class main_menu : MonoBehaviour
{

    private VisualElement start_button;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        start_button = root.Q<Button>("start");
        start_button?.RegisterCallback<ClickEvent>(ev => start_game());
    }

    private void start_game()
    {
        //print("clicked");
        SceneManager.LoadScene("game");
    }
}
