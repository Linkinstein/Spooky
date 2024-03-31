using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    [SerializeField] private GameObject[] weapons;
    [SerializeField] private bool[] weaponsAcquired;

    private GameObject currWeapon;
    private int currWeaponIndex = 1;

    private void Start()
    {
        currWeapon = transform.GetChild(0).gameObject;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1) && currWeaponIndex != 1)
        {
            Destroy(currWeapon);
            currWeapon = Instantiate(weapons[0], transform.position, Quaternion.identity, transform);
            currWeapon.transform.localPosition = Vector3.zero;
            currWeapon.transform.rotation = transform.rotation;
            currWeaponIndex = 1;
        }

        if (Input.GetKey(KeyCode.Alpha2) && currWeaponIndex != 2)
        {
            Destroy(currWeapon);
            currWeapon = Instantiate(weapons[1], transform.position, Quaternion.identity, transform);
            currWeapon.transform.localPosition = new Vector3(0.3f, 0, 0.75f);
            currWeapon.transform.rotation = transform.rotation;
            currWeaponIndex = 2;
        }
    }
}
