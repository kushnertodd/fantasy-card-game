using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Assets.unity_code;
using fantasy_card_game_lib;

namespace Assets.unity_code
{
    internal class UnityUtils
    {
        public static Sprite LoadNewSprite(string FilePath, Errors errors, float PixelsPerUnit = 100.0f)
        {

            // Load a PNG or JPG image from disk to a Texture2D, assign this texture to a new sprite and return its reference

            Texture2D SpriteTexture = LoadTexture(FilePath, errors);
            if (errors.Have)
                return null;
            return Sprite.Create(SpriteTexture, new Rect(0, 0, SpriteTexture.width, SpriteTexture.height), new Vector2(0, 0), PixelsPerUnit);
        }

        public static Texture2D LoadTexture(string FilePath, Errors errors)
        {

            // Load a PNG or JPG file from disk to a Texture2D
            // Returns null if load fails

            Texture2D Tex2D;
            byte[] FileData;

            if (File.Exists(FilePath))
            {
                FileData = File.ReadAllBytes(FilePath);
                Tex2D = new Texture2D(2, 2);           // Create new "empty" texture
                if (Tex2D.LoadImage(FileData))           // Load the imagedata into the texture (size is set automatically)
                    return Tex2D;                 // If data = readable -> return texture
            }
            errors.Add(Errors.MessageId.MISC_TEXT, "LoadTexture: texture file " + FilePath + " not found");
            return null;                     // Return null if load failed
        }
    }
}
