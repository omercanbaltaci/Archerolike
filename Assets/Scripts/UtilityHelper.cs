using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UtilityHelper
{
    // Transform object will be rotated using the given direction
    public static void ChangeRotation(Transform transform, Vector3 dir)
    {
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * 10f).eulerAngles;
        transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    // Will return true if the gameobject has the velocity of 0
    public static bool IsGameObjectSleeping(GameObject gameObject)
    {
        if (gameObject.GetComponent<Rigidbody>().velocity == new Vector3(0f, 0f, 0f))
            return true;
        else return false;
    }
}
