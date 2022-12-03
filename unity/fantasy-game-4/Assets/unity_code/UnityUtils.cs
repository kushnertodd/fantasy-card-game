using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Assets.unity_code;
using fantasy_card_game_lib;
using Unity.VisualScripting;

namespace Assets.unity_code
{
    public class UnityUtils
    {
        /**
         * LoadNewSprite -- load sprite from image file
         */
        public static Sprite LoadNewSprite(string FilePath, Errors errors, float PixelsPerUnit = 100.0f)
        {
            // Load a PNG or JPG image from disk to a Texture2D, assign this texture to a new sprite and return its reference
            Texture2D SpriteTexture = LoadTexture(FilePath, errors);
            if (errors.Have)
                return null;
            return Sprite.Create(SpriteTexture,
                new Rect(0, 0, SpriteTexture.width, SpriteTexture.height),
                // center the pivot point
                new Vector2(0.5f, 0.5f),
                PixelsPerUnit);
        }
        /// <summary>
        /// LoadTexture loads texture from text file
        /// </summary>
        public static Texture2D LoadTexture(string FilePath, Errors errors)
        {
            // Load a PNG or JPG file from disk to a Texture2D
            // Returns null if load fails
            Texture2D Tex2D;
            byte[] FileData;

            if (File.Exists(FilePath))
            {
                FileData = File.ReadAllBytes(FilePath);
                // Create new "empty" texture
                Tex2D = new Texture2D(2, 2);           
                // Load the imagedata into the texture (size is set automatically)
                if (Tex2D.LoadImage(FileData))
                    // If data = readable-> return texture
                    return Tex2D;                 
            }
            errors.Add(Errors.MessageId.MISC_TEXT, "LoadTexture: texture file " + FilePath + " not found");
            // Return null if load failed
            return null;                     
        }
    }
}
