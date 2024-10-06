using UnityEngine;
using UnityEngine.InputSystem;
public class GameManagerController : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    private bool isMenu;
    public void Menu(InputAction.CallbackContext context)
    {
        if (context.performed&&!isMenu)
        {
            menu.SetActive(true);
            isMenu = true;
            TimeGame(0);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else if (context.performed&&isMenu)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            menu.SetActive(false);
            isMenu = false;
            TimeGame(1);
        }
    }
    private void TimeGame(int time)
    {
        Time.timeScale = time;
    }
}
