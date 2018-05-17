﻿using OpenTK;
using OpenTK.Graphics;
using ShTK.Content;

namespace ShTK.Graphics
{
    /// <summary>
    /// <see cref="IDrawable"/> with Load methods from <see cref="IResourceHolder"/>
    /// </summary>
    public interface IDrawable : IBaseDrawable, IResourceHolder
    {

    }

    /// <summary>
    /// <see cref="IDrawable"/> without Load methods from <see cref="IResourceHolder"/>
    /// </summary>
    public interface IBaseDrawable
    {
        void Draw();

        /// <summary>
        /// Responsible for handling not only Draw calls but Update calls as well. 
        /// Disabling Visible will effectively disable the Drawable altogether.
        /// For proper disposal use <see cref="Dispose()"/>
        /// </summary>
        bool? Visible { get; set; }

        /// <summary>
        /// Opacity of the drawable
        /// </summary>
        float Alpha { get; set; }
        
        /// <summary>
        /// A vector2 of the objects coordinates. 
        /// Will be affected by fields such as <see cref="Anchor"/> and <see cref="Origin"/>,
        /// relationships with parents will also affect position behaviour
        /// </summary>
        Vector2 Position { get; set; }

        Vector2 AbsolutePosition { get; set; }

        /// <summary>
        /// A vector2 of the size
        /// </summary>
        Vector2 Scale { get; set; }

        /// <summary>
        /// The angle of rotation where 0deg is vertical from the radius
        /// </summary>
        float Rotation { get; set; }

        Anchor Anchor { get; set; }
        Anchor Origin { get; set; }

        /// <summary>
        /// The tint of the drawable
        /// </summary>
        Color4 Colour { get; }
    }
}
