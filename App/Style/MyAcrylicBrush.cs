using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Hosting;

namespace App.Style
{
    public static class MyAcrylicBrush
    {
        /// <summary>
        ///初始化亚克力效果
        ///需要在XAML的外层Grid中添加Span所有网格的内层Grid
        /// </summary>
        /// <param name="glassHost">内层Grid对象的名称</param>
        public static void InitializeFrostedGlass(UIElement glassHost)
        {
            if ((bool)ApplicationData.Current.LocalSettings.Values["IsUseAcrylicBrush"] == true)
            {
                Visual hostVisual = ElementCompositionPreview.GetElementVisual(glassHost);
                Compositor compositor = hostVisual.Compositor;
                var backdropBrush = compositor.CreateHostBackdropBrush();
                var glassVisual = compositor.CreateSpriteVisual();
                glassVisual.Brush = backdropBrush;
                ElementCompositionPreview.SetElementChildVisual(glassHost, glassVisual);
                var bindSizeAnimation = compositor.CreateExpressionAnimation("hostVisual.Size");
                bindSizeAnimation.SetReferenceParameter("hostVisual", hostVisual);
                glassVisual.StartAnimation("Size", bindSizeAnimation);

            }
        }
    }
}
