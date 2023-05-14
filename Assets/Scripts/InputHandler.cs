using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public Actions actions { get; private set; }

    private void Awake()
    {
        actions = new Actions();
    }

}
