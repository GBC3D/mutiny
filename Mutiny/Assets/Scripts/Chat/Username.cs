using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Username : MonoBehaviour
{
    public static string username;

    [SerializeField]
    private InputField nameField;

    public static string getUsername()
    {
        return username;
    }

    public void setUsername()
    {
        username = nameField.text;
    }

}
