using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewNews", menuName = "News")]
public class News : ScriptableObject {

public Sprite header;
public string title;
public Sprite image;
public int trust;
public int knowledge;

}
