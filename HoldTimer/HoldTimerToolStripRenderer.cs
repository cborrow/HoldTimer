using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace HoldTimer
{
    public class HoldTimerToolStripRenderer : ToolStripRenderer
    {
        public Theme ActiveTheme { get; set; }

        public HoldTimerToolStripRenderer() : base()
        {
            
        }

        protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
        {
            if (ActiveTheme == null)
                return;

            Rectangle rect = new Rectangle(1, 0, e.Item.Width - 2, e.Item.Height);

            if (e.Item.Pressed)
            {
                e.Item.ForeColor = ActiveTheme.OverTimeColor;
                e.Graphics.FillRectangle(new SolidBrush(ActiveTheme.ButtonPressedColor), rect);
            }
            else if(e.Item.Selected)
            {
                e.Item.ForeColor = ActiveTheme.AlertTimeColor;
                e.Graphics.FillRectangle(new SolidBrush(ActiveTheme.ButtonHoverColor), rect);
            }
            else
            {
                e.Item.ForeColor = ActiveTheme.ToolbarForeColor;
                e.Graphics.FillRectangle(new SolidBrush(ActiveTheme.ButtonBackColor), rect);
            }
        }

        protected override void OnRenderDropDownButtonBackground(ToolStripItemRenderEventArgs e)
        {
            if (ActiveTheme == null)
                return;

            Rectangle rect = new Rectangle(1, 0, e.Item.Width - 2, e.Item.Height);

            if (e.Item.Pressed)
            {
                e.Item.ForeColor = ActiveTheme.OverTimeColor;
                e.Graphics.FillRectangle(new SolidBrush(ActiveTheme.ButtonPressedColor), rect);
            }
            else if (e.Item.Selected)
            {
                e.Item.ForeColor = ActiveTheme.AlertTimeColor;
                e.Graphics.FillRectangle(new SolidBrush(ActiveTheme.ButtonHoverColor), rect);
            }
            else
            {
                e.Item.ForeColor = ActiveTheme.ToolbarForeColor;
                e.Graphics.FillRectangle(new SolidBrush(ActiveTheme.ButtonBackColor), rect);
            }
        }

        protected override void OnRenderItemBackground(ToolStripItemRenderEventArgs e)
        {
            if (ActiveTheme == null)
                return;

            if (e.Item.Selected)
            {
                e.Graphics.FillRectangle(new SolidBrush(ActiveTheme.TimerForeColor), e.Item.Bounds);
            }
            else if (e.Item.Pressed)
            {
                e.Graphics.FillRectangle(new SolidBrush(ActiveTheme.TimerForeColor), e.Item.Bounds);
            }
            else
            {
                e.Graphics.FillRectangle(new SolidBrush(ActiveTheme.TimerBackColor), e.Item.Bounds);
            }
        }

        protected override void OnRenderLabelBackground(ToolStripItemRenderEventArgs e)
        {
            if (ActiveTheme == null)
                return;

            e.Item.ForeColor = ActiveTheme.ToolbarForeColor;
            e.Graphics.FillRectangle(new SolidBrush(ActiveTheme.ToolbarBackColor), e.Item.Bounds);
        }

        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            if (ActiveTheme == null)
                return;

            Rectangle rect = new Rectangle(1, 0, e.Item.Width - 2, e.Item.Height);

            if (e.Item.Pressed)
            {
                e.Item.ForeColor = ActiveTheme.OverTimeColor;
                e.Graphics.FillRectangle(new SolidBrush(ActiveTheme.ButtonPressedColor), rect);
            }
            else if (e.Item.Selected)
            {
                e.Item.ForeColor = ActiveTheme.AlertTimeColor;
                e.Graphics.FillRectangle(new SolidBrush(ActiveTheme.ButtonHoverColor), rect);
            }
            else
            {
                e.Item.ForeColor = ActiveTheme.ToolbarForeColor;
                e.Graphics.FillRectangle(new SolidBrush(ActiveTheme.ButtonBackColor), rect);
            }
        }

        protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
        {
            if(ActiveTheme != null)
                e.Graphics.FillRectangle(new SolidBrush(ActiveTheme.ToolbarBackColor), e.ToolStrip.ClientRectangle);
        }
    }
}
