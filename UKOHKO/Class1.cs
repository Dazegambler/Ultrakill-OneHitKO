using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx;
using BepInEx.Logging;
using BepInEx.Configuration;
using UnityEngine;

namespace TestMod
{
    [BepInPlugin("UK.OHKO", "UKOHKO", "1.0.0")]

    public class Plugin : BaseUnityPlugin
    {
        private ConfigEntry<KeyCode> Toggle;

        GameObject Player;
        bool toggle = false;

        public void Start()
        {
            Toggle = Config.Bind("Binds", "OHKO toggle", KeyCode.L, "");
        }
        public void Update()
        {
            if(Player != null)
            {
                if (Input.GetKeyDown(Toggle.Value))
                {
                    toggle = !toggle;
                }
                if (toggle)
                {
                    var hp = Player.gameObject.GetComponent<NewMovement>();
                    if (hp.hp > 1)
                    {
                        hp.hp = 1;
                    }
                }
            }
            ObjCheck();
        }
        private void ObjCheck()
        {
            if(Player == null)
            {
                Player = GameObject.Find("Player");
            }
        }
    }
}
