﻿using System;
using System.Reflection;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using ShTK.Input;
using ShTK.Maths;
using ShTK.Graphics.OpenGL.Shaders;

namespace ShTK
{
    public class AppWindow : GameWindow
    {
        public Color4 backgroundColour = Color4.Black;

        public Matrix4 projMatrix;

        public static Rectangle ScreenBounds;

        public static KeyListener KeyListener = new KeyListener();
        public static MouseListener MouseListener = new MouseListener();

        public static VSFS vsfs;

        public AppWindow() : base(1366, 768, GraphicsMode.Default, $"Running {Assembly.GetCallingAssembly().GetName().Name} - Powered by ShTK")
        {
            ScreenBounds = new Rectangle(ClientRectangle);
            vsfs = new VSFS(GL.CreateProgram());
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            PreLoad();
            BeginLoad();
        }

        internal virtual void PreLoad()
        {
            GL.Enable(EnableCap.Blend);
            GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);

            GL.Enable(EnableCap.DepthTest);
            GL.DepthFunc(DepthFunction.Lequal);

            GL.ClearColor(backgroundColour);

            GL.Enable(EnableCap.Texture2D);

            GL.Enable(EnableCap.AlphaTest);
            GL.AlphaFunc(AlphaFunction.Gequal, 0.5f);

            vsfs.Load();
        }

        public virtual void BeginLoad()
        {

        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            GL.Viewport(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width, ClientRectangle.Height);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            KeyListener.Update();
            MouseListener.Update();
            MouseListener.Position = new Point (PointToClient(new System.Drawing.Point(Mouse.GetCursorState().X, Mouse.GetCursorState().Y)));

            Update();

            MouseListener.LateUpdate();
            KeyListener.LateUpdate();
        }

        public virtual void Update()
        {

        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            ScreenBounds = new Rectangle (ClientRectangle);
            
            GL.Viewport(0, 0, Width, Height);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.Enable(EnableCap.DepthTest);

            projMatrix = Matrix4.CreateOrthographicOffCenter(ClientRectangle.Left, ClientRectangle.Right, ClientRectangle.Bottom, ClientRectangle.Top, -1.0f, 1.0f);
            GL.LoadMatrix(ref projMatrix);
            
            Draw();
                     
            SwapBuffers();
        }

        public virtual void Draw()
        {

        }        
    }
}

//despacito 2