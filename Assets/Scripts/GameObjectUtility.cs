using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

namespace Takashi
{
    public class GameObjectUtility
    {
        public static T CopyComponent<T>(T p_original, GameObject p_destination) where T : Component
        {
            System.Type __type = p_original.GetType();
            Component __copy = p_destination.AddComponent(__type);
            BindingFlags __flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Default | BindingFlags.DeclaredOnly;
            
            PropertyInfo[] __pinfos = __type.GetProperties(__flags);
            foreach (var __pinfo in __pinfos) {
                if (__pinfo.CanWrite) {
                    try {
                        __pinfo.SetValue(__copy, __pinfo.GetValue(p_original, null), null);
                    }
                    catch { } // In case of NotImplementedException being thrown. For some reason specifying that exception didn't seem to catch it, so I didn't catch anything specific.
                }
            }
            
            FieldInfo[] __fields = __type.GetFields(__flags);
            foreach (FieldInfo __field in __fields)
            {
                __field.SetValue(__copy, __field.GetValue(p_original));
            }

            return __copy as T;
        }
    }
}
