using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WindowScreenshot
{
    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        private int _left;
        private int _top;
        private int _right;
        private int _bottom;

        public RECT(Rectangle rectangle)
            : this(rectangle.Left, rectangle.Top, rectangle.Right, rectangle.Bottom)
        {
        }

        public RECT(int left, int top, int right, int bottom)
        {
            _left = left;
            _top = top;
            _right = right;
            _bottom = bottom;
        }

        public int X
        {
            get { return Left; }
            set { Left = value; }
        }

        public int Y
        {
            get { return Top; }
            set { Top = value; }
        }

        public int Left
        {
            get { return _left; }
            set { _left = value; }
        }

        public int Top
        {
            get { return _top; }
            set { _top = value; }
        }

        public int Right
        {
            get { return _right; }
            set { _right = value; }
        }

        public int Bottom
        {
            get { return _bottom; }
            set { _bottom = value; }
        }

        public int Height
        {
            get { return Bottom - Top; }
            set { Bottom = value - Top; }
        }

        public int Width
        {
            get { return Right - Left; }
            set { Right = value + Left; }
        }

        public Point Location
        {
            get { return new Point(Left, Top); }
            set
            {
                Left = value.X;
                Top = value.Y;
            }
        }

        public Size Size
        {
            get { return new Size(Width, Height); }
            set
            {
                Right = value.Width + Left;
                Bottom = value.Height + Top;
            }
        }

        public Rectangle ToRectangle()
        {
            return new Rectangle(Left, Top, Width, Height);
        }

        public static Rectangle ToRectangle(RECT Rectangle)
        {
            return Rectangle.ToRectangle();
        }

        public static RECT FromRectangle(Rectangle Rectangle)
        {
            return new RECT(Rectangle.Left, Rectangle.Top, Rectangle.Right, Rectangle.Bottom);
        }

        public static implicit operator Rectangle(RECT Rectangle)
        {
            return Rectangle.ToRectangle();
        }

        public static implicit operator RECT(Rectangle Rectangle)
        {
            return new RECT(Rectangle);
        }

        public static bool operator ==(RECT Rectangle1, RECT Rectangle2)
        {
            return Rectangle1.Equals(Rectangle2);
        }

        public static bool operator !=(RECT Rectangle1, RECT Rectangle2)
        {
            return !Rectangle1.Equals(Rectangle2);
        }

        public override string ToString()
        {
            return "{Left: " + Left + "; " + "Top: " + Top + "; Right: " + Right + "; Bottom: " + Bottom + "}";
        }

        public bool Equals(RECT Rectangle)
        {
            return Rectangle.Left == Left && Rectangle.Top == Top && Rectangle.Right == Right &&
                   Rectangle.Bottom == Bottom;
        }

        public override bool Equals(object Object)
        {
            if (Object is RECT)
            {
                return Equals((RECT)Object);
            }
            else if (Object is Rectangle)
            {
                return Equals(new RECT((Rectangle)Object));
            }

            return false;
        }

        public override int GetHashCode()
        {
            return Left.GetHashCode() ^ Right.GetHashCode() ^ Top.GetHashCode() ^ Bottom.GetHashCode();
        }
    }
}
