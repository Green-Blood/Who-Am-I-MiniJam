using UnityEngine;

public class ToggleGameObject : MonoBehaviour
{
    public void ToggleObject() => gameObject.SetActive(!gameObject.activeSelf);
}