using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using LookOrFeel.Animation;
using System.Diagnostics;
using System.Windows.Media.Animation;


namespace AnimationTester
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : System.Windows.Window
    {

        public Window1()
        {
            InitializeComponent();

            Loaded += new RoutedEventHandler( Window1_Loaded );
        }

        void Window1_Loaded( object sender, RoutedEventArgs e )
        {
            // populate ComboBox with Equation types
            foreach ( string equationName in Enum.GetNames( typeof( PennerDoubleAnimation.Equations ) ) )
                _Equations.Items.Add( equationName );

            _Equations.SelectedIndex = 0;
        }

        private void Animate()
        {
            PennerDoubleAnimation.Equations equation =
                ( PennerDoubleAnimation.Equations ) Enum.Parse( typeof( PennerDoubleAnimation.Equations ), _Equations.SelectedItem.ToString() );
            double from = double.Parse( _FromTB.Text );
            double to = double.Parse( _ToTB.Text );
            int durationMS = int.Parse( _DurationTB.Text );

            Animator.AnimatePenner( _Rect, Canvas.LeftProperty, equation, from, to, durationMS, OnAnimationComplete );

            StatusTB.Text = "Animating";
        }

        void OnAnimateClicked( object sender, RoutedEventArgs e )
        {
            Animate();
        }

        /// <summary>
        /// Sets a random value for "To" and calls animate
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnAnimateRandomClicked( object sender, RoutedEventArgs e )
        {
            Random rand = new Random();
            _FromTB.Text = Canvas.GetLeft( _Rect ).ToString();
            _ToTB.Text = Math.Round( rand.NextDouble() * 750 ).ToString();

            Animate();
        }

        /// <summary>
        /// Sample animation callback.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnAnimationComplete( object sender, EventArgs e )
        {
            AnimationTimeline at = sender as AnimationTimeline;
            if ( at != null )
                at.Completed -= OnAnimationComplete;

            StatusTB.Text = "Animation Complete!";
        }
    }
}