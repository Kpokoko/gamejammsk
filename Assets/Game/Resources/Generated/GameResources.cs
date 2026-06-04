using Game.Scripts;
using Game.Scripts.Triggers;
using UnityEngine;
using UnityEngine.UIElements;

// This file is auto-generated. Do not modify manually.

public static class GameResources
{
    public static class Animations
    {
    }
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
            public static Carriage CarriagePortal => Resources.Load<Carriage>("Prefabs/Carriages/CarriagePortal");
            public static Carriage CutsceneCarriage_1 => Resources.Load<Carriage>("Prefabs/Carriages/CutsceneCarriage 1");
            public static Carriage CutsceneCarriage => Resources.Load<Carriage>("Prefabs/Carriages/CutsceneCarriage");
            public static Carriage FakeCarriage => Resources.Load<Carriage>("Prefabs/Carriages/FakeCarriage");
            public static Carriage LCarriageWithDoor => Resources.Load<Carriage>("Prefabs/Carriages/LCarriageWithDoor");
            public static Carriage LTurnstileCarriage => Resources.Load<Carriage>("Prefabs/Carriages/LTurnstileCarriage");
            public static Carriage RCarriageWithDoor => Resources.Load<Carriage>("Prefabs/Carriages/RCarriageWithDoor");
            public static Carriage RTurnstileCarriage => Resources.Load<Carriage>("Prefabs/Carriages/RTurnstileCarriage");
            public static Carriage WallCarriage => Resources.Load<Carriage>("Prefabs/Carriages/WallCarriage");
        }
        public static class Layout
        {
            public static GameObject Wall => Resources.Load<GameObject>("Prefabs/Layout/Wall");
        }
        public static GameObject Door => Resources.Load<GameObject>("Prefabs/Door");
        public static DoorButton DoorButton => Resources.Load<DoorButton>("Prefabs/DoorButton");
        public static CarriageBounds LeftBorder => Resources.Load<CarriageBounds>("Prefabs/LeftBorder");
        public static GameObject PauseCont => Resources.Load<GameObject>("Prefabs/PauseCont");
        public static CharacterController Player => Resources.Load<CharacterController>("Prefabs/Player");
        public static PortalTp Portal => Resources.Load<PortalTp>("Prefabs/Portal");
        public static CarriageBounds RightBorder => Resources.Load<CarriageBounds>("Prefabs/RightBorder");
        public static TurnstileButton TurnstileButton => Resources.Load<TurnstileButton>("Prefabs/TurnstileButton");
    }
    public static class Sprites
    {
        public static class ded
        {
            public static Sprite ded_sit => Resources.Load<Sprite>("Sprites/ded/ded_sit");
        }
        public static class Dialoge
        {
            public static class ded
            {
                public static Sprite cmile => Resources.Load<Sprite>("Sprites/Dialoge/ded/cmile");
                public static Sprite common => Resources.Load<Sprite>("Sprites/Dialoge/ded/common");
            }
        }
        public static class girl
        {
            public static Sprite girl_sit01 => Resources.Load<Sprite>("Sprites/girl/girl_sit01");
            public static Sprite girl_sit02 => Resources.Load<Sprite>("Sprites/girl/girl_sit02");
            public static Sprite girl_sit03 => Resources.Load<Sprite>("Sprites/girl/girl_sit03");
            public static Sprite girl_sit04 => Resources.Load<Sprite>("Sprites/girl/girl_sit04");
            public static Sprite girl_sit05 => Resources.Load<Sprite>("Sprites/girl/girl_sit05");
            public static Sprite girl_sit06 => Resources.Load<Sprite>("Sprites/girl/girl_sit06");
        }
        public static class main_hero
        {
            public static class Walk
            {
                public static Sprite Walk01 => Resources.Load<Sprite>("Sprites/main_hero/Walk/Walk01");
                public static Sprite Walk02 => Resources.Load<Sprite>("Sprites/main_hero/Walk/Walk02");
                public static Sprite Walk03 => Resources.Load<Sprite>("Sprites/main_hero/Walk/Walk03");
                public static Sprite Walk04 => Resources.Load<Sprite>("Sprites/main_hero/Walk/Walk04");
                public static Sprite Walk05 => Resources.Load<Sprite>("Sprites/main_hero/Walk/Walk05");
                public static Sprite Walk06 => Resources.Load<Sprite>("Sprites/main_hero/Walk/Walk06");
                public static Sprite Walk07 => Resources.Load<Sprite>("Sprites/main_hero/Walk/Walk07");
                public static Sprite Walk08 => Resources.Load<Sprite>("Sprites/main_hero/Walk/Walk08");
            }
            public static Sprite stand => Resources.Load<Sprite>("Sprites/main_hero/stand");
        }
        public static Sprite CarriageDialogue1 => Resources.Load<Sprite>("Sprites/CarriageDialogue1");
        public static Sprite CarriagePlaceholder => Resources.Load<Sprite>("Sprites/CarriagePlaceholder");
        public static Sprite chel1 => Resources.Load<Sprite>("Sprites/chel1");
    }
}
