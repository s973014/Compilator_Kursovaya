using Compilator_kursovaya.Properties;
using Compilator_Kursovaya;
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
        private string SaveFileStr1 = "��������� ����";
        private string SaveFileStr2 = "���������� �����";
        private string FileSaved = "���� ������� ��������.";
        private string FileOpened = "���� ������� ������.";
        private string ErrorStr = "������";
        private string FileErrorStr = "���������� ������� ����.";


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
            lastText = "";
            doc.errors = new List<Error>();
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

            

            /*
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                
                HeaderText = "",
                Width = 40,
                
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Path",
                HeaderText = "����",
                Width = 450
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Line",
                HeaderText = "������",
                Width = 85
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Column",
                HeaderText = "�������",
                Width = 90
            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Message",
                HeaderText = "���������",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            */

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                
                HeaderText = "",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,

            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Code",
                HeaderText = "���",
                Width = 100,

            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Type",
                HeaderText = "��� �������",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,

            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Lec",
                HeaderText = "�������",
                Width = 150,

            });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Location",
                HeaderText = "��������������",
                Width = 200,

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

            toolStripMenuItem4.Click += RunButton_Click;


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


            saveFileDialog1.Filter = "��������� �����(*.txt)|*.txt|��� �����(*.*)|*.*";



            toolTip1.SetToolTip(this.CreateFileButton, "�������");
            toolTip1.SetToolTip(this.OpenFileButton, "�������");
            toolTip1.SetToolTip(this.SaveFileButton, "���������");
            toolTip1.SetToolTip(this.ReturnButton, "��������");
            toolTip1.SetToolTip(this.RepeatButton, "���������");
            toolTip1.SetToolTip(this.CopyButton, "����������");
            toolTip1.SetToolTip(this.CutButton, "��������");
            toolTip1.SetToolTip(this.PasteButton, "��������");
            toolTip1.SetToolTip(this.RunButton, "����");
            toolTip1.SetToolTip(this.AboutButton, "����� �������");
            toolTip1.SetToolTip(this.InfoButton, "� ���������");

        }




        private void UpdateLineNumbers()
        {
            try
            {
                int lineCount = richTextBox1.Lines.Length;
                richTextBox3.Text = "";
                for (int i = 1; i <= lineCount; i++)
                {
                    richTextBox3.Text += i + "\n";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {

            try
            {
                UpdateLineNumbers();
                HighlighSyntax(richTextBox1);

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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                if (!richTextBox1.Focused) return;

                string newText = richTextBox1.Text;
                int cursorPos = richTextBox1.SelectionStart;

                if (lastText == null) lastText = "";
                if (newText.Length > lastText.Length) 
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
                else if (newText.Length < lastText.Length)
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void RichTextBox1_VScroll(object sender, EventArgs e)
        {

            try
            {
                int firstVisibleLine = richTextBox1.GetLineFromCharIndex(richTextBox1.GetCharIndexFromPosition(new Point(0, 0)));
                richTextBox3.SelectionStart = richTextBox3.GetFirstCharIndexFromLine(firstVisibleLine);
                richTextBox3.ScrollToCaret();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }




        private void AddNewTabPage(string filename)
        {

            try
            {
                TabPage newTab = new TabPage(filename);
                newTab.Controls.Add(this.splitContainer1);
                tabControl1.TabPages.Add(newTab);
                splitContainer1.SplitterDistance = tabControl1.Height / 2;

                tabControl1.SelectedTab = newTab;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        public static void HighlighSyntax(RichTextBox richTextBox)
        {
            
            int selectionStart = richTextBox.SelectionStart;
            int selectionLength = richTextBox.SelectionLength;

            
            richTextBox.SelectAll();
            richTextBox.SelectionColor = Color.Black;

            
            string[] keywords = { "const", "integer" };
            Color keywordColor = Color.Blue;

            
            foreach (string keyword in keywords)
            {
                MatchCollection matches = Regex.Matches(richTextBox.Text, $@"\b{keyword}\b", RegexOptions.IgnoreCase);
                foreach (Match match in matches)
                {
                    richTextBox.Select(match.Index, match.Length);
                    richTextBox.SelectionColor = keywordColor;
                }
            }

            
            richTextBox.Select(selectionStart, selectionLength);
            richTextBox.SelectionColor = Color.Black;
        }


        private void CreateToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                Document doc = new Document();
                doc.filename = "New File";
                doc.saved = false;
                doc.savedAs = false;
                doc.errors = new List<Error>();
                this.documents.Add(doc);
                AddNewTabPage("* New File");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



            /*
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;

            string filename = saveFileDialog1.FileName;
            System.IO.File.WriteAllText(filename, "");
            this.Text = "Compiler" + saveFileDialog1.FileName;
            this.filename = filename;
            MessageBox.Show("���� ������� ������.");
            */
        }



        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFile();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void SaveFile()
        {

            try
            {
                //MessageBox.Show(Convert.ToString(documents.Count));
                if (documents[tabControl1.SelectedIndex].full_path != "" && documents[tabControl1.SelectedIndex].full_path != null)
                {
                    System.IO.File.WriteAllText(documents[tabControl1.SelectedIndex].full_path, richTextBox1.Text);
                    //MessageBox.Show("���� ������� ��������.");
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
                    //MessageBox.Show("���� ������� ��������.");
                    documents[tabControl1.SelectedIndex].saved = true;
                    documents[tabControl1.SelectedIndex].savedAs = true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void OpenFile()
        {

            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                    return;

                string filename = openFileDialog1.SafeFileName;

                string file_path = openFileDialog1.FileName;


                for (int i = 0; i < documents.Count; i++)
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
                doc.errors = new List<Error>();
                doc.rtb1_text = fileText;
                doc.saved = true;
                doc.savedAs = true;

                lastText = fileText;

                documents.Add(doc);

                AddNewTabPage(filename);

                UpdateLineNumbers();



                MessageBox.Show(FileOpened);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }



        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFile();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void ReturnButton_Click(object sender, EventArgs e)
        {

            try
            {
                if (richTextBox1.CanUndo)
                {
                    richTextBox1.Undo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void RepeatButton_Click(object sender, EventArgs e)
        {

            try
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
                    if (richTextBox1.SelectionStart > 0)
                    {
                        int position = richTextBox1.SelectionStart;
                        richTextBox1.Text = richTextBox1.Text.Remove(position - 1, 1);
                        lastText = richTextBox1.Text;
                        richTextBox1.Focus();
                        richTextBox1.SelectionStart = position - containtment.Length;
                    }



                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void CopyButton_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBox1.Copy();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void CutButton_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBox1.Cut();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void PasteButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (Clipboard.ContainsText())
                {
                    richTextBox1.Paste();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (richTextBox1.SelectedText.Length > 0)
                {
                    richTextBox1.SelectedText = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void SelectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBox1.SelectAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Document doc = new Document();

            doc.rtb1_text = richTextBox1.Text;

            doc.errors = new List<Error>();
            //doc.rtb2_text = richTextBox2.Text;


            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                var row = dataGridView1.Rows[i];

                var error = new Error()
                {
                    index = Convert.ToInt32(row.Cells[0].Value),
                    code = Convert.ToInt32(row.Cells[1].Value), 
                    token_type = row.Cells[2].Value?.ToString(), 
                    token = row.Cells[3].Value?.ToString(),    
                    location = row.Cells[4].Value?.ToString()
                };

                doc.errors.Add(error);
            }



            doc.rtb3_text = richTextBox3.Text;



            tabControl1.TabPages[tabControl1.SelectedIndex].Controls.Add(this.splitContainer1);

            documents[this.index].rtb1_text = doc.rtb1_text;
            documents[this.index].errors = doc.errors;
            //AddErrsToDocs(this.index);
            documents[this.index].rtb3_text = doc.rtb3_text;

            //MessageBox.Show(Convert.ToString(documents[tabControl1.SelectedIndex].errors.Count));

            change = true;
            richTextBox1.Text = documents[tabControl1.SelectedIndex].rtb1_text;
            lastText = documents[tabControl1.SelectedIndex].rtb1_text;
            //richTextBox2.Text = documents[tabControl1.SelectedIndex].rtb2_text;
            dataGridView1.Rows.Clear();
            for (int i = 0; i < documents[tabControl1.SelectedIndex].errors.Count; i++)
            {
                dataGridView1.Rows.Add(
                    documents[tabControl1.SelectedIndex].errors[i].index,
                    documents[tabControl1.SelectedIndex].errors[i].code,
                    documents[tabControl1.SelectedIndex].errors[i].token_type,
                    documents[tabControl1.SelectedIndex].errors[i].token,
                    documents[tabControl1.SelectedIndex].errors[i].location);
            }


            richTextBox3.Text = documents[tabControl1.SelectedIndex].rtb3_text;


            this.index = tabControl1.SelectedIndex;
            try
            {
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void CloseFile()
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void CloseFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                CloseFile();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            try
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
                    doc.errors = new List<Error>();
                    this.documents.Add(doc);
                    AddNewTabPage("* New File");
                }
                else if (keyData == (Keys.Control | Keys.W))
                {
                    CloseFile();
                }
                else if (keyData == Keys.F5)
                {
                    RunButton_Click(this, EventArgs.Empty);
                }
                return base.ProcessCmdKey(ref msg, keyData);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return base.ProcessCmdKey(ref msg, keyData);
            }

        }

        private void text11_Click(object sender, EventArgs e)
        {
            try
            {
                change = true;
                richTextBox1.Font = new Font("Cascadia Mono", 11F, FontStyle.Regular, GraphicsUnit.Point, 204);
                //richTextBox2.Font = new Font("Segoe UI", 11F);
                richTextBox3.Font = new Font("Cascadia Mono", 11F, FontStyle.Regular, GraphicsUnit.Point, 204);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void text12_Click(object sender, EventArgs e)
        {
            try
            {
                change = true;
                richTextBox1.Font = new Font("Cascadia Mono", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
                //richTextBox2.Font = new Font("Segoe UI", 12F);
                richTextBox3.Font = new Font("Cascadia Mono", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void text14_Click(object sender, EventArgs e)
        {
            try
            {
                change = true;
                richTextBox1.Font = new Font("Cascadia Mono", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
                //richTextBox2.Font = new Font("Segoe UI", 14F);
                richTextBox3.Font = new Font("Cascadia Mono", 14F, FontStyle.Regular, GraphicsUnit.Point, 204);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void text16_Click(object sender, EventArgs e)
        {
            try
            {
                change = true;
                richTextBox1.Font = new Font("Cascadia Mono", 16F, FontStyle.Regular, GraphicsUnit.Point, 204);
                //richTextBox2.Font = new Font("Segoe UI", 16F);
                richTextBox3.Font = new Font("Cascadia Mono", 16F, FontStyle.Regular, GraphicsUnit.Point, 204);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void text18_Click(object sender, EventArgs e)
        {
            try
            {
                change = true;
                richTextBox1.Font = new Font("Cascadia Mono", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);
                //richTextBox2.Font = new Font("Segoe UI", 18F);
                richTextBox3.Font = new Font("Cascadia Mono", 18F, FontStyle.Regular, GraphicsUnit.Point, 204);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void text20_Click(object sender, EventArgs e)
        {
            try
            {
                change = true;
                richTextBox1.Font = new Font("Cascadia Mono", 20F, FontStyle.Regular, GraphicsUnit.Point, 204);
                //richTextBox2.Font = new Font("Segoe UI", 20F);
                richTextBox3.Font = new Font("Cascadia Mono", 20F, FontStyle.Regular, GraphicsUnit.Point, 204);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void ShowContentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(@"������������ ������ 2
���������� ������������ ����������� (�������).
�������� ������ ��������� ���-214", "� ���������");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void UpdateControlsText(Control control, ResourceManager res)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void UpdateMenuItems(ToolStripMenuItem menuItem, ResourceManager res)
        {
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        private void EnglishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
                //Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

                ResourceManager res = new ResourceManager("Compilator_Kursovaya.Properties.Resources", typeof(MainForm).Assembly);
                UpdateControlsText(this, res);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        private void RussanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("ru");
                //Thread.CurrentThread.CurrentCulture = new CultureInfo("ru-RU");

                ResourceManager res = new ResourceManager("Compilator_Kursovaya.Properties.Resources", typeof(MainForm).Assembly);
                UpdateControlsText(this, res);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {

            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            try
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
                        doc.errors = new List<Error>();
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void AboutButton_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] chmBytes = Properties.Resources.Contents;


                string tempPath = Path.Combine(Path.GetTempPath(), "Contents.chm");
                File.WriteAllBytes(tempPath, chmBytes);


                Help.ShowHelp(this, tempPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }



        private void AddErrsToDocs(int ind)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++) 
            {
                var row = dataGridView1.Rows[i];

                var error = new Error()
                {
                    index = i, // ������ ������
                    code = Convert.ToInt32(row.Cells[0].Value), 
                    token_type = row.Cells[1].Value?.ToString(), 
                    token = row.Cells[2].Value?.ToString(),
                    location = row.Cells[4].Value?.ToString()
                };

                documents[ind].errors.Add(error);
            }
        }

        private void RunButton_Click(object sender, EventArgs e)
        {
            documents[tabControl1.SelectedIndex].errors.Clear();
            Scaner scaner = new Scaner(richTextBox1.Text, documents[tabControl1.SelectedIndex].errors);
            scaner.Analyze();

            documents[tabControl1.SelectedIndex].errors = scaner.errors;

            dataGridView1.Rows.Clear();


            for(int i = 0; i < documents[tabControl1.SelectedIndex].errors.Count; i++)
            {
                dataGridView1.Rows.Add(documents[tabControl1.SelectedIndex].errors[i].index,
                    documents[tabControl1.SelectedIndex].errors[i].code,
                    documents[tabControl1.SelectedIndex].errors[i].token_type,
                    documents[tabControl1.SelectedIndex].errors[i].token,
                    documents[tabControl1.SelectedIndex].errors[i].location);
            }


            //dataGridView1.Rows.Add(1,2,3,4,5);
            //AddErrsToDocs(tabControl1.SelectedIndex);

        }
    }
}
