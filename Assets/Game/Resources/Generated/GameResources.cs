using Game.Scripts;
using Game.Scripts.Triggers;
using UnityEngine;
using UnityEngine.UIElements;

// This file is auto-generated. Do not modify manually.

public static class GameResources
{
    public static class Dialogues
    {
    }
    public static class Effects
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
            public static Carriage FakeCarriage => Resources.Load<Carriage>("Prefabs/Carriages/FakeCarriage");
            public static Carriage LCarriageWithDoor => Resources.Load<Carriage>("Prefabs/Carriages/LCarriageWithDoor");
            public static Carriage RCarriageWithDoor => Resources.Load<Carriage>("Prefabs/Carriages/RCarriageWithDoor");
            public static Carriage TurnstileCarriage => Resources.Load<Carriage>("Prefabs/Carriages/TurnstileCarriage");
            public static Carriage WallCarriage => Resources.Load<Carriage>("Prefabs/Carriages/WallCarriage");
        }
        public static class Layout
        {
            public static GameObject Wall => Resources.Load<GameObject>("Prefabs/Layout/Wall");
        }
        public static GameObject Door => Resources.Load<GameObject>("Prefabs/Door");
        public static DoorButton DoorButton => Resources.Load<DoorButton>("Prefabs/DoorButton");
        public static CarriageBounds LeftBorder => Resources.Load<CarriageBounds>("Prefabs/LeftBorder");
        public static CharacterController Player => Resources.Load<CharacterController>("Prefabs/Player");
        public static CarriageBounds RightBorder => Resources.Load<CarriageBounds>("Prefabs/RightBorder");
        public static TurnstileButton TurnstileButton => Resources.Load<TurnstileButton>("Prefabs/TurnstileButton");
    }
    public static class Sprites
    {
        public static Sprite CarriageDialogue1 => Resources.Load<Sprite>("Sprites/CarriageDialogue1");
        public static Sprite CarriagePlaceholder => Resources.Load<Sprite>("Sprites/CarriagePlaceholder");
        public static Sprite chel1 => Resources.Load<Sprite>("Sprites/chel1");
    }
}
