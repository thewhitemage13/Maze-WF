namespace Maze
{
    public partial class LevelForm : Form
    {
        public Maze maze;
        public Character Hero;
        public TextBox textBox;
        private AudioPlayer audioPlayer;
        public LevelForm()
        {
            audioPlayer = new AudioPlayer();
            InitializeComponent();
            FormSettings();
            audioPlayer.PlaySound(@"C:\Users\lolim\Desktop\Home Work\2.2. Maze\GameEffects\02-Metal-Area.wav");
            this.FormClosing += LevelForm_FormClosing;
            StartGameProcess();
        }
        public void FormSettings()
        {
            //Text = Configuration.Title;
            BackColor = Configuration.Background;

            //ClientSize = new Size(
            //Configuration.Columns * Configuration.PictureSide,
            //Configuration.Rows * Configuration.PictureSide);

            StartPosition = FormStartPosition.CenterScreen;
        }

        public void StartGameProcess()
        {
            Hero = new Character(this);
            maze = new Maze(this);
            maze.Generate();
            maze.Show();
        }
        // Дз: 
        // пробовал добавить TextBox, чтоб во время подбора монет информация высвечиваласт возле игрового поля,
        // но почему-то если добавляю новый элемент (тот же TextBox), то ничего не запускается и вылетает ;(
        private void KeyDownHandler(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                if (maze.cells[Hero.PosY, Hero.PosX + 1].Type != CellType.WALL)
                {
                    if (maze.cells[Hero.PosY, Hero.PosX + 1].Type == CellType.MEDAL)
                    {
                        Hero.MedalCount++;
                        audioPlayer.PlaySound(@"C:\Users\lolim\Desktop\Home Work\2.2. Maze\GameEffects\money.wav");
                        Text = Hero.MedalCount.ToString();
                    }

                    Hero.Clear();
                    Hero.MoveRight();
                    Hero.Show();
                    bool check = Hero.CheckVictory();
                    if (check)
                    {
                        audioPlayer.PlaySound(@"C:\Users\lolim\Desktop\Home Work\2.2. Maze\GameEffects\Game-Over.wav");
                    }
                }
            }
            else if (e.KeyCode == Keys.Left && Hero.PosX != 0)
            {
                if (maze.cells[Hero.PosY, Hero.PosX - 1].Type != CellType.WALL)
                {
                    if (maze.cells[Hero.PosY, Hero.PosX - 1].Type == CellType.MEDAL)
                    {
                        Hero.MedalCount++;
                        audioPlayer.PlaySound(@"C:\Users\lolim\Desktop\Home Work\2.2. Maze\GameEffects\money.wav");
                        Text = Hero.MedalCount.ToString();
                    }
                    Hero.Clear();
                    Hero.MoveLeft();
                    Hero.Show();
                    Hero.CheckVictory();
                }
            }
            else if (e.KeyCode == Keys.Up)
            {
                if (maze.cells[Hero.PosY - 1, Hero.PosX].Type != CellType.WALL)
                {
                    if (maze.cells[Hero.PosY - 1, Hero.PosX].Type == CellType.MEDAL)
                    {

                        Hero.MedalCount++;
                        audioPlayer.PlaySound(@"C:\Users\lolim\Desktop\Home Work\2.2. Maze\GameEffects\money.wav");
                        Text = Hero.MedalCount.ToString();
                    }
                    Hero.Clear();
                    Hero.MoveUp();
                    Hero.Show();
                    Hero.CheckVictory();
                }
            }
            else if (e.KeyCode == Keys.Down)
            {
                if (maze.cells[Hero.PosY + 1, Hero.PosX].Type != CellType.WALL)
                {
                    if (maze.cells[Hero.PosY + 1, Hero.PosX].Type == CellType.MEDAL)
                    {
                        Hero.MedalCount++;
                        audioPlayer.PlaySound(@"C:\Users\lolim\Desktop\Home Work\2.2. Maze\GameEffects\money.wav");
                        Text = Hero.MedalCount.ToString();
                    }
                    Hero.Clear();
                    Hero.MoveDown();
                    Hero.Show();
                    Hero.CheckVictory();
                }
            }
        }
        private void LevelForm_Load(object sender, EventArgs e)
        {

        }

        private void LevelForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            audioPlayer.Stop();
        }

    }
}