﻿using BusinessLogic;
using System;
using System.Globalization;
using System.Windows.Forms;
using UI.Tabs;

namespace UI.Cards
{
    public partial class SceneCard : UserControl
    {
        private Scene _thisScene;

        public SceneCard(Scene scene)
        {
            InitializeComponent();
            _thisScene = scene;
            LoadData();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            Scenes.RemoveScene(_thisScene.Name, _thisScene.Owner);
            this.Parent.Controls.Remove(this);
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            ScenesTab scenesTab = this.Parent.Parent as ScenesTab;
            scenesTab.LoadSceneEditTab(_thisScene);
        }

        private void LoadData()
        {
            nameLabel.Text = _thisScene.Name;
            lastModificationLabel.Text += _thisScene.LastModificationDate.ToString("f", new CultureInfo("en-US"));
            if (_thisScene.Preview == null)
            {
                PictureBox pictureBox = new PictureBox();
                pictureBox.Image = Properties.Resources.no_img_placeholder;
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                previewPanel.Controls.Add(pictureBox);
                pictureBox.Dock = DockStyle.Fill;
            }
            else
            {
                previewPanel.Controls.Clear();
                previewPanel.Controls.Add(new PPMViewer(_thisScene.Preview));
            }
        }
    }
}
