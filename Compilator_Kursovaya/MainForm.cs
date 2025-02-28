using Compilator_kursovaya.Properties;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Security.Policy;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;


namespace Compilator_kursovaya
{
    public partial class MainForm : Form
    {


        public List<Document> documents;

        public int index = 0;
        private bool change;
        private int fontsize = 14;
        private string SaveFileStr1 = "Сохранить файл";
        private string SaveFileStr2 = "Сохранение файла";
        private string FileSaved = "Файл успешно сохранен.";
        private string FileOpened = "Файл успешно открыт.";
        private string ErrorStr = "Ошибка";
        private string FileErrorStr = "Невозможно открыть файл.";


        private string lastText = "";

        public string containtment;
        public bool isCut;
        public bool isDelete;
        public bool isPaste;




        public MainForm()
        {

            InitializeComponent();
            richTextBox3.Clear();
            richTextBox3.Text = string.Empty;

            Document doc = new Document();
            doc.filename = "New File";
            tabControl1.TabPages[tabControl1.SelectedIndex].Text = "* " + doc.filename;
            doc.full_path = "";
            doc.rtb1_text = "";
            doc.rtb2_text = "";
            doc.rtb3_text = "";
            doc.saved = true;
            doc.savedAs = false;

            Font commonFont = new Font("Times New Roman", 14);

            richTextBox1.Font = commonFont;
            
            richTextBox3.Font = commonFont;


            dataGridView1.AllowUserToAddRows = false;   
            dataGridView1.AllowUserToDeleteRows = false; 
            dataGridView1.ReadOnly = true;               
            dataGridView1.RowHeadersVisible = false;     
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

           
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                
                HeaderText = "",
                Width = 40,
                
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Path",
                HeaderText = "Путь",
                Width = 450
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Line",
                HeaderText = "Строка",
                Width = 85
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Column",
                HeaderText = "Колонка",
                Width = 90
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Message",
                HeaderText = "Сообщение",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });


            this.AllowDrop = true;
            richTextBox1.AllowDrop = true;
            
            richTextBox1.WordWrap = false;
            
            

            CreateFileButton.Click += CreateToolStripMenuItem_Click;
            OpenFileButton.Click += OpenToolStripMenuItem_Click;
            SaveFileButton.Click += SaveToolStripMenuItem_Click;

            CancelToolStripMenuItem.Click += ReturnButton_Click;
            RepeatToolStripMenuItem.Click += RepeatButton_Click;
            CutToolStripMenuItem.Click += CutButton_Click;
            CopyToolStripMenuItem.Click += CopyButton_Click;
            PasteToolStripMenuItem.Click += PasteButton_Click;
            InfoButton.Click += ShowContentsToolStripMenuItem_Click;


            richTextBox3.ReadOnly = true; 
            richTextBox3.BackColor = richTextBox1.BackColor; 
            richTextBox3.ForeColor = richTextBox1.ForeColor;
            richTextBox3.Font = richTextBox1.Font;
            richTextBox3.WordWrap = false;
            
            richTextBox3.ScrollBars = RichTextBoxScrollBars.None;

            documents = new List<Document>();

            
            richTextBox1.VScroll += RichTextBox1_VScroll;
            richTextBox1.TextChanged += RichTextBox1_TextChanged;

            richTextBox1.DragEnter += new DragEventHandler(MainForm_DragEnter);
            richTextBox1.DragDrop += new DragEventHandler(MainForm_DragDrop);



            UpdateLineNumbers();

            this.documents.Add(doc);


            saveFileDialog1.Filter = "Текстовые файлы(*.txt)|*.txt|Все файлы(*.*)|*.*";



            toolTip1.SetToolTip(this.CreateFileButton, "Создать");
            toolTip1.SetToolTip(this.OpenFileButton, "Открыть");
            toolTip1.SetToolTip(this.SaveFileButton, "Сохранить");
            toolTip1.SetToolTip(this.ReturnButton, "Отменить");
            toolTip1.SetToolTip(this.RepeatButton, "Повторить");
            toolTip1.SetToolTip(this.CopyButton, "Копировать");
            toolTip1.SetToolTip(this.CutButton, "Вырезать");
            toolTip1.SetToolTip(this.PasteButton, "Вставить");
            toolTip1.SetToolTip(this.RunButton, "Пуск");
            toolTip1.SetToolTip(this.AboutButton, "Вызов справки");
            toolTip1.SetToolTip(this.InfoButton, "О программе");

        }




        private void UpdateLineNumbers()
        {
            int lineCount = richTextBox1.Lines.Length;
            richTextBox3.Text = "";
            for (int i = 1; i <= lineCount; i++)
            {
                richTextBox3.Text += i + "\n";
            }
            
            
        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {
            UpdateLineNumbers();

            int firstVisibleLine = richTextBox1.GetLineFromCharIndex(richTextBox1.GetCharIndexFromPosition(new Point(0, 0)));
            richTextBox3.SelectionStart = richTextBox3.GetFirstCharIndexFromLine(firstVisibleLine);
            richTextBox3.ScrollToCaret();

            int index = tabControl1.SelectedIndex;

            if (change)
            {
                change = false;
                return;
            }

            if (index >= 0)
            {
                if (documents[index].saved == true)
                {
                    documents[index].saved = false;
                    tabControl1.TabPages[tabControl1.SelectedIndex].Text = "* " + documents[tabControl1.SelectedIndex].filename;
                }

            }



            if (!richTextBox1.Focused) return;

            string newText = richTextBox1.Text;
            int cursorPos = richTextBox1.SelectionStart;

            if (newText.Length > lastText.Length) // Ввод символа
            {
                int diff = newText.Length - lastText.Length;
                string insertedText = newText.Substring(cursorPos - (newText.Length - lastText.Length), newText.Length - lastText.Length);
                if (diff == 1)
                {
                    containtment = insertedText;
                    isCut = false;
                    isDelete = false;
                    isPaste = false;
                }
                else
                {
                    containtment = insertedText;
                    isCut = false;
                    isDelete = false;
                    isPaste = true;

                    
                }
            }
            else if (newText.Length < lastText.Length) // Удаление символа
            {
                int diff = lastText.Length - newText.Length;
                string deletedText = lastText.Substring(cursorPos, diff);
                if (diff == 1)
                {
                    containtment = deletedText;
                    isCut = false;
                    isDelete = true;
                    isPaste = false;
                    
                }
                else
                {
                    containtment = null;
                    isCut = false;
                    isDelete = false;
                    isPaste = false;
                    
                }
            }
            lastText = newText;
        }

        private void RichTextBox1_VScroll(object sender, EventArgs e)
        {
            
            int firstVisibleLine = richTextBox1.GetLineFromCharIndex(richTextBox1.GetCharIndexFromPosition(new Point(0, 0)));
            richTextBox3.SelectionStart = richTextBox3.GetFirstCharIndexFromLine(firstVisibleLine);
            richTextBox3.ScrollToCaret();
        }




        private void AddNewTabPage(string filename)
        {
            TabPage newTab = new TabPage(filename);
            newTab.Controls.Add(this.splitContainer1);
            tabControl1.TabPages.Add(newTab);
            splitContainer1.SplitterDistance = tabControl1.Height / 2;

            tabControl1.SelectedTab = newTab;
        }

        private void CreateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Document doc = new Document();
            doc.filename = "New File";
            doc.saved = false;
            doc.savedAs = false;
            this.documents.Add(doc);
            AddNewTabPage("* New File");

            /*
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            string filename = saveFileDialog1.FileName;
            System.IO.File.WriteAllText(filename, "");
            this.Text = "Compiler" + saveFileDialog1.FileName;
            this.filename = filename;
            MessageBox.Show("Файл успешно создан.");
            */
        }



        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {

            OpenFile();
        }

        private void SaveFile()
        {

            //MessageBox.Show(Convert.ToString(documents.Count));
            if (documents[tabControl1.SelectedIndex].full_path != "" && documents[tabControl1.SelectedIndex].full_path != null)
            {
                System.IO.File.WriteAllText(documents[tabControl1.SelectedIndex].full_path, richTextBox1.Text);
                //MessageBox.Show("Файл успешно сохранен.");
                documents[tabControl1.SelectedIndex].saved = true;
                tabControl1.TabPages[tabControl1.SelectedIndex].Text = documents[tabControl1.SelectedIndex].filename;
            }
            else
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                    return;

                string filepath = saveFileDialog1.FileName;
                string filename = Path.GetFileName(saveFileDialog1.FileName);

                documents[tabControl1.SelectedIndex].full_path = filepath;
                documents[tabControl1.SelectedIndex].filename = filename;
                tabControl1.TabPages[tabControl1.SelectedIndex].Text = filename;


                System.IO.File.WriteAllText(filepath, richTextBox1.Text);
                //MessageBox.Show("Файл успешно сохранен.");
                documents[tabControl1.SelectedIndex].saved = true;
                documents[tabControl1.SelectedIndex].savedAs = true;

            }
        }

        private void OpenFile()
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            string filename = openFileDialog1.SafeFileName;

            string file_path = openFileDialog1.FileName;

            
            for(int i = 0; i < documents.Count; i++)
            {
                if (documents[i].full_path == file_path)
                {
                    tabControl1.SelectedIndex = i;
                    return;
                } 
            }




            string fileText = System.IO.File.ReadAllText(file_path);

            Document doc = new Document();

            doc.filename = filename;
            doc.full_path = file_path;
            doc.rtb1_text = fileText;
            doc.saved = true;
            doc.savedAs = true;

            lastText = fileText;

            documents.Add(doc);

            AddNewTabPage(filename);

            UpdateLineNumbers();



            MessageBox.Show(FileOpened);
        }



        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            string filepath = saveFileDialog1.FileName;
            string filename = Path.GetFileName(saveFileDialog1.FileName);

            documents[tabControl1.SelectedIndex].full_path = filepath;
            documents[tabControl1.SelectedIndex].filename = filename;
            tabControl1.TabPages[tabControl1.SelectedIndex].Text = filename;


            System.IO.File.WriteAllText(filepath, richTextBox1.Text);
            MessageBox.Show(FileSaved);
            documents[tabControl1.SelectedIndex].saved = true;
            documents[tabControl1.SelectedIndex].savedAs = true;

        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var file in documents)
            {
                if (file.saved == false)
                {
                    DialogResult result = MessageBox.Show(
                        SaveFileStr1 + $" \"{file.filename}\"?",
                        SaveFileStr2,
                        MessageBoxButtons.YesNoCancel,
                        MessageBoxIcon.Question
                    );

                    if (result == DialogResult.Yes)
                    {
                        SaveFile();
                    }
                    else if (result == DialogResult.No)
                    {

                    }
                    else
                    {
                        return;
                    }
                }
            }


            this.Close();
        }

        private void ReturnButton_Click(object sender, EventArgs e)
        {
            if (richTextBox1.CanUndo)
            {
                richTextBox1.Undo();
            }
        }

        private void RepeatButton_Click(object sender, EventArgs e)
        {
            if (isDelete == false)
            {
                int position = richTextBox1.SelectionStart;
                if (containtment == null) return;
                richTextBox1.Text = richTextBox1.Text.Insert(richTextBox1.SelectionStart, containtment);
                lastText = richTextBox1.Text;
                richTextBox1.Focus();
                richTextBox1.SelectionStart = position + containtment.Length;
            }
            else
            {
                if(richTextBox1.SelectionStart > 0)
                {
                    int position = richTextBox1.SelectionStart;
                    richTextBox1.Text = richTextBox1.Text.Remove(position - 1, 1);
                    lastText = richTextBox1.Text;
                    richTextBox1.Focus();
                    richTextBox1.SelectionStart = position - containtment.Length;
                }


                
            }
        }

        private void CopyButton_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void CutButton_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void PasteButton_Click(object sender, EventArgs e)
        {
            if (Clipboard.ContainsText())
            {
                richTextBox1.Paste();
            }
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectedText.Length > 0)
            {
                richTextBox1.SelectedText = "";
            }
        }

        private void SelectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Document doc = new Document();

            doc.rtb1_text = richTextBox1.Text;
            //doc.rtb2_text = richTextBox2.Text;
            doc.rtb3_text = richTextBox3.Text;



            tabControl1.TabPages[tabControl1.SelectedIndex].Controls.Add(this.splitContainer1);

            documents[this.index].rtb1_text = doc.rtb1_text;
            documents[this.index].rtb2_text = doc.rtb2_text;
            documents[this.index].rtb3_text = doc.rtb3_text;


            change = true;
            richTextBox1.Text = documents[tabControl1.SelectedIndex].rtb1_text;
            //richTextBox2.Text = documents[tabControl1.SelectedIndex].rtb2_text;
            richTextBox3.Text = documents[tabControl1.SelectedIndex].rtb3_text;


            this.index = tabControl1.SelectedIndex;

        }

        private void CloseFile()
        {
            if (!documents[tabControl1.SelectedIndex].saved)
            {
                DialogResult result = MessageBox.Show(
                        SaveFileStr1 + $" \"{documents[tabControl1.SelectedIndex].filename}\"?",
                        SaveFileStr2,
                        MessageBoxButtons.YesNoCancel,
                        MessageBoxIcon.Question
                    );

                if (result == DialogResult.Yes)
                {
                    SaveFile();
                }
                else if (result == DialogResult.No)
                {

                }
                else
                {
                    return;
                }
            }



            if (tabControl1.TabPages.Count == 1)
            {
                documents[0].saved = true;
                this.Close();
            }
            else if (tabControl1.SelectedIndex == 0)
            {
                tabControl1.SelectedTab = tabControl1.TabPages[tabControl1.SelectedIndex + 1];
                tabControl1.TabPages.RemoveAt(index - 1);
                documents.RemoveAt(index - 1);
            }
            else
            {
                tabControl1.SelectedTab = tabControl1.TabPages[tabControl1.SelectedIndex - 1];
                tabControl1.TabPages.RemoveAt(index + 1);
                documents.RemoveAt(index + 1);
            }

            this.index = tabControl1.SelectedIndex;
        }

        private void CloseFileToolStripMenuItem_Click(object sender, EventArgs e)
        {

            CloseFile();

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.S))
            {
                SaveFile();
                return true;
            }
            else if (keyData == (Keys.Control | Keys.O))
            {
                OpenFile();
                return true;
            }
            else if (keyData == (Keys.Control | Keys.N))
            {
                Document doc = new Document();
                doc.filename = "New File";
                doc.saved = false;
                doc.savedAs = false;
                this.documents.Add(doc);
                AddNewTabPage("* New File");
            }
            else if (keyData == (Keys.Control | Keys.W))
            {
                CloseFile();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void text11_Click(object sender, EventArgs e)
        {
            change = true;
            richTextBox1.Font = new Font("Cascadia Mono", 11F, FontStyle.Regular, GraphicsUnit.Point, 204);
            //richTextBox2.Font = new Font("Segoe UI", 11F);
            richTextBox3.Font = new Font("Cascadia Mono", 11F, FontStyle.Regular, GraphicsUnit.Point, 204);
        }

        private void text12_Click(object sender, EventArgs e)
        {
            change = true;
            richTextBox1.Font = new Font("Cascadia Mono", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            //richTextBox2.Font = new Font("Segoe UI", 12F);
            richTextBox3.Font = new Font("Cascadia Mono", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
        }

        private void text14_Click(object sender, EventArgs e)
        {
            change = true;
            richTextBox1.Font = new Font("Cascadia Mono", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            //richTextBox2.Font = new Font("Segoe UI", 14F);
            richTextBox3.Font = new Font("Cascadia Mono", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
        }

        private void text16_Click(object sender, EventArgs e)
        {
            change = true;
            richTextBox1.Font = new Font("Cascadia Mono", 16F, FontStyle.Regular, GraphicsUnit.Point, 204);
            //richTextBox2.Font = new Font("Segoe UI", 16F);
            richTextBox3.Font = new Font("Cascadia Mono", 16F, FontStyle.Regular, GraphicsUnit.Point, 204);
        }

        private void text18_Click(object sender, EventArgs e)
        {
            change = true;
            richTextBox1.Font = new Font("Cascadia Mono", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
            //richTextBox2.Font = new Font("Segoe UI", 18F);
            richTextBox3.Font = new Font("Cascadia Mono", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
        }

        private void text20_Click(object sender, EventArgs e)
        {
            change = true;
            richTextBox1.Font = new Font("Cascadia Mono", 20F, FontStyle.Regular, GraphicsUnit.Point, 204);
            //richTextBox2.Font = new Font("Segoe UI", 20F);
            richTextBox3.Font = new Font("Cascadia Mono", 20F, FontStyle.Regular, GraphicsUnit.Point, 204);
        }

        private void ShowContentsToolStripMenuItem_Click(object sender, EventArgs e)
        {


            byte[] chmBytes = Properties.Resources.Contents;


            string tempPath = Path.Combine(Path.GetTempPath(), "Contents.chm");
            File.WriteAllBytes(tempPath, chmBytes);


            Help.ShowHelp(this, tempPath);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (var file in documents)
            {
                if (file.saved == false)
                {
                    DialogResult result = MessageBox.Show(
                        SaveFileStr1 + $" \"{file.filename}\"?",
                        SaveFileStr2,
                        MessageBoxButtons.YesNoCancel,
                        MessageBoxIcon.Question
                    );

                    if (result == DialogResult.Yes)
                    {
                        SaveFile();
                    }
                    else if (result == DialogResult.No)
                    {

                    }
                    else
                    {
                        e.Cancel = true;
                        return;
                    }
                }
            }
        }

        private void UpdateControlsText(Control control, ResourceManager res)
        {

            toolTip1.SetToolTip(this.CreateFileButton, res.GetString("ToolTip_CreateFileButton"));
            toolTip1.SetToolTip(this.OpenFileButton, res.GetString("ToolTip_OpenFileButton"));
            toolTip1.SetToolTip(this.SaveFileButton, res.GetString("ToolTip_SaveFileButton"));
            toolTip1.SetToolTip(this.ReturnButton, res.GetString("ToolTip_ReturnButton"));
            toolTip1.SetToolTip(this.RepeatButton, res.GetString("ToolTip_RepeatButton"));
            toolTip1.SetToolTip(this.CopyButton, res.GetString("ToolTip_CopyButton"));
            toolTip1.SetToolTip(this.CutButton, res.GetString("ToolTip_CutButton"));
            toolTip1.SetToolTip(this.PasteButton, res.GetString("ToolTip_PasteButton"));
            toolTip1.SetToolTip(this.RunButton, res.GetString("ToolTip_RunButton"));
            toolTip1.SetToolTip(this.AboutButton, res.GetString("ToolTip_AboutButton"));
            toolTip1.SetToolTip(this.InfoButton, res.GetString("ToolTip_InfoButton"));

            SaveFileStr1 = res.GetString("SaveFileStr1");
            SaveFileStr2 = res.GetString("SaveFileStr2");

            FileSaved = res.GetString("FileSaved");
            FileOpened = res.GetString("FileOpened");

            ErrorStr = res.GetString("ErrorStr");
            FileErrorStr = res.GetString("FileErrorStr");


            foreach (var item in this.dataGridView1.Columns)
            {
                if (item is DataGridViewTextBoxColumn menuItem)
                {
                    if (!string.IsNullOrEmpty(menuItem.Name))
                    {
                        string newText = res.GetString(menuItem.Name);
                        if (!string.IsNullOrEmpty(newText))
                            menuItem.HeaderText = newText;
                    }
                }
            }

            
            foreach (var item in this.MainMenuStrip.Items)
            {
                if (item is ToolStripMenuItem menuItem)
                {
                    UpdateMenuItems(menuItem, res);
                }
            }
        }

        private void UpdateMenuItems(ToolStripMenuItem menuItem, ResourceManager res)
        {
            if (!string.IsNullOrEmpty(menuItem.Name))
            {
                string newText = res.GetString(menuItem.Name);
                if (!string.IsNullOrEmpty(newText))
                    menuItem.Text = newText;
            }

           
            foreach (ToolStripItem subItem in menuItem.DropDownItems)
            {
                if (subItem is ToolStripMenuItem subMenuItem)
                {
                    UpdateMenuItems(subMenuItem, res);
                }
            }
        }


        private void EnglishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
            //Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

            ResourceManager res = new ResourceManager("Compilator_Kursovaya.Properties.Resources", typeof(MainForm).Assembly);
            UpdateControlsText(this, res);

        }

        private void RussanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("ru");
            //Thread.CurrentThread.CurrentCulture = new CultureInfo("ru-RU");

            ResourceManager res = new ResourceManager("Compilator_Kursovaya.Properties.Resources", typeof(MainForm).Assembly);
            UpdateControlsText(this, res);
        }

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {




            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            foreach (string filePath in files)
            {
                if (File.Exists(filePath))
                {

                    string filename = Path.GetFileName(filePath);

                    string file_path = filePath;


                    string fileText = System.IO.File.ReadAllText(file_path);

                    Document doc = new Document();

                    doc.filename = filename;
                    doc.full_path = file_path;
                    doc.rtb1_text = fileText;
                    doc.saved = true;
                    doc.savedAs = true;

                    for (int i = 0; i < documents.Count; i++)
                    {
                        if (documents[i].full_path == file_path)
                        {
                            tabControl1.SelectedIndex = i;
                            return;
                        }
                    }

                    documents.Add(doc);

                    AddNewTabPage(filename);

                    UpdateLineNumbers();

                }
                else
                {
                    MessageBox.Show(FileErrorStr, ErrorStr, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void AboutButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"Лабораторная работа 1
Разработка пользовательского интерфейса (GUI) для языкового процессора.
Демченко Степан Сергеевич АВТ-214", "О программе");
        }
    }
}
