using System;
using UnityEngine;

namespace NTools.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    public class SpritePreviewAttribute : PropertyAttribute
    {
        public float Size { get; private set; }

        public SpritePreviewAttribute(float size = 64)
        {
            Size = size;
        }
    }
}