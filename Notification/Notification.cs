#region

using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Media;
using System.Windows.Forms;

#endregion

//Made by Coefficient @ http://coefficient.me
public class Notification : Form
{
    #region Properties

    private string _title;
    private string _text;
    private Image _iconImage;
    public string SoundPath { get; set; }
    public Stream SoundStream { get; set; }
    public int Seconds { get; set; }

    public string Title
    {
        get { return _title; }
        set
        {
            _title = value;
            labelTitle.Text = value;
        }
    }

    public string DisplayText
    {
        get { return _text; }
        set
        {
            _text = value;
            textBoxText.Text = _text;
        }
    }

    public Color BorderColor
    {
        get { return _borderColor; }
        set
        {
            _borderColor = value;
            Invalidate();
        }
    }

    public Image IconImage
    {
        get { return _iconImage; }
        set
        {
            _iconImage = value;
            Invalidate();
        }
    }

    #endregion

    #region Fields

    private int _time;
    private Color _borderColor;
    private Timer _timer;
    private SoundPlayer _player;

    #endregion

    #region Constructors

    /// <summary>
    ///     Creates a new notification with the specified icon, title, text, border color.
    /// </summary>
    /// <param name="image">The icon that will be placed at the left of the form</param>
    /// <param name="title">The title that will be shown at the top left of the form</param>
    /// <param name="text">The text that will be placed ton the center right of the form</param>
    /// <param name="borderColor">The color which form the border will have</param>
    public Notification(Image image, string title, string text, Color borderColor)
    {
        //Initialize our form
        InitializeComponent();
        //Set our image
        IconImage = image;
        //Set our title
        Title = title;
        //Set our text
        DisplayText = text;
        //Set our border color
        BorderColor = borderColor;
        //Set topmost to true, this enables the form to always be visible even if the form doesn't have focus
        TopMost = true;
        //Add an event so when the form is minimized
        Resize += NodeNotification_Resized;
        //Add an event so when the form has focus
        GotFocus += NodeNotification_GotFocus;
        //Enable double buffering
        DoubleBuffered = true;
    }

    /// <summary>
    ///     Creates a new notification with the specified icon, title, text, border color for the specified amount of time in
    ///     seconds.
    /// </summary>
    /// <param name="image">The icon that will be placed at the left of the form</param>
    /// <param name="title">The title that will be shown at the top left of the form</param>
    /// <param name="text">The text that will be placed ton the center right of the form</param>
    /// <param name="borderColor">The color which form the border will have</param>
    /// <param name="seconds">The time in seconds for the form to be left displayed</param>
    public Notification(Image image, string title, string text, Color borderColor, int seconds)
        : this(image, title, text, borderColor)
    {
        Seconds = seconds;
    }

    /// <summary>
    ///     Creates a new notification with the specified icon, title, text, border color for the specified amount of time in
    ///     seconds with a sound to be played on display.
    /// </summary>
    /// <param name="image">The icon that will be placed at the left of the form</param>
    /// <param name="title">The title that will be shown at the top left of the form</param>
    /// <param name="text">The text that will be placed ton the center right of the form</param>
    /// <param name="borderColor">The color which form the border will have</param>
    /// <param name="seconds">The time in seconds for the form to be left displayed</param>
    /// <param name="soundPath">The path to the sound file (SoundPlayer class)</param>
    public Notification(Image image, string title, string text, Color borderColor, int seconds,
        string soundPath) : this(image, title, text, borderColor, seconds)
    {
        SoundPath = soundPath;
    }

    /// <summary>
    ///     Creates a new notification with the specified icon, title, text, border color with a sound to be played on display.
    /// </summary>
    /// <param name="image">The icon that will be placed at the left of the form</param>
    /// <param name="title">The title that will be shown at the top left of the form</param>
    /// <param name="text">The text that will be placed ton the center right of the form</param>
    /// <param name="borderColor">The color which form the border will have</param>
    /// <param name="soundPath">The path to the sound file (SoundPlayer class)</param>
    public Notification(Image image, string title, string text, Color borderColor, string soundPath)
        : this(image, title, text, borderColor)
    {
        SoundPath = soundPath;
    }

    /// <summary>
    ///     Creates a new notification with the specified icon, title, text, border color with a sound to be played on display.
    /// </summary>
    /// <param name="image">The icon that will be placed at the left of the form</param>
    /// <param name="title">The title that will be shown at the top left of the form</param>
    /// <param name="text">The text that will be placed ton the center right of the form</param>
    /// <param name="borderColor">The color which form the border will have</param>
    /// <param name="soundStream">The stream for which the SoundPlayer will read</param>
    public Notification(Image image, string title, string text, Color borderColor, Stream soundStream)
        : this(image, title, text, borderColor)
    {
        SoundStream = soundStream;
    }

    /// <summary>
    ///     Creates a new notification with the specified icon, title, text, border color for the specified amount of time in
    ///     seconds with a sound to be played on display.
    /// </summary>
    /// <param name="image">The icon that will be placed at the left of the form</param>
    /// <param name="title">The title that will be shown at the top left of the form</param>
    /// <param name="text">The text that will be placed ton the center right of the form</param>
    /// <param name="borderColor">The color which form the border will have</param>
    /// <param name="seconds">The time in seconds for the form to be left displayed</param>
    /// <param name="soundStream">The stream for which the SoundPlayer will read</param>
    public Notification(Image image, string title, string text, Color borderColor, int seconds,
        Stream soundStream) : this(image, title, text, borderColor, seconds)
    {
        SoundStream = soundStream;
    }

    #endregion

    #region Event Handlers & Methods

    private void NodeNotification_Resized(object sender, EventArgs args)
    {
        //When the form is minimized, it will bring it back to focus, this stops the form from disappearing when the user goes to desktop using the bottom right button on the taskbar
        if (WindowState == FormWindowState.Minimized)
            WindowState = FormWindowState.Normal;
    }

    private void NodeNotification_Load(object sender, EventArgs e)
    {
        //Once loaded, position the form to the bottom left of the screen with added padding
        Location = new Point(Screen.PrimaryScreen.WorkingArea.Width - Width - 5,
            Screen.PrimaryScreen.WorkingArea.Height - Height - 5);
        FadeIn();
        //Start the timer
        if (_timer != null)
            _timer.Start();
        //Play the sound
        if (_player != null)
            _player.Play();
    }

    private void NodeNotification_GotFocus(object sender, EventArgs e)
    {
        //Once the form has focus, directly give it to buttonDismis so the user can easily press enter to close the form
        buttonDismiss.Focus();
    }

    private void buttonDismiss_Click(object sender, EventArgs e)
    {
        FadeOutAndClose();
        //Closes the notification
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        //Define our graphics object
        Graphics g = e.Graphics;
        //Draw the border with the specified color
        using (Pen pen = new Pen(BorderColor))
        {
            g.DrawRectangle(pen, 0, 0, Width - 1, Height - 1);
        }
    }

    private void FadeIn()
    {
        Timer timer = new Timer();
        timer.Interval = 10;
        timer.Tick += (sender, args) =>
        {
            if (Opacity == 1d)
                timer.Stop();

            Opacity += 0.02d;
        };
        timer.Start();
    }

    private void FadeOutAndClose()
    {
        Timer timer = new Timer();
        timer.Interval = 10;
        timer.Tick += (sender, args) =>
        {
            if (Opacity == 0d)
            {
                timer.Stop();
                Close();
            }
            Opacity -= 0.02d;
        };
        timer.Start();
    }

    public new void Show()
    {
        Opacity = 0;
        pictureBoxImage.Image = IconImage;
        //Set our title
        labelTitle.Text = Title;
        //Set our text
        textBoxText.Text = DisplayText;
        //Set our color
        _borderColor = BorderColor;
        if (Seconds != 0)
        {
            buttonDismiss.Text = $"Dismiss ({Seconds - _time}s)";
            _timer = new Timer();
            _timer.Interval = 1000;
            _timer.Tick += (sender, args) =>
            {
                _time++;
                buttonDismiss.Text = $"Dismiss ({Seconds - _time}s)";
                if (_time == Seconds)
                {
                    _timer.Stop();
                    FadeOutAndClose();
                }
            };
        }
        if (SoundPath != null)
            _player = new SoundPlayer(SoundPath);
        if (SoundStream != null)
            _player = new SoundPlayer(SoundStream);
        base.Show();
    }

    protected override bool ShowWithoutActivation
    {
        get { return true; }
    }

    #endregion

    #region Windows Forms Code

    /// <summary>
    ///     Required designer variable.
    /// </summary>
    private readonly IContainer components = null;

    /// <summary>
    ///     Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
            components.Dispose();
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///     Required method for Designer support - do not modify
    ///     the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.pictureBoxImage = new System.Windows.Forms.PictureBox();
        this.buttonDismiss = new System.Windows.Forms.Button();
        this.labelTitle = new System.Windows.Forms.Label();
        this.textBoxText = new System.Windows.Forms.TextBox();
        ((System.ComponentModel.ISupportInitialize) (this.pictureBoxImage)).BeginInit();
        this.SuspendLayout();
        // 
        // pictureBoxImage
        // 
        this.pictureBoxImage.Anchor = System.Windows.Forms.AnchorStyles.Left;
        this.pictureBoxImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
        this.pictureBoxImage.Location = new System.Drawing.Point(18, 34);
        this.pictureBoxImage.Name = "pictureBoxImage";
        this.pictureBoxImage.Size = new System.Drawing.Size(64, 64);
        this.pictureBoxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
        this.pictureBoxImage.TabIndex = 0;
        this.pictureBoxImage.TabStop = false;
        // 
        // buttonDismiss
        // 
        this.buttonDismiss.Anchor =
        ((System.Windows.Forms.AnchorStyles)
            ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        this.buttonDismiss.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
        this.buttonDismiss.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        this.buttonDismiss.Location = new System.Drawing.Point(215, 76);
        this.buttonDismiss.Name = "buttonDismiss";
        this.buttonDismiss.Size = new System.Drawing.Size(90, 23);
        this.buttonDismiss.TabIndex = 0;
        this.buttonDismiss.Text = "Dismiss";
        this.buttonDismiss.UseVisualStyleBackColor = false;
        this.buttonDismiss.Click += new System.EventHandler(this.buttonDismiss_Click);
        // 
        // labelTitle
        // 
        this.labelTitle.AutoSize = true;
        this.labelTitle.Location = new System.Drawing.Point(15, 10);
        this.labelTitle.Name = "labelTitle";
        this.labelTitle.Size = new System.Drawing.Size(26, 14);
        this.labelTitle.TabIndex = 3;
        this.labelTitle.Text = "Title";
        this.labelTitle.Font = new Font("Arial", 8.25f);
        // 
        // textBoxText
        // 
        this.textBoxText.Anchor =
        ((System.Windows.Forms.AnchorStyles)
        ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
           | System.Windows.Forms.AnchorStyles.Left)
          | System.Windows.Forms.AnchorStyles.Right)));
        this.textBoxText.BorderStyle = System.Windows.Forms.BorderStyle.None;
        this.textBoxText.Enabled = false;
        this.textBoxText.Location = new System.Drawing.Point(102, 31);
        this.textBoxText.Multiline = true;
        this.textBoxText.Name = "textBoxText";
        this.textBoxText.ReadOnly = true;
        this.textBoxText.Size = new System.Drawing.Size(194, 39);
        this.textBoxText.TabIndex = 0;
        // 
        // IgniteNotification
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(317, 111);
        this.Controls.Add(this.textBoxText);
        this.Controls.Add(this.labelTitle);
        this.Controls.Add(this.buttonDismiss);
        this.Controls.Add(this.pictureBoxImage);
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        this.Name = "IgniteNotification";
        this.Text = "IgniteNotification";
        this.Load += new System.EventHandler(this.NodeNotification_Load);
        ((System.ComponentModel.ISupportInitialize) (this.pictureBoxImage)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    #endregion

    private PictureBox pictureBoxImage;
    private Button buttonDismiss;
    private Label labelTitle;
    private TextBox textBoxText;

    #endregion
}