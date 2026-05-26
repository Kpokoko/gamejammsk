using Game.Scripts;
using UnityEngine;
using UnityEngine.UIElements;

// This file is auto-generated. Do not modify manually.

public static class GameResources
{
    public static class Generated
    {
    }
    public static class Levels
    {
    }
    public static class Prefabs
    {
        public static class Layout
        {
            public static GameObject Wall => Resources.Load<GameObject>("Prefabs/Layout/Wall");
        }
        public static Carriage BaseCarriage => Resources.Load<Carriage>("Prefabs/BaseCarriage");
        public static CharacterController Player => Resources.Load<CharacterController>("Prefabs/Player");
    }
    public static class Sprites
    {
        public static Sprite CarriagePlaceholder => Resources.Load<Sprite>("Sprites/CarriagePlaceholder");
    }
}
