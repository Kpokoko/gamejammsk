using Game.Scripts;
using UnityEngine;
using UnityEngine.UIElements;

// This file is auto-generated. Do not modify manually.

public static class GameResources
{
    public static class Dialogues
    {
    }
    public static class Generated
    {
    }
    public static class Levels
    {
    }
    public static class Prefabs
    {
        public static class Carriages
        {
            public static Carriage BaseCarriage => Resources.Load<Carriage>("Prefabs/Carriages/BaseCarriage");
            public static Carriage CutsceneCarriage_1 => Resources.Load<Carriage>("Prefabs/Carriages/CutsceneCarriage 1");
            public static Carriage CutsceneCarriage => Resources.Load<Carriage>("Prefabs/Carriages/CutsceneCarriage");
        }
        public static class Layout
        {
            public static GameObject Wall => Resources.Load<GameObject>("Prefabs/Layout/Wall");
        }
        public static CharacterController Player => Resources.Load<CharacterController>("Prefabs/Player");
    }
    public static class Sprites
    {
        public static Sprite CarriagePlaceholder => Resources.Load<Sprite>("Sprites/CarriagePlaceholder");
    }
}
