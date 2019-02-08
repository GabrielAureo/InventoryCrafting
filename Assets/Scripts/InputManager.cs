using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
public class InputManager : MonoBehaviour{

    void Update(){
    }

    public static bool IsUIElementActive()
    {
        if (EventSystem.current.currentSelectedGameObject != null)
        {
            //Debug.Log(EventSystem.current.currentSelectedGameObject);
            TMP_InputField IF = EventSystem.current.currentSelectedGameObject.GetComponent<TMP_InputField>();
            if (IF != null)
            {
                return IF.isFocused;
            }
        }
        return false;
    }
}