﻿using System;
using System.Windows.Media;
using System.Reflection;
using TEdit.Common;
using TEdit.TerrariaWorld.Structures;

namespace TEdit.RenderWorld
{
    [Serializable]
    public class FrameProperty : TileFrameProperty
    {

        public FrameProperty()
        {
            ID = 0;
            UpperLeft = new PointShort(0, 0);
        }

        // If object is Null/Empty/Whitespace, looks for any data in the parent, creating parental inheritence of Tiles/Frames properties
        public T InheritCheck<T>(T chk, string parentVar)
        {
            T temp = chk;
            if (String.IsNullOrWhiteSpace(temp.ToString()) && Parent != null)
                temp = (T)typeof(TileProperty).GetProperty(parentVar).GetValue(Parent, null);

            return temp;
        }

        // Must be here and referencing TileProperty to prevent circular references within TileFrameProperty
        // (this means some overrides below)
        private TileProperty _parent;
        public TileProperty Parent { get { return _parent; } }
        // Special SetParent method for ref passing
        public void SetParent (ref TileProperty tile) { SetProperty(ref _parent, ref tile, "Parent"); }

        // InheritCheck overrides
        public override string Name
        {
            get { return InheritCheck(_name, "Name"); }
            set { SetProperty(ref _name, ref value, "Name"); }
        }
        public override Color Color {
            get { return InheritCheck(_color, "Color"); }
            set { SetProperty(ref _color, ref value, "Color"); }
        }
        public override bool IsSolid
        {
            get { return InheritCheck(_isSolid, "IsSolid"); }
            set { SetProperty(ref _isSolid, ref value, "IsSolid"); }
        }
        public override bool IsSolidTop
        {
            get { return InheritCheck(_isSolidTop, "IsSolidTop"); }
            set { SetProperty(ref _isSolidTop, ref value, "IsSolidTop"); }
        }
        public override bool IsHouseItem
        {
            get { return InheritCheck(_isHouseItem, "IsHouseItem"); }
            set { SetProperty(ref _isHouseItem, ref value, "IsHouseItem"); }
        }
        public override PointShort UpperLeft
        {
            get { return InheritCheck(_upperLeft, "UpperLeft"); }
            set { SetProperty(ref _upperLeft, ref value, "UpperLeft"); }
        }
        public override PointShort Size
        {
            get { return InheritCheck(_size, "Size"); }
            set { SetProperty(ref _size, ref value, "Size"); }
        }
        public override FrameDirection? Direction
        {
            get { return InheritCheck(_direction, "Direction"); }
            set { SetProperty(ref _direction, ref value, "Direction"); }
        }
        public override string Variety
        {
            get { return InheritCheck(_variety, "Variety"); }
            set { SetProperty(ref _variety, ref value, "Variety"); }
        }
        public override FramePlacement Placement
        {
            get { return InheritCheck(_placement, "Placement"); }
            set { SetProperty(ref _placement, ref value, "Placement"); }
        }
        public override TileNumArray GrowsOn
        {
            get { return InheritCheck(_growsOn, "GrowsOn"); }
            set { SetProperty(ref _growsOn, ref value, "GrowsOn"); }
        }
        public override TileNumArray HangsOn
        {
            get { return InheritCheck(_hangsOn, "HangsOn"); }
            set { SetProperty(ref _hangsOn, ref value, "HangsOn"); }
        }
        public override byte LightBrightness
        {
            get { return InheritCheck(_lightBrightness, "LightBrightness"); }
            set { SetProperty(ref _lightBrightness, ref value, "LightBrightness"); }
        }
        public override ushort ContactDmg
        {
            get { return InheritCheck(_contactDmg, "ContactDmg"); }
            set { SetProperty(ref _contactDmg, ref value, "ContactDmg"); }
        }

        public override string ToString()
        {
            string n = Name;
            if (!String.IsNullOrWhiteSpace(Variety)) n += " - " + Variety;
            if (!String.IsNullOrWhiteSpace(((DisplayFrameDirection?)Direction).ToString())) n += " (" + ((DisplayFrameDirection?)Direction).ToString() + ")";

            return n;
        }
    }
}