using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Skin Collection", menuName = "Skins/Skin Collection")]
public class SkinCollection : ScriptableObject
{
    [SerializeField] public List<PlayerSkin> skins;
}
