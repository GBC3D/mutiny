using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roles : MonoBehaviour
{

    public enum Role
    {
        Shipmate,
        Mutineer,
        Captain
    }

    private Role playerRole;

    private void SetRole(Role role)
    {
        playerRole = role;
    }
}
