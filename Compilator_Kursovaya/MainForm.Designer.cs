namespace Compilator_kursovaya
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            menuStrip1 = new MenuStrip();
            toolStripMenuItem1 = new ToolStripMenuItem();
            CreateToolStripMenuItem = new ToolStripMenuItem();
            OpenToolStripMenuItem = new ToolStripMenuItem();
            SaveToolStripMenuItem = new ToolStripMenuItem();
            SaveAsToolStripMenuItem = new ToolStripMenuItem();
            CloseFileToolStripMenuItem = new ToolStripMenuItem();
            ExitToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            CancelToolStripMenuItem = new ToolStripMenuItem();
            RepeatToolStripMenuItem = new ToolStripMenuItem();
            CutToolStripMenuItem = new ToolStripMenuItem();
            CopyToolStripMenuItem = new ToolStripMenuItem();
            PasteToolStripMenuItem = new ToolStripMenuItem();
            DeleteToolStripMenuItem = new ToolStripMenuItem();
            SelectAllToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem3 = new ToolStripMenuItem();
            TaskToolStripMenuItem = new ToolStripMenuItem();
            GrammarToolStripMenuItem = new ToolStripMenuItem();
            GrammarClassificToolStripMenuItem = new ToolStripMenuItem();
            AnalisysMethodToolStripMenuItem = new ToolStripMenuItem();
            ErrorDiagToolStripMenuItem = new ToolStripMenuItem();
            TestExampleToolStripMenuItem = new ToolStripMenuItem();
            LiteratureToolStripMenuItem = new ToolStripMenuItem();
            CodeToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem4 = new ToolStripMenuItem();
            toolStripMenuItem5 = new ToolStripMenuItem();
            ShowContentsToolStripMenuItem = new ToolStripMenuItem();
            AboutToolStripMenuItem = new ToolStripMenuItem();
            SettingsToolStripMenuItem1 = new ToolStripMenuItem();
            TestSizeToolStripMenuItem = new ToolStripMenuItem();
            text11 = new ToolStripMenuItem();
            text12 = new ToolStripMenuItem();
            text14 = new ToolStripMenuItem();
            text16 = new ToolStripMenuItem();
            text18 = new ToolStripMenuItem();
            text20 = new ToolStripMenuItem();
            LanguageToolStripMenuItem = new ToolStripMenuItem();
            RussanToolStripMenuItem = new ToolStripMenuItem();
            EnglishToolStripMenuItem = new ToolStripMenuItem();
            panel1 = new Panel();
            InfoButton = new Button();
            AboutButton = new Button();
            RunButton = new Button();
            PasteButton = new Button();
            CutButton = new Button();
            CopyButton = new Button();
            RepeatButton = new Button();
            ReturnButton = new Button();
            SaveFileButton = new Button();
            OpenFileButton = new Button();
            CreateFileButton = new Button();
            richTextBox1 = new RichTextBox();
            saveFileDialog1 = new SaveFileDialog();
            openFileDialog1 = new OpenFileDialog();
            splitContainer1 = new SplitContainer();
            richTextBox3 = new RichTextBox();
            dataGridView1 = new DataGridView();
            параметрыToolStripMenuItem = new ToolStripMenuItem();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            toolTip1 = new ToolTip(components);
            menuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { toolStripMenuItem1, toolStripMenuItem2, toolStripMenuItem3, toolStripMenuItem4, toolStripMenuItem5, SettingsToolStripMenuItem1 });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1622, 33);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { CreateToolStripMenuItem, OpenToolStripMenuItem, SaveToolStripMenuItem, SaveAsToolStripMenuItem, CloseFileToolStripMenuItem, ExitToolStripMenuItem });
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(69, 29);
            toolStripMenuItem1.Tag = "toolStripMenuItem1";
            toolStripMenuItem1.Text = "Файл";
            // 
            // CreateToolStripMenuItem
            // 
            CreateToolStripMenuItem.Name = "CreateToolStripMenuItem";
            CreateToolStripMenuItem.Size = new Size(232, 34);
            CreateToolStripMenuItem.Tag = "CreateToolStripMenuItem";
            CreateToolStripMenuItem.Text = "Создать";
            CreateToolStripMenuItem.Click += CreateToolStripMenuItem_Click;
            // 
            // OpenToolStripMenuItem
            // 
            OpenToolStripMenuItem.Name = "OpenToolStripMenuItem";
            OpenToolStripMenuItem.Size = new Size(232, 34);
            OpenToolStripMenuItem.Text = "Открыть";
            OpenToolStripMenuItem.Click += OpenToolStripMenuItem_Click;
            // 
            // SaveToolStripMenuItem
            // 
            SaveToolStripMenuItem.Name = "SaveToolStripMenuItem";
            SaveToolStripMenuItem.Size = new Size(232, 34);
            SaveToolStripMenuItem.Text = "Сохранить";
            SaveToolStripMenuItem.Click += SaveToolStripMenuItem_Click;
            // 
            // SaveAsToolStripMenuItem
            // 
            SaveAsToolStripMenuItem.Name = "SaveAsToolStripMenuItem";
            SaveAsToolStripMenuItem.Size = new Size(232, 34);
            SaveAsToolStripMenuItem.Text = "Сохранить как";
            SaveAsToolStripMenuItem.Click += SaveAsToolStripMenuItem_Click;
            // 
            // CloseFileToolStripMenuItem
            // 
            CloseFileToolStripMenuItem.Name = "CloseFileToolStripMenuItem";
            CloseFileToolStripMenuItem.Size = new Size(232, 34);
            CloseFileToolStripMenuItem.Text = "Закрыть файл";
            CloseFileToolStripMenuItem.Click += CloseFileToolStripMenuItem_Click;
            // 
            // ExitToolStripMenuItem
            // 
            ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            ExitToolStripMenuItem.Size = new Size(232, 34);
            ExitToolStripMenuItem.Text = "Выход";
            ExitToolStripMenuItem.Click += ExitToolStripMenuItem_Click;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.DropDownItems.AddRange(new ToolStripItem[] { CancelToolStripMenuItem, RepeatToolStripMenuItem, CutToolStripMenuItem, CopyToolStripMenuItem, PasteToolStripMenuItem, DeleteToolStripMenuItem, SelectAllToolStripMenuItem });
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(89, 29);
            toolStripMenuItem2.Text = "Правка";
            // 
            // CancelToolStripMenuItem
            // 
            CancelToolStripMenuItem.Name = "CancelToolStripMenuItem";
            CancelToolStripMenuItem.Size = new Size(223, 34);
            CancelToolStripMenuItem.Text = "Отменить";
            // 
            // RepeatToolStripMenuItem
            // 
            RepeatToolStripMenuItem.Name = "RepeatToolStripMenuItem";
            RepeatToolStripMenuItem.Size = new Size(223, 34);
            RepeatToolStripMenuItem.Text = "Повторить";
            // 
            // CutToolStripMenuItem
            // 
            CutToolStripMenuItem.Name = "CutToolStripMenuItem";
            CutToolStripMenuItem.Size = new Size(223, 34);
            CutToolStripMenuItem.Text = "Вырезать";
            // 
            // CopyToolStripMenuItem
            // 
            CopyToolStripMenuItem.Name = "CopyToolStripMenuItem";
            CopyToolStripMenuItem.Size = new Size(223, 34);
            CopyToolStripMenuItem.Text = "Копировать";
            // 
            // PasteToolStripMenuItem
            // 
            PasteToolStripMenuItem.Name = "PasteToolStripMenuItem";
            PasteToolStripMenuItem.Size = new Size(223, 34);
            PasteToolStripMenuItem.Text = "Вставить";
            // 
            // DeleteToolStripMenuItem
            // 
            DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem";
            DeleteToolStripMenuItem.Size = new Size(223, 34);
            DeleteToolStripMenuItem.Text = "Удалить";
            DeleteToolStripMenuItem.Click += DeleteToolStripMenuItem_Click;
            // 
            // SelectAllToolStripMenuItem
            // 
            SelectAllToolStripMenuItem.Name = "SelectAllToolStripMenuItem";
            SelectAllToolStripMenuItem.Size = new Size(223, 34);
            SelectAllToolStripMenuItem.Text = "Выделить все";
            SelectAllToolStripMenuItem.Click += SelectAllToolStripMenuItem_Click;
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.DropDownItems.AddRange(new ToolStripItem[] { TaskToolStripMenuItem, GrammarToolStripMenuItem, GrammarClassificToolStripMenuItem, AnalisysMethodToolStripMenuItem, ErrorDiagToolStripMenuItem, TestExampleToolStripMenuItem, LiteratureToolStripMenuItem, CodeToolStripMenuItem });
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size(70, 29);
            toolStripMenuItem3.Text = "Текст";
            // 
            // TaskToolStripMenuItem
            // 
            TaskToolStripMenuItem.Name = "TaskToolStripMenuItem";
            TaskToolStripMenuItem.Size = new Size(428, 34);
            TaskToolStripMenuItem.Text = "Постановка задачи";
            // 
            // GrammarToolStripMenuItem
            // 
            GrammarToolStripMenuItem.Name = "GrammarToolStripMenuItem";
            GrammarToolStripMenuItem.Size = new Size(428, 34);
            GrammarToolStripMenuItem.Text = "Грамматика";
            // 
            // GrammarClassificToolStripMenuItem
            // 
            GrammarClassificToolStripMenuItem.Name = "GrammarClassificToolStripMenuItem";
            GrammarClassificToolStripMenuItem.Size = new Size(428, 34);
            GrammarClassificToolStripMenuItem.Text = "Классификация грамматики";
            // 
            // AnalisysMethodToolStripMenuItem
            // 
            AnalisysMethodToolStripMenuItem.Name = "AnalisysMethodToolStripMenuItem";
            AnalisysMethodToolStripMenuItem.Size = new Size(428, 34);
            AnalisysMethodToolStripMenuItem.Text = "Метод анализа";
            // 
            // ErrorDiagToolStripMenuItem
            // 
            ErrorDiagToolStripMenuItem.Name = "ErrorDiagToolStripMenuItem";
            ErrorDiagToolStripMenuItem.Size = new Size(428, 34);
            ErrorDiagToolStripMenuItem.Text = "Диагностика и нейтрализация ошибок";
            // 
            // TestExampleToolStripMenuItem
            // 
            TestExampleToolStripMenuItem.Name = "TestExampleToolStripMenuItem";
            TestExampleToolStripMenuItem.Size = new Size(428, 34);
            TestExampleToolStripMenuItem.Text = "Тестовый пример";
            // 
            // LiteratureToolStripMenuItem
            // 
            LiteratureToolStripMenuItem.Name = "LiteratureToolStripMenuItem";
            LiteratureToolStripMenuItem.Size = new Size(428, 34);
            LiteratureToolStripMenuItem.Text = "Список литературы";
            // 
            // CodeToolStripMenuItem
            // 
            CodeToolStripMenuItem.Name = "CodeToolStripMenuItem";
            CodeToolStripMenuItem.Size = new Size(428, 34);
            CodeToolStripMenuItem.Text = "Исходный код программы";
            // 
            // toolStripMenuItem4
            // 
            toolStripMenuItem4.Name = "toolStripMenuItem4";
            toolStripMenuItem4.Size = new Size(67, 29);
            toolStripMenuItem4.Text = "Пуск";
            // 
            // toolStripMenuItem5
            // 
            toolStripMenuItem5.DropDownItems.AddRange(new ToolStripItem[] { ShowContentsToolStripMenuItem, AboutToolStripMenuItem });
            toolStripMenuItem5.Name = "toolStripMenuItem5";
            toolStripMenuItem5.Size = new Size(97, 29);
            toolStripMenuItem5.Text = "Справка";
            // 
            // ShowContentsToolStripMenuItem
            // 
            ShowContentsToolStripMenuItem.Name = "ShowContentsToolStripMenuItem";
            ShowContentsToolStripMenuItem.Size = new Size(238, 34);
            ShowContentsToolStripMenuItem.Text = "Вызов справки";
            ShowContentsToolStripMenuItem.Click += ShowContentsToolStripMenuItem_Click;
            // 
            // AboutToolStripMenuItem
            // 
            AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            AboutToolStripMenuItem.Size = new Size(238, 34);
            AboutToolStripMenuItem.Text = "О программе";
            // 
            // SettingsToolStripMenuItem1
            // 
            SettingsToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { TestSizeToolStripMenuItem, LanguageToolStripMenuItem });
            SettingsToolStripMenuItem1.Name = "SettingsToolStripMenuItem1";
            SettingsToolStripMenuItem1.Size = new Size(123, 29);
            SettingsToolStripMenuItem1.Text = "Параметры";
            // 
            // TestSizeToolStripMenuItem
            // 
            TestSizeToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { text11, text12, text14, text16, text18, text20 });
            TestSizeToolStripMenuItem.Name = "TestSizeToolStripMenuItem";
            TestSizeToolStripMenuItem.Size = new Size(228, 34);
            TestSizeToolStripMenuItem.Text = "Размер текста";
            // 
            // text11
            // 
            text11.Name = "text11";
            text11.Size = new Size(134, 34);
            text11.Text = "11";
            text11.Click += text11_Click;
            // 
            // text12
            // 
            text12.Name = "text12";
            text12.Size = new Size(134, 34);
            text12.Text = "12";
            text12.Click += text12_Click;
            // 
            // text14
            // 
            text14.Name = "text14";
            text14.Size = new Size(134, 34);
            text14.Text = "14";
            text14.Click += text14_Click;
            // 
            // text16
            // 
            text16.Name = "text16";
            text16.Size = new Size(134, 34);
            text16.Text = "16";
            text16.Click += text16_Click;
            // 
            // text18
            // 
            text18.Name = "text18";
            text18.Size = new Size(134, 34);
            text18.Text = "18";
            text18.Click += text18_Click;
            // 
            // text20
            // 
            text20.Name = "text20";
            text20.Size = new Size(134, 34);
            text20.Text = "20";
            text20.Click += text20_Click;
            // 
            // LanguageToolStripMenuItem
            // 
            LanguageToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { RussanToolStripMenuItem, EnglishToolStripMenuItem });
            LanguageToolStripMenuItem.Name = "LanguageToolStripMenuItem";
            LanguageToolStripMenuItem.Size = new Size(228, 34);
            LanguageToolStripMenuItem.Text = "Язык";
            // 
            // RussanToolStripMenuItem
            // 
            RussanToolStripMenuItem.Name = "RussanToolStripMenuItem";
            RussanToolStripMenuItem.Size = new Size(209, 34);
            RussanToolStripMenuItem.Text = "Русский";
            RussanToolStripMenuItem.Click += RussanToolStripMenuItem_Click;
            // 
            // EnglishToolStripMenuItem
            // 
            EnglishToolStripMenuItem.Name = "EnglishToolStripMenuItem";
            EnglishToolStripMenuItem.Size = new Size(209, 34);
            EnglishToolStripMenuItem.Text = "Английский";
            EnglishToolStripMenuItem.Click += EnglishToolStripMenuItem_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(InfoButton);
            panel1.Controls.Add(AboutButton);
            panel1.Controls.Add(RunButton);
            panel1.Controls.Add(PasteButton);
            panel1.Controls.Add(CutButton);
            panel1.Controls.Add(CopyButton);
            panel1.Controls.Add(RepeatButton);
            panel1.Controls.Add(ReturnButton);
            panel1.Controls.Add(SaveFileButton);
            panel1.Controls.Add(OpenFileButton);
            panel1.Controls.Add(CreateFileButton);
            panel1.Location = new Point(0, 36);
            panel1.Name = "panel1";
            panel1.Size = new Size(1619, 72);
            panel1.TabIndex = 1;
            // 
            // InfoButton
            // 
            InfoButton.BackgroundImage = (Image)resources.GetObject("InfoButton.BackgroundImage");
            InfoButton.BackgroundImageLayout = ImageLayout.Stretch;
            InfoButton.Location = new Point(783, 3);
            InfoButton.Name = "InfoButton";
            InfoButton.Size = new Size(72, 66);
            InfoButton.TabIndex = 0;
            InfoButton.TextAlign = ContentAlignment.TopRight;
            InfoButton.UseVisualStyleBackColor = true;
            // 
            // AboutButton
            // 
            AboutButton.BackgroundImage = (Image)resources.GetObject("AboutButton.BackgroundImage");
            AboutButton.BackgroundImageLayout = ImageLayout.Stretch;
            AboutButton.Location = new Point(705, 3);
            AboutButton.Name = "AboutButton";
            AboutButton.Size = new Size(72, 66);
            AboutButton.TabIndex = 0;
            AboutButton.TextAlign = ContentAlignment.TopRight;
            AboutButton.UseVisualStyleBackColor = true;
            AboutButton.Click += AboutButton_Click;
            // 
            // RunButton
            // 
            RunButton.BackgroundImage = (Image)resources.GetObject("RunButton.BackgroundImage");
            RunButton.BackgroundImageLayout = ImageLayout.Stretch;
            RunButton.Location = new Point(627, 3);
            RunButton.Name = "RunButton";
            RunButton.Size = new Size(72, 66);
            RunButton.TabIndex = 0;
            RunButton.TextAlign = ContentAlignment.TopRight;
            RunButton.UseVisualStyleBackColor = true;
            // 
            // PasteButton
            // 
            PasteButton.BackgroundImage = (Image)resources.GetObject("PasteButton.BackgroundImage");
            PasteButton.BackgroundImageLayout = ImageLayout.Stretch;
            PasteButton.Location = new Point(549, 3);
            PasteButton.Name = "PasteButton";
            PasteButton.Size = new Size(72, 66);
            PasteButton.TabIndex = 0;
            PasteButton.TextAlign = ContentAlignment.TopRight;
            PasteButton.UseVisualStyleBackColor = true;
            PasteButton.Click += PasteButton_Click;
            // 
            // CutButton
            // 
            CutButton.BackgroundImage = (Image)resources.GetObject("CutButton.BackgroundImage");
            CutButton.BackgroundImageLayout = ImageLayout.Stretch;
            CutButton.Location = new Point(471, 3);
            CutButton.Name = "CutButton";
            CutButton.Size = new Size(72, 66);
            CutButton.TabIndex = 0;
            CutButton.TextAlign = ContentAlignment.TopRight;
            CutButton.UseVisualStyleBackColor = true;
            CutButton.Click += CutButton_Click;
            // 
            // CopyButton
            // 
            CopyButton.BackgroundImage = (Image)resources.GetObject("CopyButton.BackgroundImage");
            CopyButton.BackgroundImageLayout = ImageLayout.Stretch;
            CopyButton.Location = new Point(393, 3);
            CopyButton.Name = "CopyButton";
            CopyButton.Size = new Size(72, 66);
            CopyButton.TabIndex = 0;
            CopyButton.TextAlign = ContentAlignment.TopRight;
            CopyButton.UseVisualStyleBackColor = true;
            CopyButton.Click += CopyButton_Click;
            // 
            // RepeatButton
            // 
            RepeatButton.BackgroundImage = (Image)resources.GetObject("RepeatButton.BackgroundImage");
            RepeatButton.BackgroundImageLayout = ImageLayout.Stretch;
            RepeatButton.Location = new Point(315, 3);
            RepeatButton.Name = "RepeatButton";
            RepeatButton.Size = new Size(72, 66);
            RepeatButton.TabIndex = 0;
            RepeatButton.TextAlign = ContentAlignment.TopRight;
            RepeatButton.UseVisualStyleBackColor = true;
            RepeatButton.Click += RepeatButton_Click;
            // 
            // ReturnButton
            // 
            ReturnButton.BackgroundImage = (Image)resources.GetObject("ReturnButton.BackgroundImage");
            ReturnButton.BackgroundImageLayout = ImageLayout.Stretch;
            ReturnButton.Location = new Point(237, 3);
            ReturnButton.Name = "ReturnButton";
            ReturnButton.Size = new Size(72, 66);
            ReturnButton.TabIndex = 0;
            ReturnButton.TextAlign = ContentAlignment.TopRight;
            ReturnButton.UseVisualStyleBackColor = true;
            ReturnButton.Click += ReturnButton_Click;
            // 
            // SaveFileButton
            // 
            SaveFileButton.BackgroundImage = (Image)resources.GetObject("SaveFileButton.BackgroundImage");
            SaveFileButton.BackgroundImageLayout = ImageLayout.Stretch;
            SaveFileButton.Location = new Point(159, 3);
            SaveFileButton.Name = "SaveFileButton";
            SaveFileButton.Size = new Size(72, 66);
            SaveFileButton.TabIndex = 0;
            SaveFileButton.TextAlign = ContentAlignment.TopRight;
            SaveFileButton.UseVisualStyleBackColor = true;
            // 
            // OpenFileButton
            // 
            OpenFileButton.BackgroundImage = (Image)resources.GetObject("OpenFileButton.BackgroundImage");
            OpenFileButton.BackgroundImageLayout = ImageLayout.Stretch;
            OpenFileButton.Location = new Point(81, 3);
            OpenFileButton.Name = "OpenFileButton";
            OpenFileButton.Size = new Size(72, 66);
            OpenFileButton.TabIndex = 0;
            OpenFileButton.TextAlign = ContentAlignment.TopRight;
            OpenFileButton.UseVisualStyleBackColor = true;
            // 
            // CreateFileButton
            // 
            CreateFileButton.AccessibleDescription = "";
            CreateFileButton.BackgroundImage = (Image)resources.GetObject("CreateFileButton.BackgroundImage");
            CreateFileButton.BackgroundImageLayout = ImageLayout.Stretch;
            CreateFileButton.Location = new Point(3, 3);
            CreateFileButton.Name = "CreateFileButton";
            CreateFileButton.Size = new Size(72, 66);
            CreateFileButton.TabIndex = 0;
            CreateFileButton.TextAlign = ContentAlignment.TopRight;
            CreateFileButton.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            richTextBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            richTextBox1.Font = new Font("Cascadia Mono", 14F);
            richTextBox1.Location = new Point(71, 3);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(1529, 396);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = "";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(3, 3);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(richTextBox1);
            splitContainer1.Panel1.Controls.Add(richTextBox3);
            splitContainer1.Panel1MinSize = 200;
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(dataGridView1);
            splitContainer1.Panel2MinSize = 100;
            splitContainer1.Size = new Size(1605, 625);
            splitContainer1.SplitterDistance = 402;
            splitContainer1.SplitterWidth = 15;
            splitContainer1.TabIndex = 2;
            // 
            // richTextBox3
            // 
            richTextBox3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            richTextBox3.Enabled = false;
            richTextBox3.Font = new Font("Cascadia Mono", 14F);
            richTextBox3.Location = new Point(3, 3);
            richTextBox3.Name = "richTextBox3";
            richTextBox3.ReadOnly = true;
            richTextBox3.Size = new Size(76, 396);
            richTextBox3.TabIndex = 0;
            richTextBox3.Text = "";
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.BackgroundColor = SystemColors.Window;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(0, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(1602, 166);
            dataGridView1.TabIndex = 1;
            // 
            // параметрыToolStripMenuItem
            // 
            параметрыToolStripMenuItem.Name = "параметрыToolStripMenuItem";
            параметрыToolStripMenuItem.Size = new Size(32, 19);
            параметрыToolStripMenuItem.Text = "Параметры";
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(tabPage1);
            tabControl1.ItemSize = new Size(200, 30);
            tabControl1.Location = new Point(3, 111);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1619, 669);
            tabControl1.SizeMode = TabSizeMode.Fixed;
            tabControl1.TabIndex = 3;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(splitContainer1);
            tabPage1.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            tabPage1.Location = new Point(4, 34);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1611, 631);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Новый документ *";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // toolTip1
            // 
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;
            toolTip1.ShowAlways = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1622, 779);
            Controls.Add(tabControl1);
            Controls.Add(panel1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(900, 835);
            Name = "MainForm";
            Text = "Compiler";
            FormClosing += MainForm_FormClosing;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem toolStripMenuItem4;
        private ToolStripMenuItem toolStripMenuItem5;
        private ToolStripMenuItem CreateToolStripMenuItem;
        private ToolStripMenuItem OpenToolStripMenuItem;
        private ToolStripMenuItem SaveToolStripMenuItem;
        private ToolStripMenuItem SaveAsToolStripMenuItem;
        private ToolStripMenuItem ExitToolStripMenuItem;
        private ToolStripMenuItem CancelToolStripMenuItem;
        private ToolStripMenuItem RepeatToolStripMenuItem;
        private ToolStripMenuItem CutToolStripMenuItem;
        private ToolStripMenuItem CopyToolStripMenuItem;
        private ToolStripMenuItem PasteToolStripMenuItem;
        private ToolStripMenuItem DeleteToolStripMenuItem;
        private ToolStripMenuItem SelectAllToolStripMenuItem;
        private ToolStripMenuItem TaskToolStripMenuItem;
        private ToolStripMenuItem GrammarToolStripMenuItem;
        private ToolStripMenuItem GrammarClassificToolStripMenuItem;
        private ToolStripMenuItem AnalisysMethodToolStripMenuItem;
        private ToolStripMenuItem ErrorDiagToolStripMenuItem;
        private ToolStripMenuItem TestExampleToolStripMenuItem;
        private ToolStripMenuItem LiteratureToolStripMenuItem;
        private ToolStripMenuItem CodeToolStripMenuItem;
        private ToolStripMenuItem ShowContentsToolStripMenuItem;
        private ToolStripMenuItem AboutToolStripMenuItem;
        private Panel panel1;
        private RichTextBox richTextBox1;
        private Button CreateFileButton;
        private Button OpenFileButton;
        private Button ReturnButton;
        private Button SaveFileButton;
        private Button RepeatButton;
        private Button CopyButton;
        private Button CutButton;
        private Button RunButton;
        private Button PasteButton;
        private Button AboutButton;
        private Button InfoButton;
        private SaveFileDialog saveFileDialog1;
        private OpenFileDialog openFileDialog1;
        private SplitContainer splitContainer1;
        private ToolStripMenuItem SettingsToolStripMenuItem1;
        private ToolStripMenuItem TestSizeToolStripMenuItem;
        private ToolStripMenuItem LanguageToolStripMenuItem;
        private ToolStripMenuItem параметрыToolStripMenuItem;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private ToolStripMenuItem CloseFileToolStripMenuItem;
        private ToolStripMenuItem text11;
        private ToolStripMenuItem text12;
        private ToolStripMenuItem text14;
        private ToolStripMenuItem text16;
        private ToolStripMenuItem text18;
        private ToolStripMenuItem text20;
        private ToolStripMenuItem RussanToolStripMenuItem;
        private ToolStripMenuItem EnglishToolStripMenuItem;
        private ToolTip toolTip1;
        private RichTextBox richTextBox3;
        private DataGridView dataGridView1;
    }
}
