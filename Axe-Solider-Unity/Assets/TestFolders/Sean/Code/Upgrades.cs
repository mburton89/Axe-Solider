using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MenteBacata.ScivoloCharacterControllerDemo
{
    public class Upgrades : SimpleCharacterController
    {
        public void IncreaseHealth()
        {
            PlayerPrefs.SetFloat("health", PlayerPrefs.GetFloat("health") + 10);
            print("health; " + PlayerPrefs.GetFloat("health"));
        }

        public void IncreaseJumpHeight()
        {
            PlayerPrefs.SetFloat("jump", PlayerPrefs.GetFloat("jump") + 3);
            print("jump; " + PlayerPrefs.GetFloat("jump"));
        }

        public void IncreaseSpeed()
        {
            PlayerPrefs.SetFloat("speed", PlayerPrefs.GetFloat("speed") + 2);
            print("speed; " + PlayerPrefs.GetFloat("speed"));
        }

        public void IncreaseAxeDamage()
        {
            PlayerPrefs.SetFloat("damage", PlayerPrefs.GetFloat("damage") + 10);
            print("damage; " + PlayerPrefs.GetFloat("damage"));
        }
    }
}

