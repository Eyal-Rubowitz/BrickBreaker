﻿

#pragma checksum "C:\Users\eyalr\Desktop\Games\BrickBreaker\BrickBreaker\BrickBreaker.Windows\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "008D68CCD68E6475872A257C4B5D9128"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BrickBreaker
{
    partial class MainPage : global::Windows.UI.Xaml.Controls.Page
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.Canvas gameBoard; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Shapes.Rectangle rectBar; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Shapes.Rectangle leftRectWall; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Shapes.Rectangle topRectWall; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Shapes.Rectangle rightRectWall; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Shapes.Ellipse paintBall; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.MediaElement gameMusic; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.TextBlock txtPhrsGameOver; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.MediaElement sndCollision; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.MediaElement sndFallingBall; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.MediaElement sndGameWinning; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.TextBlock txtBlScore; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.Button btnRestartGame; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.Button btnPause; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.Button BtnMute; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.Button btnSndEfx; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.Button btnExit; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private global::Windows.UI.Xaml.Controls.TextBlock txtBlLevel; 
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        private bool _contentLoaded;

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent()
        {
            if (_contentLoaded)
                return;

            _contentLoaded = true;
            global::Windows.UI.Xaml.Application.LoadComponent(this, new global::System.Uri("ms-appx:///MainPage.xaml"), global::Windows.UI.Xaml.Controls.Primitives.ComponentResourceLocation.Application);
 
            gameBoard = (global::Windows.UI.Xaml.Controls.Canvas)this.FindName("gameBoard");
            rectBar = (global::Windows.UI.Xaml.Shapes.Rectangle)this.FindName("rectBar");
            leftRectWall = (global::Windows.UI.Xaml.Shapes.Rectangle)this.FindName("leftRectWall");
            topRectWall = (global::Windows.UI.Xaml.Shapes.Rectangle)this.FindName("topRectWall");
            rightRectWall = (global::Windows.UI.Xaml.Shapes.Rectangle)this.FindName("rightRectWall");
            paintBall = (global::Windows.UI.Xaml.Shapes.Ellipse)this.FindName("paintBall");
            gameMusic = (global::Windows.UI.Xaml.Controls.MediaElement)this.FindName("gameMusic");
            txtPhrsGameOver = (global::Windows.UI.Xaml.Controls.TextBlock)this.FindName("txtPhrsGameOver");
            sndCollision = (global::Windows.UI.Xaml.Controls.MediaElement)this.FindName("sndCollision");
            sndFallingBall = (global::Windows.UI.Xaml.Controls.MediaElement)this.FindName("sndFallingBall");
            sndGameWinning = (global::Windows.UI.Xaml.Controls.MediaElement)this.FindName("sndGameWinning");
            txtBlScore = (global::Windows.UI.Xaml.Controls.TextBlock)this.FindName("txtBlScore");
            btnRestartGame = (global::Windows.UI.Xaml.Controls.Button)this.FindName("btnRestartGame");
            btnPause = (global::Windows.UI.Xaml.Controls.Button)this.FindName("btnPause");
            BtnMute = (global::Windows.UI.Xaml.Controls.Button)this.FindName("BtnMute");
            btnSndEfx = (global::Windows.UI.Xaml.Controls.Button)this.FindName("btnSndEfx");
            btnExit = (global::Windows.UI.Xaml.Controls.Button)this.FindName("btnExit");
            txtBlLevel = (global::Windows.UI.Xaml.Controls.TextBlock)this.FindName("txtBlLevel");
        }
    }
}



