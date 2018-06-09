using System;
using Windows.System;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Shapes;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace BrickBreaker
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        #region  prop
        // data members of shadow objects
        Bar gameBar;
        DispatcherTimer timer;
        Wall leftWall;
        Wall topWall;
        Wall rightWall;
        Ball ball;
        Brick[] bricks;
        const int BOARD_LIMIT = 900;
        int bricksCounter;
        int score = 0;
        bool isGamePaused = false;
        bool isPlayMusic = true;
        bool isPlaySndEfx = true;
        int level = 1;
        #endregion


        public MainPage()
        {
            this.InitializeComponent();
            StartGame();
        }

        // each tick activate the next objects methods
        private void Timer_Tick(object sender, object e)
        {
            // move objects
            gameBar.Movement();

            // game speed grows as level up
            for (int j = 0; j < level; j++)
            {
                ball.Movement();

                // check collisions
                gameBar.Collision(leftWall);
                gameBar.Collision(rightWall);

                ball.Collision(leftWall);
                ball.Collision(topWall);
                ball.Collision(rightWall);

                ball.Collision(gameBar);

                for (int i = 0; i < bricks.Length; i++)
                {
                    // for brick that is not exist, skip (continue) the collision
                    if (bricks[i] == null) continue;
                    if (ball.Collision(bricks[i]))
                    {
                        DeleteBrick(i);
                        score += 100;
                        txtBlScore.Text = "SCORE: " + score.ToString();
                        bricksCounter--;
                    }

                    // cleanup - use the ball to make one collide only
                    ball.countCollides = 0;
                }
            }

            if (IsLevelComplete())
                LevelUp();

            if (IsGameOver())
                EndGame();

            // paint objects
            Canvas.SetLeft(rectBar, gameBar.Position_X);
            Canvas.SetLeft(paintBall, ball.Position_X);
            Canvas.SetTop(paintBall, ball.Position_Y);
        }

        // Initiate game instanses
        private void StartGame()
        {
            // count the amount of all GUI elements & set it for array length 
            bool[] ToDelete = new bool[gameBoard.Children.Count];
            for (int i = 0; i < gameBoard.Children.Count; i++)
            {
                // delet all painted Rectangle bricks only from canvas 
                var brick = gameBoard.Children[i] as FrameworkElement;
                string elementName = brick.Name;
                if (elementName == "rectBar" || elementName == "leftRectWall"
                    || elementName == "rightRectWall" || elementName == "topRectWall")
                {
                    continue;
                }
                ToDelete[i] = (gameBoard.Children[i] is Rectangle);
            }

            // delet Rectangle only (a canvas children) from array 
            for (int i = ToDelete.Length - 1; i > -1; i--)
            {
                if (ToDelete[i])
                {
                    gameBoard.Children.RemoveAt(i);
                }
            }

            btnExit.Visibility = Visibility.Collapsed;
            btnRestartGame.Visibility = Visibility.Collapsed;
            txtPhrsGameOver.Visibility = Visibility.Collapsed;

            // initialize and activate timer that use to run the game
            // each tick represent a one frame shot of movement.
            if (timer == null)
            {
                timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromMilliseconds(16);
                timer.Tick += Timer_Tick;
                timer.Start();
            }
            else
            {
                timer.Start();
            }

            // update event of set keys input every thread (frame) 
            CoreWindow.GetForCurrentThread().KeyDown += MainPage_KeyDown;
            CoreWindow.GetForCurrentThread().KeyUp += MainPage_KeyUp;

            // initiation objects
            gameBar = new Bar(position_X: 525, position_Y: 700, objWidth: 300, objLength: 50);
            leftWall = new Wall(position_X: 0, position_Y: 20, objWidth: 20, objLength: 748);
            topWall = new Wall(position_X: 0, position_Y: 0, objWidth: 1366, objLength: 20);
            rightWall = new Wall(position_X: 1346, position_Y: 20, objWidth: 20, objLength: 748);
            ball = new Ball(470, 490, 20, 20, 5, 5);
            txtBlLevel.Text = "LEVEL: " + level.ToString();
            InitiateBricks();

            ControlMusic();
        }

        // on each ball collision with brick, run this method
        private void DeleteBrick(int BrickIndex)
        {
            Rectangle rect = bricks[BrickIndex].Rectangle as Rectangle;
            gameBoard.Children.Remove(rect);
            bricks[BrickIndex] = null;
            sndCollision.Position = TimeSpan.FromMilliseconds(0);
            SndEfx();
        }

        private bool IsLevelComplete()
        {
            return (bricksCounter <= 0);
        }

        private void LevelUp()
        {
            timer.Stop();
            ball.StopMovement();
            sndGameWinning.Play();
            level++;
            StartGame();
        }

        private bool IsGameOver()
        {
            return ball.Position_Y >= BOARD_LIMIT;
        }

        private void EndGame()
        {
            ShowButtons();
            txtPhrsGameOver.Visibility = Visibility.Visible;
            gameMusic.Stop();
            sndFallingBall.Position = TimeSpan.FromMilliseconds(0);
            sndFallingBall.Play();
            timer.Stop();
        }

        private void MainPage_KeyDown(CoreWindow sender, KeyEventArgs args)
        {
            if (args.VirtualKey == VirtualKey.Left)
            {
                gameBar.SetMovement(Bar.Directions.LEFT);
            }
            else if (args.VirtualKey == VirtualKey.Right)
            {
                gameBar.SetMovement(Bar.Directions.RIGHT);
            }
        }

        private void MainPage_KeyUp(object sender, KeyEventArgs args)
        {
            if (args.VirtualKey == VirtualKey.Left || args.VirtualKey == VirtualKey.Right)
            {
                gameBar.SetMovement(Bar.Directions.NONE);
            }
        }


        private void InitiateBricks()
        {
            // brick objects initialisation
            bool x = true;
            bool _ = false;
            bool[,] bricksMap = new bool[7, 9];

            switch (level)
            {
                case 1:
                    bool[,] bricksMap1 = //[7,9]
            {
                { x, x, x, x, x, x, x, x, x },
                { x, x, _, x, x, x, _, x, x },
                { x, x, x, x, x, x, x, x, x },
                { x, x, x, x, x, x, x, x, x },
                { x, x, _, x, x, x, _, x, x },
                { x, x, x, _, _, _, x, x, x },
                { x, x, x, x, x, x, x, x, x },
            };
                    bricksMap = bricksMap1;
                    break;
                case 2:
                    bool[,] bricksMap2 = //[7,9]
           {
                { x, x, x, x, x, x, x, x, x },
                { _, _, _, _, _, _, _, _, _, },
                { x, x, x, x, x, x, x, x, x },
                { _, _, _, _, _, _, _, _, _, },
                { x, x, x, x, x, x, x, x, x },
                { _, _, _, _, _, _, _, _, _, },
                { x, x, x, x, x, x, x, x, x },
            };
                    bricksMap = bricksMap2;
                    break;
                case 3:
                    bool[,] bricksMap3 = //[7,9]
           {
                { x, x, _, _, x, _, _, x, x },
                { x, _, _, x, _, x, _, _, x },
                { _, _, x, _, x, _, x, _, _ },
                { _, x, _, x, _, x, _, x, _ },
                { _, _, x, _, x, _, x, _, _ },
                { x, _, _, x, _, x, _, _, x },
                { x, x, _, _, x, _, _, x, x },
            };
                    bricksMap = bricksMap3;
                    break;
                default:
                    bool[,] bricksMapD = //[7,9]
            {
                { x, x, x, x, x, x, x, x, x },
                { x, x, _, x, x, x, _, x, x },
                { x, x, x, x, x, x, x, x, x },
                { x, x, x, x, x, x, x, x, x },
                { x, x, _, x, x, x, _, x, x },
                { x, x, x, _, _, _, x, x, x },
                { x, x, x, x, x, x, x, x, x },
            };
                    bricksMap = bricksMapD;
                    break;

            }

            int i = 0;
            for (int row = 0; row < bricksMap.GetLength(0); row++)
            {
                for (int col = 0; col < bricksMap.GetLength(1); col++)
                {
                    if (bricksMap[row, col] == true)
                    {
                        i++;
                    }
                }
            }

            // initiate the Brick array by giving it the length
            bricks = new Brick[i];
            bricksCounter = i;

            // paint brick objects
            SolidColorBrush mySolidColorBrush = new SolidColorBrush();
            mySolidColorBrush.Color = Color.FromArgb(255, 255, 255, 0);
            int brickWidth = 100;
            int brickHeight = 50;
            i = 0;
            for (int row = 0; row < bricksMap.GetLength(0); row++)
            {
                for (int col = 0; col < bricksMap.GetLength(1); col++)
                {
                    if (bricksMap[row, col] == true)
                    {
                        // col ==> X: each step of col make a step progress of brickWidth + location on the X axis
                        // row ==> Y: each step of row make a step progress of brickHeight + location on the Y axis
                        bricks[i] = new Brick(position_X: (col * (brickWidth + 1)) + 200, position_Y: (row * (brickHeight + 1)) + 100, objLength: brickHeight, objWidth: brickWidth);

                        Rectangle rect = new Rectangle()
                        {
                            Width = brickWidth,
                            Height = brickHeight
                        };

                        // drow paint for the brick cover 
                        rect.Fill = mySolidColorBrush;
                        gameBoard.Children.Add(rect);
                        Canvas.SetTop(rect, bricks[i].Position_Y);
                        Canvas.SetLeft(rect, bricks[i].Position_X);

                        // initilze brick paint cover property 
                        bricks[i].Rectangle = rect;
                        i++;
                    }
                }
            }
        }

        private void btnRestartGame_Click(object sender, RoutedEventArgs e)
        {
            score = 0;
            level = 1;
            StartGame();
            paintBall.Visibility = Visibility.Visible;
            txtBlScore.Text = "SCORE: 0";
        }

        private void btnPause_Click(object sender, RoutedEventArgs e)
        {
            isGamePaused = !isGamePaused;
            if (isGamePaused)
                timer.Stop();
            else
                timer.Start();
        }

        private void BtnMute_Click(object sender, RoutedEventArgs e)
        {
            isPlayMusic = !isPlayMusic;
            ControlMusic();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }

        private void btnSndEfx_Click(object sender, RoutedEventArgs e)
        {
            isPlaySndEfx = !isPlaySndEfx;
        }

        private void ControlMusic()
        {
            if (isPlayMusic)
                gameMusic.Play();
            else
                gameMusic.Stop();
        }

        private void SndEfx()
        {
            if (isPlaySndEfx)
                sndCollision.Play();
            else
                sndCollision.Stop();
        }

        private void ShowButtons()
        {
            btnRestartGame.Visibility = Visibility.Visible;
            btnExit.Visibility = Visibility.Visible;
        }
    }
}
