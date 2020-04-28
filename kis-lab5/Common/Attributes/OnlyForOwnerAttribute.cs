using System;

namespace Common.Attributes
{
    public class OnlyForOwnerAttribute : Attribute
    {
        public bool OnlyForOwner { get; set; }

        public OnlyForOwnerAttribute()
        {
            OnlyForOwner = true;
        }

        public OnlyForOwnerAttribute(bool onlyForOwner)
        {
            OnlyForOwner = onlyForOwner;
        }
    }
}
