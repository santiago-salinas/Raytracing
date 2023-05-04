﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLogic.Objects;
using BusinessLogic.Collections;
using BusinessLogic;

namespace UI.Dialogs
{
    public partial class AddSphereDialog : Form
    {

        public Sphere NewSphere = new Sphere();
        private User loggedUser {  get; set; }
        public AddSphereDialog(User loggedUser)
        {
            InitializeComponent();
            this.loggedUser = loggedUser;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string sphereName = nameTextBox.Text;
            float radius = (float)radiusInput.Value;
            nameStatusLabel.Text = "";
            radiusStatusLabel.Visible = false;

            bool nameIsCorrect = true;
            bool radiusIsCorrect = true;
            
            try
            {
                NewSphere.Name = sphereName;
            }catch (ArgumentNullException ex)
            {
                nameStatusLabel.Text = "* Name cannot be empty";
                nameIsCorrect = false;
            }

            if (SphereCollection.ContainsSphere(sphereName,loggedUser)) {
                nameIsCorrect = false;
                nameStatusLabel.Text = "* Sphere with that name already exists";
            }

            try
            {
                NewSphere.Radius = radius;
            }catch(BusinessLogicException ex)
            {
                radiusStatusLabel.Visible = true;
                radiusIsCorrect = false;
            }

            if(nameIsCorrect && radiusIsCorrect) {
                NewSphere.Owner = loggedUser;
                DialogResult = DialogResult.OK;
            }
                         
        }
    }
}
