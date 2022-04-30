using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine;

public class menu_manager : VisualElement
{

    public new class UxmlFactory : UxmlFactory<menu_manager, UxmlTraits> { };
    public new class UxmlTraits : VisualElement.UxmlTraits { };

    private VisualElement start_button;

    public menu_manager()
    {
        this.RegisterCallback<GeometryChangedEvent>(OnGeometryChange);
        Debug.Log("created");
    }

    public void OnEnable()
    {
        start_button = this.Q<Label>("start");
        start_button?.RegisterCallback<ClickEvent>(ev => start_game());
        Debug.Log("enabled");
    }

    private void OnGeometryChange(GeometryChangedEvent evt)
    {
        start_button = this.Q<Label>("start");
        start_button?.RegisterCallback<ClickEvent>(ev => start_game());
        Debug.Log("changed");
    }

    private void start_game()
    {
        Debug.Log("clicked");
        SceneManager.LoadScene("game");
    }
}