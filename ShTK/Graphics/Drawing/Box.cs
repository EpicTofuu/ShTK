﻿using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace ShTK.Graphics.Drawing
{
    public class Box
    {
        public Color4 Colour { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Scale { get; set; }
        public bool Visible { get; set; }

        public Box()
        {
            Visible = true;

            if (Colour == new Color4(0.0f, 0.0f, 0.0f, 0.0f))
            {
                Colour = Color4.White;
            }
        }

        public void Draw (Rectangle Viewport)
        {
            if (Visible)
            {
                GL.Viewport(Viewport.ToSystemDrawing());
                GL.Begin(PrimitiveType.Quads);
                GL.Color4(Colour);

                GL.Vertex2(Position.X, Position.Y);
                GL.Vertex2(Position.X, Position.Y + Scale.Y);
                GL.Vertex2(Position.X + Scale.X, Position.Y + Scale.Y);
                GL.Vertex2(Position.X + Scale.X, Position.Y);

                GL.End();
            }
        }

        public void Draw()
        {
            Draw(App.Bounds);
        }
        
        public void Load()
        {
        }

        public void Update()
        {
        }
    }
}
