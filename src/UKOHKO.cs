namespace UKOHKO;

using BepInEx;
using BepInEx.Configuration;
using UnityEngine;
using UnityEngine.InputSystem;

[BepInPlugin("UKOHKO","UKOHKO","2.0")]
public class Plugin:BaseUnityPlugin
{
    ConfigEntry<KeyCode> ohkokey;

    ConfigEntry<bool> ohkostart;

    NewMovement Player;

    bool ohko = false;

    void Start(){
        Debug.Log("UKOHKO Loaded");
        ohkokey = Config.Bind("Binds","OHKO toggle", KeyCode.O, "Key to toggle One hit ko");
        ohkostart = Config.Bind("Misc","Start with OHKO enabled",false,"");
        ohko = ohkostart.Value;
    }

    void Update(){
        if(Keyboard.current.oKey.wasPressedThisFrame){
            ohko = !ohko;
            Debug.Log("ohko:"+ohko);
        }
        if(ohko && GetPlayer()) Player.hp = Mathf.Clamp(Player.hp, 0, 1);
    }

    NewMovement GetPlayer(){
        if(!Player)Player = NewMovement.Instance;
        return Player;
    }
}
